using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStrikeBot
{
    public class ScreenStateFFXV : ScreenState
    {
        public ScreenStateFFXV() : base()
        {
            
        }

        protected override void GetGameArea(SuperBitmap bmp)
        {
            //Y-axis 485-551 notification area
            //menu area
            ushort chksum = ScreenState.GetScreenChecksum(bmp, 160, 16, 14);//DIFF
            ushort chksum2;
            Color c, c2, c3;

            switch (chksum)
            {
                case 0x77b5:
                    CurrentArea = Area.MainBases.Main;
                    break;
                case 0x79ed:
                case 0x4169: //loading/modal
                    CurrentArea = Area.Menus.Alliance;
                    break;
                case 0xf31c:
                //case 0x8759: //TODO modal
                    CurrentArea = Area.Menus.Gifts;
                    break;
                /*case 0x3b42: //memu main menu
                case 0x4c18: //memu store
                case 0x1a87: //memu catalog
                    CurrentArea = Area.Menus.AllianceStore;
                    break;*/
                case 0xdd22:
                    CurrentArea = Area.Menus.AllianceHelp;
                    break;
                //case 0x6f55: //"Unknown" glitch on Alliance Help
                //    if (!Logout())
                //    {
                //        if (!KillApp())
                //        {
                //            Controller.Instance.RestartEmulator(this);
                //        }
                //    }
                //    break;
                case 0x53d3:
                    CurrentArea = Area.Menus.AllianceWar;
                    break;
                case 0xbf5d:
                    CurrentArea = Area.Menus.Challenge;
                    break;
                case 0x229a:
                    CurrentArea = Area.Menus.Deployment;
                    break;
                case 0x4901:
                    CurrentArea = Area.Menus.Boost;
                    break;
                case 0xf0d5:
                    CurrentArea = Area.Menus.Boosts.PeaceShield;
                    break;
                case 0xafea:
                    CurrentArea = Area.Menus.Boosts.Attack;
                    break;
                case 0x7de9:
                    CurrentArea = Area.Menus.Boosts.Health;
                    break;
                case 0xb253: //memu
                    CurrentArea = Area.Menus.Boosts.Defense;
                    break;
                case 0x0602:
                    CurrentArea = Area.Menus.Boosts.DeploymentSize;
                    break;
                case 0x7c48:
                    CurrentArea = Area.Menus.Boosts.CommanderXP;
                    break;
                case 0x274c:
                    CurrentArea = Area.Menus.Boosts.UpkeepReduction;
                    break;
                case 0x464b:
                    CurrentArea = Area.Menus.Boosts.Gathering;
                    break;
                case 0x4f97:
                    CurrentArea = Area.Menus.Boosts.FakeForces;
                    break;
                case 0x5402:
                    CurrentArea = Area.Menus.Boosts.AntiScout;
                    break;
                case 0x19b3:
                    CurrentArea = Area.Menus.Boosts.FoodProduction;
                    break;
                case 0xc678:
                    CurrentArea = Area.Menus.Boosts.OilProduction;
                    break;
                case 0x17f4:
                    CurrentArea = Area.Menus.Boosts.StoneProduction;
                    break;
                case 0xce7f:
                    CurrentArea = Area.Menus.Boosts.IronProduction;
                    break;
                case 0x2c0e:
                    CurrentArea = Area.Menus.Boosts.CoinProduction;
                    break;
                case 0x4e99:
                    CurrentArea = Area.Menus.Boosts.TroopQueue;
                    break;
                case 0xc3ab://
                    CurrentArea = Area.Menus.Boosts.TrainingSpeed;
                    break;
                case 0x6d81://
                    CurrentArea = Area.Menus.Boosts.TrainingStimulant;
                    break;
                case 0xdd70: //memu
                    CurrentArea = Area.Menus.Boosts.SetBonus;
                    break;
                case 0x9138://
                    CurrentArea = Area.Menus.Boosts.AttackStimulant;
                    break;
                case 0xee24:
                    CurrentArea = Area.Menus.Items;
                    break;
                case 0xc6d5:
                case 0x422f: //loading
                    CurrentArea = Area.Menus.Mission;
                    break;
                case 0xce0f:
                    CurrentArea = Area.Menus.Missions.Base;
                    break;
                case 0x5b6f:
                    CurrentArea = Area.Menus.Missions.Daily;
                    break;
                case 0xe273:
                    CurrentArea = Area.Menus.Missions.Alliance;
                    break;
                case 0x7333:
                    CurrentArea = Area.Menus.Missions.VIP;
                    break;
                case 0x6e83:
                    CurrentArea = Area.Menus.Missions.ActivateVIP;
                    break;
                /*case 0x2670:
                case 0xb55a: //nox
                case 0xe02e: //nox new
                    CurrentArea = Area.Menus.Missions.VIPStreak;
                    break;*/
                case 0x24c5:
                    CurrentArea = Area.Menus.Mail;
                    break;
                case 0x4379:
                case 0x770c: //modal
                    CurrentArea = Area.Menus.MailCompose;
                    break;
                case 0xf2b5:
                    CurrentArea = Area.Menus.More;
                    break;
                case 0xead2:
                case 0x9e8c: //log out modal
                case 0xd29c: //logging out
                    CurrentArea = Area.Menus.Account;
                    break;
                case 0xab66:
                    CurrentArea = Area.Menus.ResourceHelp;
                    break;
                /*case 0x6c9f: //nox
                case 0x7ef5: //nox new
                    CurrentArea = Area.Menus.Resources;
                    break;*/
                case 0x5417:
                    CurrentArea = Area.Menus.Commander;
                    break;
                case 0x3ff9:
                    CurrentArea = Area.Menus.Profile;
                    break;
                case 0x8657: //weapon
                case 0x29d0: //DO helmet
                case 0x8d23: //armor
                case 0x466d: //DO footwear
                case 0x67ce: //accessory
                    CurrentArea = Area.Menus.Gear;
                    break;
                case 0xb898:
                case 0x45af: //vip points
                    CurrentArea = Area.Menus.VIP;
                    break;
                case 0x6db5:	
                    CurrentArea = Area.Menus.VIPSubscriptions;
                    break;
                case 0xd0b4: //attack of the flan
                    CurrentArea = Area.Menus.ShootingRanges.Main;
                    break;
                /*case 0x6eae:
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
                    break;*/
                /*case 0xfab0:
                case 0xee9d:
                    chksum = ScreenState.GetScreenChecksum(bmp, 110, 430, 20);
                    switch (chksum)
                    {
                        case 0x3075: //MEmu
                            CurrentArea = Area.Emulators.Android;
                            break;
                        //TODO Redo
                        //case 0xb47c:
                        //    CurrentArea = Area.Emulators.TaskManagerApp;
                        //    break;
                        //case 0xfcff:
                        //    CurrentArea = Area.Emulators.TaskManagerRemove;
                        //    break;
                        //case 0xa115:
                        //    CurrentArea = Area.Emulators.TaskManager;
                        //    break;
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
                    break;*/
                case 0x04ae:
                    CurrentArea = Area.Emulators.Android;
                    break;
                //TODO: Move to outer scope
                case 0x9fc9: 
                    CurrentArea = Area.Emulators.Loading;
                    break;
                case 0x4a61: //loading
                case 0xcaa2: //blank
                case 0x8cc0: //logging in
                //case 0x103b: //blank with black bar
                    CurrentArea = Area.Others.Splash;
                    break;
                case 0x2ce8:
                case 0x2689: //loading
                case 0x033d: //modal (login failed)
                    CurrentArea = Area.Others.Login;
                    break;
                case 0x5272:
                case 0x1a37: //upgrade building TODO move to new enum
                    CurrentArea = Area.Menus.BuildingList;
                    break;
                case 0x1224:
                    CurrentArea = Area.Menus.Buildings.HQ;
                    break;
                case 0x7bfb:
                    CurrentArea = Area.Menus.Buildings.Wall;
                    break;
                case 0x4bf0: //memu
                    CurrentArea = Area.Menus.Buildings.Warehouse;
                    break;
                case 0xdc9b:
                    CurrentArea = Area.Menus.Buildings.Radar;
                    break;
                case 0xeda1:
                    CurrentArea = Area.Menus.Buildings.TradingPost;
                    break;
                case 0xc307:
                    CurrentArea = Area.Menus.Buildings.HallOfHeroes;
                    break;
                case 0xce86: //hospital ward
                case 0xed1d: //hospital
                    CurrentArea = Area.Menus.Buildings.Hospital;
                    break;
                case 0x0f62: //barracks
                case 0xe46e: //training grounds
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 180, 240, 14);
                    if (chksum2 == 0x4d6a)
                    {
                        CurrentArea = Area.Menus.ShootingRanges.Lobby;
                    }
                    else
                    {
                        CurrentArea = Area.Menus.Buildings.TrainingGrounds;
                    }
                    break;
                case 0x5af3:
                    CurrentArea = Area.Menus.Buildings.Bank;
                    break;
                case 0x59f2: //research
                case 0xae91: //economics
                case 0x3ef6: //combat
                case 0x657a: //defense
                case 0x8d10: //hero
                    CurrentArea = Area.Menus.Buildings.Research;
                    break;
                case 0x70d7:
                    CurrentArea = Area.Menus.Buildings.Armory;
                    break;
                case 0x51fa:
                    CurrentArea = Area.Menus.Buildings.Embassy;
                    break;
                case 0xd37c:
                    CurrentArea = Area.Menus.Buildings.WarRoom;
                    break;
                case 0xe17d:
                    CurrentArea = Area.Menus.Buildings.Prison;
                    break;
                case 0x9dc8:
                    CurrentArea = Area.Menus.Buildings.DeathRow;
                    break;
                case 0xdab0:
                    CurrentArea = Area.Menus.Buildings.Farm;
                    break;
                case 0x534c:
                    CurrentArea = Area.Menus.Buildings.Quarry;
                    break;
                case 0xf4dd:
                    CurrentArea = Area.Menus.Buildings.IronMine;
                    break;
                case 0x6600:
                    CurrentArea = Area.Menus.Buildings.OilWell;
                    break;
                case 0x34cf:
                    CurrentArea = Area.Menus.Buildings.Vault;
                    break;
                case 0x1a80: //alliance chat
                //case 0x1380: //state/alliance transition
                case 0xe554: //state/custom chat
                case 0xfff8: //contact list
                    CurrentArea = Area.Others.Chat;
                    break;
                case 0x0ed3: //get gold
                    CurrentArea = Area.Others.Ad;
                    break;
                case 0x6aad:
                    c = bmp.GetPixel(190, 425);
                    if (c.R < 80 && c.G < 80 && c.B < 80)
                    {
                        CurrentArea = Area.MainBases.GlobalGiftCollect;
                    }
                    else
                    {
                        CurrentArea = Area.MainBases.SecretGiftCollect;
                    }
                    break;
                case 0xa4b5: //blank menu
                    CurrentArea = Area.Menus.Casino;
                    break;
                case 0xd1a4: //world map with compass button
                    CurrentArea = Area.StateMaps.Main;
                    break;
                default:
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 72, 302, 20); //DIFF

                    switch (chksum2)
                    {
                        case 0x7c8c:
                            CurrentArea = Area.Others.Quit;
                            /*try
                            {
                                bmp.Bitmap.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                            }
                            catch (System.Runtime.InteropServices.ExternalException e) { }*/
                            break;
                        default:
                            chksum2 = ScreenState.GetScreenChecksum(bmp, 16, 15, 12);
                            if (chksum2 == 0x3fa1)
                            {
                                CurrentArea = Area.StateMaps.FullScreen;
                            }
                            else if (chksum2 == 0xc465)
                            {
                                chksum2 = ScreenState.GetScreenChecksum(bmp, 215, 235, 10);
                                if (chksum2 == 0x3702)
                                {
                                    CurrentArea = Area.StateMaps.CoordinateError;
                                }
                                else
                                {
                                    CurrentArea = Area.StateMaps.Coordinate;
                                }
                            }
                            else
                            {
                                chksum2 = ScreenState.GetScreenChecksum(bmp, 60, 120, 20);
                                if (chksum2 == 0x994e || chksum2 == 0x0e05) //shooting range crate collect or casino jackpot crate collect
                                {
                                    CurrentArea = Area.Menus.ShootingRanges.NormalCrate;
                                }
                                else
                                {
                                    chksum2 = ScreenState.GetScreenChecksum(bmp, 190, 476, 20);
                                    if (chksum2 == 0xefdf)
                                    {
                                        CurrentArea = Area.Menus.BuildingList; //DIFF Citadel upgrade complete
                                    }
                                    else
                                    {
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
                                    }
                                }
                            }
                            break;
                    }
                    break;
            }

            try  //TODO: Move this to outer scope after CONST are set up
            {
                if (CurrentArea == Area.Unknown)
                {
                    chksum = ScreenState.GetScreenChecksum(bmp, 160, 16, 14);
                    bmp.Bitmap.Save(String.Format("{0}\\unknown{1}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);

                    if (CurrentArea == Area.Menu)
                    {
                        bmp.Bitmap.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
            }
            catch (System.Runtime.InteropServices.ExternalException ex) { }
        }

        protected override void GetGameOverlays(SuperBitmap bmp)
        {
            Overlays.Clear();

            ushort chksum;
            Color c;

            //Overlays
            if (CurrentArea == Area.MainBases.Main)
            {
                chksum = ScreenState.GetScreenChecksum(bmp, 352, 545, 20);//DIFF

                if (chksum == 0xab54)
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
                if (ScreenState.BlackBoxExists(bmp, new Rectangle(4, 588, 51, 18), Color.FromArgb(74, 77, 74)))
                {
                    Overlays.Add(Overlay.Widgets.GlobalGift);
                }

                if (!ScreenState.BlackBoxExists(bmp, new Rectangle(64, 588, 51, 18), Color.FromArgb(74, 77, 74)))
                {
                    Overlays.Add(Overlay.Widgets.SecretGift);
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
                //if (ScreenState.BlackBoxExists(bmp, new Rectangle(178, 563, 63, 17), Color.FromArgb(74, 77, 74)))
                if (ScreenState.BlackBoxExists(bmp, new Rectangle(249, 590, 51, 16), Color.FromArgb(74, 77, 74))) //DIFF ff
                {
                    Overlays.Add(Overlay.Widgets.AmmoFreeAttack);
                }
            }
            else if (CurrentArea == Area.StateMaps.Main || CurrentArea == Area.StateMaps.FullScreen)
            {
                chksum = ScreenState.GetScreenChecksum(bmp, 352, 545, 20);//DIFF

                if (chksum == 0xab54)
                {
                    Overlays.Add(Overlay.Widgets.AllianceHelp);
                }
            }

            c = bmp.GetPixel(213, 664);
            if (c.Equals(24, 130, 16) || c.Equals(0, 28, 0))
            {
                Overlays.Add(Overlay.Widgets.AllianceGift);
            }

            c = bmp.GetPixel(128, 653);
            if (c.Equals(231, 4, 82))
            {
                Overlays.Add(Overlay.Widgets.MissionsAvailable);
            }

            chksum = ScreenState.GetScreenChecksum(bmp, 360, 494, 8);//DIFF ff
            switch (chksum)
            {
            //    case 0x7d6a:
            //        Overlays.Add(Overlay.Incomings.Rally);
            //        s.SuperBitmap.Bitmap.Save(Controller.Instance.GetFullScreenshotDir() + "rally.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            //        break;
                case 0x3d9f:
                    Overlays.Add(Overlay.Incomings.Attack);
                    break;
            //    case 0x1475:
            //        Overlays.Add(Overlay.Incomings.Scout);
            //        break;
            //    case 0xb76e:
            //        Overlays.Add(Overlay.Incomings.Transport);
            //        break;
            //    case 0xe405:
            //        Overlays.Add(Overlay.Incomings.Reinforcement);
            //        break;
            }
        }
    }
}
