using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ManagementMobile.Msg
{
    public static class MsgBox
    {
        public enum TypeOs
        {
            Warning,
            Information,
            Error,
            Delete,
            Agree
        }

        public enum Icons
        {
            Warning,
            Information,
            Error
        }

        public static void KeyDownUs(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MyMsgBox ss = (MyMsgBox) (sender);
                ss.Cancel();
            }
        }

        public static void KeyDownOk(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MyMsgBox ss = (MyMsgBox)(sender);
                ss.Ok();
            }
        }

        public static DialogResult Show(string title, string info, TypeOs type, Icons icons)
        {
            string one = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).ToString();
            string three = System.IO.Directory.GetParent(one).ToString() + @"\Resources\";
            MyMsgBox ms = new MyMsgBox();
            ms.lbl_title.Content = title;
            ms.txt_info.Document.Blocks.Clear();
            ms.txt_info.Document.Blocks.Add(new Paragraph(new Run(info)));
            if (type == TypeOs.Warning)
            {
                SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(241, 135, 11));
                ms.my_border.BorderBrush = brush;
                ms.mygrid.Background = brush;
                ms.txt_info.Background = brush;
                ms.txt_info.BorderBrush = brush;
                ms.btn_Ok.Visibility = Visibility.Hidden;
                ms.btn_Cancel.Background = brush;
                ms.btn_Cancel.Content = "خروج";
                ms.KeyDown += KeyDownUs;
                ms.lbl_title.Background = brush;
            }

            if (type == TypeOs.Delete)
            {
                SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(241, 135, 11));
                ms.my_border.BorderBrush = brush;
                ms.mygrid.Background = brush;
                ms.txt_info.Background = brush;
                ms.txt_info.BorderBrush = brush;
                ms.btn_Ok.Background = brush;
                ms.btn_Cancel.Background = brush;
                ms.KeyDown += KeyDownOk;
                ms.lbl_title.Background = brush;
            }

            if (type == TypeOs.Information)
            {
                SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(118, 120, 237));
                ms.my_border.BorderBrush = brush;
                ms.mygrid.Background = brush;
                ms.txt_info.Background = brush;
                ms.txt_info.BorderBrush = brush;
                ms.btn_Ok.Visibility = Visibility.Hidden;
                ms.btn_Cancel.Background = brush;
                ms.btn_Cancel.Content = "خروج";
                ms.KeyDown += KeyDownUs;
                ms.lbl_title.Background = brush;
            }

            if (type == TypeOs.Agree)
            {
                SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(118, 120, 237));
                ms.my_border.BorderBrush = brush;
                ms.mygrid.Background = brush;
                ms.txt_info.Background = brush;
                ms.txt_info.BorderBrush = brush;
                ms.btn_Ok.Background = brush;
                ms.btn_Cancel.Background = brush;
                ms.KeyDown += KeyDownOk;
                ms.lbl_title.Background = brush;
            }

            if (type == TypeOs.Error)
            {
                SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(243, 91, 4));
                ms.my_border.BorderBrush = brush;
                ms.mygrid.Background = brush;
                ms.txt_info.Background = brush;
                ms.txt_info.BorderBrush = brush;
                ms.btn_Ok.Visibility = Visibility.Hidden;
                ms.btn_Cancel.Background = brush;
                ms.btn_Cancel.Content = "خروج";
                ms.KeyDown += KeyDownUs;
                ms.lbl_title.Background = brush;
            }

            if (icons == Icons.Warning)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(three+ @"\warning.png");
                bitmap.EndInit();
                ms.Image.Source = bitmap;
            }

            if (icons == Icons.Information)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(three+ @"\Info.png");
                bitmap.EndInit();
                ms.Image.Source = bitmap;
            }

            if (icons == Icons.Error)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(three+ @"\Error.png");
                bitmap.EndInit();
                ms.Image.Source = bitmap;
            }
            ms.ShowDialog();
            return ms.Result;
        }

        public static string ReturnValue(string title)
        {
            string one = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).ToString();
            string three = System.IO.Directory.GetParent(one).ToString() + @"\Resources\";
            MyMsgBox ms = new MyMsgBox();
            ms.lbl_title.Content = title;
            SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(118, 120, 237));
            ms.my_border.BorderBrush = brush;
            ms.mygrid.Background = brush;
            ms.txt_info.Visibility = Visibility.Hidden;
            ms.MyText.Visibility = Visibility.Visible;
            ms.btn_Ok.Visibility = Visibility.Hidden;
            ms.Label_return.Visibility = Visibility.Visible;
            ms.btn_Cancel.Background = brush;
            ms.btn_Cancel.Content = "تائید";
            ms.lbl_title.Background = brush;
            //---------------------------------------------------------------------------
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(three + @"\Info.png");
            bitmap.EndInit();
            ms.Image.Source = bitmap;


            ms.ShowDialog();
            return ms.MyText.Text;
        }

        public static string ReturnPrice(string title,string label)
        {
            string one = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).ToString();
            string three = System.IO.Directory.GetParent(one).ToString() + @"\Resources\";
            MyMsgBox ms = new MyMsgBox();
            ms.lbl_title.Content = title;
            SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(118, 120, 237));
            ms.my_border.BorderBrush = brush;
            ms.mygrid.Background = brush;
            ms.txt_info.Visibility = Visibility.Hidden;
            ms.MyText.Visibility = Visibility.Visible;
            ms.btn_Ok.Visibility = Visibility.Hidden;
            ms.Label_return.Content = label;
            ms.Label_return.Visibility = Visibility.Visible;
            ms.btn_Cancel.Background = brush;
            ms.btn_Cancel.Content = "تائید";
            ms.KeyDown += KeyDownOk;
            ms.lbl_title.Background = brush;
            //---------------------------------------------------------------------------
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(three + @"\Info.png");
            bitmap.EndInit();
            ms.Image.Source = bitmap;


            ms.ShowDialog();
            return ms.MyText.Text;
        }
    }
}
