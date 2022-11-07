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
using System.Windows.Threading;
using Utility;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for MyClock.xaml
    /// </summary>
    public partial class MyClock : UserControl
    {
        public MyClock()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(Timer_tick);
            timer.Start();
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            ClockText.Text = DateTime.Now.ToShamsi();

        }
    }
}
