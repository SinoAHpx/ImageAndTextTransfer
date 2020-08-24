using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Text2ImageGui.Core;

namespace Text2ImageGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// 最小化窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// 页面跳转器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var tag = Convert.ToInt32(((Button)sender).Tag);
            switch (tag)
            {
                case 0:
                    HomeControl.Display();
                    EncoderControl.Display(false);
                    DecoderControl.Display(false);
                    break;

                case 1:
                    HomeControl.Display(false);
                    EncoderControl.Display();
                    DecoderControl.Display(false);
                    break;

                case 2:
                    HomeControl.Display(false);
                    EncoderControl.Display(false);
                    DecoderControl.Display();
                    break;
            }
        }
    }
}