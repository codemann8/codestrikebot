using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStrikeBot
{
    public struct ID
    {
        public static ID none;

        public ID this[int childID]
        {
            get { return new ID((mID << 8) | (uint)childID); }
        }

        public ID super
        {
            get { return new ID(mID >> 8); }
        }

        public bool isa(ID super)
        {
            return (this != none) && ((this.super == super) || this.super.isa(super));
        }

        public static implicit operator ID(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new ID((uint)id);
        }

        public static bool operator ==(ID a, ID b)
        {
            return a.mID == b.mID;
        }

        public static bool operator !=(ID a, ID b)
        {
            return a.mID != b.mID;
        }

        public override bool Equals(object obj)
        {
            if (obj is ID)
                return ((ID)obj).mID == mID;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (int)mID;
        }

        private ID(uint id)
        {
            mID = id;
        }

        private readonly uint mID;
    }

    public abstract class ScreenState 
    {
        public ID CurrentArea;
        public List<ID> Overlays;

        public ScreenState()
        {
            this.Overlays = new List<ID>();
        }

        public override string ToString()
        {
            string ret = "<null>";
            if (CurrentArea != null)
            {
                ret = CurrentArea.ToString<Area>().Replace("CodeStrikeBot.Area.", "");

                if (this.Overlays.Count > 0)
                {
                    ret += "[";

                    foreach (ID overlay in this.Overlays)
                    {
                        if (overlay == Overlay.Widgets.AllianceHelp)
                        {
                            ret += "H";
                        }
                        else if (overlay == Overlay.Widgets.SecretGift)
                        {
                            ret += "S";
                        }
                        else if (overlay == Overlay.Widgets.GlobalGift)
                        {
                            ret += "L";
                        }
                        else if (overlay == Overlay.Widgets.AmmoFreeAttack)
                        {
                            ret += "F";
                        }
                        else if (overlay == Overlay.Widgets.AllianceGift)
                        {
                            ret += "G";
                        }
                        else if (overlay == Overlay.Widgets.DailyLogin)
                        {
                            ret += "D";
                        }
                        else if (overlay == Overlay.Widgets.MissionsAvailable)
                        {
                            ret += "M";
                        }
                        else if (overlay == Overlay.Widgets.BoostsActive)
                        {
                            ret += "O";
                        }
                        else if (overlay == Overlay.Widgets.Blog)
                        {
                            ret += "B";
                        }
                        else if (overlay == Overlay.Notification)
                        {
                            ret += "N";
                        }
                        else if (overlay == Overlay.Incomings.Attack || overlay == Overlay.Incomings.Rally || overlay == Overlay.Incomings.Scout)
                        {
                            ret += "A";
                        }
                        else if (overlay == Overlay.Incomings.Transport)
                        {
                            ret += "T";
                        }
                        else if (overlay == Overlay.Incomings.Reinforcement)
                        {
                            ret += "R";
                        }
                        else if (overlay == Overlay.Widgets.RewardsCrate)
                        {
                            //ret += "W";
                        }
                        else if (overlay == Overlay.Statuses.VIPInactive)
                        {
                            ret += "V";
                        }
                        else if (overlay == Overlay.Dialogs.Tiles.Empty
                            || overlay == Overlay.Dialogs.Tiles.Blocked
                            || overlay == Overlay.Dialogs.Tiles.RssOpen
                            || overlay == Overlay.Dialogs.Tiles.Rebel
                            || overlay == Overlay.Dialogs.Tiles.PlayerEnemy
                            || overlay == Overlay.Dialogs.Tiles.ControlPoint
                            || overlay == Overlay.Dialogs.Tiles.Warzone)
                        {
                            ret += "P";
                        }
                    }

                    ret += "]";
                }
            }

            return ret;
        }

        public static ushort GetScreenChecksum(SuperBitmap bmp, int x, int y, int size)
        {
            ushort ret;
            //Bitmap icon = new Bitmap(size, size);

            /*using (Graphics g = Graphics.FromImage(icon))
            {
                bool success = false;
                do
                {
                    try
                    {
                        g.DrawImage(bmp, 0, 0, new Rectangle(x, y, icon.Width, icon.Height), GraphicsUnit.Pixel);
                        success = true;
                    }
                    catch (InvalidOperationException e)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }
                while (!success);
            }*/

            //ret = icon.Checksum();

            ret = bmp.Checksum(x, y, size, size);

            //icon.Dispose();

            return ret;
        }

        protected abstract void GetGameArea(SuperBitmap bmp);

        protected abstract void GetGameOverlays(SuperBitmap bmp);

        public bool UpdateScreenState(SuperBitmap bmp)
        {
            bool success = true;

            try
            {
                if (bmp != null && bmp.Bitmap != null)
                {
                    //bmp.SetPixel(117, 7, Color.FromArgb(255,255,255));
                    if (true)
                    {
                        //bmp.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                    }

                    this.GetGameArea(bmp);

                    this.GetGameOverlays(bmp);
                }
            }
            catch (ArgumentException e)
            {
                success = false;
            }
            catch (InvalidOperationException e)
            {
                success = false;
            }

            return success;
        }

        public static bool BlackBoxExists(SuperBitmap bmp, Rectangle rect, Color color, int leftOmit = 0)
        {
            if (bmp != null)
            {
                Color c;
                bool foundPixelTop = false, foundPixelBottom = false, foundPixelLeft = false, foundPixelRight = false;

                for (int i = rect.X + leftOmit; i < rect.X + rect.Width; i++)
                {
                    //top row
                    c = bmp.GetPixel(i, rect.Y);

                    if (c.R > color.R || c.G > color.G || c.B > color.B)
                    {
                        return false;
                    }

                    //bottom row
                    /*c = bmp.GetPixel(i, rect.Y + rect.Height - 1);

                    if (c.R > color.R || c.G > color.G || c.B > color.B)
                    {
                        return false;
                    }*/

                    if (!foundPixelTop && rect.Y > 0)
                    {
                        //line before top row
                        c = bmp.GetPixel(i, rect.Y - 1);

                        if (c.R > color.R || c.G > color.G || c.B > color.B)
                        {
                            foundPixelTop = true;
                        }
                    }

                    if (!foundPixelBottom && rect.Y + rect.Height < bmp.Height)
                    {
                        //line after bottom row
                        c = bmp.GetPixel(i, rect.Y + rect.Height);

                        if (c.R > color.R || c.G > color.G || c.B > color.B)
                        {
                            foundPixelBottom = true;
                        }
                    }
                }

                //check left/right column
                for (int i = rect.Y; i < rect.Y + rect.Height; i++)
                {
                    //left column
                    c = bmp.GetPixel(rect.X + leftOmit, i);

                    if (c.R > color.R || c.G > color.G || c.B > color.B)
                    {
                        return false;
                    }

                    //right column
                    /*c = bmp.GetPixel(rect.X + rect.Width - 1, i);

                    if (c.R > color.R || c.G > color.G || c.B > color.B)
                    {
                        return false;
                    }*/

                    //line before left column
                    if (!foundPixelLeft && rect.X > 0)
                    {
                        c = bmp.GetPixel(rect.X - 1, i);

                        if (c.R > color.R || c.G > color.G || c.B > color.B)
                        {
                            foundPixelLeft = true;
                        }
                    }

                    //line after right column
                    if (!foundPixelRight && rect.X + rect.Width < bmp.Width)
                    {
                        c = bmp.GetPixel(rect.X + rect.Width, i);

                        if (c.R > color.R || c.G > color.G || c.B > color.B)
                        {
                            foundPixelRight = true;
                        }
                    }
                }

                return foundPixelTop || foundPixelBottom || foundPixelLeft || foundPixelRight;
            }

            return false;
        }
    }

    public sealed class Area
    {
        private Area() { }

        public static readonly ID MainBase = 1;
        public static class MainBases
        {
            public static readonly ID Main = MainBase[0];
            public static readonly ID SecretGiftCollect = MainBase[1];
            public static readonly ID GlobalGiftCollect = MainBase[2];
            public static readonly ID DailyLogin = MainBase[3];
            public static readonly ID DailyLoginClaimed = MainBase[4];
        }

        public static readonly ID StateMap = 2;
        public static class StateMaps
        {
            public static readonly ID Main = StateMap[0];
            public static readonly ID FullScreen = StateMap[1];
            public static readonly ID Coordinate = StateMap[2];
            public static readonly ID CoordinateError = StateMap[3];
        }

        public static readonly ID Menu = 3;
        public static class Menus
        {
            public static readonly ID More = Menu[0];
            public static readonly ID Mission = Menu[1];
            public static class Missions
            {
                public static readonly ID Base = Mission[0];
                public static readonly ID Daily = Mission[1];
                public static readonly ID Alliance = Mission[2];
                public static readonly ID VIP = Mission[3];
                public static readonly ID ActivateVIP = Mission[4];
                public static readonly ID VIPStreak = Mission[5];
            }
            public static readonly ID Items = Menu[2];
            public static readonly ID Alliance = Menu[3];
            public static readonly ID Mail = Menu[4];
            public static readonly ID Challenge = Menu[5];
            public static readonly ID Commander = Menu[6];
            public static readonly ID VIP = Menu[7];
            public static readonly ID Profile = Menu[8];
            public static readonly ID Bookmarks = Menu[9];
            public static readonly ID Building = Menu[10];
            public static class Buildings
            {
                public static readonly ID HQ = Building[0];
                public static readonly ID Wall = Building[1];
                public static readonly ID ShootingRange = Building[2];
                public static readonly ID Memorial = Building[3];
                public static readonly ID Radar = Building[4];
                public static readonly ID Warehouse = Building[5];
                public static readonly ID TradingPost = Building[6];
                public static readonly ID Armory = Building[7];
                public static readonly ID Research = Building[8];
                public static readonly ID HallOfHeroes = Building[9];
                public static readonly ID Hospital = Building[10];
                public static readonly ID TrainingGrounds = Building[11];
                public static readonly ID Bank = Building[12];
                public static readonly ID Embassy = Building[13];
                public static readonly ID WarRoom = Building[14];
                public static readonly ID Prison = Building[15];
                public static readonly ID DeathRow = Building[16];
                public static readonly ID Farm = Building[17];
                public static readonly ID OilWell = Building[18];
                public static readonly ID Quarry = Building[19];
                public static readonly ID IronMine = Building[20];
                public static readonly ID GoldMine = Building[21];
                public static readonly ID Vault = Building[22];
                public static readonly ID Monument = Building[23];
                public static readonly ID SpeedUpFactory = Building[24];
                public static readonly ID CombatLab = Building[25];
                public static readonly ID TroopAcademy = Building[26];
                public static readonly ID CovertOpsCenter = Building[27];
            }
            public static readonly ID BuildingList = Menu[11];
            public static readonly ID Boost = Menu[12];
            public static class Boosts
            {
                public static readonly ID PeaceShield = Boost[0];
                public static readonly ID AntiScout = Boost[1];
                public static readonly ID FakeForces = Boost[2];
                public static readonly ID CoinProduction = Boost[3];
                public static readonly ID FoodProduction = Boost[4];
                public static readonly ID OilProduction = Boost[5];
                public static readonly ID StoneProduction = Boost[6];
                public static readonly ID IronProduction = Boost[7];
                public static readonly ID UpkeepReduction = Boost[8];
                public static readonly ID Gathering = Boost[9];
                public static readonly ID Attack = Boost[10];
                public static readonly ID Health = Boost[11];
                public static readonly ID Defense = Boost[12];
                public static readonly ID AttackStimulant = Boost[13];
                public static readonly ID SetBonus = Boost[14];
                public static readonly ID DeploymentSize = Boost[15];
                public static readonly ID CommanderXP = Boost[16];
                public static readonly ID TrainingSpeed = Boost[17];
                public static readonly ID TroopQueue = Boost[18];
                public static readonly ID TrainingStimulant = Boost[19];
            }
            public static readonly ID Gifts = Menu[13];
            public static readonly ID AllianceHelp = Menu[14];
            public static readonly ID AllianceHelpLoading = Menu[15];
            public static readonly ID ShootingRange = Menu[16];
            public static class ShootingRanges
            {
                public static readonly ID Main = ShootingRange[0];
                public static readonly ID Lobby = ShootingRange[1];
                public static readonly ID NormalCrate = ShootingRange[2];
                public static readonly ID Crates = ShootingRange[3];
                //public static readonly ID UltimateCrate = ShootingRange[4];
            }
            public static readonly ID RewardCrate = Menu[20];
            public static readonly ID Account = Menu[21];
            public static readonly ID ResourceHelp = Menu[22];
            public static readonly ID Resources = Menu[23];
            public static readonly ID VIPSubscriptions = Menu[24];
            public static readonly ID MailCompose = Menu[25];
            public static readonly ID AllianceStore = Menu[26];
            public static readonly ID AllianceWar = Menu[27];
            public static readonly ID Gear = Menu[28];
            public static readonly ID Deployment = Menu[29];
            public static readonly ID BuildingBoost = Menu[30];
            public static readonly ID Casino = Menu[31];
        }

        public static readonly ID Emulator = 98;
        public static class Emulators
        {
            public static readonly ID Loading = Emulator[0];
            public static readonly ID Android = Emulator[1];
            public static readonly ID Crash = Emulator[2];
            public static readonly ID TaskManager = Emulator[3];
            public static readonly ID TaskManagerApp = Emulator[4];
            public static readonly ID TaskManagerRemove = Emulator[5];
        }

        public static readonly ID Other = 99;
        public static class Others
        {
            public static readonly ID Splash = Other[0];
            public static readonly ID Login = Other[1];
            public static readonly ID Ad = Other[2];
            public static readonly ID GetGold = Other[3];
            public static readonly ID Alliance = Other[4];
            public static readonly ID Mail = Other[5];
            public static readonly ID Chat = Other[6];
            public static readonly ID Quit = Other[7];
            public static readonly ID SessionTimeout = Other[8];
        }

        public static readonly ID Unknown = 254;
        public static readonly ID Null = 255;
    }

    public sealed class Overlay
    {
        private Overlay() { }

        public static readonly ID None = 1;

        public static readonly ID Notification = 2;
        public static class Notifications
        {
            public static readonly ID AllianceHelp = Notification[0];
            public static readonly ID War = Notification[1];
            public static readonly ID ItemUse = Notification[2];
            public static readonly ID Gift = Notification[3];
            public static readonly ID ItemReceived = Notification[4];
            public static readonly ID MissionComplete = Notification[5];
        }

        public static readonly ID Incoming = 3;
        public static class Incomings
        {
            public static readonly ID Attack = Incoming[0];
            public static readonly ID Transport = Incoming[1];
            public static readonly ID Reinforcement = Incoming[2];
            public static readonly ID Rally = Incoming[3];
            public static readonly ID Scout = Incoming[4];
        }

        public static readonly ID Challenge = 4;
        public static class Challenges
        {
            public static readonly ID State = Challenge[0];
            public static readonly ID Extreme = Challenge[1];
            public static readonly ID Alliance = Challenge[2];
            public static readonly ID Basic = Challenge[3];
        }

        public static readonly ID Widget = 5;
        public static class Widgets
        {
            public static readonly ID AllianceHelp = Widget[0];
            public static readonly ID Blog = Widget[1];
            public static readonly ID SecretGift = Widget[2];
            public static readonly ID GlobalGift = Widget[3];
            public static readonly ID RewardsCrate = Widget[4];
            public static readonly ID Challenge = Widget[5];
            public static readonly ID BoostsActive = Widget[6];
            public static readonly ID Deployments = Widget[7];
            public static readonly ID AllianceGift = Widget[8];
            public static readonly ID AmmoFreeAttack = Widget[9];
            public static readonly ID DailyLogin = Widget[10];
            public static readonly ID MissionsAvailable = Widget[11];
        }

        public static readonly ID ControlPoint = 6;
        public static class ControlPoints
        {
            public static readonly ID UnderAttack = ControlPoint[0];
            public static readonly ID NewControl = ControlPoint[1];
            public static readonly ID NewTitle = ControlPoint[2];
        }

        public static readonly ID Status = 7;
        public static class Statuses
        {
            public static readonly ID VIPInactive = Status[0];
        }

        public static readonly ID Dialog = 8;
        public static class Dialogs
        {
            public static readonly ID Tile = Dialog[0];
            public static class Tiles
            {
                public static readonly ID Empty = Tile[0];
                public static readonly ID Blocked = Tile[1];
                public static readonly ID RssOpen = Tile[2];
                public static readonly ID RssOccupied = Tile[3];
                public static readonly ID RebelOpen = Tile[4];
                public static readonly ID RebelOccupied = Tile[5];
                public static readonly ID Rebel = Tile[6];
                public static readonly ID PlayerFriend = Tile[7];
                public static readonly ID PlayerEnemy = Tile[8];
                public static readonly ID Warzone = Tile[9];
                public static readonly ID ControlPoint = Tile[10];
            }
        }
    }

    /*internal enum ScreenState : short
        {
            Coordinate = 0,
            CoordinateError = 1,
            WorldMap = 2,
            WorldFullScreen = 3,
            Unknown = 255
        }*/
}
