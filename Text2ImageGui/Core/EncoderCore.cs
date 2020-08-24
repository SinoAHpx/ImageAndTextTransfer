using System;
using System.Drawing;

namespace Text2ImageGui.Core
{
    public class EncoderCore
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Bitmap Encode(string text)
        {
            var length = text.Replace("\n", "").Length;
            var width = (int)Math.Ceiling(Math.Pow(length, 0.5));

            var im = new Bitmap(width, width);

            int x = 0, y = 0;
            foreach (var i in text)
            {
                var index = (int)i;
                int g = (index & 0xFF00) >> 8, b = index & 0xFF;
                im.SetPixel(x, y, Color.FromArgb(123, g, b));

                if (x == width - 1)
                {
                    x = 0;
                    if (y != width - 1)
                    {
                        y++;
                    }
                }
                else
                {
                    x++;
                }
            }

            return im;
        }
    }
}