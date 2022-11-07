using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogicLayer;
using Entities;
using ManagementMobile.Msg;
using Utility;
using Path = System.IO.Path;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
            btn_setting.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
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
        public static RoutedCommand btn_setting = new RoutedCommand();

        public User LoginInWindow { get; set; }
        void OpenForm(Window frm)
        {
            Window window = (Window)this.FindName("Main");
            BlurBitmapEffect blur = new BlurBitmapEffect();
            blur.Radius = 20;
            window.BitmapEffect = blur;
            frm.ShowDialog();
            blur.Radius = 0;
            window.BitmapEffect = blur;

        }

        public void Refresh()
        {
            Label_UserName.Content = LoginInWindow.UserName;
            using (DashboardCrud crud=new DashboardCrud())
            {
                TextReminderCount.Text = crud.GetCountOfReminder(LoginInWindow.UserId).ToString();
                TextCustomerCount.Text = crud.GetCustomerCount().ToString();
                TextRepairCount.Text = crud.GetCountOfRepair(LoginInWindow.UserId).ToString();
                if (crud.GetCountOfReminder(LoginInWindow.UserId) > 0)
                {
                    foreach (var item in crud.GetReminders(LoginInWindow.UserId))
                    {
                        ReminderOption option = new ReminderOption();
                        option.Visibility = Visibility.Visible;
                        option.txt_ReminderTitle.Text = item.ReminderTitle;
                        option.txt_ReminderInfo.Text = item.ReminderInfo;
                        option.txt_tarikh.Text = item.RemindDate.Shamsi();
                        option.Id = item.ReminderId;
                        Grid.SetRow(option, 5);
                        Grid.SetColumnSpan(option, 6);
                        StackPanel1.Children.Add(option);
                    }
                }
            }
        }

        public void clear()
        {
            StackPanel1.Children.Clear();
        }
        private void Leave_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (MsgBox.Show("هشدار", "آیا از خروج در نرم افزار مطمئن هستید؟", MsgBox.TypeOs.Delete,
                    MsgBox.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Customers_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud=new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش مشتریان", 1))
                {
                    CustomerWindow cw=new CustomerWindow();
                    cw.LoginInWindow = LoginInWindow;
                    OpenForm(cw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void Phone_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "پذیرش جدید", 1))
                {
                    PhoneWindow pw = new PhoneWindow();
                    pw.LoginInWindow = LoginInWindow;
                    OpenForm(pw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void User_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش کاربران", 1))
                {
                    UserWindow uw = new UserWindow();
                    uw.LoginInWindow = LoginInWindow;
                    OpenForm(uw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void Reminder_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش یادآورها", 1))
                {
                    ReminderWindow rw = new ReminderWindow();
                    rw.LoginInWindow = LoginInWindow;
                    OpenForm(rw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void Repair_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "تعمیرات", 1))
                {
                    RepairWindow rw = new RepairWindow();
                    rw.LoginInWindow = LoginInWindow;
                    OpenForm(rw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void Activity_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش فعالیت", 1))
                {
                    ActivityWindow aw = new ActivityWindow();
                    aw.LoginInWindow = LoginInWindow;
                    OpenForm(aw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void Invoice_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش فاکتورها", 1))
                {
                    InvoiceWindow iw = new InvoiceWindow();
                    iw.LoginInWindow = LoginInWindow;
                    OpenForm(iw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (LoginInWindow.Status == false)
            {
                Window window = (Window)this.FindName("Main");
                BlurBitmapEffect blur = new BlurBitmapEffect();
                blur.Radius = 20;
                window.BitmapEffect = blur;
                if (MsgBox.Show("خطا", "حساب کاربری شما توسط مدیر غیرفعال شده است", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error) == System.Windows.Forms.DialogResult.Cancel)
                {
                    Application.Current.Shutdown();
                    System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
                }
                blur.Radius = 0;
                window.BitmapEffect = blur;

            }
            else
            {
                SplashScreen ss = (SplashScreen)Application.Current.Windows.OfType<Window>().FirstOrDefault();
                ss.Close();
            }

        }

        private void Profile_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ProfileWindow pw=new ProfileWindow();
            pw.MyUser = LoginInWindow;
            OpenForm(pw);
        }

        private void Report_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش گزارشات", 1))
                {
                    ReportWindow rw = new ReportWindow();
                    rw.LoginInWindow = LoginInWindow;
                    OpenForm(rw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void Message_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "پنل پیامکی", 1))
                {
                    MessageWindow mw = new MessageWindow();
                    mw.LoginInWindow = LoginInWindow;
                    OpenForm(mw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void ButtonSetting_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش تنظیمات", 1))
                {
                    SettingWindow sw=new SettingWindow();
                    sw.LoginInWindow = LoginInWindow;
                    OpenForm(sw);
                    clear();
                    Refresh();
                }
                else
                {
                    MsgBox.Show("خطا", "شما اجازه دسترسی به این بخش را ندارید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }
        #region Shortcut

        public void LeaveMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Leave_OnMouseLeftButtonDown(sender);
        }

        public void CustomerMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Customers_OnMouseLeftButtonDown(sender);
        }
        public void ActivityMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Activity_OnMouseLeftButtonDown(sender);
        }
        public void PhoneMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Phone_OnMouseLeftButtonDown(sender);
        }
        public void InvoiceMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Invoice_OnMouseLeftButtonDown(sender);
        }
        public void UserMethod(object sender, ExecutedRoutedEventArgs e)
        {
            User_OnMouseLeftButtonDown(sender);
        }
        public void RepairMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Repair_OnMouseLeftButtonDown(sender);
        }
        public void ReportMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Report_OnMouseLeftButtonDown(sender);
        }
        public void ReminderMethod(object sender, ExecutedRoutedEventArgs e)
        { 
            Reminder_OnMouseLeftButtonDown(sender);
        }
        public void MessageMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Message_OnMouseLeftButtonDown(sender);
        }
        public void SettingMethod(object sender, ExecutedRoutedEventArgs e)
        {
            ButtonSetting_OnMouseLeftButtonDown(sender);
        }
        #endregion

        private void Btn_about_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AboutWindow aw=new AboutWindow();
            aw.LoginInWindow = LoginInWindow;
            OpenForm(aw);
        }
    }
}
