using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class AllianceHelpRequestedMessage : JsonMessage
    {
        public string _event { get; set; }
        public string help_id { get; set; }
        public string help_name { get; set; }
        public Description description { get; set; }
        public int rank { get; set; }
        public int help_count { get; set; }
        public int help_category { get; set; }
        public int help_max { get; set; }

        public AllianceHelpRequestedMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.AllianceUpdate;

            try
            {
                if (this.Json is JObject)
                {
                    foreach (KeyValuePair<string, JToken> stat in (JObject)this.Json)
                    {
                        switch (stat.Key)
                        {
                            case "_event": this._event = stat.Value.ToString(); break;
                            case "help_id": this.help_id = stat.Value.ToString(); break;
                            case "help_name": this.help_name = stat.Value.ToString(); break;
                            case "description":
                                this.description = new Description();
                                foreach (KeyValuePair<string, JToken> desc in (JObject)stat.Value)
                                {
                                    switch (desc.Key)
                                    {
                                        case "key": this.description.key = desc.Value.ToString(); break;
                                        case "dict":
                                            this.description.dict = new Dict();
                                            foreach (KeyValuePair<string, JToken> dict in (JObject)desc.Value)
                                            {
                                                switch (dict.Key)
                                                {
                                                    case "level": this.description.dict.level = (int)dict.Value; break;
                                                    case "dict":
                                                        this.description.dict.building_name = new List<string>();
                                                        foreach (string name in (JArray)dict.Value)
                                                        {
                                                            this.description.dict.building_name.Add(name);
                                                        }
                                                        break;
                                                    default: this.Error = true; break;
                                                }
                                            }
                                            break;
                                        default: this.Error = true; break;
                                    }
                                }
                                break;
                            case "rank": this.rank = (int)stat.Value; break;
                            case "help_count": this.help_count = (int)stat.Value; break;
                            case "help_category": this.help_category = (int)stat.Value; break;
                            case "help_max": this.help_max = (int)stat.Value; break;
                            default: this.Error = true; break;
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                this.Error = true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this.Error = true;
            }
        }

        public class Dict
        {
            public int level { get; set; }
            public List<string> building_name { get; set; }
        }

        public class Description
        {
            public string key { get; set; }
            public Dict dict { get; set; }
        }
    }
}
