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
using Utility;
using ViewModels;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for RepairWindow.xaml
    /// </summary>
    public partial class RepairWindow : Window
    {
        public RepairWindow()
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

        public int IdForEdit=0;
        public User LoginInWindow { get; set; }
        void Show()
        {
            DataGrid1.ItemsSource = null;
            RepairCrud crud=new RepairCrud();
            DataGrid1.ItemsSource = crud.Read();
        }

        private void RepairWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Show();
            Clear();
            RefreshWindow();
        }

        public void RefreshWindow()
        {
            DashboardCrud crud=new DashboardCrud();
            foreach (var item  in crud.GetRepairsForMe(LoginInWindow.UserId))
            {
                Notification notification = new Notification();
                notification.Visibility = Visibility.Visible;
                notification.txt_id.Text = item.RepairId.ToString();
                notification.txt_code.Text = item.ReceptionNumber;
                notification.txt_date.Text = item.VisitDate;
                notification.txt_model.Text = item.PhoneModel;
                notification.txt_phoneId.Text = item.PhoneId.ToString();
                Grid.SetRow(notification, 4);
                Grid.SetColumnSpan(notification, 4);
                StackPanel1.Children.Add(notification);
            }

        }

        public void Clear()
        {
            StackPanel1.Children.Clear();
        }
        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (DataGrid1.SelectedItem != null)
            {
                RepairViewModel rw = (RepairViewModel) (DataGrid1.SelectedItem);
                RepairCrud crud=new RepairCrud();
                int customerId = crud.GetCustomer(rw.PhoneNumber).CustomerId;

                if (IdForEdit == 0)
                {
                    Repair repair = new Repair()
                    {
                        VisitDate = DateTime.Now,
                        Customer_id = customerId,
                        P_id = rw.PhoneId,
                        User_id = LoginInWindow.UserId
                    };
                    if (crud.Create(repair))
                    {
                        MsgBox.Show("تائید", "ثبت اطلاعات با موفقیت انجام شد", MsgBox.TypeOs.Information,
                            MsgBox.Icons.Information);
                        using (PhoneCrud pc=new PhoneCrud())
                        {
                            var find= pc.Find(rw.PhoneId);
                            find.Visit = true;
                            pc.Edit(find);
                        }
                        Show();
                        Clear();
                        RefreshWindow();
                    }
                    else
                    {
                        MsgBox.Show("خطا", "مشکلی در ثبت اطلاعات پیش آمده است", MsgBox.TypeOs.Error,
                            MsgBox.Icons.Error);
                    }
                }
            }
            else
            {

                MsgBox.Show("خطا", "لطفا یک آیتم را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
            }
        }

        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void RepairWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
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
            MsgBox.Show("خطا", "شما در صفحه بخش تعمیرات حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
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
