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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogicLayer;
using ManagementMobile.Msg;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for ReminderOption.xaml
    /// </summary>
    public partial class ReminderOption : UserControl
    {
        public ReminderOption()
        {
            InitializeComponent();
        }

        public int Id;
        private void Btn_confirm_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ReminderCrud crud=new ReminderCrud();
            crud.Update(Id);
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Name == "Main")
                {
                    (item as MainWindow).clear();
                    (item as MainWindow).Refresh();
                }
            }
        }

        private void Btn_about_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MsgBox.Show("درباره", $"تاریخ یادآوری:\t{txt_tarikh.Text}\n \n توضیحات:\t{txt_ReminderInfo.Text}", MsgBox.TypeOs.Information,
                MsgBox.Icons.Information);
        }
    }
}
