using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using MaterialDesignThemes.Wpf;

namespace Text2ImageGui.Views
{
    /// <summary>
    /// HomeControl.xaml 的交互逻辑
    /// </summary>
    public partial class HomeControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(((Control)sender).Tag.ToString());
        }

        /// <summary>
        /// 弹出赞赏码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var image = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Media/mmexport1598204863380.png")),
                ToolTip = "可以使用QQ/微信/支付宝，右击以关闭此弹窗",
            };
            await DialogHost.Show(image, (object o, DialogOpenedEventArgs a) =>
            {
                image.MouseRightButtonDown += (obj, args) => CloseDialog(a.Session);
            });
        }

        private void CloseDialog(DialogSession dc)
        {
            dc.Close();
        }
    }
}