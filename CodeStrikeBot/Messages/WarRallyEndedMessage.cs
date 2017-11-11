using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web.UI.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace CodeStrikeBot.Messages
{
    public class WarRallyEndedMessage : JsonMessage
    {
        public string war_key { get; set; }
        public int alliance_id { get; set; }
        public int war_id { get; set; }
        public int role { get; set; }
        public int state { get; set; }
        public int war { get; set; }
        public Objects.Rally.SharedCounts shared_counts { get; set; }

        public WarRallyEndedMessage(JsonMessage message)
            : base(message)
        {
            this.Id = message.Id;
            this.Type = MessageType.Rally;

            try
            {
                if (this.Json is JObject)
                {
                    foreach (KeyValuePair<string, JToken> war in (JObject)this.Json)
                    {
                        switch (war.Key)
                        {
                            case "war_key": this.war_key = war.Value.ToString(); break;
                            case "alliance_id": this.alliance_id = (int)war.Value; break;
                            case "war_id": this.war_id = (int)war.Value; break;
                            case "role": this.role = (int)war.Value; break;
                            case "state": this.state = (int)war.Value; break;
                            case "war": this.war = (int)war.Value; break;
                            case "shared_counts":
                                this.shared_counts = new Objects.Rally.SharedCounts();

                                foreach (KeyValuePair<string, JToken> kvp in (JObject)war.Value)
                                {
                                    switch (kvp.Key)
                                    {
                                        case "alliance_incoming_invites": this.shared_counts.AllianceIncomingInvites = (int)kvp.Value; break;
                                        case "alliance_war_attack": this.shared_counts.AllianceWarAttacks = (int)kvp.Value; break;
                                        case "alliance_war_defense": this.shared_counts.AllianceWarDefenses = (int)kvp.Value; break;
                                        case "alliance_ac_war_attack": this.shared_counts.AllianceACWarAttacks = (int)kvp.Value; break;
                                        case "alliance_ac_war_defense": this.shared_counts.AllianceACWarDefenses = (int)kvp.Value; break;
                                        case "alliance_group_war_attack": this.shared_counts.AllianceGroupWarAttacks = (int)kvp.Value; break;
                                        case "alliance_group_war_defense": this.shared_counts.AllianceGroupWarDefenses = (int)kvp.Value; break;
                                        default: this.Error = true; break;
                                    }
                                }
                                break;
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
    }
}
