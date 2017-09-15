using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStrikeBot
{
    public class ScreenStateMS : ScreenState
    {
        public ScreenStateMS() : base()
        {
            
        }

        protected override void GetGameArea(SuperBitmap bmp)
        {
            //menu area
            ushort chksum = ScreenState.GetScreenChecksum(bmp, 160, 12, 20);
            Color c, c2, c3;

            switch (chksum)
            {
                case 0x633d:
                case 0x13c0: //nox
                case 0xc4eb: //nox new
                    CurrentArea = Area.Menus.Alliance;
                    break;
                case 0x3956:
                case 0x501e: //nox
                case 0xbb5f: //nox new
                case 0x8759: //now new modal
                    CurrentArea = Area.Menus.Gifts;
                    break;
                case 0x3b42: //memu main menu
                case 0x4c18: //memu store
                case 0x1a87: //memu catalog
                    CurrentArea = Area.Menus.AllianceStore;
                    break;
                case 0xc88e:
                case 0x08eb: //nox
                case 0xa240: //nox new
                    CurrentArea = Area.Menus.AllianceHelp;
                    break;
                /*case 0x6f55: //"Unknown" glitch on Alliance Help
                    if (!Logout())
                    {
                        if (!KillApp())
                        {
                            Controller.Instance.RestartEmulator(this);
                        }
                    }
                    break;*/
                case 0x26e5: //memu
                    CurrentArea = Area.Menus.AllianceWar;
                    break;
                case 0x6ff2:
                    CurrentArea = Area.Menus.Challenge;
                    break;
                case 0xfddf:
                    CurrentArea = Area.Menus.Deployments;
                    break;
                case 0x4e34:
                case 0xe9f1: //nox
                case 0x24ba: //nox new
                    CurrentArea = Area.Menus.Boost;
                    break;
                case 0x712b:
                case 0x25c8: //nox
                case 0x2498: //nox new
                    CurrentArea = Area.Menus.Boosts.PeaceShield;
                    break;
                case 0x994f: //memu
                    CurrentArea = Area.Menus.Boosts.Attack;
                    break;
                case 0x46b7: //memu
                    CurrentArea = Area.Menus.Boosts.Health;
                    break;
                case 0xb253: //memu
                    CurrentArea = Area.Menus.Boosts.Defense;
                    break;
                case 0xd58f:
                    CurrentArea = Area.Menus.Boosts.DeploymentSize;
                    break;
                case 0xde1e:
                    CurrentArea = Area.Menus.Boosts.CommanderXP;
                    break;
                case 0x7623:
                    CurrentArea = Area.Menus.Boosts.UpkeepReduction;
                    break;
                case 0x6253:
                    CurrentArea = Area.Menus.Boosts.Gathering;
                    break;
                case 0x456f:
                    CurrentArea = Area.Menus.Boosts.FakeForces;
                    break;
                case 0x56e4:
                case 0xbf74: //nox
                case 0xf0cb: //nox new
                    CurrentArea = Area.Menus.Boosts.AntiScout;
                    break;
                case 0x5c99:
                    CurrentArea = Area.Menus.Boosts.FoodProduction;
                    break;
                case 0x8115:
                    CurrentArea = Area.Menus.Boosts.OilProduction;
                    break;
                case 0xb74b:
                    CurrentArea = Area.Menus.Boosts.StoneProduction;
                    break;
                case 0xfea6:
                    CurrentArea = Area.Menus.Boosts.IronProduction;
                    break;
                case 0x506a:
                    CurrentArea = Area.Menus.Boosts.CoinProduction;
                    break;
                case 0x0506:
                    CurrentArea = Area.Menus.Boosts.TroopQueue;
                    break;
                case 0xc3ab:
                    CurrentArea = Area.Menus.Boosts.TrainingSpeed;
                    break;
                case 0x6d81:
                    CurrentArea = Area.Menus.Boosts.TrainingStimulant;
                    break;
                case 0xdd70: //memu
                    CurrentArea = Area.Menus.Boosts.SetBonus;
                    break;
                case 0x9138:
                    CurrentArea = Area.Menus.Boosts.AttackStimulant;
                    break;
                case 0x0d52:
                case 0x775c: //nox
                case 0xcbf5: //memu
                    CurrentArea = Area.Menus.Items;
                    break;
                case 0x217e:
                case 0xba89: //nox
                case 0x750a: //nox new
                    CurrentArea = Area.Menus.Mission;
                    break;
                case 0x2556: //Base Missions also fall here
                case 0x54fe: //nox
                case 0x5f4e: //nox new
                    CurrentArea = Area.Menus.Missions.Daily;
                    break;
                case 0x753c:
                case 0x6588: //nox
                case 0x89f8: //nox new
                    CurrentArea = Area.Menus.Missions.Alliance;
                    break;
                case 0x4262:
                case 0x6074: //nox
                case 0x7067: //nox new
                    CurrentArea = Area.Menus.Missions.VIP;
                    break;
                case 0x996d:
                case 0xa138: //nox
                case 0x9ee3: //nox new
                    CurrentArea = Area.Menus.Missions.ActivateVIP;
                    break;
                case 0x2670:
                case 0xb55a: //nox
                case 0xe02e: //nox new
                    CurrentArea = Area.Menus.Missions.VIPStreak;
                    break;
                case 0x5d85:
                case 0xc459: //nox
                case 0xf52c: //nox new
                    CurrentArea = Area.Menus.Mail;
                    break;
                case 0xb12c: //memu
                    CurrentArea = Area.Menus.MailCompose;
                    break;
                case 0x2186:
                case 0x653b: //nox
                case 0xf278: //nox new
                    CurrentArea = Area.Menus.More;
                    break;
                case 0xe814:
                case 0xfa8f: //grayed out loading/modal dialog
                case 0x255b: //nox
                case 0xe2f4: //nox modal
                case 0x3737: //now new
                case 0x4f4a: //now modal new
                    CurrentArea = Area.Menus.Account;
                    break;
                case 0x3561:
                case 0x3ad6: //grayed out (confirmation/max limit)
                case 0x055b: //nox
                case 0x6229: //nox grayed out
                case 0x8d70: //memu
                case 0xc22d: //memu modal
                    CurrentArea = Area.Menus.ResourceHelp;
                    break;
                case 0x6c9f: //nox
                case 0x7ef5: //nox new
                    CurrentArea = Area.Menus.Resources;
                    break;
                case 0x4e3e: //memu
                    CurrentArea = Area.Menus.Commander;
                    break;
                case 0xf40e: //memu weapon
                case 0x29d0: //memu helmet
                case 0xfc5a: //memu armor
                case 0x466d: //memu footwear
                case 0x0e0b: //memu accessory
                    CurrentArea = Area.Menus.Gear;
                    break;
                case 0x7b13:
                case 0x0359: //nox
                case 0xb69b: //nox new
                    CurrentArea = Area.Menus.VIP;
                    break;
                case 0x8f1e: //nox new		
                    CurrentArea = Area.Menus.VIPSubscriptions;
                    break;
                case 0x6eae:
                case 0x8993: //nox
                case 0xa5f9: //nox new
                    CurrentArea = Area.Menus.ShootingRanges.Lobby;
                    break;
                case 0x1cea:
                case 0x0a36: //nox
                case 0x68e7: //nox Special Winter Shooting Range modal
                case 0x3554: //nox Special Winter Shooting Range
                case 0xc192: //memu Special Valentine's Day Shooting Range modal
                case 0x3a76: //memu Special Valentine's Day Shooting Range
                    chksum = ScreenState.GetScreenChecksum(bmp, 300, 70, 10);
                    if (chksum == 0xd714)
                    {
                        CurrentArea = Area.Menus.ShootingRanges.Crates;
                    }
                    else
                    {
                        CurrentArea = Area.Menus.ShootingRanges.Main;
                    }
                    break;
                case 0x7fab:
                case 0xf3f8: //nox
                case 0x969e: //nox new
                    CurrentArea = Area.Menus.ShootingRanges.NormalCrate;
                    break;
                case 0x87db:
                case 0xf551:
                case 0x9a77: //nox
                case 0xed12: //nox new
                    CurrentArea = Area.Menus.RewardCrate;
                    break;
                case 0xfab0:
                case 0xee9d:
                    chksum = ScreenState.GetScreenChecksum(bmp, 110, 430, 20);
                    switch (chksum)
                    {
                        case 0x3075: //MEmu
                            CurrentArea = Area.Emulators.Android;
                            break;
                        /*TODO Redo
                        case 0xb47c:
                            CurrentArea = Area.Emulators.TaskManagerApp;
                            break;
                        case 0xfcff:
                            CurrentArea = Area.Emulators.TaskManagerRemove;
                            break;
                        case 0xa115:
                            CurrentArea = Area.Emulators.TaskManager;
                            break;*/
                        case 0xfab0:
                            chksum = ScreenState.GetScreenChecksum(bmp, 190, 150, 20);
                            //if (chksum == 0xa265)
                            if (chksum == 0xf81a || chksum == 0x3dd6) //nox and nox new
                            {
                                CurrentArea = Area.Others.SessionTimeout;
                            }
                            else
                            {
                                CurrentArea = Area.Emulators.Crash;
                            }
                            break;
                    }
                    break;
                case 0xac21:
                case 0x99c8: //nox
                    CurrentArea = Area.Emulators.Android;
                    break;
                case 0xa43d:
                case 0xd521: //memu
                    CurrentArea = Area.Emulators.Loading;
                    break;
                case 0x59b7:
                case 0xe2f3: //arnold
                case 0xb951: //halloween arnold
                case 0x67fa:
                    //case 0x9e4f:  //depricated?
                    CurrentArea = Area.Others.Splash;
                    break;
                case 0x60b3: //memu
                case 0xa5a8: //memu loading
                case 0xb1d0: //memu modal
                    CurrentArea = Area.Others.Login;
                    break;
                case 0x0f50: //memu
                    CurrentArea = Area.Menus.BuildingList;
                    break;
                case 0x4491: //memu
                    CurrentArea = Area.Menus.Buildings.HQ;
                    break;
                case 0xfdea: //memu
                    CurrentArea = Area.Menus.Buildings.Wall;
                    break;
                case 0x0aa6: //memu
                    CurrentArea = Area.Menus.Buildings.Memorial;
                    break;
                case 0x4bf0: //memu
                    CurrentArea = Area.Menus.Buildings.Warehouse;
                    break;
                case 0xe7c6: //memu
                    CurrentArea = Area.Menus.Buildings.Radar;
                    break;
                case 0x96c1: //memu
                    CurrentArea = Area.Menus.Buildings.TradingPost;
                    break;
                case 0xc5e2: //memu
                    CurrentArea = Area.Menus.Buildings.HallOfHeroes;
                    break;
                case 0xdf29: //memu
                    CurrentArea = Area.Menus.Buildings.Hospital;
                    break;
                case 0x0316: //memu
                    CurrentArea = Area.Menus.Buildings.TrainingGrounds;
                    break;
                case 0xe980: //memu
                    CurrentArea = Area.Menus.Buildings.Bank;
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
                    CurrentArea = Area.Menus.Buildings.Research;
                    break;
                case 0xc1fe: //memu
                    CurrentArea = Area.Menus.Buildings.Embassy;
                    break;
                case 0xf4d6: //memu
                    CurrentArea = Area.Menus.Buildings.WarRoom;
                    break;
                case 0x36a2: //memu
                    CurrentArea = Area.Menus.Buildings.Prison;
                    break;
                case 0x8b1e: //memu
                    CurrentArea = Area.Menus.Buildings.DeathRow;
                    break;
                case 0x3c43: //memu
                    CurrentArea = Area.Menus.Buildings.Farm;
                    break;
                case 0x9046: //memu
                    CurrentArea = Area.Menus.Buildings.Quarry;
                    break;
                case 0x007e: //memu
                    CurrentArea = Area.Menus.Buildings.IronMine;
                    break;
                case 0x582a: //memu
                    CurrentArea = Area.Menus.Buildings.OilWell;
                    break;
                case 0x39bb: //memu
                    CurrentArea = Area.Menus.Buildings.Vault;
                    break;
                case 0xfcbb: //memu
                    CurrentArea = Area.Menus.Buildings.Monument;
                    break;
                case 0x8b9e: //memu
                    CurrentArea = Area.Menus.Buildings.SpeedUpFactory;
                    break;
                case 0x7d41: //memu
                    CurrentArea = Area.Menus.Buildings.CombatLab;
                    break;
                case 0xcb14: //memu
                    CurrentArea = Area.Menus.Buildings.TroopAcademy;
                    break;
                case 0x6e5b: //memu
                    CurrentArea = Area.Menus.Buildings.CovertOpsCenter;
                    break;
                case 0x30ac:
                    CurrentArea = Area.Menus.BuildingBoost;
                    break;
                case 0x9be4: //memu alliance chat
                case 0x9d42: //memu state/alliance transition
                case 0x658b: //memu state chat
                case 0x1cbd: //memu custom chat
                case 0x0169: //memu contact list
                    CurrentArea = Area.Others.Chat;
                    break;
                case 0x3436:
                case 0x6716: //memu get gold
                    CurrentArea = Area.Others.Ad;
                    break;
                default:
                    ushort chksum2 = ScreenState.GetScreenChecksum(bmp, 267, 20, 20);

                    switch (chksum2)
                    {
                        case 0xf958:
                        case 0x2f05: //nox new
                        case 0x97e4:
                            CurrentArea = Area.MainBases.Main;
                            break;
                        case 0x3ef3: //main base with modal dialog
                        case 0x7d45: //nox new
                            chksum2 = ScreenState.GetScreenChecksum(bmp, 145, 125, 20);
                            switch (chksum2)
                            {
                                case 0xb69d: //Free Daily Bonus
                                case 0x32c5: //Daily Bonus Club
                                case 0xf84f: //nox Free Daily Bonus
                                    c = bmp.GetPixel(100, 430);
                                    if (c.Equals(41, 93, 115))
                                    {
                                        CurrentArea = Area.MainBases.DailyLogin;
                                    }
                                    else if (c.Equals(115, 121, 123))
                                    {
                                        CurrentArea = Area.MainBases.DailyLoginClaimed;
                                    }
                                    break;
                                case 0x68a6: //Daily Bonus Club: Elite Pack
                                case 0xa0fb:
                                    CurrentArea = Area.MainBases.DailyLoginClaimed;
                                    break;
                                case 0xa377: //"Congratulations"
                                case 0x76a1: //"Supply Crate"
                                case 0x8770: //"Supply Crate"
                                case 0x57d2: //nox congrats
                                    CurrentArea = Area.MainBases.SecretGiftCollect;
                                    break;
                                case 0xc5ca:
                                case 0x220f: //nox
                                    CurrentArea = Area.MainBases.GlobalGiftCollect;
                                    break;
                                default:
                                    chksum = ScreenState.GetScreenChecksum(bmp, 180, 190, 10);
                                    if (chksum == 0x4c29)// || chksum == 0x0a22)
                                    {
                                        CurrentArea = Area.Others.Quit;
                                    }
                                    else if (chksum == 0xad22)
                                    {
                                        //some kind of small message with blue button, like errors
                                        //CurrentArea = Area.Others.Quit;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            bmp.Bitmap.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                                        }
                                        catch (System.Runtime.InteropServices.ExternalException e) { }
                                    }
                                    break;
                            }
                            break;
                        default:
                            c = bmp.GetPixel(112, 17);
                            c2 = bmp.GetPixel(285, 28);
                            if (c.Equals(41, 113, 156))
                            {
                                //world map
                                c = bmp.GetPixel(372, 12);

                                if (c.R > 30 && c.G > 30 && c.B > 35)
                                {
                                    CurrentArea = Area.StateMaps.FullScreen;
                                }
                                else
                                {
                                    CurrentArea = Area.StateMaps.Main;
                                }
                            }
                            else if (c.Equals(16, 44, 57))
                            {
                                //world map modal		
                                chksum = ScreenState.GetScreenChecksum(bmp, 180, 190, 10);
                                if (chksum == 0x4c29)
                                {
                                    CurrentArea = Area.Others.Quit;
                                }
                                else
                                {
                                    c = bmp.GetPixel(178, 183);

                                    if (c.Equals(239, 239, 239) || c.Equals(247, 255, 255))
                                    {
                                        //world map coordinate		
                                        c = bmp.GetPixel(269, 265);

                                        if (c.R > 5 && c.G > 40 && c.B > 50)
                                        {
                                            CurrentArea = Area.StateMaps.Coordinate;
                                        }
                                        else
                                        {
                                            CurrentArea = Area.StateMaps.CoordinateError;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                c = bmp.GetPixel(178, 183);

                                if (c.Equals(239, 239, 239) || c.Equals(247, 255, 255))
                                {
                                    //world map coordinate
                                    c = bmp.GetPixel(269, 265);

                                    if (c.R > 5 && c.G > 40 && c.B > 50)
                                    {
                                        CurrentArea = Area.StateMaps.Coordinate;
                                    }
                                    else
                                    {
                                        CurrentArea = Area.StateMaps.CoordinateError;
                                    }
                                }
                                else
                                {
                                    c = bmp.GetPixel(20, 20);

                                    if (!c.Equals(140, 211, 239))
                                    {
                                        c = bmp.GetPixel(50, 350);
                                        c2 = bmp.GetPixel(325, 550);
                                        c3 = bmp.GetPixel(200, 500);
                                        if (!c.Equals(0, 0, 0) || !c2.Equals(0, 0, 0))
                                        {
                                            c = bmp.GetPixel(378, 20);
                                            c2 = bmp.GetPixel(135, 665);
                                            c3 = bmp.GetPixel(135, 535);
                                            if ((c.Equals(239, 239, 239) && (c2.Equals(222, 130, 0) || c2.Equals(33, 158, 90)))
                                                || (c.Equals(247, 247, 247) && c3.Equals(222, 130, 0))
                                                || c.Equals(239, 235, 231)) //&& c3.Equals(222, 130, 0)))
                                            {
                                                CurrentArea = Area.Others.Ad;
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
        }

        protected override void GetGameOverlays(SuperBitmap bmp)
        {
            Overlays.Clear();

            ushort chksum;
            Color c;

            //Overlays
            if (CurrentArea == Area.MainBases.Main)
            {
                chksum = ScreenState.GetScreenChecksum(bmp, 345, 500, 20);

                //if (chksum == 0xb877) //depricated?
                if (chksum == 0xe925)
                {
                    Overlays.Add(Overlay.Widgets.AllianceHelp);
                }

                chksum = ScreenState.GetScreenChecksum(bmp, 373, 348, 10);
                //if (chksum != 0xe8ae && chksum != 0x6bb1) ///depricated?
                if (chksum == 0x0060)
                {
                    //c = bmp.GetPixel(44, 395);
                    //if (!c.Equals(165, 121, 24))
                    c = bmp.GetPixel(372, 345);
                    if (!c.Equals(198, 150, 33))
                    {
                        Overlays.Add(Overlay.Widgets.DailyLogin);
                    }
                }

                //c = s.bmp.GetPixel(35, 498);
                //c2 = s.bmp.GetPixel(29, 498);
                c = bmp.GetPixel(275, 535);
                //Rectangle(4, 489, 63, 18)
                //if (Math.Abs(c.R - c.G) <= 11 && (c.Within(157, 156, 155, 28) || c2.Within(165, 162, 156, 28)) && 
                if (ScreenState.BlackBoxExists(bmp, new Rectangle(253, 562, 63, 18), Color.FromArgb(74, 77, 74), 10)
                && !c.Equals(57, 85, 140))
                {
                    Overlays.Add(Overlay.Widgets.GlobalGift);
                }

                chksum = ScreenState.GetScreenChecksum(bmp, 275, 532, 10);
                c = bmp.GetPixel(275, 535);
                if (chksum != 0x41fa && !ScreenState.BlackBoxExists(bmp, new Rectangle(253, 562, 63, 18), Color.FromArgb(74, 77, 74)))
                {
                    int n = 0;
                    for (int i = 514; i <= 544; i++)
                    {
                        c = bmp.GetPixel(278, i);
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
                            c = bmp.GetPixel(298, i);
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
                                c = bmp.GetPixel(286, i);
                                if (Math.Abs(c.G - c.R) < 18 && Math.Abs(c.B - c.G) < 18 && c.R < 80 && c.G < 80 && c.B < 80)
                                {
                                    n++;
                                }
                            }

                            if (n > 7)
                            {
                                Overlays.Add(Overlay.Widgets.SecretGift);
                            }
                        }
                    }
                }

                chksum = ScreenState.GetScreenChecksum(bmp, 98, 16, 10);
                if (chksum == 0x0f1e)
                {
                    Overlays.Add(Overlay.Statuses.VIPInactive);
                }

                if (ScreenState.BlackBoxExists(bmp, new Rectangle(16, 562, 63, 18), Color.FromArgb(74, 77, 74)))
                {
                    Overlays.Add(Overlay.Widgets.RewardsCrate);
                }
                //Rectangle(253, 490, 63, 17)
                if (ScreenState.BlackBoxExists(bmp, new Rectangle(178, 563, 63, 17), Color.FromArgb(74, 77, 74)))
                {
                    Overlays.Add(Overlay.Widgets.AmmoFreeAttack);
                }
            }
            else if (CurrentArea == Area.StateMaps.Main || CurrentArea == Area.StateMaps.FullScreen)
            {
                c = bmp.GetPixel(387, 515);
                if (c.Equals(239, 8, 41))
                {
                    Overlays.Add(Overlay.Widgets.AllianceHelp);
                }
            }

            c = bmp.GetPixel(213, 664);
            if (c.Equals(24, 130, 16) || c.Equals(0, 28, 0))
            {
                Overlays.Add(Overlay.Widgets.AllianceGift);
            }

            c = bmp.GetPixel(134, 668);
            if (c.Equals(231, 8, 33))
            {
                Overlays.Add(Overlay.Widgets.MissionsAvailable);
            }

            chksum = ScreenState.GetScreenChecksum(bmp, 352, 457, 8);
            /*switch (chksum)
            {
                case 0x7d6a:
                    Overlays.Add(Overlay.Incomings.Rally);
                    s.SuperBitmap.Bitmap.Save(Controller.Instance.GetFullScreenshotDir() + "rally.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case 0x6de0:
                    Overlays.Add(Overlay.Incomings.Attack);
                    break;
                case 0x1475:
                    Overlays.Add(Overlay.Incomings.Scout);
                    break;
                case 0xb76e:
                    Overlays.Add(Overlay.Incomings.Transport);
                    break;
                case 0xe405:
                    Overlays.Add(Overlay.Incomings.Reinforcement);
                    break;
            }*/
        }
    }
}
