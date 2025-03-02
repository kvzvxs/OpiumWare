using System;
using System.Collections.Generic;
using System.Text;
using ExitGames.Client.Photon;
using GorillaGameModes;
using GorillaTagScripts;
using OpiumWare.Notifications;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using static OpiumWare.Menu.Main;

namespace OpiumWare.Mods
{
    internal class Master
    {
        public static void MasterCheck()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>You are master client.</color>");
            }
            else
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
        }

        public static void BetaSetStatus(int state, RaiseEventOptions balls)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                object[] statusSendData = new object[1];
                statusSendData[0] = state;
                object[] sendEventData = new object[3];
                sendEventData[0] = PhotonNetwork.ServerTimestamp;
                sendEventData[1] = (byte)2;
                sendEventData[2] = statusSendData;
                PhotonNetwork.RaiseEvent(3, sendEventData, balls, SendOptions.SendUnreliable);
            }
        }

        public static void InfectionToTag()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaTagManager gorillaTagManager = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                gorillaTagManager.SetisCurrentlyTag(true);
                gorillaTagManager.ClearInfectionState();
                gorillaTagManager.ChangeCurrentIt(GameMode.ParticipatingPlayers[UnityEngine.Random.Range(0, GameMode.ParticipatingPlayers.Count)]);
            }
        }

        public static void TagToInfection()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaTagManager gorillaTagManager = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                gorillaTagManager.SetisCurrentlyTag(false);
                gorillaTagManager.ClearInfectionState();
                NetPlayer victim = GameMode.ParticipatingPlayers[UnityEngine.Random.Range(0, GameMode.ParticipatingPlayers.Count)];
                gorillaTagManager.AddInfectedPlayer(victim);
                gorillaTagManager.lastInfectedPlayer = victim;
            }
        }

        public static void TagLag()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                GorillaAmbushManager ambman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Stealth Manager").GetComponent<GorillaAmbushManager>();
                if (GorillaGameManager.instance.GameModeName().ToLower().Contains("ambush") || GorillaGameManager.instance.GameModeName().ToLower().Contains("stealth"))
                {
                    ambman.tagCoolDown = 2147483647f;
                }
                else
                {
                    tagman.tagCoolDown = 2147483647f;
                }
            }
        }

        public static void NahTagLag()
        {
            GorillaTagManager tagman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
            GorillaAmbushManager ambman = GameObject.Find("GT Systems/GameModeSystem/Gorilla Stealth Manager").GetComponent<GorillaAmbushManager>();
            if (GorillaGameManager.instance.GameModeName().ToLower().Contains("ambush") || GorillaGameManager.instance.GameModeName().ToLower().Contains("stealth"))
            {
                ambman.tagCoolDown = 5f;
            }
            else
            {
                tagman.tagCoolDown = 5f;
            }
        }

        public static float tagAuraDistance = 1.666f;
        public static int tagAuraIndex = 1;

        public static float spamtagdelay = -1f;
        public static void SpamTagSelf()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                if (Time.time > spamtagdelay)
                {
                    spamtagdelay = Time.time + 0.1f;
                    if (InfectedList().Contains(PhotonNetwork.LocalPlayer))
                    {
                        RemoveInfected(PhotonNetwork.LocalPlayer);
                    }
                    else
                    {
                        AddInfected(PhotonNetwork.LocalPlayer);
                    }
                }
            }
        }

        public static void SpamTagAll()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                if (Time.time > spamtagdelay)
                {
                    spamtagdelay = Time.time + 0.1f;
                    foreach (Photon.Realtime.Player v in PhotonNetwork.PlayerList)
                    {
                        if (InfectedList().Contains(v))
                        {
                            AddInfected(v);
                        }
                        else
                        {
                            RemoveInfected(v);
                        }
                    }
                }
            }
        }

        public static void BattleStartGame()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                lol.StartBattle();
            }
        }

        public static void BattleEndGame()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                lol.BattleEnd();
            }
        }

        public static void BattleRestartGame()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                lol.BattleEnd();
                lol.StartBattle();
            }
        }

        public static void BattleBalloonSpamSelf()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                lol.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] = UnityEngine.Random.Range(0, 4);
            }
        }

        public static void BattleBalloonSpam()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                foreach (Photon.Realtime.Player loln in PhotonNetwork.PlayerList)
                {
                    lol.playerLives[loln.ActorNumber] = UnityEngine.Random.Range(0, 4);
                }
            }
        }

        public static void BattleKillSelf()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                lol.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] = 0;
            }
        }

        public static void BattleKillAll()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                foreach (Photon.Realtime.Player loln in PhotonNetwork.PlayerList)
                {
                    lol.playerLives[loln.ActorNumber] = 0;
                }
            }
        }

        public static void BattleReviveSelf()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                lol.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] = 4;
            }
        }

        public static void BattleReviveAll()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                foreach (Photon.Realtime.Player loln in PhotonNetwork.PlayerList)
                {
                    lol.playerLives[loln.ActorNumber] = 4;
                }
            }
        }

        public static void BattleGodMode()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>");
            }
            else
            {
                GorillaPaintbrawlManager lol = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaPaintbrawlManager>();
                lol.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] = 4;
                GorillaLocomotion.Player.Instance.disableMovement = false;
            }
        }
    }
}

