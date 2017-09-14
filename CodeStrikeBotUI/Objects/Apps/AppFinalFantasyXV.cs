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
            ushort chksum = ScreenState.GetScreenChecksum(bmp, 67, 16, 4);
            ushort chksum2 = 0, chksum3 = 0;
            bool enteredGeneric = false;
            Color c, c2, c3;

            switch (chksum)
            {
                case 0x76fb: //menu
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 160, 16, 14);
                    switch (chksum2)
                    {
                        case 0x79ed:
                            CurrentArea = Area.Menus.Alliance;
                            break;
                        case 0xf31c:
                            CurrentArea = Area.Menus.Gifts;
                            break;
                        case 0xdd22:
                            CurrentArea = Area.Menus.AllianceHelp;
                            break;
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
                        case 0xee24:
                            CurrentArea = Area.Menus.Items;
                            break;
                        case 0xc6d5:
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
                        case 0x24c5:
                            CurrentArea = Area.Menus.Mail;
                            break;
                        case 0x4379:
                            CurrentArea = Area.Menus.MailCompose;
                            break;
                        case 0xf2b5:
                            CurrentArea = Area.Menus.More;
                            break;
                        case 0xead2:
                            CurrentArea = Area.Menus.Account;
                            break;
                        case 0xa4b5: //blank menu
                            CurrentArea = Area.Menus.Casino;
                            break;
                        case 0xab66:
                            CurrentArea = Area.Menus.ResourceHelp;
                            break;
                        case 0x7307:
                            CurrentArea = Area.Menus.Resources;
                            break;
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
                        case 0x0ed3: //get gold
                            CurrentArea = Area.Others.Ad;
                            break;
                        case 0xd0b4: //attack of the flan
                        case 0x857c: //the gem dungeon
                            CurrentArea = Area.Menus.ShootingRanges.Main;
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
                        case 0x4bf0:
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
                        default:
                            chksum3 = ScreenState.GetScreenChecksum(bmp, 16, 16, 10);
                            if (chksum3 != 0xa037)
                            {
                                enteredGeneric = true;
                            }
                            break;
                    }
                    break;
                case 0x7f20: //menu loading
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 160, 16, 14);
                    switch (chksum2)
                    {
                        case 0x4169:
                            CurrentArea = Area.Menus.Alliance;
                            break;
                        case 0x422f:
                            CurrentArea = Area.Menus.Mission;
                            break;
                        case 0xd29c: //logging out
                            CurrentArea = Area.Menus.Account;
                            break;
                        case 0x6caf:
                            CurrentArea = Area.Menus.Deployment;
                            break;
                        default:
                            enteredGeneric = true;
                            break;
                    }
                    break;
                case 0xcfeb: //menu modal
                case 0xb191: //large modal
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 160, 16, 14);
                    switch (chksum2)
                    {
                        case 0x6e83:
                            //TODO: Convert this to overlay popup, see unknown0cde-6e83
                            CurrentArea = Area.Menus.Missions.ActivateVIP;
                            break;
                        case 0x770c:
                            CurrentArea = Area.Menus.MailCompose;
                            break;
                        case 0x9e8c: //log out
                            CurrentArea = Area.Menus.Account;
                            break;
                        case 0x49ef: //donation confirmation
                            CurrentArea = Area.Menus.ResourceHelp;
                            break;
                        case 0xec6f: //rss use confirmation
                            CurrentArea = Area.Menus.Resources;
                            break;
                        case 0xddf8: //economics
                        case 0xf417: //economics
                        case 0xd6b2: //combat
                        case 0x0792: //defense
                        case 0x9b6b: //hero
                        case 0x1477: //hero mastered
                            CurrentArea = Area.Menus.Buildings.Research;
                            break;
                        case 0x84e5:
                            CurrentArea = Area.Menus.Buildings.Farm;
                            break;
                        case 0x1fe2:
                            CurrentArea = Area.Menus.Buildings.OilWell;
                            break;
                        case 0x1537:
                            CurrentArea = Area.Menus.Buildings.Quarry;
                            break;
                        case 0x8731:
                            CurrentArea = Area.Menus.Buildings.IronMine;
                            break;
                        case 0x54cd:
                            CurrentArea = Area.Menus.Buildings.Bank;
                            break;
                        case 0xdb75:
                        case 0x8f88: //absolute black //TODO this scenario when demo building confirmation screen
                            CurrentArea = Area.Menus.BuildingList;
                            break;
                        case 0x3e5c:
                            CurrentArea = Area.Menus.Deployment;
                            break;
                        default:
                            enteredGeneric = true;
                            break;
                    }
                    break;
                case 0x09ab:
                case 0x97aa: //loading
                    CurrentArea = Area.MainBases.Main;
                    break;
                case 0xbcd1: //realm map
                case 0xbf65: //monster modal
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 366, 16, 10);
                    if (chksum2 == 0xa71b)
                    {
                        CurrentArea = Area.StateMaps.Main;
                    }
                    else
                    {
                        CurrentArea = Area.StateMaps.FullScreen;
                    }
                    break;
                case 0x0a49: //memu
                    CurrentArea = Area.Emulators.Loading;
                    break;
                case 0x88c8:
                    CurrentArea = Area.Emulators.Android;
                    break;
                case 0x2274:
                case 0x07b8: //loading
                    CurrentArea = Area.Others.Splash;
                    break;
                case 0x33e2: //login
                    CurrentArea = Area.Others.Login;
                    break;
                case 0xc7bd: //login modal/loading
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 60, 120, 20);
                    if (chksum2 == 0xbe30) //TODO: collision case: casino jackpot crate collect
                    {
                        CurrentArea = Area.Others.Login;
                    }
                    else
                    {
                        CurrentArea = Area.Menus.ShootingRanges.NormalCrate;
                    }
                    break;
                case 0x49c2: //main base modal
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 190, 115, 20);
                    switch (chksum2)
                    {
                        case 0xda08: //secret gift uncollectable
                            CurrentArea = Area.MainBases.SecretGiftCollect;
                            break;
                        case 0x18e3:
                            CurrentArea = Area.MainBases.SecretGiftCollect;
                            break;
                        case 0x7448:
                            CurrentArea = Area.MainBases.GlobalGiftCollect;
                            break;
                        default:
                            CurrentArea = Area.MainBases.Main;
                            break;
                    }
                    break;
                case 0x4a40: //realm map modal
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 215, 235, 10);
                    if (chksum2 == 0x3702)
                    {
                        CurrentArea = Area.StateMaps.CoordinateError;
                    }
                    else if (chksum2 == 0xeb3d)
                    {
                        CurrentArea = Area.StateMaps.Coordinate;
                    }
                    else
                    {
                        chksum3 = ScreenState.GetScreenChecksum(bmp, 366, 16, 10);
                        if (chksum3 == 0x630e)
                        {
                            CurrentArea = Area.StateMaps.Main;
                        }
                        else if (chksum3 == 0x2a78)
                        {
                            CurrentArea = Area.StateMaps.FullScreen;
                        }
                        else
                        {
                            enteredGeneric = true;
                        }
                    }
                    break;
                case 0xd49a: //black screen
                    chksum2 = ScreenState.GetScreenChecksum(bmp, 190, 115, 20);
                    if (chksum2 == 0x4489) //notice
                    {
                        chksum3 = ScreenState.GetScreenChecksum(bmp, 190, 150, 20);
                        if (chksum3 == 0x7bcf) //session timeout
                        {
                            CurrentArea = Area.Others.SessionTimeout;
                        }
                    }
                    break;
                case 0x793a: //guild chat
                case 0xaca3: //realm chat
                case 0xe5d3: //contacts
                    CurrentArea = Area.Others.Chat;
                    break;
                case 0x1f46: //trial of the titan
                    CurrentArea = Area.Menus.ShootingRanges.Main;
                    break;
            }

            if (CurrentArea == Area.Unknown)
            {
                chksum3 = ScreenState.GetScreenChecksum(bmp, 72, 302, 20);

                switch (chksum3)
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
                        chksum3 = ScreenState.GetScreenChecksum(bmp, 60, 120, 20);
                        switch (chksum3)
                        {
                            case 0x994e: //shooting range crate collect
                            case 0x0e05: //casino jackpot crate collect
                                CurrentArea = Area.Menus.ShootingRanges.NormalCrate;
                                break;
                            default:
                                chksum3 = ScreenState.GetScreenChecksum(bmp, 190, 476, 20);
                                if (chksum3 == 0xefdf)
                                {
                                    CurrentArea = Area.Menus.BuildingList; //Citadel upgrade complete
                                }
                                else
                                {
                                    chksum3 = ScreenState.GetScreenChecksum(bmp, 194, 642, 20);
                                    switch (chksum3)
                                    {
                                        case 0x5019:
                                        case 0x8a64:
                                            CurrentArea = Area.Others.Ad;
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                }
            }

            try  //TODO: Move this to outer scope after CONST are set up
            {
                if (CurrentArea == Area.Unknown)
                {
                    //chksum3 = ScreenState.GetScreenChecksum(bmp, 190, 115, 20);
                    if (!System.IO.File.Exists(String.Format("{0}\\unknown\\unknown{1}-{2}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4"))))
                    {
                        bmp.Bitmap.Save(String.Format("{0}\\unknown\\unknown{1}-{2}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    /*if (CurrentArea == Area.Menu)
                    {
                        bmp.Bitmap.Save(String.Format("{0}\\-save.bmp", Controller.Instance.GetFullScreenshotDir()), System.Drawing.Imaging.ImageFormat.Bmp);
                    }*/
                }
                else if (enteredGeneric && CurrentArea != Area.Others.Quit)
                {
                    if (!System.IO.File.Exists(String.Format("{0}\\unknown\\genericCase-{1}-{2}-{3}.bmp", Controller.Instance.GetFullScreenshotDir(), this.ToString(), chksum.ToString("X4"), chksum2.ToString("X4"))))
                    {
                        bmp.Bitmap.Save(String.Format("{0}\\unknown\\genericCase-{1}-{2}-{3}.bmp", Controller.Instance.GetFullScreenshotDir(), this.ToString(), chksum.ToString("X4"), chksum2.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    //Controller.Instance.SendNotification(string.Format("ScreenState found but missed above\n{0}-{1}-{2}", this.ToString(), chksum.ToString("X4"), chksum2.ToString("X4")), NotificationType.General);
                }

                /*chksum = ScreenState.GetScreenChecksum(bmp, 67, 16, 7);
                if (!System.IO.File.Exists(String.Format("{0}\\unknown\\unknown{1}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"))))
                {
                    bmp.Bitmap.Save(String.Format("{0}\\unknown\\unknown{1}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);
                }*/
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
                chksum = ScreenState.GetScreenChecksum(bmp, 67, 16, 6);
                if (chksum == 0x95ca)
                {
                    Overlays.Add(Overlay.Statuses.Loading);
                }

                chksum = ScreenState.GetScreenChecksum(bmp, 352, 545, 20);
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
                
                if (ScreenState.BlackBoxExists(bmp, new Rectangle(249, 590, 51, 16), Color.FromArgb(74, 77, 74))) //DIFF ff
                {
                    Overlays.Add(Overlay.Widgets.AmmoFreeAttack);
                }
            }
            else if (CurrentArea == Area.StateMaps.Main || CurrentArea == Area.StateMaps.FullScreen)
            {
                chksum = ScreenState.GetScreenChecksum(bmp, 352, 545, 20);
                if (chksum == 0xab54)
                {
                    Overlays.Add(Overlay.Widgets.AllianceHelp);
                }

                chksum = ScreenState.GetScreenChecksum(bmp, 54, 198, 10);
                if (chksum == 0xce01)
                {
                    Overlays.Add(Overlay.Dialogs.Tiles.Empty);
                }
                else
                {
                    chksum = ScreenState.GetScreenChecksum(bmp, 40, 107, 10);
                    if (chksum == 0x0ce0)
                    {
                        c = bmp.GetPixel(195, 233);
                        if (c.Equals(8, 235, 255))
                        {
                            Overlays.Add(Overlay.Dialogs.Tiles.PlayerFriend);
                        }
                        else
                        {
                            Overlays.Add(Overlay.Dialogs.Tiles.PlayerEnemy);
                        }
                    }
                    else
                    {
                        chksum = ScreenState.GetScreenChecksum(bmp, 54, 71, 10);
                        if (chksum == 0xce01)
                        {
                            Overlays.Add(Overlay.Dialogs.Tiles.RssOpen);
                        }
                        else
                        {
                            chksum = ScreenState.GetScreenChecksum(bmp, 23, 18, 10);
                            if (chksum == 0x10f3)
                            {
                                Overlays.Add(Overlay.Dialogs.Tiles.Rebel);
                            }
                            else
                            {
                                chksum = ScreenState.GetScreenChecksum(bmp, 54, 128, 10);
                                if (chksum == 0x8fdc)
                                {
                                    Overlays.Add(Overlay.Dialogs.Tiles.Warzone);
                                }
                                else
                                {
                                    chksum = ScreenState.GetScreenChecksum(bmp, 54, 128, 10);
                                    if (chksum == 0xce01)
                                    {
                                        Overlays.Add(Overlay.Dialogs.Tiles.ControlPoint);
                                    }
                                    else
                                    {
                                        chksum = ScreenState.GetScreenChecksum(bmp, 192, 120, 10);
                                        if (chksum == 0xad61) //crystal no occupy allowed
                                        {
                                            Overlays.Add(Overlay.Dialogs.Tiles.Blocked);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (CurrentArea == Area.Menus.Alliance || CurrentArea == Area.Menus.Mission || CurrentArea == Area.Menus.Account)
            {
                chksum = ScreenState.GetScreenChecksum(bmp, 67, 16, 6);
                if (chksum == 0x041e)
                {
                    Overlays.Add(Overlay.Statuses.Loading);
                }
            }
            else if (CurrentArea == Area.Menus.AllianceHelp)
            {
                chksum = ScreenState.GetScreenChecksum(bmp, 36, 225, 20);
                if (chksum == 0xeeab)
                {
                    Overlays.Add(Overlay.Statuses.Loading);
                }
            }

            chksum = ScreenState.GetScreenChecksum(bmp, 190, 105, 10);
            if (chksum == 0xaea3) //popup
            {
                chksum = ScreenState.GetScreenChecksum(bmp, 190, 115, 20);
                switch (chksum)
                {
                    case 0x3795:
                    case 0xbf0a:
                        // TODO: Remove, debugging
                        chksum = ScreenState.GetScreenChecksum(bmp, 67, 16, 4);
                        ushort chksum2 = ScreenState.GetScreenChecksum(bmp, 160, 16, 14);
                        ushort chksum3 = ScreenState.GetScreenChecksum(bmp, 190, 115, 20);

                        if (!System.IO.File.Exists(String.Format("{0}\\unknown\\rss{1}-{2}-{3}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4"), chksum3.ToString("X4"))))
                        {
                            bmp.Bitmap.Save(String.Format("{0}\\unknown\\rss{1}-{2}-{3}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4"), chksum3.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                        Overlays.Add(Overlay.Dialogs.Popups.TransferConfirmation);
                        break;
                    case 0x043b:
                        Overlays.Add(Overlay.Dialogs.Popups.MaxDeployments);
                        break;
                    case 0x7a0f:
                        Overlays.Add(Overlay.Dialogs.Popups.DemolishBuilding);
                        break;
                    case 0xff64:
                        Overlays.Add(Overlay.Dialogs.Popups.AreYouSure);
                        break;
                    case 0x5065:
                        Overlays.Add(Overlay.Dialogs.Popups.LoginFailed);
                        break;
                    case 0x1d4c: //notice
                        chksum = ScreenState.GetScreenChecksum(bmp, 190, 150, 20);
                        if (chksum == 0xaae6)
                        {
                            Overlays.Add(Overlay.Dialogs.Popups.ConnectionInterrupted);
                        }
                            //91f8 //google play error
                            //057d //quest timer not completed
                        else
                        {
                            Overlays.Add(Overlay.Dialogs.Popups.Unknown);
                        }
                        break;
                    case 0xce2f: //tip!
                        chksum = ScreenState.GetScreenChecksum(bmp, 190, 150, 20);
                        if (chksum == 0x8772) //warning troops attacking outside base are not saved by hospital
                        {
                            Overlays.Add(Overlay.Dialogs.Popups.WarningOutsideAttack);
                        }
                        else
                        {
                            Overlays.Add(Overlay.Dialogs.Popups.Unknown);
                        }
                        break;
                    case 0xd856: //scout
                        chksum = ScreenState.GetScreenChecksum(bmp, 190, 150, 20);
                        if (chksum == 0x68e1) //scout not unlocked 
                        {
                            Overlays.Add(Overlay.Dialogs.Popups.ScoutNotUnlocked);
                        }
                        else
                        {
                            Overlays.Add(Overlay.Dialogs.Popups.Unknown);
                        }
                        break;
                    default:
                        Overlays.Add(Overlay.Dialogs.Popups.Unknown);
                        break;
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

            try
            {
                if (Overlays.Count == 0 && CurrentArea != Area.Unknown && CurrentArea != Area.MainBases.Main
                    && CurrentArea != Area.StateMaps.Main && CurrentArea != Area.StateMaps.FullScreen
                    && CurrentArea != Area.Emulators.Loading && CurrentArea != Area.Emulators.Android
                    && CurrentArea != Area.Others.Login && CurrentArea != Area.Others.Splash && CurrentArea != Area.Others.Ad
                    && CurrentArea != Area.Others.Chat && CurrentArea != Area.Others.SessionTimeout)
                {
                    chksum = ScreenState.GetScreenChecksum(bmp, 67, 16, 4);
                    ushort chksum2 = ScreenState.GetScreenChecksum(bmp, 160, 16, 14);
                    ushort chksum3 = ScreenState.GetScreenChecksum(bmp, 190, 115, 20);

                    if (chksum == 0x0cde || chksum == 0x57ca) //modal or double modal on a menu
                    {
                        if (!System.IO.File.Exists(String.Format("{0}\\unknown\\unknown{1}-{2}-{3}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4"), chksum3.ToString("X4"))))
                        {
                            bmp.Bitmap.Save(String.Format("{0}\\unknown\\unknown{1}-{2}-{3}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4"), chksum3.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                    }
                }

                if (Overlays.Contains(Overlay.Dialogs.Popups.Unknown))
                {
                    chksum = ScreenState.GetScreenChecksum(bmp, 190, 115, 20);
                    ushort chksum2 = ScreenState.GetScreenChecksum(bmp, 190, 150, 20);

                    if (!System.IO.File.Exists(String.Format("{0}\\unknown\\popup{1}-{2}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4"))))
                    {
                        bmp.Bitmap.Save(String.Format("{0}\\unknown\\popup{1}-{2}.bmp", Controller.Instance.GetFullScreenshotDir(), chksum.ToString("X4"), chksum2.ToString("X4")), System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
            }
            catch (InvalidOperationException e) { }
        }
    }
}
