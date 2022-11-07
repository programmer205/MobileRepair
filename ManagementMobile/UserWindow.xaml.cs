using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;
using BusinessLogicLayer;
using Entities;
using ManagementMobile.Msg;
using ViewModels;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Path = System.IO.Path;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            MyGrid.DataContext = this;
            GroupCrud gc=new GroupCrud();
            MyGroup = gc.GetAllNames();
            ButtonLeave.InputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            ButtonSubmit.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            ButtonCustomer.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));
            ButtonActivity.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
            ButtonInvoice.InputGestures.Add(new KeyGesture(Key.I, ModifierKeys.Alt));
            ButtonPhone.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Alt));
            ButtonRepair.InputGestures.Add(new KeyGesture(Key.R, ModifierKeys.Alt));
            ButtonReport.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Alt));
            ButtonReminder.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Alt));
            ButtonUser.InputGestures.Add(new KeyGesture(Key.U, ModifierKeys.Alt));
            ButtonMessage.InputGestures.Add(new KeyGesture(Key.M, ModifierKeys.Alt));
            ButtonSetting.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
        }

        public static RoutedCommand ButtonLeave = new RoutedCommand();
        public static RoutedCommand ButtonSubmit = new RoutedCommand();
        public static RoutedCommand ButtonCustomer = new RoutedCommand();
        public static RoutedCommand ButtonInvoice = new RoutedCommand();
        public static RoutedCommand ButtonActivity = new RoutedCommand();
        public static RoutedCommand ButtonRepair = new RoutedCommand();
        public static RoutedCommand ButtonReport = new RoutedCommand();
        public static RoutedCommand ButtonReminder = new RoutedCommand();
        public static RoutedCommand ButtonPhone = new RoutedCommand();
        public static RoutedCommand ButtonUser = new RoutedCommand();
        public static RoutedCommand ButtonMessage = new RoutedCommand();
        public static RoutedCommand ButtonSetting = new RoutedCommand();

        void Reset()
        {
            MyGrid.DataContext = this;
            GroupCrud gc = new GroupCrud();
            MyGroup = gc.GetAllNames();
        }
        public string location_Image;
        public bool status;
        public int IdForEdit = 0;
        public List<string> MyGroup { get; set; }
        public User LoginInWindow { get; set; }
        OpenFileDialog open=new OpenFileDialog();
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
        private void Lbl_pic_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
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
            }
        }

        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud crud = new UserCrud();
            if (crud.Access(LoginInWindow, "بخش کاربران", 1))
            {
                if (txt_name.Text != "" && txt_phone.Text != "" && txt_password.Text != "" && txt_password2.Text != "" &&
    txt_status.Text != "" && select_image.Source != null)
                {
                    if (txt_status.Text != "مدیریت"||LoginInWindow.UserGroup.Tiltle=="مدیریت")
                    {
                        GroupCrud gc = new GroupCrud();
                        if (IdForEdit == 0)
                        {
                            User user = new User()
                            {
                                Name = txt_name.Text,
                                PhoneNumber = txt_phone.Text,
                                RegDate = DateTime.Now,
                                UserName = txt_username.Text,
                                Status = true,
                                Picture = SaveImage(txt_username.Text)
                            };
                            if (txt_password.Text == txt_password2.Text)
                            {
                                user.Password = txt_password.Text;
                            }
                            else
                            {
                                MsgBox.Show("هشدار", "رمز عبور درست وارد نشده است", MsgBox.TypeOs.Warning, MsgBox.Icons.Warning);

                            }

                            var id = gc.GetGroupByName(txt_status.SelectedItem.ToString()).Id;
                            user.GroupId = id;
                            if (crud.Create(user))
                            {
                                MsgBox.Show("تائید", "ثبت نام با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                    MsgBox.Icons.Information);
                                Refresh();
                            }
                            else
                            {
                                MsgBox.Show("خطا", "مشکلی در ثبت اطلاعات پیش آمده است", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                            }

                        }
                        else
                        {
                            UserCrud uc = new UserCrud();
                            var find = uc.Find(IdForEdit);
                            uc.Dispose();
                            User user = new User()
                            {
                                UserId = IdForEdit,
                                Name = txt_name.Text,
                                PhoneNumber = txt_phone.Text,
                                UserName = txt_username.Text,
                                Status = true,
                                RegDate = find.RegDate,
                                Picture = SaveImage(txt_username.Text)
                            };
                            if (txt_password.Text == txt_password2.Text)
                            {
                                user.Password = txt_password.Text;
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("رمز عبور درست وارد نشده است");
                            }
                            var id = gc.GetGroupByName(txt_status.Text).Id;
                            uc.Dispose();
                            user.GroupId = id;
                            if (crud.Edit(user))
                            {
                                MsgBox.Show("تائید", "ویرایش با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                    MsgBox.Icons.Information);
                                DashboardCrud dc = new DashboardCrud();
                                var info = dc.GetInfo();
                                if (info != null)
                                {
                                    if (info.UserId == user.UserId)
                                    {
                                        dc.Update(txt_password.Text,info.Id);
                                    }
                                }
                                Refresh();
                            }
                            else
                            {
                                MsgBox.Show("خطا", "مشکلی در ثبت اطلاعات پیش آمده است", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                            }
                        }
                    }
                    else
                    {
                        MsgBox.Show("خطا", "شما اجازه ساخت و ویرایش حساب کاربری با عنوان مدیریت را ندارید",
                            MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                    }
                   
                }
                else
                {

                    MsgBox.Show("خطا", "لطفا فیلد های خالی را پر نمائید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "شما اجازه ثبت و ویرایش اطلاعات را ندارید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
                crud.Dispose();
            }


        }

        void Refresh()
        {
            contacts.Text = "افزودن کاربر جدید";
            txt_name.Text = "";
            txt_phone.Text = "";
            txt_status.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_password2.Text = "";
            btn_register.Content = "ثبت اطلاعات";
            DataGrid1.ItemsSource = null;
            select_image.Source = null;
            lbl_pic.Content = "افزودن عکس";
            txt_name.Focus();
        }
        private void UserWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IdForEdit != 0)
            {
                UserCrud crud=new UserCrud();
                GroupCrud gc=new GroupCrud();
                User find = crud.Find(IdForEdit);
                txt_phone.Text = find.PhoneNumber;
                txt_name.Text = find.Name;
                txt_username.Text = find.UserName;
                btn_register.Content = "ویرایش اطلاعات";
                lbl_pic.Content = "ویرایش عکس";
                contacts.Text = "ویرایش اطلاعات کاربر";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(find.Picture);
                bitmap.EndInit();
                select_image.Source = bitmap;
                status = true;
                location_Image = find.Picture;
                var combo = gc.Find(find.GroupId);
                txt_status.SelectedItem = combo.Tiltle;
            }
        }

        void Show()
        {
            UserCrud crud = new UserCrud();
            if (LoginInWindow.UserGroup.Tiltle == "مدیریت")
            {
                DataGrid1.ItemsSource = null;
                DataGrid1.ItemsSource = crud.Read();
            }
            else
            {
                DataGrid1.ItemsSource = null;
                DataGrid1.ItemsSource = crud.ReadWithoutAdmin();
            }
            

        }
        AccessRole fillAccessRole(string Section, bool CanEnter, bool CanCreate, bool CanEdit, bool CanDelete)
        {
            AccessRole accessRole = new AccessRole()
            {
                Section = Section,
                CanEnter = CanEnter,
                CanCreate = CanCreate,
                CanDelete = CanDelete,
                CanUpdate = CanEdit
            };
            return accessRole;
        }

        private void Btn_SubmitGroup_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش کاربران", 1))
            {
                UserGroup userGroup = new UserGroup()
                {
                    Tiltle = txt_group.Text
                };
                userGroup.AccessRoles.Add(fillAccessRole(Label_Customer.Content.ToString(), CheckBox1.IsChecked.Value, CheckBox2.IsChecked.Value, CheckBox3.IsChecked.Value, CheckBox3.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Product.Content.ToString(), CheckBox5.IsChecked.Value, CheckBox6.IsChecked.Value, CheckBox7.IsChecked.Value, CheckBox8.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Invoice.Content.ToString(), CheckBox9.IsChecked.Value, CheckBox10.IsChecked.Value, CheckBox11.IsChecked.Value, CheckBox12.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Users.Content.ToString(), CheckBox13.IsChecked.Value, CheckBox14.IsChecked.Value, CheckBox15.IsChecked.Value, CheckBox16.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Activity.Content.ToString(), CheckBox17.IsChecked.Value, CheckBox18.IsChecked.Value, CheckBox19.IsChecked.Value, CheckBox20.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Reminder.Content.ToString(), CheckBox21.IsChecked.Value, CheckBox22.IsChecked.Value, CheckBox23.IsChecked.Value, CheckBox24.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Report.Content.ToString(), CheckBox25.IsChecked.Value, CheckBox26.IsChecked.Value, CheckBox27.IsChecked.Value, CheckBox28.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Setting.Content.ToString(), CheckBox29.IsChecked.Value, CheckBox30.IsChecked.Value, CheckBox31.IsChecked.Value, CheckBox32.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Message.Content.ToString(), CheckBox33.IsChecked.Value, CheckBox34.IsChecked.Value, CheckBox35.IsChecked.Value, CheckBox36.IsChecked.Value));
                userGroup.AccessRoles.Add(fillAccessRole(Label_Repair.Content.ToString(), CheckBox37.IsChecked.Value, CheckBox38.IsChecked.Value, CheckBox39.IsChecked.Value, CheckBox40.IsChecked.Value));
                GroupCrud crud = new GroupCrud();
                if (crud.Create(userGroup))
                {
                    MsgBox.Show("تائید", "ثبت اطلاعات با موفقیت انجام شد", MsgBox.TypeOs.Information,
                        MsgBox.Icons.Information);
                    MyGroup.Add(userGroup.Tiltle);
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "ثبت اطلاعات با موفقیت انجام نشد", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "شما اجازه ثبت اطلاعات را ندارید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
                uc.Dispose();
            }
        }

        private void DataGrid1_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dt_btn.Visibility = Visibility.Visible;
            ed_btn.Visibility = Visibility.Visible;
            var res = (UserViewModel) (DataGrid1.SelectedItem);
            if (res!=null&&res.Status)
            {
                btn_disabled.Content = "غیر فعال کن";
                btn_disabled.Visibility = Visibility.Visible;
            }
            else
            {
                btn_disabled.Content = "فعال کن";
                btn_disabled.Visibility = Visibility.Visible;
            }
        }

        private void Btn_show_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Show();
        }

        private void Dt_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud crud = new UserCrud();
            if (crud.Access(LoginInWindow, "بخش کاربران", 4))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    UserViewModel uw = (UserViewModel)(DataGrid1.SelectedItem);
                    if (uw.Title != "مدیریت")
                    {
                        IdForEdit = uw.UserId;

                        if (MsgBox.Show("اخطار", "آیا از حذف کاربر مورد نظر مطمئن هستید", MsgBox.TypeOs.Delete, MsgBox.Icons.Warning) ==
                            System.Windows.Forms.DialogResult.OK)
                        {
                            crud.Delete(IdForEdit);
                            IdForEdit = 0;
                            Refresh();
                        }
                    }
                    else
                    {
                        MsgBox.Show("خطا", "شما نمی توانید اکانت کاربری خود را حذف کنید", MsgBox.TypeOs.Error,
                            MsgBox.Icons.Error);
                    }

                }
                else
                {
                    MsgBox.Show("خطا", "لطفا یک آیتم را انتخاب نمایید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                };
            }
            else
            {
                MsgBox.Show("خطا", "شما اجازه حذف اطلاعات را ندارید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
                crud.Dispose();
            }
        }

        private void Ed_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش کاربران", 3))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    UserViewModel uw = (UserViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = uw.UserId;
                    UserWindow_OnLoaded(sender, e);
                    uc.Dispose();
                    txt_name.Focus();
                }
                else
                {
                    MsgBox.Show("خطا", "لطفا یک آیتم را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "شما اجازه ویرایش اطلاعات را ندارید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
                uc.Dispose();
            }

        }

        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void Btn_disabled_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                UserViewModel uw = (UserViewModel)(DataGrid1.SelectedItem);
                if (uw.Title != "مدیریت")
                {
                    using (UserCrud crud = new UserCrud())
                    {
                        User user = crud.Find(uw.UserId);
                        if (user.Status)
                        {
                            user.Status = false;
                        }
                        else
                        {
                            user.Status = true;
                        }

                        if (crud.Edit(user))
                        {
                            MsgBox.Show("تائید", "تغییرات با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                MsgBox.Icons.Information);
                            Refresh();
                        }

                    }
                }
                else
                {
                    MsgBox.Show("خطا", "شما نمی توانید حساب کاربری خود را غیر فعال کنید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }

            }
            else
            {
                MsgBox.Show("خطا", "لطفا یک آیتم را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }

        }


        #region  Rules

        private void Txt_username_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_password_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_password2_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Txt_name_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text.ToString(), @"\p{IsArabic}")
                && !string.IsNullOrWhiteSpace(e.Text.ToString()))
                e.Handled = true;
        }

        private void Txt_family_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_name_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_phone.Focus();
            }
        }

        private void Txt_family_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_status.Focus();
            }
        }

        private void Txt_status_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_username.Focus();
            }
        }

        private void Txt_password_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_password2.Focus();
            }
        }

        private void Txt_password2_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Lbl_pic_OnMouseLeftButtonDown(sender);
            }
        }

        private void Txt_username_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_password.Focus();
            }
        }

        private void UserWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        #endregion

        #region Shortcut

        public void LeaveMethod(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public void SubmitMethod(object sender, ExecutedRoutedEventArgs e)
        {
            txt_name.Focus();
        }
        public void CustomerMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش مشتریان", 1))
                {
                    this.Close();
                    CustomerWindow cw=new CustomerWindow();
                    cw.LoginInWindow = LoginInWindow;
                    cw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void ActivityMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش فعالیت", 1))
                {
                    this.Close();
                    ActivityWindow aw=new ActivityWindow();
                    aw.LoginInWindow = LoginInWindow;
                    aw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void PhoneMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "پذیرش جدید", 1))
                {
                    this.Close();
                    PhoneWindow pw = new PhoneWindow();
                    pw.LoginInWindow = LoginInWindow;
                    pw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void InvoiceMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش فاکتورها", 1))
                {
                    this.Close();
                    InvoiceWindow iw=new InvoiceWindow();
                    iw.LoginInWindow = LoginInWindow;
                    iw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void UserMethod(object sender, ExecutedRoutedEventArgs e)
        {
            MsgBox.Show("خطا", "شما در صفحه بخش کاربران حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
        }
        public void RepairMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "تعمیرات", 1))
                {
                    this.Close();
                    RepairWindow rw = new RepairWindow();
                    rw.LoginInWindow = LoginInWindow;
                    rw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void ReportMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش گزارشات", 1))
                {
                    this.Close();
                    ReportWindow rw = new ReportWindow();
                    rw.LoginInWindow = LoginInWindow;
                    rw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void ReminderMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش یادآورها", 1))
                {
                    this.Close();
                    ReminderWindow rw = new ReminderWindow();
                    rw.LoginInWindow = LoginInWindow;
                    rw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void MessageMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "پنل پیامکی", 1))
                {
                    this.Close();
                    MessageWindow mw = new MessageWindow();
                    mw.LoginInWindow = LoginInWindow;
                    mw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void SettingMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش تنظیمات", 1))
                {
                    this.Close();
                    SettingWindow sw=new SettingWindow();
                    sw.LoginInWindow = LoginInWindow;
                    sw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        #endregion
    }
}
