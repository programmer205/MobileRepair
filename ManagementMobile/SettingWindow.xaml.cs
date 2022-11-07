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
using BusinessLogicLayer;
using Entities;
using ManagementMobile.Msg;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
            ButtonLeave.InputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            ButtonCustomer.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));
            ButtonActivity.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
            ButtonInvoice.InputGestures.Add(new KeyGesture(Key.I, ModifierKeys.Alt));
            ButtonPhone.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Alt));
            ButtonRepair.InputGestures.Add(new KeyGesture(Key.R, ModifierKeys.Alt));
            ButtonReport.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Alt));
            ButtonReminder.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Alt));
            ButtonUser.InputGestures.Add(new KeyGesture(Key.U, ModifierKeys.Alt));
            ButtonMessage.InputGestures.Add(new KeyGesture(Key.M, ModifierKeys.Alt));
            btn_Backup.InputGestures.Add(new KeyGesture(Key.Z , ModifierKeys.Alt));
            btn_Restore.InputGestures.Add(new KeyGesture(Key.X, ModifierKeys.Alt));
            ButtonSetting.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
        }
        public User LoginInWindow { get; set; }

        public static RoutedCommand btn_Backup = new RoutedCommand();
        public static RoutedCommand btn_Restore = new RoutedCommand();
        public static RoutedCommand ButtonLeave = new RoutedCommand();
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

        void bind()
        {
            BackupCrud crud = new BackupCrud();
            DataGrid1.ItemsSource = crud.GetAllBackups();
        }

        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ButtonBackup_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            string path = open.SelectedPath;
            string name = MsgBox.ReturnValue("نام فایل");
            BackupCrud crud = new BackupCrud();
            if (crud.Backup(path, name))
            {
                MsgBox.Show("تائید", "عملیت بکاپ از دیتابیس با موفقیت انجام شد", MsgBox.TypeOs.Information,
                    MsgBox.Icons.Information);
            }
            else
            {
                MsgBox.Show("خطا", "عملیت بکاپ از دیتابیس با موفقیت انجام نشد", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
            }
            MyBackup myBackup = new MyBackup()
            {
                Name = name,
                Address = path + @"\" + name + ".bak"
            };
            crud.Create(myBackup);
            bind();
        }

        private void ButtonRestore_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (MsgBox.Show("اخطار", "در صورت بازگردانی ممکن است برخی از اطلاعات شما از دست رفته باشند",
                    MsgBox.TypeOs.Warning, MsgBox.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                if (open.FileName.Length > 0)
                {
                    string path = open.FileName;
                    BackupCrud crud = new BackupCrud();
                    if (crud.Restore(path))
                    {
                        MsgBox.Show("تائید", "بازگردانی اطلاعات با موفقیت انجام شد", MsgBox.TypeOs.Information,
                            MsgBox.Icons.Information);
                    }
                    else
                    {
                        MsgBox.Show("خطا", "عملیت بازگردانی با موفقیت انجام نشد", MsgBox.TypeOs.Error,
                            MsgBox.Icons.Error);
                    }
                }
            };
        }

        private void DataGrid1_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dt_btn.Visibility = Visibility.Visible;
        }

        private void Dt_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                MyBackup mk = (DataGrid1.SelectedItem) as MyBackup;
                if (MsgBox.Show("اخطار", "در صورت بازگردانی ممکن است برخی از اطلاعات شما از دست رفته باشند",
                        MsgBox.TypeOs.Delete, MsgBox.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    string path = mk.Address;
                    BackupCrud crud = new BackupCrud();
                    if (crud.Restore(path))
                    {
                        MsgBox.Show("تائید", "بازگردانی اطلاعات با موفقیت انجام شد", MsgBox.TypeOs.Information,
                            MsgBox.Icons.Information);
                    }
                    else
                    {
                        MsgBox.Show("خطا", "عملیت بازگردانی با موفقیت انجام نشد", MsgBox.TypeOs.Error,
                            MsgBox.Icons.Error);
                    }
                }
            }
            else
            {
                MsgBox.Show("خطا", "لطفا یک آیتم را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }
        }

        private void SettingWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            bind();
        }

        #region Shortcut

        public void LeaveMethod(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
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
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش کاربران", 1))
                {
                    this.Close();
                    UserWindow uw = new UserWindow();
                    uw.LoginInWindow = LoginInWindow;
                    uw.ShowDialog();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
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
            MsgBox.Show("خطا", "شما در صفحه بخش تنظیمات  حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
        }
        public void BackupMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش تنظیمات", 2))
                {
                    ButtonBackup_OnMouseLeftButtonDown(sender);
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        public void RestoreMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش تنظیمات", 2))
                {
                    ButtonRestore_OnMouseLeftButtonDown(sender);
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        #endregion

        private void SettingWindow_OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }
    }
}
