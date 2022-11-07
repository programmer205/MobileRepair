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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagementMobile.Msg
{
    /// <summary>
    /// Interaction logic for MyMsgBox.xaml
    /// </summary>
    public partial class MyMsgBox : Window
    {
        public MyMsgBox()
        {
            InitializeComponent();
        }

        private void Btn_Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Result = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        public System.Windows.Forms.DialogResult Result;
        private void Btn_Ok_OnClick(object sender, RoutedEventArgs e)
        {
            Result = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public void Btn_Cancel_OnKeyDown(object sender=null, KeyEventArgs e=null)
        {
            Result = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public void Btn_Ok_OnKeyDown(object sender=null, KeyEventArgs e=null)
        {
            Result = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public void Cancel()
        {
            Result = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public void Ok()
        {
            Result = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
