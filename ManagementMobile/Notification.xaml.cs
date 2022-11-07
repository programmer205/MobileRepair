using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogicLayer;
using Entities;
using ManagementMobile.Msg;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        public Notification()
        {
            InitializeComponent();
        }

        private void Btn_cancel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            RepairCrud crud = new RepairCrud();
            crud.Delete(int.Parse(txt_id.Text));
            PhoneCrud cs = new PhoneCrud();
            var find = cs.Find(int.Parse(txt_phoneId.Text));
            find.Visit = false;
            cs.Edit(find);
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Name == "RepairWPF")
                {
                    (item as RepairWindow).Clear();
                    (item as RepairWindow).RefreshWindow();
                    (item as RepairWindow).DataGrid1.ItemsSource = null;
                    (item as RepairWindow).DataGrid1.ItemsSource = crud.Read();
                }
            }
        }

        private void Btn_confirm_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string price= MsgBox.ReturnPrice("تائید", "لطفا مبلغ نهایی را وارد نمائید");
            if (price != "")
            {
                RepairCrud crud = new RepairCrud();
                var find = crud.Find(int.Parse(txt_id.Text));
                find.EndDate = DateTime.Now;
                crud.Edit(find);
                PhoneCrud pc=new PhoneCrud();
                var findPhone = pc.Find(int.Parse(txt_phoneId.Text));
                findPhone.IsDone = true;
                findPhone.EndDate=DateTime.Now;
                findPhone.FinalPrice = double.Parse(price);
                if (pc.Edit(findPhone))
                {
                    MsgBox.Show("تائید", "عملیت با موفقیت انجام شد", MsgBox.TypeOs.Information,
                        MsgBox.Icons.Information);
                }
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.Name == "RepairWPF")
                    {
                        (item as RepairWindow).Clear();
                        (item as RepairWindow).RefreshWindow();
                        (item as RepairWindow).DataGrid1.ItemsSource = null;
                        (item as RepairWindow).DataGrid1.ItemsSource = crud.Read();
                    }
                }
            }

        }
    }
}
