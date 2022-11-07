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
using ManagementMobile.Msg;
using Stimulsoft.Report;
using Utility;
using ViewModels;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow()
        {
            InitializeComponent();
            InvoiceCrud crud = new InvoiceCrud();
            MyGrid.DataContext = this;
            MyCustomers = crud.GetAllCustomers();
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
        public List<string> MyCustomers { get; set; }
        public List<Phone> Phones { get; set; }=new List<Phone>();
        private double Start_Price=0;
        private double Final_Price=0;
        public int CustomerId = 0;
        public int IdForEdit = 0;

        private void Submit_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            if (txt_customer.Text != "")
            {
                InvoiceCrud crud = new InvoiceCrud();
                var FindCustomer = crud.GetCustomerByPhone(txt_customer.Text);
                if (crud.GetPhones(FindCustomer.CustomerId).Count() > 0)
                {
                    CustomerId = FindCustomer.CustomerId;
                    Label_Name.Content = FindCustomer.FullName;
                    Label_Name.IsEnabled = false;
                    Label_Phone.Content = FindCustomer.PhoneNumber;
                    Label_Phone.IsEnabled = false;
                    Submit.IsEnabled = false;
                    txt_customer.IsEnabled = false;
                    foreach (var item in crud.GetPhones(FindCustomer.CustomerId))
                    {
                        Phones.Add(item);
                        InvoiceOption option = new InvoiceOption();
                        option.Visibility = Visibility.Visible;
                        option.txt_code.Text = item.ReceptionNumber;
                        option.txt_model.Text = item.Model;
                        option.txt_price.Text = item.FinalPrice.ToString();
                        Grid.SetRow(option, 1);
                        Grid.SetColumn(option, 2);
                        Grid.SetColumnSpan(option, 2);
                        StackPanel1.Children.Add(option);
                        Start_Price += item.FinalPrice.Value;
                        Final_Price += item.FinalPrice.Value;
                    }

                    btn_register.IsEnabled = true;
                    Label_StartPrice.Content = Start_Price.ToString();
                    Label_FinalPrice.Content = Start_Price.ToString();
                }
                else
                {
                    MsgBox.Show("خطا", "فاکتوری برای این مشتری صادر نشده است", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "لطفا شماره تلفن یا نام مشتری را در فیلد خالی وارد نمائید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
            }
        }

        void Show()
        {
            DataGrid1.ItemsSource = null;
            using (InvoiceCrud crud=new InvoiceCrud())
            {
                DataGrid1.ItemsSource = crud.Read();
            }
        }

        void Refresh()
        {
            txt_customer.IsEnabled = true;
            Submit.IsEnabled = true;
            txt_customer.Text = "";
            Label_Name.Content = "";
            Label_Phone.Content = "";
            Label_StartPrice.Content = "30000";
            Label_FinalPrice.Content = "30000";
            txt_Discount.Text = "";
            Start_Price = 0;
            Final_Price = 0;
            DataGrid1.ItemsSource = null;
            SearchBar.Text = "";
            dt_btn.Visibility = Visibility.Hidden;
            rp_btn.Visibility = Visibility.Hidden;
            btn_register.IsEnabled = false;
            StackPanel1.Children.Clear();
            txt_customer.Focus();
        }

        private void Txt_Discount_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_Discount.Text == "")
            {
                Label_FinalPrice.Content = Start_Price.ToString("N0");
            }
            else
            {
                Label_FinalPrice.Content = (Final_Price - double.Parse(txt_Discount.Text)).ToString("N0");

            }


        }

        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش فاکتورها", 1))
            {
                Invoice invoice = new Invoice()
                {
                    RegDate = DateTime.Now,
                    CheckOutDate = DateTime.Now,
                    FinalPrice = Label_FinalPrice.Content.ToString(),
                    Customer_id = CustomerId,
                    IsCheck = true,
                    UserId = LoginInWindow.UserId
                };
                InvoiceCrud crud = new InvoiceCrud();
                if (crud.Create(invoice, Phones))
                {
                    if (MsgBox.Show("اطلاعیه", "ثبت فاکتور با موفقیت انجام شد.آیا قصد چاپ فاکتور را دارید؟",
                            MsgBox.TypeOs.Agree,
                            MsgBox.Icons.Information) == System.Windows.Forms.DialogResult.OK)
                    {
                        InvoiceCrud ic = new InvoiceCrud();
                        StiReport sti = new StiReport();
                        var myCustomer = ic.GetCustomerById(CustomerId);
                        sti.Load(System.Windows.Forms.Application.StartupPath + "/Report.mrt");
                        sti.Dictionary.Variables["InvoiceNumber"].Value = ic.ReturnInvoiceNumber();
                        sti.Dictionary.Variables["Date"].Value = invoice.RegDate.Shamsi();
                        sti.Dictionary.Variables["CustomerName"].Value = myCustomer.FullName;
                        sti.Dictionary.Variables["PhoneNumber"].Value = myCustomer.PhoneNumber;
                        sti.Dictionary.Variables["EndPrice"].Value = Label_FinalPrice.Content.ToString();
                        sti.Dictionary.Variables["Discount"].Value = txt_Discount.Text;
                        sti.RegData("DT", ic.Report(CustomerId));
                        sti.ShowWithWpf();
                        using (PhoneCrud pc = new PhoneCrud())
                        {
                            pc.Change(CustomerId);
                        }
                        Refresh();
                    }
                }
                else
                {
                    MsgBox.Show("خطا", "ثبت فاکتور با موفقیت انجام نشد", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "شما اجازه ثبت فاکتور را ندارید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
                uc.Dispose();
            }
        }

        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Show();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBar.Text == "")
            {
                DataGrid1.ItemsSource = null;
            }
            else
            {
                using (InvoiceCrud crud=new InvoiceCrud())
                {
                    DataGrid1.ItemsSource = crud.ReadByName(SearchBar.Text);
                }
            }
        }

        private void DataGrid1_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dt_btn.Visibility = Visibility.Visible;
            rp_btn.Visibility = Visibility.Visible;
        }

        private void Dt_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش فاکتورها", 4))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    InvoiceViewModel cs = (InvoiceViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.InvoiceId;
                    InvoiceCrud crud = new InvoiceCrud();
                    if (MsgBox.Show("هشدار", "آیا از حذف فاکتور مورد نطر مطمئن هستید؟", MsgBox.TypeOs.Delete, MsgBox.Icons.Warning) ==
                        System.Windows.Forms.DialogResult.OK)
                    {
                        crud.Delete(IdForEdit);
                        IdForEdit = 0;
                        Refresh();
                    }
                }
                else
                {
                    MsgBox.Show("خطا", "لطفا یک آیتم را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "شما اجازه حذف اطلاعات را ندارید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
                uc.Dispose();
            }

        }

        private void Rp_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش فاکتورها", 1))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    InvoiceViewModel cs = (InvoiceViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.InvoiceId;
                    InvoiceCrud ic = new InvoiceCrud();
                    StiReport sti = new StiReport();
                    var myCustomer = ic.GetCustomerById(CustomerId);
                    sti.Load(System.Windows.Forms.Application.StartupPath + "/Report.mrt");
                    sti.Dictionary.Variables["InvoiceNumber"].Value = cs.InvoiceNumber;
                    sti.Dictionary.Variables["Date"].Value = cs.RegDate;
                    sti.Dictionary.Variables["CustomerName"].Value = cs.CustomerName;
                    sti.Dictionary.Variables["PhoneNumber"].Value = cs.PhoneNumber;
                    sti.Dictionary.Variables["EndPrice"].Value = cs.FinalPrice;
                    sti.RegData("DT", ic.PhonesUs(cs.InvoiceId));
                    sti.ShowWithWpf();

                }
                else
                {
                    MsgBox.Show("خطا", "لطفا یک آیتم را انتخاب نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            else
            {
                MsgBox.Show("خطا", "شما اجازه چاپ فاکتور را ندارید", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
                uc.Dispose();
            }
        }

        private void Txt_customer_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                Submit_OnMouseLeftButtonDown(sender);
            }
        }

        private void Txt_Discount_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_register_OnMouseLeftButtonDown(sender);
            }
        }

        private void InvoiceWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        private void Txt_Discount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
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
            Submit_OnMouseLeftButtonDown(sender);
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
            MsgBox.Show("خطا", "شما در صفحه بخش فاکتورها حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
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
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش تنظیمات", 1))
                {
                    this.Close();
                    SettingWindow mw=new SettingWindow();
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
        #endregion

        private void Txt_customer_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
