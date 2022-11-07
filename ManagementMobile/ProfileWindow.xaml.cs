using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogicLayer;
using Entities;
using ManagementMobile.Msg;
using Microsoft.Win32;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
        }

        public bool Confirm = true;
        public User MyUser { get; set; }
        OpenFileDialog open=new OpenFileDialog();
        private bool status;
        public string location_Image;
        string SaveImage(string UserName)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
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

        void show(int number)
        {
            if (number == 0)
            {
                StackPanel1.Visibility = Visibility.Hidden;
                StackPanel2.Visibility = Visibility.Visible;
                ButtonChangeImage.Visibility = Visibility.Visible;
            }
            else
            {
                StackPanel1.Visibility = Visibility.Visible;
                StackPanel2.Visibility = Visibility.Hidden;
                ButtonChangeImage.Visibility = Visibility.Hidden;
            }
        }

        void refresh()
        {
            TextFullName.Text = "";
            TextUserName.Text = "";
            Pass1.Text = "";
            Pass2.Text = "";
        }

        private void ProfileWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(MyUser.Picture);
            bitmap.EndInit();
            MyImage.Source = bitmap;
            txt_fullname.Text = MyUser.Name;
            txt_username.Text = MyUser.UserName;
            status = true;
            location_Image = MyUser.Picture;
        }

        private void ButtonChangeImage_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                MyImage.Source = bitmap;
                location_Image = selectedFileName;
                status = false;
            }
        }

        private void ButtonEdit_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show(0);
            TextFullName.Focus();
        }

        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (TextFullName.Text != "" && TextUserName.Text != "" && Pass1.Text != "" && Pass2.Text != ""&&MyImage.Source!=null)
            {
                User user = new User()
                {
                    UserId = MyUser.UserId,
                    Name = TextFullName.Text,
                    UserName = TextUserName.Text,
                    Picture = SaveImage(TextUserName.Text),
                    GroupId = MyUser.GroupId,
                    RegDate = MyUser.RegDate,
                    Status = MyUser.Status
                };
                if (Pass1.Text == Pass2.Text)
                {
                    user.Password = Pass1.Text;
                }
                else
                {
                    Confirm = false;
                    MsgBox.Show("خطا", "رمز عبور شما با تکرارش همخوانی ندارد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
                UserCrud crud = new UserCrud();
                if (Confirm)
                {
                    if (crud.Edit(user))
                    {
                        MsgBox.Show("تائید", "ویرایش با موفقیت انجام شد", MsgBox.TypeOs.Information,
                            MsgBox.Icons.Information);
                        refresh();
                        MyUser = user;
                        ProfileWindow_OnLoaded(sender, e);
                    }
                    else
                    {
                        MsgBox.Show("خطا", "مشکلی در ثبت اطلاعات پیش آمده است", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                    }
                }
            }
            else
            {
                MsgBox.Show("خطا", "لطفا فیلد های خالی را پر نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }
        }

        private void Btn_back_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show(1);
            refresh();
        }

        private void ButtonBack_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Name == "Main")
                {
                    (item as MainWindow).LoginInWindow = MyUser;
                }
            }
            this.Close();
        }

        private void ButtonExit_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
        }


        private void Txt_username_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void TextUserName_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Pass1_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Pass2_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void TextFullName_OnKeyDown(object sender, KeyEventArgs e)
        {
            TextUserName.Focus();
        }

        private void TextUserName_OnKeyDown(object sender, KeyEventArgs e)
        {
            Pass1.Focus();
        }

        private void Pass1_OnKeyDown(object sender, KeyEventArgs e)
        {
            Pass2.Focus();
        }

        private void Pass2_OnKeyDown(object sender, KeyEventArgs e)
        {
            Btn_register_OnMouseLeftButtonDown(sender);
        }
    }
}
