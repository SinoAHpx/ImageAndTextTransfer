using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Text2ImageGui.Core;
using Image = System.Windows.Controls.Image;

namespace Text2ImageGui.Views
{
    /// <summary>
    /// EncoderControl.xaml 的交互逻辑
    /// </summary>
    public partial class EncoderControl : UserControl
    {
        public EncoderControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 导入文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "文本文件|*.txt|所有文件|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            dialog.ShowDialog();

            TextBoxImport.Text = File.ReadAllText(dialog.FileName);
        }

        /// <summary>
        /// 设置保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "图片文件|*.bmp",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                AddExtension = true,
            };

            dialog.ShowDialog();

            TextBoxExport.Text = dialog.FileName;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var bit = EncoderCore.Encode(TextBoxImport.Text);
            bit.Save(TextBoxExport.Text);
            StatSnackBar.IsActive = true;
            var image = new Image
            {
                Source = bit.ToBitmapImage(),
                ToolTip = "右击以关闭此弹窗",
                Stretch = Stretch.Uniform,
                Width = 400,
                Height = 400
            };
            await DialogHost.Show(image, (object o, DialogOpenedEventArgs a) =>
            {
                image.MouseRightButtonDown += (obj, args) => CloseDialog(a.Session);
            });
        }

        private void CloseDialog(DialogSession ds)
        {
            ds.Close();
        }

        private void SnackbarMessage_OnActionClick(object sender, RoutedEventArgs e)
        {
            StatSnackBar.IsActive = false;
        }
    }
}