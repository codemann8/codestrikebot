using System;
using System.Reflection;
using PacketDotNet;
using System.Drawing;
using System.Diagnostics;

namespace CodeStrikeBot
{
    public static class Extensions
    {
        public static ushort PayloadChecksum(this PacketDotNet.Packet packet)
        {
            return CRC16.ComputeChecksum(packet.PayloadData);
        }

        public static ushort Checksum(this SuperBitmap bitmap)
        {
            //return Checksum(bitmap, 0, 0, bitmap.Bitmap.Width, bitmap.Bitmap.Height);

            return CRC16.ComputeChecksum((byte[])(new ImageConverter()).ConvertTo(bitmap.Bitmap, typeof(byte[])));
        }

        public static ushort Checksum(this Bitmap bitmap, int x, int y, int w, int h)
        {

            byte[] bytes;
            Bitmap bmp = new Bitmap(w, h);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                bool success = false;
                do
                {
                    try
                    {
                        g.DrawImage(bitmap, 0, 0, new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
                        success = true;
                    }
                    catch (InvalidOperationException e)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }
                while (!success);
            }

            //ret = icon.Checksum();
            bytes = (byte[])(new ImageConverter()).ConvertTo(bmp, typeof(byte[]));
            bmp.Dispose();
            /*bytes = new byte[w * h * 2];
            for (int r = 0; r < h; r++)
            {
                System.Buffer.BlockCopy(bitmap.Bits, (y + r) * bitmap.Bitmap.Width * 2 + x * 2, bytes, r * w * 2, w * 2);
            }*/
            return CRC16.ComputeChecksum(bytes);

            //return CRC16.ComputeChecksum((byte[])(new ImageConverter()).ConvertTo(bmp, typeof(byte[])));
        }

        public static ushort Checksum(this Bitmap bitmap)
        {
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(bitmap, typeof(byte[]));

            return CRC16.ComputeChecksum(bytes);
        }

        public static byte[] ToByteArray(this Object obj)
        {
            byte[] ret;

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var ms = new System.IO.MemoryStream())
            {
                bf.Serialize(ms, obj);
                ret = ms.ToArray();
            }

            return ret;
        }

        public static string CommandLineArgs(this Process p, EmulatorType type)
        {
            string ret = "";
            string wmiQuery = String.Format("select CommandLine, ProcessId from Win32_Process where Name='{0}.exe' and ProcessId={1}", p.ProcessName, p.Id);
            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(wmiQuery);
            foreach (System.Management.ManagementObject retObject in searcher.Get())
            {
                ret = retObject["CommandLine"].ToString();
                if (type == EmulatorType.Nox)
                {
                    ret = ret.Replace("Nox", "C:\\Program Files (x86)\\Nox\\bin\\Nox.exe");
                }
            }

            return ret;
        }

        public static DateTime ToDateTime(this Int32 i)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(i);
        }
    }
}
