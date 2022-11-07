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
using System.Windows.Threading;
using BusinessLogicLayer;
using Entities;

namespace ManagementMobile
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        DispatcherTimer Timer1 = new DispatcherTimer();
        DispatcherTimer Timer2 = new DispatcherTimer();
        UserCrud crud = new UserCrud();
        private void SplashScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 15);
            Timer1.Tick += Timer1_Tick;
            Timer1.Start();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ProgressBar.Value == 100)
            {
                Timer1.Stop();
                ProgressBar.Visibility = Visibility.Hidden;
                Label_Splash.Visibility = Visibility.Hidden;
                Label_Exit.Visibility = Visibility.Visible;
                LoginForm.Visibility = Visibility.Visible;
                Timer2.Interval = new TimeSpan(0, 0, 0, 0, 15);
                Timer2.Tick += Timer2_Tick;
                Timer2.Start();

            }

            if (ProgressBar.Value == 45)
            {
                var Count = crud.ReadAll().Select(n => n.Name).Count();
                DashboardCrud dc=new DashboardCrud();
                MyInformation information = dc.GetInfo();
                bool check = dc.Check();
                if (Count > 0 && check == true)
                {
                    LoginForm.Status = true;
                    LoginForm.ShowRemember = false;
                    LoginForm.Label_Restore.Visibility = Visibility.Visible;
                    LoginForm.ForgetPassword.Visibility = Visibility.Visible;
                    LoginForm.LabelRegister.Visibility = Visibility.Hidden;
                    LoginForm.txt_username.Text = information.UserName;
                    LoginForm.txt_pasword.Password = information.Password;
                }
                if (Count > 0&&check==false)
                {
                    LoginForm.Status = true;
                    LoginForm.Label_Restore.Visibility = Visibility.Visible;
                    LoginForm.ForgetPassword.Visibility = Visibility.Visible;
                    LoginForm.LabelRegister.Visibility = Visibility.Hidden;
                    LoginForm.ShowRemember = true;
                    LoginForm.Return(sender);
                }
                else
                {
                    LoginForm.Status = false;
                }
                ProgressBar.Value++;
            }
            else
            {
                ProgressBar.Value++;
            }
        }

        private int y = 630;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (LoginForm.Margin.Top >= 0)
            {
                y = y - 30;
                LoginForm.Margin = new Thickness(0, y, 0, 0);
            }
            else
            {
                Timer2.Stop();
            }
        }

        private void Label_Exit_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
