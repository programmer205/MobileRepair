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
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using ManagementMobile.Msg;
using ViewModels;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for ReminderWindow.xaml
    /// </summary>
    public partial class ReminderWindow : Window
    {
        public ReminderWindow()
        {
            InitializeComponent();
            MyGrid.DataContext = this;
            ReminderCrud crud = new ReminderCrud();
            MyUsers = crud.GetAllNames();
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

        public int IdForEdit;
        public List<string> MyUsers { get; set; }
        public User LoginInWindow { get; set; }

        private void ReminderWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IdForEdit != 0)
            {
                contacts.Text = "ویرایش اطلاعات";
                btn_register.Content = "ویرایش";
                ReminderCrud crud = new ReminderCrud();
                var find = crud.Find(IdForEdit);
                txt_user.Text = crud.back(IdForEdit);
                txt_title.Text = find.ReminderTitle;
                tarikh.SelectedDate = find.RemindDate;
                txt_info.Document.Blocks.Clear();
                txt_info.Document.Blocks.Add(new Paragraph(new Run(find.ReminderInfo)));
            }
        }

        private void Btn_register_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e=null)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش یادآورها", 1))
            {
                if (txt_user.Text != "" && txt_info.Document != null && txt_title.Text != "" && tarikh.Text != "")
                {
                    if (IdForEdit == 0)
                    {
                        ReminderCrud crud = new ReminderCrud();
                        string richText = new TextRange(txt_info.Document.ContentStart, txt_info.Document.ContentEnd).Text;
                        Reminder reminder = new Reminder()
                        {
                            ReminderTitle = txt_title.Text,
                            ReminderInfo = richText,
                            IsDone = false,
                            RegDate = DateTime.Now,
                            RemindDate = tarikh.SelectedDate.Value,
                            User_Id = crud.FindUserByName(txt_user.Text)
                        };
                        if (crud.Create(reminder))
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
                        string richText = new TextRange(txt_info.Document.ContentStart, txt_info.Document.ContentEnd).Text;
                        ReminderCrud crud = new ReminderCrud();
                        Reminder reminder = new Reminder()
                        {
                            ReminderId = IdForEdit,
                            ReminderTitle = txt_title.Text,
                            ReminderInfo = richText,
                            IsDone = false,
                            RegDate = DateTime.Now,
                            RemindDate = tarikh.SelectedDate.Value,
                            User_Id = crud.FindUserByName(txt_user.Text)
                        };
                        if (crud.Edit(reminder))
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
                    MsgBox.Show("خطا", "لطفا مقادیر خالی را پر نمائید", MsgBox.TypeOs.Error, MsgBox.Icons.Error);
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
            contacts.Text = "افزودن یادآوری جدید";
            txt_user.Text = "";
            txt_title.Text = "";
            txt_info.Document.Blocks.Clear();
            tarikh.Text = "";
            btn_register.Content = "ثبت اطلاعات";
            SearchBar.Text = "";
            DataGrid1.ItemsSource = null;
            dt_btn.Visibility = Visibility.Hidden;
            ed_btn.Visibility = Visibility.Hidden;
            txt_user.Focus();
        }

        void Show()
        {
            ReminderCrud crud=new ReminderCrud();
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = crud.Read();
        }
        private void Ex_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void DataGrid1_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            dt_btn.Visibility = Visibility.Visible;
            ed_btn.Visibility = Visibility.Visible;
        }

        private void Dt_btn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserCrud uc=new UserCrud();
            if (uc.Access(LoginInWindow, "بخش یادآورها", 4))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    ReminderViewModel cs = (ReminderViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.ReminderId;
                    ReminderCrud crud = new ReminderCrud();
                    if (MsgBox.Show("هشدار", "آیا از حذف یادآور مورد نطر مطمئن هستید؟", MsgBox.TypeOs.Delete, MsgBox.Icons.Warning) ==
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
            if (uc.Access(LoginInWindow, "بخش یادآورها", 3))
            {
                if (DataGrid1.SelectedItem != null)
                {
                    ReminderViewModel cs = (ReminderViewModel)(DataGrid1.SelectedItem);
                    IdForEdit = cs.ReminderId;
                    uc.Dispose();
                    ReminderWindow_OnLoaded(sender, e);
                    txt_user.Focus();
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

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Show();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBar.Text=="")
            {
                DataGrid1.ItemsSource = null;
            }
            else
            {
                ReminderCrud crud = new ReminderCrud();
                DataGrid1.ItemsSource = crud.ReadByName(SearchBar.Text);
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

        private void Txt_info_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tarikh.Focus();
                tarikh.SelectedDate=DateTime.Now;
            }
        }

        private void ReminderWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.Close();
            }
        }

        private void Txt_user_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { Convert.ToChar(e.Text) }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Tarikh_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_register_OnMouseLeftButtonDown(sender);
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
            MsgBox.Show("خطا", "شما در صفحه بخش یادآورها حضور دارید امکان درخواست باز شدن دوباره این صفحه نمی باشد",
                MsgBox.TypeOs.Error, MsgBox.Icons.Error);
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
