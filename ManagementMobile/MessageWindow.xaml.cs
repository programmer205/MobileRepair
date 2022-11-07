using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BusinessLogicLayer;
using Entities;
using Kavenegar;
using ManagementMobile.Msg;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent();
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

        public User LoginInWindow { get; set; }
        List<Customer> customers=new List<Customer>();
        List<string> Numbers=new List<string>();
        List<string>Show=new List<string>();
        private void Submit_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (DataGrid1.Items.Count>0)
            {
                var select = (Customer) (DataGrid1.SelectedItem);
                if (select == null)
                {
                    var res = DataGrid1.Items;
                    var customer = (Customer)(res[0]);
                    var Search = customers.Where(n => n.PhoneNumber == customer.PhoneNumber);
                    if (Search.Count() == 0)
                    {
                        customers.Add(customer);
                        Numbers.Add(customer.PhoneNumber);
                        string text = $"نام کامل {customer.FullName} شماره تلفن {customer.PhoneNumber}";
                        Show.Add(text);
                        ListBox.ItemsSource = null;
                        ListBox.ItemsSource = Show;
                    }
                    else
                    {
                        MsgBox.Show("خطا", "این مخاطب در لیست انتخابی شما وجود دراد لطفا مخاطب دیگری را انتخاب نمائید",
                            MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                    }
                }
                else
                {
                    var Search = customers.Where(n => n.PhoneNumber == select.PhoneNumber);
                    if (Search.Count() == 0)
                    {
                        customers.Add(select);
                        Numbers.Add(select.PhoneNumber);
                        string text = $"نام کامل {select.FullName} شماره تلفن {select.PhoneNumber}";
                        Show.Add(text);
                        ListBox.ItemsSource = null;
                        ListBox.ItemsSource = Show;
                    }
                    else
                    {
                        MsgBox.Show("خطا", "این مخاطب در لیست انتخابی شما وجود دراد لطفا مخاطب دیگری را انتخاب نمائید",
                            MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                    }
                }

            }

        }
        bool Send(List<string> num, string text)
        {
            try
            {
                var phoneline = "2000500666";
                var phone = num;
                var message = text;
                KavenegarApi s =
                    new KavenegarApi(
                        "32646F6F31574E55537A757A48344E6755443067536F447267647A2F63643356704C5A474E7174687848553D");
                s.Send(phoneline, phone, message);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        private void Txt_number_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_number.Text == "")
            {
                DataGrid1.ItemsSource = null;
            }
            else
            {
                using (CustomerCrud crud = new CustomerCrud())
                {
                    DataGrid1.ItemsSource = crud.GetCustomerByText(txt_number.Text);
                }
            }
        }

        void Refresh()
        {
            txt_number.Text = "";
            txt_info.Document.Blocks.Clear();
            Numbers.Clear();
            Show.Clear();
            customers.Clear();
            ListBox.ItemsSource = null;
            DataGrid1.ItemsSource = null;
            txt_number.IsEnabled = true;
            DataGrid1.IsEnabled = true;
            txt_number.Focus();
        }
        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (customers.Count() > 0)
            {
                string richText = new TextRange(txt_info.Document.ContentStart, txt_info.Document.ContentEnd).Text;
                if (Send(Numbers, richText))
                {
                    MsgBox.Show("تائید", "پیام شما با موفقیت ارسال شد", MsgBox.TypeOs.Information,
                        MsgBox.Icons.Information);
                }
                else
                {
                    MsgBox.Show("خطا", "پیام شما ارسال نشد لطفا با اپراتور مربوطه تماس فرمائید", MsgBox.TypeOs.Error,
                        MsgBox.Icons.Error);
                }
            }
        }

        private void MessageWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        private void Txt_number_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Submit_OnMouseLeftButtonDown(sender);
            }
        }

        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void CheckBox1_OnChecked(object sender, RoutedEventArgs e)
        {
            txt_number.IsEnabled = false;
            DataGrid1.IsEnabled = false;
            customers.Clear();
            Numbers.Clear();
            Show.Clear();
            using (CustomerCrud crud=new CustomerCrud())
            {
                foreach (var item in crud.SelectAll())
                {
                    customers.Add(item);
                    Numbers.Add(item.PhoneNumber);
                    string text = $"نام کامل {item.FullName} شماره تلفن {item.PhoneNumber}";
                    Show.Add(text);
                }

                ListBox.ItemsSource = null;
                ListBox.ItemsSource = Show;
            }
        }

        private void CheckBox1_OnUnchecked(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Refresh();
        }

        private void Txt_number_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #region Shortcut

        public void LeaveMethod(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public void SubmitMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Btn_register_OnMouseLeftButtonDown(sender);
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
            MsgBox.Show("خطا", "شما در صفحه پنل پیامکی حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
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
