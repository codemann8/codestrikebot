using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;

namespace CodeStrikeBot
{
    static class Utilities
    {
        private static int ChunkTileId2XCoordinate(int chunkId, int tileId)
        {
            return chunkId / 256 * 16 + tileId % 16;
        }

        private static int ChunkTileId2YCoordinate(int chunkId, int tileId)
        {
            return chunkId % 256 * 32 + (tileId / 16) * 2 + tileId % 2;
        }

        public static Point3D ProvinceChunkTile2Point3D(int provinceId, int chunkId, int tileId)
        {
            return new Point3D(ChunkTileId2XCoordinate(chunkId, tileId), ChunkTileId2YCoordinate(chunkId, tileId), provinceId);
        }
    }
}
