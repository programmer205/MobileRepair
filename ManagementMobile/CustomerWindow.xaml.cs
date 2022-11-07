using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using ViewModels;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
            btn_leave.InputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            btn_submit.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
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
        public static RoutedCommand btn_leave = new RoutedCommand();
        public static RoutedCommand btn_submit = new RoutedCommand();
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
        private int IdForEdit = 0;
        void Show()
        {
            CustomerCrud crud=new CustomerCrud();
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = crud.GetAllCustomers();
            
        }

        void Refresh()
        {
            txt_name.Text = "";
            txt_phone.Text = "";
            register.Content = "ثبت اطلاعات";
            contacts.Text = "افزودن مشتری جدید";
            DataGrid1.ItemsSource = null;
            ed_btn.Visibility = Visibility.Hidden;
            dt_btn.Visibility = Visibility.Hidden;
            SearchBar.Text = "";
            txt_name.Focus();
        }
        private void CustomerWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IdForEdit != 0)
            {
                contacts.Text = "ویرایش اطلاعات مشتری";
                register.Content = "ویرایش";
                CustomerCrud crud = new CustomerCrud();
                var find = crud.Find(IdForEdit);
                txt_name.Text = find.FullName;
                txt_phone.Text = find.PhoneNumber;
            }
        }

        private void Register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            UserCrud uc = new UserCrud();
            if (uc.Access(LoginInWindow, "بخش مشتریان", 2))
            {
                if (txt_name.Text != "" && txt_phone.Text != "")
                {
                    if (IdForEdit == 0)
                    {
                        Customer cs = new Customer()
                        {
                            FullName = txt_name.Text,
                            PhoneNumber = txt_phone.Text,
                            RegDate = DateTime.Now
                        };
                        CustomerCrud crud = new CustomerCrud();
                        if (crud.Create(cs))
                        {
                            MsgBox.Show("تائید", "ثبت اطلاعات با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                MsgBox.Icons.Information);
                            Refresh();
                        }
                        else
                        {
                            MsgBox.Show("خطا", "مشکلی در ثبت اطلاعات پیش آمده است", MsgBox.TypeOs.Error,
                                MsgBox.Icons.Error);
                        }
                    }
                    else
                    {
                        Customer cs = new Customer()
                        {
                            CustomerId = IdForEdit,
                            FullName = txt_name.Text,
                            PhoneNumber = txt_phone.Text,
                            RegDate = DateTime.Now
                        };
                        CustomerCrud crud = new CustomerCrud();
                        if (crud.Edit(cs))
                        {
                            MsgBox.Show("تائید", "ویرایش اطلاعات با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                MsgBox.Icons.Information);
                            Refresh();
                        }
                        else
                        {
                            MsgBox.Show("خطا", "مشکلی در ویرایش اطلاعات پیش آمده است", MsgBox.TypeOs.Error,
                                MsgBox.Icons.Error);
                        }
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
                uc.Dispose();
            }
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Show();
        }

        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBar.Text == "")
            {
                DataGrid1.ItemsSource = null;
            }
            else
            {
                CustomerCrud crud=new CustomerCrud();
                DataGrid1.ItemsSource = crud.GetCustomerByName(SearchBar.Text);
            }
        }

        private void Dt_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش مشتریان", 4))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    CustomerViewModel cs = (CustomerViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.CustomerId;
                    CustomerCrud crud = new CustomerCrud();
                    if (MsgBox.Show("هشدار", "آیااز حذف مشتری مورد نظر مطمئن هستید؟", MsgBox.TypeOs.Delete, MsgBox.Icons.Warning) ==
                        System.Windows.Forms.DialogResult.OK)
                    {
                        crud.Delete(IdForEdit);
                        IdForEdit = 0;
                        Refresh();
                        txt_name.Focus();
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

        private void Ed_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش مشتریان", 3))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    CustomerViewModel cs = (CustomerViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.CustomerId;
                    CustomerWindow_OnLoaded(sender, e);
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


        private void DataGrid1_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ed_btn.Visibility = Visibility.Visible;
            dt_btn.Visibility = Visibility.Visible;
        }

        private void Txt_name_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_phone.Focus();
            }
        }

        private void Txt_phone_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Register_OnMouseLeftButtonDown(sender);
            }
        }

        private void CustomerWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        private void Txt_phone_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_name_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text.ToString(), @"\p{IsArabic}")
                && !string.IsNullOrWhiteSpace(e.Text.ToString()))
                e.Handled = true;
        }

        #region Shortcut

        public void LeaveMethod(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public void SubmitMethod(object sender, ExecutedRoutedEventArgs e)
        {
            Register_OnMouseLeftButtonDown(sender);
        }
        public void CustomerMethod(object sender, ExecutedRoutedEventArgs e)
        {
            MsgBox.Show("خطا", "شما در صفحه بخش مشتریان حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
        }
        public void ActivityMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخش فعالیت", 1))
                {
                    this.Close();
                    ActivityWindow aw = new ActivityWindow();
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
                    PhoneWindow pw=new PhoneWindow();
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
                    UserWindow uw=new UserWindow();
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
                    RepairWindow rw=new RepairWindow();
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
                    ReportWindow rw=new ReportWindow();
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
                    ReminderWindow rw=new ReminderWindow();
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
                    MessageWindow mw=new MessageWindow();
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
