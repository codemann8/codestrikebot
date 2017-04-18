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

    public class ScreenState
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
                        else if (overlay == Overlay.Widgets.BlueCrate)
                        {
                            ret += "C";
                        }
                        else if (overlay == Overlay.Widgets.SilverCrate)
                        {
                            ret += "S";
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
                            ret += "L";
                        }
                        else if (overlay == Overlay.Widgets.MissionsAvailable)
                        {
                            ret += "M";
                        }
                        else if (overlay == Overlay.Widgets.Deployments)
                        {
                            ret += "D";
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

        public static void GetScreenState(Screen s)
        {
            ScreenState state = new ScreenState();

            int failure = 100;
            do
            {
                try
                {
                    state.CurrentArea = Area.Unknown;

                    if (s.SuperBitmap != null && s.SuperBitmap.Bitmap != null)
                    {
                        //bmp.SetPixel(117, 7, Color.FromArgb(255,255,255));
                        if (true)
                        {
                            //bmp.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                        }

                        ushort chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 160, 12, 20);
                        Color c, c2, c3;

                        switch (chksum)
                        {
                            case 0x633d:
                            case 0x13c0: //nox
                            case 0xc4eb: //nox new
                                state.CurrentArea = Area.Menus.Alliance;
                                break;
                            case 0x3956:
                            case 0x501e: //nox
                            case 0xbb5f: //nox new
                            case 0x8759: //now new modal
                                state.CurrentArea = Area.Menus.Gifts;
                                break;
                            case 0x3b42: //memu main menu
                            case 0x4c18: //memu store
                            case 0x1a87: //memu catalog
                                state.CurrentArea = Area.Menus.AllianceStore;
                                break;
                            case 0xc88e:
                            case 0x08eb: //nox
                            case 0xa240: //nox new
                                state.CurrentArea = Area.Menus.AllianceHelp;
                                break;
                            case 0x6f55: //"Unknown" glitch on Alliance Help
                                if (!s.Logout())
                                {
                                    if (!s.KillApp())
                                    {
                                        Controller.Instance.RestartEmulator(s);
                                    }
                                }
                                break;
                            case 0x26e5: //memu
                                state.CurrentArea = Area.Menus.AllianceWar;
                                break;
                            case 0x6ff2:
                                state.CurrentArea = Area.Menus.Challenge;
                                break;
                            case 0xfddf:
                                state.CurrentArea = Area.Menus.Deployment;
                                break;
                            case 0x4e34:
                            case 0xe9f1: //nox
                            case 0x24ba: //nox new
                                state.CurrentArea = Area.Menus.Boost;
                                break;
                            case 0x712b:
                            case 0x25c8: //nox
                            case 0x2498: //nox new
                                state.CurrentArea = Area.Menus.Boosts.PeaceShield;
                                break;
                            case 0x994f: //memu
                                state.CurrentArea = Area.Menus.Boosts.Attack;
                                break;
                            case 0x46b7: //memu
                                state.CurrentArea = Area.Menus.Boosts.Health;
                                break;
                            case 0xb253: //memu
                                state.CurrentArea = Area.Menus.Boosts.Defense;
                                break;
                            case 0xd58f:
                                state.CurrentArea = Area.Menus.Boosts.DeploymentSize;
                                break;
                            case 0xde1e:
                                state.CurrentArea = Area.Menus.Boosts.CommanderXP;
                                break;
                            case 0x7623:
                                state.CurrentArea = Area.Menus.Boosts.UpkeepReduction;
                                break;
                            case 0x6253:
                                state.CurrentArea = Area.Menus.Boosts.Gathering;
                                break;
                            case 0x456f:
                                state.CurrentArea = Area.Menus.Boosts.FakeForces;
                                break;
                            case 0x56e4:
                            case 0xbf74: //nox
                            case 0xf0cb: //nox new
                                state.CurrentArea = Area.Menus.Boosts.AntiScout;
                                break;
                            case 0x5c99:
                                state.CurrentArea = Area.Menus.Boosts.FoodProduction;
                                break;
                            case 0x8115:
                                state.CurrentArea = Area.Menus.Boosts.OilProduction;
                                break;
                            case 0xb74b:
                                state.CurrentArea = Area.Menus.Boosts.StoneProduction;
                                break;
                            case 0xfea6:
                                state.CurrentArea = Area.Menus.Boosts.IronProduction;
                                break;
                            case 0x506a:
                                state.CurrentArea = Area.Menus.Boosts.CoinProduction;
                                break;
                            case 0x0506:
                                state.CurrentArea = Area.Menus.Boosts.TroopQueue;
                                break;
                            case 0xc3ab:
                                state.CurrentArea = Area.Menus.Boosts.TrainingSpeed;
                                break;
                            case 0x6d81:
                                state.CurrentArea = Area.Menus.Boosts.TrainingStimulant;
                                break;
                            case 0xdd70: //memu
                                state.CurrentArea = Area.Menus.Boosts.SetBonus;
                                break;
                            case 0x9138:
                                state.CurrentArea = Area.Menus.Boosts.AttackStimulant;
                                break;
                            case 0x0d52:
                            case 0x775c: //nox
                            case 0xcbf5: //memu
                                state.CurrentArea = Area.Menus.Items;
                                break;
                            case 0x217e:
                            case 0xba89: //nox
                            case 0x750a: //nox new
                                state.CurrentArea = Area.Menus.Mission;
                                break;
                            case 0x2556: //Base Missions also fall here
                            case 0x54fe: //nox
                            case 0x5f4e: //nox new
                                state.CurrentArea = Area.Menus.Missions.Daily;
                                break;
                            case 0x753c:
                            case 0x6588: //nox
                            case 0x89f8: //nox new
                                state.CurrentArea = Area.Menus.Missions.Alliance;
                                break;
                            case 0x4262:
                            case 0x6074: //nox
                            case 0x7067: //nox new
                                state.CurrentArea = Area.Menus.Missions.VIP;
                                break;
                            case 0x996d:
                            case 0xa138: //nox
                            case 0x9ee3: //nox new
                                state.CurrentArea = Area.Menus.Missions.ActivateVIP;
                                break;
                            case 0x2670:
                            case 0xb55a: //nox
                            case 0xe02e: //nox new
                                state.CurrentArea = Area.Menus.Missions.VIPStreak;
                                break;
                            case 0x5d85:
                            case 0xc459: //nox
                            case 0xf52c: //nox new
                                state.CurrentArea = Area.Menus.Mail;
                                break;
                            case 0xb12c: //memu
                                state.CurrentArea = Area.Menus.MailCompose;
                                break;
                            case 0x2186:
                            case 0x653b: //nox
                            case 0xf278: //nox new
                                state.CurrentArea = Area.Menus.More;
                                break;
                            case 0xe814:
                            case 0xfa8f: //grayed out loading/modal dialog
                            case 0x255b: //nox
                            case 0xe2f4: //nox modal
                            case 0x3737: //now new
                            case 0x4f4a: //now modal new
                                state.CurrentArea = Area.Menus.Account;
                                break;
                            case 0x3561:
                            case 0x3ad6: //grayed out (confirmation/max limit)
                            case 0x055b: //nox
                            case 0x6229: //nox grayed out
                            case 0x8d70: //memu
                            case 0xc22d: //memu modal
                                state.CurrentArea = Area.Menus.ResourceHelp;
                                break;
                            case 0x6c9f: //nox
                            case 0x7ef5: //nox new
                                state.CurrentArea = Area.Menus.Resources;
                                break;
                            case 0x4e3e: //memu
                                state.CurrentArea = Area.Menus.Commander;
                                break;
                            case 0xf40e: //memu weapon
                            case 0x29d0: //memu helmet
                            case 0xfc5a: //memu armor
                            case 0x466d: //memu footwear
                            case 0x0e0b: //memu accessory
                                state.CurrentArea = Area.Menus.Gear;
                                break;
                            case 0x7b13:
                            case 0x0359: //nox
                            case 0xb69b: //nox new
                                state.CurrentArea = Area.Menus.VIP;
                                break;
                            case 0x8f1e: //nox new		
                                state.CurrentArea = Area.Menus.VIPSubscriptions;		
                                break;
                            case 0x6eae:
                            case 0x8993: //nox
                            case 0xa5f9: //nox new
                                state.CurrentArea = Area.Menus.ShootingRanges.Lobby;
                                break;
                            case 0x1cea:
                            case 0x0a36: //nox
                            case 0x68e7: //nox Special Winter Shooting Range modal
                            case 0x3554: //nox Special Winter Shooting Range
                            case 0xc192: //memu Special Valentine's Day Shooting Range modal
                            case 0x3a76: //memu Special Valentine's Day Shooting Range
                                chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 300, 70, 10);
                                if (chksum == 0xd714)
                                {
                                    state.CurrentArea = Area.Menus.ShootingRanges.Crates;
                                }
                                else
                                {
                                    state.CurrentArea = Area.Menus.ShootingRanges.Main;
                                }
                                break;
                            case 0x7fab:
                            case 0xf3f8: //nox
                            case 0x969e: //nox new
                                state.CurrentArea = Area.Menus.ShootingRanges.NormalCrate;
                                break;
                            case 0x87db:
                            case 0xf551:
                            case 0x9a77: //nox
                            case 0xed12: //nox new
                                state.CurrentArea = Area.Menus.RewardCrate;
                                break;
                            case 0xfab0:
                            case 0xee9d:
                                chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 110, 440, 20);
                                switch (chksum)
                                {
                                    case 0x8e17: //Leap?
                                    case 0xd04b: //MEmu
                                        state.CurrentArea = Area.Emulators.Android;
                                        break;
                                    case 0xb47c:
                                        state.CurrentArea = Area.Emulators.TaskManagerApp;
                                        break;
                                    case 0xfcff:
                                        state.CurrentArea = Area.Emulators.TaskManagerRemove;
                                        break;
                                    case 0xa115:
                                        state.CurrentArea = Area.Emulators.TaskManager;
                                        break;
                                    case 0xfab0:
                                        chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 190, 150, 20);
                                        //if (chksum == 0xa265)
                                        if (chksum == 0xf81a || chksum == 0x3dd6) //nox and nox new
                                        {
                                            state.CurrentArea = Area.Others.SessionTimeout;
                                        }
                                        else
                                        {
                                            state.CurrentArea = Area.Emulators.Crash;
                                        }
                                        break;
                                }
                                break;
                            case 0xac21:
                            case 0x99c8: //nox
                                state.CurrentArea = Area.Emulators.Android;
                                break;
                            case 0xa43d:
                            case 0xd521: //memu
                                state.CurrentArea = Area.Emulators.Loading;
                                break;
                            case 0x59b7:
                            case 0xe2f3: //arnold
                            case 0xb951: //halloween arnold
                                //case 0x9e4f:  //depricated?
                                state.CurrentArea = Area.Others.Splash;
                                break;
                            case 0x60b3: //memu
                            case 0xa5a8: //memu loading
                            case 0xb1d0: //memu modal
                                state.CurrentArea = Area.Others.Login;
                                break;
                            case 0x0f50: //memu
                                state.CurrentArea = Area.Menus.BuildingList;
                                break;
                            case 0x4491: //memu
                                state.CurrentArea = Area.Menus.Buildings.HQ;
                                break;
                            case 0xfdea: //memu
                                state.CurrentArea = Area.Menus.Buildings.Wall;
                                break;
                            case 0x0aa6: //memu
                                state.CurrentArea = Area.Menus.Buildings.Memorial;
                                break;
                            case 0x4bf0: //memu
                                state.CurrentArea = Area.Menus.Buildings.Warehouse;
                                break;
                            case 0xe7c6: //memu
                                state.CurrentArea = Area.Menus.Buildings.Radar;
                                break;
                            case 0x96c1: //memu
                                state.CurrentArea = Area.Menus.Buildings.TradingPost;
                                break;
                            case 0xc5e2: //memu
                                state.CurrentArea = Area.Menus.Buildings.HallOfHeroes;
                                break;
                            case 0xdf29: //memu
                                state.CurrentArea = Area.Menus.Buildings.Hospital;
                                break;
                            case 0x0316: //memu
                                state.CurrentArea = Area.Menus.Buildings.TrainingGrounds;
                                break;
                            case 0xe980: //memu
                                state.CurrentArea = Area.Menus.Buildings.Bank;
                                break;
                            case 0xe810: //memu research
                            case 0x2671: //memu economics
                            case 0xe157: //memu combat
                            case 0x3f17: //memu traps
                            case 0x4d3e: //memu commander
                            case 0x618e: //memu adv combat
                            case 0x09d1: //memu adv traps
                            case 0x8ce4: //memu manufacturing
                            case 0x2b70: //memu battle tactics
                            case 0x9d3c: //memu set bonus
                            case 0x2b6d: //memu mod set bonus
                            case 0xf8a7: //memu building development
                            case 0xcb06: //memu mercenary combat
                            case 0xcf59: //memu augments
                                state.CurrentArea = Area.Menus.Buildings.Research;
                                break;
                            case 0xc1fe: //memu
                                state.CurrentArea = Area.Menus.Buildings.Embassy;
                                break;
                            case 0xf4d6: //memu
                                state.CurrentArea = Area.Menus.Buildings.WarRoom;
                                break;
                            case 0x36a2: //memu
                                state.CurrentArea = Area.Menus.Buildings.Prison;
                                break;
                            case 0x8b1e: //memu
                                state.CurrentArea = Area.Menus.Buildings.DeathRow;
                                break;
                            case 0x3c43: //memu
                                state.CurrentArea = Area.Menus.Buildings.Farm;
                                break;
                            case 0x9046: //memu
                                state.CurrentArea = Area.Menus.Buildings.Quarry;
                                break;
                            case 0x007e: //memu
                                state.CurrentArea = Area.Menus.Buildings.IronMine;
                                break;
                            case 0x582a: //memu
                                state.CurrentArea = Area.Menus.Buildings.OilWell;
                                break;
                            case 0x39bb: //memu
                                state.CurrentArea = Area.Menus.Buildings.Vault;
                                break;
                            case 0xfcbb: //memu
                                state.CurrentArea = Area.Menus.Buildings.Monument;
                                break;
                            case 0x8b9e: //memu
                                state.CurrentArea = Area.Menus.Buildings.SpeedUpFactory;
                                break;
                            case 0x7d41: //memu
                                state.CurrentArea = Area.Menus.Buildings.CombatLab;
                                break;
                            case 0xcb14: //memu
                                state.CurrentArea = Area.Menus.Buildings.TroopAcademy;
                                break;
                            case 0x6e5b: //memu
                                state.CurrentArea = Area.Menus.Buildings.CovertOpsCenter;
                                break;
                            case 0x30ac:
                                state.CurrentArea = Area.Menus.BuildingBoost;
                                break;
                            case 0x9be4: //memu alliance chat
                            case 0x9d42: //memu state/alliance transition
                            case 0x658b: //memu state chat
                            case 0x1cbd: //memu custom chat
                            case 0x0169: //memu contact list
                                state.CurrentArea = Area.Others.Chat;
                                break;
                            case 0x3436:
                            case 0x6716: //memu get gold
                                state.CurrentArea = Area.Others.Ad;
                                break;
                            default:
                                ushort chksum2 = ScreenState.GetScreenChecksum(s.SuperBitmap, 267, 20, 20);

                                switch (chksum2)
                                {
                                    case 0xf958:
                                    case 0x2f05: //nox new
                                        state.CurrentArea = Area.MainBases.Main;
                                        break;
                                    case 0x3ef3: //main base with modal dialog
                                    case 0x7d45: //nox new
                                        chksum2 = ScreenState.GetScreenChecksum(s.SuperBitmap, 145, 125, 20);
                                        switch (chksum2)
                                        {
                                            case 0xb69d: //Free Daily Bonus
                                            case 0x32c5: //Daily Bonus Club
                                            case 0xf84f: //nox Free Daily Bonus
                                                c = s.SuperBitmap.GetPixel(100, 430);
                                                if (c.Equals(41, 93, 115))
                                                {
                                                    state.CurrentArea = Area.MainBases.DailyLogin;
                                                }
                                                else if (c.Equals(115, 121, 123))
                                                {
                                                    state.CurrentArea = Area.MainBases.DailyLoginClaimed;
                                                }
                                                break;
                                            case 0x68a6: //Daily Bonus Club: Elite Pack
                                            case 0xa0fb:
                                                state.CurrentArea = Area.MainBases.DailyLoginClaimed;
                                                break;
                                            case 0xa377: //"Congratulations"
                                            case 0x76a1: //"Supply Crate"
                                            case 0x57d2: //nox congrats
                                                state.CurrentArea = Area.MainBases.BlueCrateCollect;
                                                break;
                                            case 0xc5ca:
                                            case 0x220f: //nox
                                                state.CurrentArea = Area.MainBases.SilverCrateCollect;
                                                break;
                                            default:
                                                chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 180, 190, 10);
                                                if (chksum == 0x4c29)// || chksum == 0x0a22)
                                                {
                                                    state.CurrentArea = Area.Others.Quit;
                                                }
                                                else if (chksum == 0xad22)
                                                {
                                                    //some kind of small message with blue button, like errors
                                                    //state.CurrentArea = Area.Others.Quit;
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        s.SuperBitmap.Bitmap.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                                                    }
                                                    catch (System.Runtime.InteropServices.ExternalException e) { }
                                                }
                                                break;
                                        }
                                        break;
                                    default:
                                        c = s.SuperBitmap.GetPixel(112, 17);
                                        c2 = s.SuperBitmap.GetPixel(285, 28);
                                        if (c.Equals(41, 113, 156))
                                        {
                                            //world map
                                            c = s.SuperBitmap.GetPixel(372, 12);

                                            if (c.R > 30 && c.G > 30 && c.B > 35)
                                            {
                                                state.CurrentArea = Area.StateMaps.FullScreen;
                                            }
                                            else
                                            {
                                                state.CurrentArea = Area.StateMaps.Main;
                                            }
                                        }
                                        else if (c.Equals(16, 44, 57))
                                        {		
                                            //world map modal		
                                            chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 180, 190, 10);		
                                            if (chksum == 0x4c29)		
                                            {		
                                                state.CurrentArea = Area.Others.Quit;		
                                            }		
                                            else		
                                            {		
                                                c = s.SuperBitmap.GetPixel(178, 183);		
		
                                                if (c.Equals(239, 239, 239) || c.Equals(247, 255, 255))		
                                                {		
                                                    //world map coordinate		
                                                    c = s.SuperBitmap.GetPixel(269, 265);		
		
                                                    if (c.R > 5 && c.G > 40 && c.B > 50)		
                                                    {		
                                                        state.CurrentArea = Area.StateMaps.Coordinate;		
                                                    }		
                                                    else		
                                                    {		
                                                        state.CurrentArea = Area.StateMaps.CoordinateError;		
                                                    }		
                                                }		
                                            }		
                                        }
                                        else
                                        {
                                            c = s.SuperBitmap.GetPixel(178, 183);

                                            if (c.Equals(239, 239, 239) || c.Equals(247, 255, 255))
                                            {
                                                //world map coordinate
                                                c = s.SuperBitmap.GetPixel(269, 265);

                                                if (c.R > 5 && c.G > 40 && c.B > 50)
                                                {
                                                    state.CurrentArea = Area.StateMaps.Coordinate;
                                                }
                                                else
                                                {
                                                    state.CurrentArea = Area.StateMaps.CoordinateError;
                                                }
                                            }
                                            else
                                            {
                                                c = s.SuperBitmap.GetPixel(20, 20);

                                                if (!c.Equals(140, 211, 239))
                                                {
                                                    c = s.SuperBitmap.GetPixel(50, 350);
                                                    c2 = s.SuperBitmap.GetPixel(325, 550);
                                                    c3 = s.SuperBitmap.GetPixel(200, 500);
                                                    if (!c.Equals(0, 0, 0) || !c2.Equals(0, 0, 0))
                                                    {
                                                        c = s.SuperBitmap.GetPixel(378, 20);
                                                        c2 = s.SuperBitmap.GetPixel(135, 665);
                                                        c3 = s.SuperBitmap.GetPixel(135, 535);
                                                        if ((c.Equals(239, 239, 239) && (c2.Equals(222, 130, 0) || c2.Equals(33, 158, 90)))
                                                            || (c.Equals(247, 247, 247) && c3.Equals(222, 130, 0))
                                                            || c.Equals(239, 235, 231)) //&& c3.Equals(222, 130, 0)))
                                                        {
                                                            state.CurrentArea = Area.Others.Ad;
                                                        }
                                                        else
                                                        {
                                                            c = c;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    c = c;
                                                }
                                            }
                                        }
                                        break;
                                }
                                break;
                        }

                        if (state.CurrentArea == Area.Unknown)
                        {
                            chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 160, 12, 20);
                            s.SuperBitmap.Bitmap.Save(String.Format("{0}\\unknown{1}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);
                            
                            if (state.CurrentArea == Area.Menu)
                            {
                                s.SuperBitmap.Bitmap.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                            }
                            state = state;
                        }

                        state.Overlays.Clear();

                        //Overlays
                        if (state.CurrentArea == Area.MainBases.Main)
                        {
                            chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 345, 500, 20);

                            //if (chksum == 0xb877) //depricated?
                            if (chksum == 0xe925)
                            {
                                state.Overlays.Add(Overlay.Widgets.AllianceHelp);
                            }

                            chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 373, 348, 10);
                            //if (chksum != 0xe8ae && chksum != 0x6bb1) ///depricated?
                            if (chksum == 0x0060)
                            {
                                //c = bmp.GetPixel(44, 395);
                                //if (!c.Equals(165, 121, 24))
                                c = s.SuperBitmap.GetPixel(372, 345);
                                if (!c.Equals(198, 150, 33))
                                {
                                    state.Overlays.Add(Overlay.Widgets.DailyLogin);
                                }
                            }

                            c = s.SuperBitmap.GetPixel(35, 498);
                            c2 = s.SuperBitmap.GetPixel(29, 498);
                            //Rectangle(4, 489, 63, 18)
                            //if (Math.Abs(c.R - c.G) <= 11 && (c.Within(157, 156, 155, 28) || c2.Within(165, 162, 156, 28)) && 
                            if (ScreenState.BlackBoxExists(s.SuperBitmap, new Rectangle(253, 562, 63, 18), Color.FromArgb(74, 77, 74), 10))
                            {
                                state.Overlays.Add(Overlay.Widgets.SilverCrate);
                            }

                            chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 275, 532, 10);
                            if (chksum != 0x41fa && !ScreenState.BlackBoxExists(s.SuperBitmap, new Rectangle(253, 562, 63, 18), Color.FromArgb(74, 77, 74)))
                            {
                                int n = 0;
                                for (int i = 514; i <= 544; i++)
                                {
                                    c = s.SuperBitmap.GetPixel(278, i);
                                    if (c.Within(49, 83, 155, 50))
                                    {
                                        n++;
                                    }
                                }
                                if (n > 6)
                                {
                                    n = 0;
                                    for (int i = 514; i <= 544; i++)
                                    {
                                        c = s.SuperBitmap.GetPixel(298, i);
                                        if (c.Within(49, 83, 155, 50))
                                        {
                                            n++;
                                        }
                                    }

                                    if (n > 6)
                                    {
                                        n = 0;
                                        for (int i = 514; i <= 544; i++)
                                        {
                                            c = s.SuperBitmap.GetPixel(286, i);
                                            if (Math.Abs(c.G - c.R) < 18 && Math.Abs(c.B - c.G) < 18 && c.R < 80 && c.G < 80 && c.B < 80)
                                            {
                                                n++;
                                            }
                                        }

                                        if (n > 7)
                                        {
                                            state.Overlays.Add(Overlay.Widgets.BlueCrate);
                                        }
                                    }
                                }
                            }

                            chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 98, 16, 10);
                            if (chksum == 0x0f1e)
                            {
                                state.Overlays.Add(Overlay.Statuses.VIPInactive);
                            }

                            if (ScreenState.BlackBoxExists(s.SuperBitmap, new Rectangle(16, 562, 63, 18), Color.FromArgb(74, 77, 74)))
                            {
                                state.Overlays.Add(Overlay.Widgets.RewardsCrate);
                            }
                            //Rectangle(253, 490, 63, 17)
                            if (ScreenState.BlackBoxExists(s.SuperBitmap, new Rectangle(178, 563, 63, 17), Color.FromArgb(74, 77, 74)))
                            {
                                state.Overlays.Add(Overlay.Widgets.AmmoFreeAttack);
                            }
                        }
                        else if (state.CurrentArea == Area.StateMaps.Main || state.CurrentArea == Area.StateMaps.FullScreen)
                        {
                            c = s.SuperBitmap.GetPixel(387, 515);
                            if (c.Equals(239, 8, 41))
                            {
                                state.Overlays.Add(Overlay.Widgets.AllianceHelp);
                            }
                        }

                        c = s.SuperBitmap.GetPixel(213, 664);
                        if (c.Equals(24, 130, 16) || c.Equals(0, 28, 0))
                        {
                            state.Overlays.Add(Overlay.Widgets.AllianceGift);
                        }

                        c = s.SuperBitmap.GetPixel(134, 668);
                        if (c.Equals(231, 8, 33))
                        {
                            state.Overlays.Add(Overlay.Widgets.MissionsAvailable);
                        }

                        chksum = ScreenState.GetScreenChecksum(s.SuperBitmap, 352, 457, 8);
                        /*switch (chksum)
                        {
                            case 0x7d6a:
                                state.Overlays.Add(Overlay.Incomings.Rally);
                                s.SuperBitmap.Bitmap.Save(Controller.Instance.GetFullScreenshotDir() + "rally.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 0x6de0:
                                state.Overlays.Add(Overlay.Incomings.Attack);
                                break;
                            case 0x1475:
                                state.Overlays.Add(Overlay.Incomings.Scout);
                                break;
                            case 0xb76e:
                                state.Overlays.Add(Overlay.Incomings.Transport);
                                break;
                            case 0xe405:
                                state.Overlays.Add(Overlay.Incomings.Reinforcement);
                                break;
                        }*/
                    }

                    failure = 0;
                }
                catch (ArgumentException e)
                {
                    failure--;
                }
                catch (InvalidOperationException e)
                {
                    failure--;
                }
            }
            while (failure > 0);

            if (s.ScreenState != null && s.ScreenState.CurrentArea != state.CurrentArea)
            {
                s.TimeSinceAreaChanged = DateTime.Now;
            }

            s.ScreenState = state;
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
            public static readonly ID BlueCrateCollect = MainBase[1];
            public static readonly ID SilverCrateCollect = MainBase[2];
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
            public static readonly ID BlueCrate = Widget[2];
            public static readonly ID SilverCrate = Widget[3];
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
