using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;

namespace CodeStrikeBot
{
    public static class Utilities
    {
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
    }
}
