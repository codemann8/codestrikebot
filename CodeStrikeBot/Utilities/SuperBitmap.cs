using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CodeStrikeBot
{
    public class SuperBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public UInt16[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public SuperBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new UInt16[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 2, PixelFormat.Format16bppRgb565, BitsHandle.AddrOfPinnedObject());
        }

        public Color GetPixel(int x, int y)
        {
            Color ret = new Color();
            bool success;
            int tries = 10;

            //do
            {
                //try
                {
                    int offset = y * Width + x;
                    if (offset < Bits.Length)
                    {
                        ushort value = Bits[offset];
                        int r = (0xf800 & value) >> 11,
                            g = (0x07e0 & value) >> 5,
                            b = 0x001f & value;
                        r = Convert.ToInt32(Math.Floor(255.999 * r / 0x1f));
                        g = Convert.ToInt32(Math.Floor(255.999 * g / 0x3f));
                        b = Convert.ToInt32(Math.Floor(255.999 * b / 0x1f));
                        return Color.FromArgb(r, g, b);
                    }
                    else
                    {
                        //TODO: log error?
                    }
                    //ret = Bitmap.GetPixel(x, y);
                    //success = true;
                }
                //catch (InvalidOperationException e)
                {
                    //tries--;
                    //success = false;
                    //BotDatabase.InsertLog(1, String.Format("{0} {1}", e.GetType(), e.Message), e.StackTrace, new byte[1] { 0x0 });
                    //System.Threading.Thread.Sleep(100);
                }
            }
            //while (!success && tries > 0);

            return ret;
        }

        public ushort Checksum(int x, int y, int w, int h)
        {
            Bitmap bmp = SubBitmap(x, y, w, h);

            //ret = icon.Checksum();
            byte [] bytes = (byte[])(new ImageConverter()).ConvertTo(bmp, typeof(byte[]));
            bmp.Dispose();
            /*bytes = new byte[w * h * 2];
            for (int r = 0; r < h; r++)
            {
                System.Buffer.BlockCopy(bitmap.Bits, (y + r) * bitmap.Bitmap.Width * 2 + x * 2, bytes, r * w * 2, w * 2);
            }*/
            return CRC16.ComputeChecksum(bytes);

            //return CRC16.ComputeChecksum((byte[])(new ImageConverter()).ConvertTo(bmp, typeof(byte[])));
        }

        public Bitmap SubBitmap(int x, int y, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                bool success = false;
                do
                {
                    try
                    {
                        g.DrawImage(this.Bitmap, 0, 0, new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
                        success = true;
                    }
                    catch (InvalidOperationException e)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }
                while (!success);
            }

            return bmp;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
