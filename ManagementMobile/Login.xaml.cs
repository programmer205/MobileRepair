using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BusinessLogicLayer;
using Entities;
using Kavenegar;
using ManagementMobile.Msg;
using Microsoft.Win32;
using Utility;
using Path = System.IO.Path;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private string Number="";
        private User MyUser { get; set; }
        public bool Status = false;
        public bool ShowRemember = false;
        public string location_Image;
        public bool status;
        public bool Confirm = false;
        private int num = 60;
        DispatcherTimer Timer1 = new DispatcherTimer();
        OpenFileDialog open = new OpenFileDialog();
        void Show(Visibility s)
        {
            LabelUser.Visibility = s;
            LabelPasword.Visibility = s;
            txt_username.Visibility = s;
            txt_pasword.Visibility = s;
            WrapPanel.Visibility = s;
        }

        void ShowForget(Visibility s)
        {
            LabelForget1.Visibility = s;
            LabelForget2.Visibility = s;
            txt_ForgetPass1.Visibility = s;
            txt_ForgetPass2.Visibility = s;
            SavePass.Visibility = s;
        }

        public void Time(int a=0)
        {
            if (a == 0)
            {
                Timer1.Interval = new TimeSpan(0, 0, 0, 1);
                Timer1.Tick += Timer1_Tick;
                Timer1.Start();
            }
            else
            {
                num = 60;
                Timer1= null;
                Timer1 = new DispatcherTimer();
                Timer1.Interval = new TimeSpan(0, 0, 0, 1);
                Timer1.Tick += Timer1_Tick;
                Timer1.Start();
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (num == 0)
            {
                Timer1.Stop();
                ResendCode.IsEnabled = true;
                num = 60;
            }
            else
            {
                var q = num - 1;
                Label_Tick.Content = q;
                num = q;
            }

        }

        bool Send(string num, string text)
        {
            try
            {
                var phoneline = "2000500666";
                var phone = num;
                var message = text;
                KavenegarApi s =
                    new KavenegarApi(
                        "3170635A702F515076707255764A5A794C6E43766C70564A6D32696655346D484A664E394D734162634E493D");
                s.Send(phoneline, phone, message);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        string SaveImage(string UserName)
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                          @"\UserPicture\";
            string PictureLocation;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string PictureName = UserName + ".JPG";
            string secondpic = Guid.NewGuid().ToString() + ".JPG";
            string nahaei = path + PictureName;
            string back;
            if (status == true)
            {
                PictureLocation = location_Image;
            }
            else
            {
                PictureLocation = open.FileName;
            }
            if (File.Exists(nahaei))
            {
                File.Copy(PictureLocation, path + secondpic);
                back = path + secondpic;
            }

            else
            {
                back = path + PictureName;
                try
                {
                    File.Copy(PictureLocation, path + PictureName); ;
                }
                catch (Exception)
                {
                    MsgBox.Show("خطا", "مشکلی پیش آمده است", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }


            return back;
        }
        private void Login_OnLoaded(object sender, RoutedEventArgs e=null)
        {
            if (Status)
            {
                txt_username.Focus();
                LabelRegister.Visibility = Visibility.Hidden;
                Label_Restore.Visibility = Visibility.Visible;
                ForgetPassword.Visibility = Visibility.Visible;
                if (ShowRemember)
                {
                    Label_Remember.Visibility = Visibility.Visible;
                    CheckBox1.Visibility = Visibility.Visible;
                }
            }
            else
            {
                LabelRegister.Visibility = Visibility.Visible;
            }
        }
        public void Return(object sender)
        {
            Login_OnLoaded(sender);
        }
        private void WrapPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud=new UserCrud())
            {
                if (crud.Login(txt_username.Text, txt_pasword.Password))
                {
                    MainWindow mw = new MainWindow();
                    mw.LoginInWindow = crud.GetUserByUserName(txt_username.Text);
                    if (CheckBox1.IsChecked == true)
                    {
                        DashboardCrud dc = new DashboardCrud();
                        MyInformation information = new MyInformation()
                        {
                            UserName = txt_username.Text,
                            Password = txt_pasword.Password,
                            Status = true,
                            UserId = mw.LoginInWindow.UserId
                        };
                        dc.CreateInfo(information);
                    }
                    mw.Refresh();
                    mw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "کاربری با چنین مشخصاتی در سیستم وجود ندارد", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }

        }

        private void LabelRegister_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Show(Visibility.Hidden);
            LabelRegister.Visibility = Visibility.Hidden;
            Label_Restore.Visibility = Visibility.Hidden;
            ForgetPassword.Visibility = Visibility.Hidden;
            StackPanel.Visibility = Visibility.Visible;
        }

        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            open.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            open.ShowDialog();
            if (open.FileName.Length > 0)
            {
                string selectedFileName = open.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                location_Image = selectedFileName;
                status = false;
                select_image.Source = bitmap;
                Confirm = true;
            }

            if (Confirm)
            {
                UserGroup group = new UserGroup()
                {
                    Tiltle = "مدیریت"
                };
                group.AccessRoles.Add(new AccessRole() { Section = "بخش مشتریان", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "پذیرش جدید", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "بخش فاکتورها", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "بخش کاربران", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "بخش فعالیت", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "بخش یادآورها", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "بخش گزارشات", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "بخش تنظیمات", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "پنل پیامکی", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });
                group.AccessRoles.Add(new AccessRole() { Section = "تعمیرات", CanEnter = true, CanCreate = true, CanUpdate = true, CanDelete = true });

                GroupCrud ug = new GroupCrud();

                User user = new User()
                {
                    Name = FullName.Text,
                    PhoneNumber = PhoneNumber.Text,
                    UserName = UserName.Text,
                    Picture = SaveImage(UserName.Text),
                    RegDate = DateTime.Now,
                    Status = true
                };
                if (Pasword.Text == Pasword2.Text)
                {
                    user.Password = Pasword.Text;
                }
                else
                {
                    MsgBox.Show("خطا", "پسورد شما با یکدیگر همخوانی ندارد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }

                user.UserGroup = group;
                UserCrud crud = new UserCrud();
                if (crud.Create(user))
                {
                    MsgBox.Show("تائید", "ثبت نام با موفقیت انجام شد", MsgBox.TypeOs.Information, MsgBox.Icons.Information);
                    StackPanel.Visibility = Visibility.Hidden;
                    Show(Visibility.Visible);
                    LabelRegister.Visibility = Visibility.Hidden;
                }
                else
                {
                    MsgBox.Show("خطا", "ثبت نام با موفقیت انجام نشد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "لطفا عکس پروفیل خود را تکمیل کنید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }

        }

        private void Btn_back_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            using (UserCrud crud=new UserCrud())
            {
                if (crud.ReadAll().Count()==0)
                {
                    LabelRegister.Visibility = Visibility.Visible;
                }
            }
            StackPanel.Visibility = Visibility.Hidden;
            Label_Restore.Visibility = Visibility.Visible;
            ForgetPassword.Visibility = Visibility.Visible;
            Show(Visibility.Visible);
        }



        private void Label_Restore_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Show(Visibility.Hidden);
            Label_Restore.Visibility = Visibility.Hidden;
            LabelRegister.Visibility = Visibility.Hidden;
            StackPane2.Visibility = Visibility.Visible;
        }

        bool Change()
        {
            try
            {
                DashboardCrud crud = new DashboardCrud();
                var res = crud.GetInfoByUser(txt_UserName.Text);
                if (res != null)
                {
                    crud.Update(txt_Ramz2.Text,res.Id);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void Btn_Submit_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            UserCrud crud = new UserCrud();
            if (crud.Login(txt_UserName.Text, txt_RamzNow.Text))
            {
                if (txt_Ram1.Text == txt_Ramz2.Text)
                {
                    User myUser = crud.GetUserByUserName(txt_UserName.Text);
                    myUser.Password = txt_Ramz2.Text;
                    if (crud.Edit(myUser))
                    {
                        MsgBox.Show("تائید", "رمز شما با موفقیت تغییر کرد", MsgBox.TypeOs.Information,
                            MsgBox.Icons.Information);
                        if (Change())
                        {
                            Application.Current.Shutdown();
                            System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
                        }
                    }
                    else
                    {
                        MsgBox.Show("خطا", "مشکلی در ثبت اطلاعات شما پیش آمده است", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                    }
                }
                else
                {
                    MsgBox.Show("خطا", "رمز شما با یکدیگر همخوانی ندارد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "کاربری با چنین مشخصاتی در سیستم وجود ندارد", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
            }

        }

        private void ButtonBack_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            StackPane2.Visibility = Visibility.Hidden;
            StackPanelPhone.Visibility = Visibility.Hidden;
            Show(Visibility.Visible);
            Label_Restore.Visibility = Visibility.Visible;
            ForgetPassword.Visibility = Visibility.Visible;
        }
        #region sartRules
        private void Txt_ForgetPass1_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_ForgetPass2_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_username_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_pasword_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void FullName_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text.ToString(), @"\p{IsArabic}")
                && !string.IsNullOrWhiteSpace(e.Text.ToString()))
                e.Handled = true;
        }

        private void UserName_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Pasword_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Pasword2_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_UserName_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_RamzNow_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_Ram1_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_Ramz2_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_phone_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion EndRules

        private void ForgetPassword_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label_Restore.Visibility = Visibility.Hidden;
            ForgetPassword.Visibility = Visibility.Hidden;
            Show(Visibility.Hidden);
            StackPanelPhone.Visibility = Visibility.Visible;

        }


        private void Btn_SendCode_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.SearchPhone(txt_phone.Text)!=null)
                {
                    MyUser = crud.SearchPhone(txt_phone.Text);
                    Random random = new Random();
                    Number = random.Next(1000000).ToString();
                    string text = $"نرم افزار تعمیرگاه موبایل\nکد احراز هویت شما:{Number}";
                    if (Send(txt_phone.Text, text))
                    {
                        Time();
                        txt_phone.Text = "";
                        Label_Phone.Visibility = Visibility.Hidden;
                        ResendCode.Visibility = Visibility.Visible;
                        ResendCode.IsEnabled = false;
                        Label_Tick.Visibility = Visibility.Visible;
                        WrapSendCode.Visibility = Visibility.Hidden;
                        btn_confirm.Visibility = Visibility.Visible;
                        Warning.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MsgBox.Show("خطا", "کد ارسال نشد لطفا با اپراتور مربوطه تماس حاصل فرمائید", MsgBox.TypeOs.Error,
                            MsgBox.Icons.Error);
                    }

                }
                else
                {
                    MsgBox.Show("خطا", "شماره تلفن وارد شده صحیح نمی باشد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
        }

        private void Btn_confirm_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_phone.Text == Number)
            {
                Warning.Visibility = Visibility.Hidden;
                ResendCode.Visibility = Visibility.Hidden;
                Label_Tick.Visibility = Visibility.Hidden;
                btn_confirm.Visibility = Visibility.Hidden;
                StackPanelPhone.Visibility = Visibility.Hidden;
                ShowForget(Visibility.Visible);
                txt_phone.Focus();
            }
            else
            {
                MsgBox.Show("خطا", "کد وارد شده صحیح نمی باشد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }
        }

        private void SavePass_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_ForgetPass1.Text == txt_ForgetPass2.Text)
            {
                using (UserCrud crud=new UserCrud())
                {
                    MyUser.Password = txt_ForgetPass1.Text;
                    if (crud.Edit(MyUser))
                    {
                        MsgBox.Show("تائید", "رمز عبور شما با موفقیت تغییر کرد", MsgBox.TypeOs.Information,
                            MsgBox.Icons.Information);
                        DashboardCrud dc=new DashboardCrud();
                        var information = dc.GetInfo();
                        if (information != null)
                        {
                            if (information.UserName == MyUser.UserName)
                            {
                                information.Password = txt_ForgetPass1.Text;
                                dc.EditInfo(information);
                            }
                        }
                        ShowForget(Visibility.Hidden);
                        ButtonBack_OnMouseLeftButtonDown(sender);
                    }
                    else
                    {
                        MsgBox.Show("خطا", "مشکلی پیش آمده است", MsgBox.TypeOs.Error,
                            MsgBox.Icons.Error);
                    }
                }
            }
            else
            {
                MsgBox.Show("خطا", "پسورد وارد شده با یکدیگر مطابقت ندارد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }
        }

        private void ResendCode_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResendCode.IsEnabled = false;
            Time(1);
            Random random = new Random();
            Number = random.Next(1000000).ToString();
            string text = $"نرم افزار تعمیرگاه موبایل\nکد احراز هویت شما:{Number}";
            if (Send(MyUser.PhoneNumber, text))
            {
                MsgBox.Show("تائید", "کد احراز هویت مجددا به شماره تلفن شما ارسال شد", MsgBox.TypeOs.Information,
                    MsgBox.Icons.Information);
            }
            else
            {
                MsgBox.Show("خطا", "کد ارسال نشد لطفا با اپراتور مربوطه تماس حاصل فرمائید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
            }
        }

        #region Rules

        private void Txt_username_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_pasword.Focus();
            }
        }

        private void Txt_pasword_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                WrapPanel_OnMouseLeftButtonDown(sender);
            }
        }
        private void PhoneNumber_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PhoneNumber_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserName.Focus();
            }
        }

        private void UserName_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Pasword.Focus();
            }
        }

        private void Pasword_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Pasword2.Focus();
            }
        }

        private void Pasword2_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_register_OnMouseLeftButtonDown(sender);
            }
        }

        private void Txt_UserName_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_RamzNow.Focus();
            }
        }

        private void Txt_RamzNow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_Ram1.Focus();
            }
        }

        private void Txt_Ram1_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_Ramz2.Focus();
            }
        }

        private void Txt_Ramz2_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_Submit_OnMouseLeftButtonDown(sender);
            }
        }

        private void FullName_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PhoneNumber.Focus();
            }

        }

        #endregion




    }
}
