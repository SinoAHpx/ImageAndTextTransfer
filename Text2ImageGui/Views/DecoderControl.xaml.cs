using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Text2ImageGui.Core;

namespace Text2ImageGui.Views
{
    /// <summary>
    /// DecoderControl.xaml 的交互逻辑
    /// </summary>
    public partial class DecoderControl : UserControl
    {
        public DecoderControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 导入图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "图片文件|*.bmp",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                AddExtension = true,
            };

            dialog.ShowDialog();

            TextBoxImport.Text = dialog.FileName;
        }

        /// <summary>
        /// 导出文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "文本文件|*.txt|所有文件|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            dialog.ShowDialog();

            TextBoxExport.Text = dialog.FileName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dec = DecoderCore.Decode(new Bitmap(TextBoxImport.Text));
            TextBoxImport.Text = dec;
            File.WriteAllText(TextBoxExport.Text, dec);
            StatSnackBar.IsActive = true;
        }

        private void SnackbarMessage_OnActionClick(object sender, RoutedEventArgs e)
        {
            StatSnackBar.IsActive = false;
        }
    }
}