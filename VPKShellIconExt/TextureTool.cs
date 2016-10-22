using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace VPKShellIconExt
{
    public static class TextureTool
    {
        public static Bitmap GetBitmapFromStream(Stream stream)
        {
            Image image = Image.FromStream(stream);
            return new Bitmap(image);
        }

        public static Bitmap GetBitmapFromFile(string filename)
        {
            
            Image image = Image.FromFile(filename);
            return new Bitmap(image);
        }

        public static Bitmap ResizeTex(Bitmap input, Size size)
        {
            if (input != null)
            {
                Bitmap bm = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(input, 0, 0, size.Width, size.Height);
                    g.Dispose();
                }
                return bm;
            }
            else
            {
                return null;
            }
        }

        public static Bitmap MergeTex(Bitmap bg, Bitmap fg, Rectangle bgPosition, Rectangle fgPosition, int outWidth, int outHeight)
        {
            Bitmap bm = new Bitmap(outWidth, outHeight, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(bg, bgPosition);
                g.DrawImage(fg, fgPosition);
                g.Dispose();
                return bm;
            }
        }
    }
}

