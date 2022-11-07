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
using ViewModels;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for ActivityWindow.xaml
    /// </summary>
    public partial class ActivityWindow : Window
    {
        public ActivityWindow()
        {
            InitializeComponent();
            MyGrid.DataContext = this;
            ActivityCrud crud=new ActivityCrud();
            MyCustomers = crud.GetAllCustomers();
            MyUsers = crud.GetAllUsers();
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

        public List<string> MyCustomers { get; set; }
        public List<string> MyUsers { get; set; }
        public int IdForEdit = 0;
        private bool Status = false;
        public User LoginInWindow { get; set; }

        void Refresh()
        {
            contacts.Text = "افزودن فعالیت جدید";
            btn_register.Content = "ثبت اطلاعات";
            txt_customer.Text = "";
            txt_user.Text = "";
            txt_title.Text = "";
            txt_info.Document.Blocks.Clear();
            Tarikh.SelectedDate = null;
            CheckBox1.IsChecked = false;
            SearchBar.Text = "";
            DataGrid1.ItemsSource = null;
            dt_btn.Visibility = Visibility.Hidden;
            ed_btn.Visibility = Visibility.Hidden;
            txt_customer.Focus();
        }

        private void ActivityWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IdForEdit != 0)
            {
                contacts.Text = "ویرایش فعالیت";
                btn_register.Content = "ویراش اطلاعات";
                ActivityCrud crud = new ActivityCrud();
                var find = crud.Find(IdForEdit);
                UserCrud uc = new UserCrud();
                CustomerCrud cc = new CustomerCrud();
                txt_customer.Text = cc.Find(find.Customer_id).PhoneNumber;
                txt_user.Text = uc.Find(find.User_id).UserName;
                txt_title.Text = find.Title;
                txt_info.Document.Blocks.Clear();
                txt_info.Document.Blocks.Add(new Paragraph(new Run(find.Info)));
            }
        }


        private void CheckBox1_OnUnchecked(object sender, RoutedEventArgs e)
        {
            Label_Date.IsEnabled = false;
            Tarikh.IsEnabled = false;
        }

        private void CheckBox1_OnChecked(object sender, RoutedEventArgs e)
        {
            Label_Date.IsEnabled = true;
            Tarikh.IsEnabled = true;
        }

        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            try
            {
                if (txt_customer.Text != "" && txt_user.Text != "" && txt_title.Text != "")
                {
                    UserCrud uc = new UserCrud();
                    ActivityCrud crud = new ActivityCrud();
                    string richText = new TextRange(txt_info.Document.ContentStart, txt_info.Document.ContentEnd).Text;
                    if (uc.Access(LoginInWindow, "بخش فعالیت", 1))
                    {
                        if (IdForEdit == 0)
                        {
                            Activity activity = new Activity()
                            {
                                Title = txt_title.Text,
                                Info = richText,
                                User_id = crud.GetUserName(txt_user.Text),
                                Customer_id = crud.GetCustomerByPhone(txt_customer.Text),
                                RegDate = DateTime.Now
                            };
                            if (Status == false)
                            {
                                if (crud.Create(activity))
                                {
                                    MsgBox.Show("تائید", "ثبت فعالیت با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                        MsgBox.Icons.Information);
                                }
                                else
                                {
                                    MsgBox.Show("خطا", "مشکلی در ثبت اطلاعات پیش آمده است", MsgBox.TypeOs.Error,
                                        MsgBox.Icons.Error);
                                }
                            }

                            if (CheckBox1.IsChecked == false)
                            {
                                Refresh();
                            }

                            if (CheckBox1.IsChecked == true)
                            {
                                if (Tarikh.SelectedDate != null)
                                {
                                    ReminderCrud rd = new ReminderCrud();
                                    Reminder reminder = new Reminder()
                                    {
                                        ReminderTitle = txt_title.Text,
                                        ReminderInfo = richText,
                                        RegDate = DateTime.Now,
                                        RemindDate = Tarikh.SelectedDate.Value,
                                        User_Id = crud.GetUserName(txt_user.Text)
                                    };
                                    if (rd.Create(reminder))
                                    {
                                        MsgBox.Show("تائید", "ثبت یادآور با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                            MsgBox.Icons.Information);
                                        Status = false;
                                        Refresh();
                                    }
                                }
                                else
                                {
                                    MsgBox.Show("خطا", "لطفا تاریخ یادآوری را انتخاب نمائید", MsgBox.TypeOs.Error,
                                        MsgBox.Icons.Error);
                                    Status = true;
                                }
                            }

                        }
                        else
                        {

                            Activity activity = new Activity()
                            {
                                ActivityId = IdForEdit,
                                Customer_id = crud.GetCustomerByPhone(txt_customer.Text),
                                User_id = crud.GetUserName(txt_user.Text),
                                Title = txt_title.Text,
                                Info = richText,
                                RegDate = DateTime.Now,
                            };
                            if (Status == false)
                            {
                                Refresh();
                                if (crud.Edit(activity))
                                {
                                    MsgBox.Show("تائید", "ویرایش فعالیت با موفقیت انجام شد", MsgBox.TypeOs.Information,
                                        MsgBox.Icons.Information);
                                }
                                else
                                {
                                    MsgBox.Show("خطا", "مشکلی در ویرایش اطلاعات پیش آمده است", MsgBox.TypeOs.Error,
                                        MsgBox.Icons.Error);
                                }
                            }

                        }
                    }
                    else
                    {
                        MsgBox.Show("خطا", "شما اجازه ثبت  اطلاعات را ندارید", MsgBox.TypeOs.Error,
                            MsgBox.Icons.Error);
                        uc.Dispose();
                    }


                }
                else
                {
                    MsgBox.Show("خطا", "لطفا فیلد های خالی را پر نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
                }
            }
            catch (Exception exception)
            {
                MsgBox.Show("خطا", "کاربر یا مشتری با چنین مشخصاتی وجود ندارد", MsgBox.TypeOs.Error,
                    MsgBox.Icons.Error);
            }
        }

        void Show()
        {
            DataGrid1.ItemsSource = null;
            ActivityCrud crud=new ActivityCrud();
            DataGrid1.ItemsSource = crud.Read();
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
                ActivityCrud crud = new ActivityCrud();
                DataGrid1.ItemsSource = crud.ReadByName(SearchBar.Text);
            }
        }

        private void Dt_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش فعالیت", 4))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    ActivityViewModel cs = (ActivityViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.ActivityId;
                    ActivityCrud crud = new ActivityCrud();
                    if (MsgBox.Show("هشدار", "آیا از حذف فعالیت مورد نطر مطمئن هستید؟", MsgBox.TypeOs.Delete, MsgBox.Icons.Warning) ==
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

        private void Ed_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش فعالیت", 3))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    ActivityViewModel cs = (ActivityViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.ActivityId;
                    ActivityWindow_OnLoaded(sender, e);
                    uc.Dispose();
                    txt_customer.Focus();
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
            dt_btn.Visibility = Visibility.Visible;
            ed_btn.Visibility = Visibility.Visible;
        }

        private void Txt_customer_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_user.Focus();
            }
        }

        private void Txt_user_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_title.Focus();
            }
        }

        private void Txt_title_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_info.Focus();
            }
        }
        private void ActivityWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        private void Txt_info_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_register_OnMouseLeftButtonDown(sender);
            }
        }

        private void Txt_customer_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_user_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
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
            MsgBox.Show("خطا", "شما در صفحه بخش فعالیت ها حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
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
                    InvoiceWindow iw = new InvoiceWindow();
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
