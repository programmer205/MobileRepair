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
    /// Interaction logic for PhoneWindow.xaml
    /// </summary>
    public partial class PhoneWindow : Window
    {
        
        public PhoneWindow()
        {
            InitializeComponent();
            MyGrid.DataContext = this;
            CustomerCrud cd = new CustomerCrud();
            MyCustomers = cd.SelectAllName();
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

        private int IdForEdit = 0;
        public List<string> MyCustomers { get; set; }
        public User LoginInWindow { get; set; }

        private void PhoneWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IdForEdit != 0)
            {
                contacts.Text = "ویریش اطلاعات";
                PhoneCrud crud=new PhoneCrud();
                var find = crud.Find(IdForEdit);
                txt_number.Text = find.Customer.PhoneNumber;
                txt_model.Text = find.Model;
                txt_BarCode.Text = find.BarCode;
                txt_price.Text = find.ProposedPrice.ToString("N0");
                txt_Description.Document.Blocks.Clear();
                txt_Description.Document.Blocks.Add(new Paragraph(new Run(find.Description)));
                btn_Register.Content = "ویرایش";
            }
        }

        private void Btn_Register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "پذیرش جدید", 1))
            {
                if (txt_number.Text != "" && txt_model.Text != "" && txt_BarCode.Text != "" && txt_price.Text != "")
                {
                    string text = new TextRange(txt_Description.Document.ContentStart, txt_Description.Document.ContentEnd).Text;
                    ActivityCrud cd = new ActivityCrud();
                    int id = cd.GetCustomerByPhone(txt_number.Text);
                    if (IdForEdit == 0)
                    {
                        Phone phone = new Phone()
                        {
                            Model = txt_model.Text,
                            BarCode = txt_BarCode.Text,
                            RegDate = DateTime.Now,
                            Description = text,
                            CustomerId = id,
                            IsDone = false,
                            Visit = false,
                            IsPay = false,
                            ProposedPrice = double.Parse(txt_price.Text)
                        };
                        PhoneCrud crud = new PhoneCrud();
                        if (crud.Create(phone))
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
                        PhoneCrud crud = new PhoneCrud();
                        string number = crud.Find(IdForEdit).ReceptionNumber;
                        Phone phone = new Phone()
                        {
                            PhoneID = IdForEdit,
                            Model = txt_model.Text,
                            BarCode = txt_BarCode.Text,
                            RegDate = DateTime.Now,
                            Description = text,
                            CustomerId = id,
                            IsDone = false,
                            Visit = false,
                            IsPay = false,
                            ReceptionNumber = number,
                            ProposedPrice = double.Parse(txt_price.Text)
                        };
                        if (crud.Edit(phone))
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

        void Refresh()
        {
            contacts.Text = "پذیرش موبایل جدید";
            txt_number.Text = "";
            txt_BarCode.Text = "";
            txt_Description.Document.Blocks.Clear();
            txt_model.Text = "";
            btn_Register.Content = "ثبت اطلاعات";
            SearchBar.Text = "";
            txt_price.Text = "";
            DataGrid1.ItemsSource = null;
            txt_number.Focus();
        }

        void Show()
        {
            PhoneCrud crud=new PhoneCrud();
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = crud.Read();
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
                PhoneCrud crud=new PhoneCrud();
                DataGrid1.ItemsSource = crud.ReadByName(SearchBar.Text);
            }
        }

        private void DataGrid1_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dt_btn.Visibility = Visibility.Visible;
            ed_btn.Visibility = Visibility.Visible;
        }

        private void Dt_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "پذیرش جدید", 4))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    PhoneViewModel cs = (PhoneViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.PhoneID;
                    if (MsgBox.Show("هشدار", "آیا از حذف دستگاه تعمیری مورد نطر مطمئن هستید؟", MsgBox.TypeOs.Delete, MsgBox.Icons.Warning) ==
                        System.Windows.Forms.DialogResult.OK)
                    {
                        PhoneCrud crud = new PhoneCrud();
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
            if (uc.Access(LoginInWindow, "پذیرش جدید", 3))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    PhoneViewModel cs = (PhoneViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.PhoneID;
                    PhoneWindow_OnLoaded(sender, e);
                    uc.Dispose();
                    txt_number.Focus();
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

        private void Txt_number_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_model.Focus();
            }
        }

        private void Txt_model_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_Description.Focus();
            }
        }

        private void Txt_Description_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_BarCode.Focus();
            }
        }
        private void Txt_BarCode_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_price.Focus();
            }
        }
        private void Txt_price_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_Register_OnMouseLeftButtonDown(sender);
            }
        }

        private void PhoneWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        private void Txt_number_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_BarCode_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_price_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_model_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
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
            Btn_Register_OnMouseLeftButtonDown(sender);
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
            MsgBox.Show("خطا", "شما در صفحه پذیرش جدید دستگاه تعمیری حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);

        }
        public void InvoiceMethod(object sender, ExecutedRoutedEventArgs e)
        {
            using (UserCrud crud = new UserCrud())
            {
                if (crud.Access(LoginInWindow, "بخض فاکتورها", 1))
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
