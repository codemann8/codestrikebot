using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Drawing.Imaging;
using Tesseract;

namespace CodeStrikeBot
{
    public static class Utilities
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public extern static void CopyMemory(IntPtr dest, IntPtr src, uint length);

        public static int ChunkId2XCoordinate(int chunkId)
        {
            return chunkId / 256 * 16;
        }

        public static int ChunkId2YCoordinate(int chunkId)
        {
            return chunkId % 256 * 32;
        }

        public static int TileId2XCoordinate(int tileId)
        {
            return tileId % 16;
        }

        public static int TileId2YCoordinate(int tileId)
        {
            return (tileId / 16) * 2 + tileId % 2;
        }

        private static int ChunkTileId2XCoordinate(int chunkId, int tileId)
        {
            return ChunkId2XCoordinate(chunkId) + TileId2XCoordinate(tileId);
        }

        private static int ChunkTileId2YCoordinate(int chunkId, int tileId)
        {
            return ChunkId2YCoordinate(chunkId) + TileId2YCoordinate(tileId);
        }

        public static Point3D ProvinceChunkTile2Point3D(int provinceId, int chunkId, int tileId)
        {
            return new Point3D(ChunkTileId2XCoordinate(chunkId, tileId), ChunkTileId2YCoordinate(chunkId, tileId), provinceId);
        }

        public static int DistanceSquared(Point3D from, Point3D to)
        {
            int valueX = (int)from.X - (int)to.X, valueY = (int)from.Y - (int)to.Y;
            valueX *= valueX;
            valueY *= valueY;
            return valueX + valueY;
        }

        public static string FormatJSON(string json)
        {
            int indentLevel = 0, offset = 0;
            string insert = "";
            bool kvp = false;

            while (offset < json.Length)
            {
                switch (json[offset])
                {
                    case '{':
                    case '[':
                        indentLevel++;
                        insert = "\n" + new String(' ', indentLevel * 3);
                        json = json.Insert(offset + 1, insert);
                        offset += insert.Length;
                        kvp = false;
                        break;
                    case '}':
                    case ']':
                        indentLevel--;
                        insert = "\n" + new String(' ', indentLevel * 3);
                        json = json.Insert(offset, insert);
                        offset += insert.Length;
                        kvp = false;
                        break;
                    case ',':
                        insert = (kvp ? "\n" + new String(' ', indentLevel * 3) : " ");
                        json = json.Insert(offset + 1, insert);
                        offset += insert.Length;
                        kvp = false;
                        break;
                    case ':':
                        kvp = true;
                        break;
                }

                offset++;
            }

            return json;
        }

        public static Bitmap ChangePixelFormat(Bitmap bitmap, PixelFormat pixelFormat)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
            try
            {
                Bitmap convertedBitmap = new Bitmap(bitmap.Width, bitmap.Height, pixelFormat);
                BitmapData convertedBitmapData = convertedBitmap.LockBits(rect, ImageLockMode.WriteOnly, pixelFormat);
                try
                {
                    CopyMemory(convertedBitmapData.Scan0, bitmapData.Scan0, (uint)bitmapData.Stride * (uint)bitmapData.Height);
                }
                finally
                {
                    convertedBitmap.UnlockBits(convertedBitmapData);
                }

                return convertedBitmap;
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        public static string GetTextFromImage(SuperBitmap bmp, int x, int y, int w, int h)
        {
            using (Bitmap bmp2 = bmp.SubBitmap(x, y, w, h))
            {
                return GetTextFromImage(bmp2);
            }
        }

        public static string GetTextFromImage(Bitmap bmp)
        {
            using (TesseractEngine ocr = new TesseractEngine(@"./tessdata", "eng"))
            {
                using (Page page = ocr.Process(bmp))
                {
                    return page.GetText().Trim();
                }
            }
        }
    }
}
