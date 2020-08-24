using System.Drawing;
using System.Text;

namespace Text2ImageGui.Core
{
    public class DecoderCore
    {
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="im"></param>
        /// <returns></returns>
        public static string Decode(Bitmap im)
        {
            var str = new StringBuilder();
            for (var y = 0; y < im.Width; y++)
            {
                for (var x = 0; x < im.Height; x++)
                {
                    var rgb = im.GetPixel(x, y);
                    if ((rgb.B | rgb.G | rgb.R) == 0)
                        break;

                    var index = (rgb.G << 8) + rgb.B;
                    str.Append((char)index);
                }
            }

            return str.ToString();
        }
    }
}