using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStrikeBot.Messages.Data
{
    public class March
    {
        public string march_id { get; set; }
        public int user_id { get; set; }
        public int empire_id { get; set; }
        public int id { get; set; }
        public int city_id { get; set; }
        public int army_id { get; set; }
        public int home_id { get; set; }
        public int dest_province_id { get; set; }
        public int dest_chunk_id { get; set; }
        public int dest_tile_id { get; set; }
        public int from_province_id { get; set; }
        public int from_chunk_id { get; set; }
        public int from_tile_id { get; set; }
        public MarchState state { get; set; }
        public DateTime start_time { get; set; }
        public DateTime dest_time { get; set; }
        public MarchType type { get; set; }
        public int alliance_id { get; set; }
        public MarchEmoji emoji { get; set; }
        public DateTime emoji_starttime { get; set; }
        public string type_data { get; set; }
        public DateTime update_ts { get; set; }
        public int anim_attrib { get; set; }
        public int color { get; set; }
        public bool king { get; set; }
        public string dest_name { get; set; }
        public string from_name { get; set; }

        public March(string id)
        {
            march_id = id;
        }
    }

    public enum MarchState
    {
        Advancing,
        Unknown
    }

    public enum MarchType
    {
        Attack,
        Unknown
    }

    public enum MarchEmoji
    {
        Default
    }
}
