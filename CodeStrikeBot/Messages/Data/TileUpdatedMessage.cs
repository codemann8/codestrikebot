using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStrikeBot.Messages.Data
{
    public class TileUpdatedMessage
    {
        public List<Chunk> chunks { get; set; }
        public List<Empire> empires { get; set; }
        public List<Alliance> alliances { get; set; }
    }

    public class City
    {
        public int user_id { get; set; }
        public int empire_id { get; set; }
        public int city_id { get; set; }
        public int scout_cost { get; set; }
        public string city_name { get; set; }
        public int city_level { get; set; }
        public int last_state { get; set; }
        public int state_timestamp { get; set; }
        public int a_truce_ts { get; set; }
        public object title_id { get; set; }
        public object title_province_id { get; set; }
        public int is_mz_controlled { get; set; }
        public int defeat_emoji { get; set; }
        public int defeat_emoji_ts { get; set; }
        public int special_frame_id { get; set; }
        public string captured_heroes_total { get; set; }
    }

    public class Sixty
    {
        public int id { get; set; }
        public int overlay { get; set; }
        public int object_id { get; set; }
        public int last_updated { get; set; }
        public City city { get; set; }
    }

    public class Army
    {
        public int user_id { get; set; }
        public int empire_id { get; set; }
        public int city_id { get; set; }
        public int army_id { get; set; }
        public int scout_cost { get; set; }
        public int army_load { get; set; }
        public object title_id { get; set; }
    }

    public class FiftyEight
    {
        public int id { get; set; }
        public int overlay { get; set; }
        public int object_id { get; set; }
        public int last_updated { get; set; }
        public Army army { get; set; }
    }

    public class Tiles
    {
        public Sixty sixty { get; set; }
        public FiftyEight fiftyEight { get; set; }
    }

    public class Chunk
    {
        public int p_id { get; set; }
        public int c_id { get; set; }
        public Tiles tiles { get; set; }
    }

    public class Empire
    {
        public int user_id { get; set; }
        public int empire_id { get; set; }
        public int home_province_id { get; set; }
        public int home_province_ts { get; set; }
        public string empire_name { get; set; }
        public string empire_owner { get; set; }
        public int empire_portrait { get; set; }
        public int power { get; set; }
        public int alliance_id { get; set; }
        public int tkills { get; set; }
        public int alliance_rank { get; set; }
        public int vip_level { get; set; }
    }

    public class Alliance
    {
        public int alliance_id { get; set; }
        public string alliance_name { get; set; }
        public string alliance_tag { get; set; }
        public int alliance_open_recruitment { get; set; }
    }
}
