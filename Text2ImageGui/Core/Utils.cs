using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Text2ImageGui.Core
{
    public static class Utils
    {
        public static void Display(this UserControl control, bool stat = true)
        {
            control.Visibility = stat ? Visibility.Visible : Visibility.Hidden;
        }

        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png); // 坑点：格式选Bmp时，不带透明度
            stream.Position = 0;
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            // According to MSDN, "The default OnDemand cache option retains access to the stream
            // until the image is needed." Force the bitmap to load right now so we can dispose the stream.
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.StreamSource = stream;
            result.EndInit();
            result.Freeze();
            return result;
        }
    }
}