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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogicLayer;
using Entities;
using ManagementMobile.Msg;
using Stimulsoft.Report;
using Utility;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
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
            ButtonSetting.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
            ButtonShow.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            ButtonPrint.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Control));

        }

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
        public static RoutedCommand ButtonPrint = new RoutedCommand();
        public static RoutedCommand ButtonShow = new RoutedCommand();

        public User LoginInWindow { get; set; }

        void Refresh()
        {
            DataGridCustomer.Visibility = Visibility.Hidden;
            DataGridActivity.Visibility = Visibility.Hidden;
            DataGridInvoice.Visibility = Visibility.Hidden;
            DataGridPhone.Visibility = Visibility.Hidden;
            DataGridUser.Visibility = Visibility.Hidden;
        }
        private void Btn_show_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (StartDate.Text != "" && EndDate.Text != "")
            {
                ReportCrud crud = new ReportCrud();
                int a = 0;
                if (CustomerCheck.IsChecked == true && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == false)
                {
                    Refresh();
                    DataGridCustomer.Visibility = Visibility.Visible;
                    DataGridCustomer.ItemsSource =
                        crud.GetAllCustomers(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value);
                    a = 1;
                }
                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == true && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == false)
                {
                    Refresh();
                    DataGridActivity.Visibility = Visibility.Visible;
                    DataGridActivity.ItemsSource =
                        crud.GetAllActivity(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value);
                    a = 1;
                }
                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == true &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == false)
                {
                    Refresh();
                    DataGridInvoice.Visibility = Visibility.Visible;
                    DataGridInvoice.ItemsSource =
                        crud.GetAllInvoices(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value);
                    a = 1;
                }
                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == true)
                {
                    Refresh();
                    DataGridPhone.Visibility = Visibility.Visible;
                    DataGridPhone.ItemsSource =
                        crud.GetAllPhones(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value);
                    a = 1;
                }

                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == true && PhoneCkeck.IsChecked == false)
                {
                    Refresh();
                    DataGridUser.Visibility = Visibility.Visible;
                    DataGridUser.ItemsSource =
                        crud.GetAllUsers(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value);
                    a = 1;
                }

                if (a == 0)
                {
                    MsgBox.Show("خطا", "لطفا یک گزینه را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }

            else
            {
                MsgBox.Show("خطا", "لطفا تاریخ مورد نطر را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }
        }

        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ReportWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        private void Btn_print_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (StartDate.Text != "" && EndDate.Text != "")
            {
                ReportCrud crud = new ReportCrud();
                int a = 0;
                if (CustomerCheck.IsChecked == true && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == false)
                {
                    StiReport report = new StiReport();
                    report.Load(System.Windows.Forms.Application.StartupPath + "/CustomerReport.mrt");
                    report.Dictionary.Variables["Date"].Value = DateTime.Now.ToSHAMSI();
                    report.RegData("DT", crud.GetAllCustomers(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value));
                    report.ShowWithWpf();
                    a = 1;
                }
                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == true && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == false)
                {
                    StiReport report = new StiReport();
                    report.Load(System.Windows.Forms.Application.StartupPath + "/ActivityReport.mrt");
                    report.Dictionary.Variables["Date"].Value = DateTime.Now.ToSHAMSI();
                    report.RegData("DT", crud.GetAllActivity(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value));
                    report.ShowWithWpf();
                    a = 1;
                }
                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == true &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == false)
                {
                    StiReport report = new StiReport();
                    report.Load(System.Windows.Forms.Application.StartupPath + "/SellReport.mrt");
                    report.Dictionary.Variables["Date"].Value = DateTime.Now.ToSHAMSI();
                    report.RegData("DT", crud.GetAllInvoices(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value));
                    report.ShowWithWpf();
                    a = 1;
                }
                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == false && PhoneCkeck.IsChecked == true)
                {
                    StiReport report = new StiReport();
                    report.Load(System.Windows.Forms.Application.StartupPath + "/PhoneReport.mrt");
                    report.Dictionary.Variables["Date"].Value = DateTime.Now.ToSHAMSI();
                    report.RegData("DT", crud.GetAllPhones(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value));
                    report.ShowWithWpf();
                    a = 1;
                }
                if (CustomerCheck.IsChecked == false && ActivityCheck.IsChecked == false && SellCkeck.IsChecked == false &&
                    UserCkeck.IsChecked == true && PhoneCkeck.IsChecked == false)
                {
                    StiReport report = new StiReport();
                    report.Load(System.Windows.Forms.Application.StartupPath + "/UserReport.mrt");
                    report.Dictionary.Variables["Date"].Value = DateTime.Now.ToSHAMSI();
                    report.RegData("DT", crud.GetAllUsers(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value));
                    report.ShowWithWpf();
                    a = 1;
                }
                if (a == 0)
                {
                    MsgBox.Show("خطا", "لطفا یک گزینه را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "لطفا تاریخ مورد نطر را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }
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
            MsgBox.Show("خطا", "شما در صفحه بخش گزارشات حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
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
        public void PrintMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Btn_print_OnMouseLeftButtonDown(sender);
        }
        public void ShowMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Btn_show_OnMouseLeftButtonDown(sender);
        }
        #endregion
    }
}
