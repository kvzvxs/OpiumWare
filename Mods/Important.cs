using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GorillaNetworking;
using OpiumWare.Classes;
using Photon.Pun;
using UnityEngine;
using static OpiumWare.Menu.Main;
using OpiumWare.Patches;
using Cinemachine;
using System.Reflection;
using OpiumWare.Notifications;
using UnityEngine.InputSystem;

namespace OpiumWare.Mods
{
    internal class Important
    {
        public static void Disconnect()
        {
            PhotonNetwork.Disconnect(); // bruh
        }

        public static void Reconnect()
        {
            rejRoom = PhotonNetwork.CurrentRoom.Name;
            //rejDebounce = Time.time + (float)internetTime;
            PhotonNetwork.Disconnect();
        }

        public static string roomCode;

        public static void JoinRandom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.Disconnect();
                CoroutineManager.RunCoroutine(JoinRandomDelay());
                return;
            }

            string gamemode = PhotonNetworkController.Instance.currentJoinTrigger.networkZone;

            PhotonNetworkController.Instance.AttemptToJoinPublicRoom(GorillaComputer.instance.GetJoinTriggerForZone(gamemode), JoinType.Solo);
            /*
            switch (gamemode)
            {
                case "forest":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "city":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - City Front").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "canyons":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Canyon").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "mountains":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Mountain For Computer").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "beach":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Beach from Forest").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "sky":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Clouds").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "basement":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Basement For Computer").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "metro":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Metropolis from Computer").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "arcade":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - City frm Arcade").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "rotating":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Rotating Map").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "bayou":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - BayouComputer2").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
                case "caves":
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Cave").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                    break;
            }*/
        }

        public static void RestartGame()
        {
            Process.Start("steam://rungameid/1533390");
            Application.Quit();
        }

        public static IEnumerator JoinRandomDelay()
        {
            yield return new WaitForSeconds(1f);
            JoinRandom();
        }

        public static void DisableNT()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(false);
        }

        public static void EnableNT()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
        }

        public static void DisableMT()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab").SetActive(false);
        }

        public static void EnableMT()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab").SetActive(true);
        }

        private static GameObject popup = null;
        public static void AcceptTOS()
        {
            popup = GameObject.Find("Miscellaneous Scripts/PopUpMessage");
            popup.SetActive(false);
            Patches.TOSPatch.enabled = true;
        }

        public static void DisableAcceptTOS()
        {
            popup.SetActive(true);
            Patches.TOSPatch.enabled = false;
        }

        public static void JoinDiscord()
        {
            Process.Start(serverLink);
        }

        public static void UncapFPS()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = int.MaxValue;
        }

        public static void UnlockCompetitiveQueue()
        {
            GorillaComputer.instance.CompQueueUnlockButtonPress();
        }

        public static void JoinGhostCode()
        {
            var ghostCodes = new List<(string code, int length)>
            {
                ("PBBV", 4), ("RUN", 3), ("MOOSE", 5), ("SREN17", 6),
                ("ECHO", 4), ("J3VU", 4), ("DAISY09", 7), ("BANJO", 5),
                ("PBBV2", 5), ("WRENCH", 6), ("SIT", 3), ("NOT", 3),
                ("MIRROR", 6), ("STATUE", 6), ("SPIDER", 6), ("VOID", 4),
                ("NOCLIP", 6), ("NULL", 4), ("ERROR", 5), ("BLU", 3),
                ("GLITCH", 6), ("ERROR404", 8), ("SREN18", 8), ("666", 8),
                ("HIDE", 8), ("GHOST", 8), ("CHILL", 8),
            };

            var random = new System.Random();
            var randomGhostCode = ghostCodes[random.Next(ghostCodes.Count)];

            string roomName = $"{randomGhostCode.code}.{randomGhostCode.length}";

            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomName, (JoinType)6);
        }

        public static void EnableFPC()
        {
            if (TPC != null)
            {
                wasenabled = TPC.gameObject.transform.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled;
            }
        }

        public static void MoveFPC()
        {
            if (TPC != null)
            {
                TPC.fieldOfView = 90f;
                TPC.gameObject.transform.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = false;
                TPC.gameObject.transform.position = GorillaTagger.Instance.headCollider.transform.position;
                TPC.gameObject.transform.rotation = Quaternion.Lerp(TPC.transform.rotation, GorillaTagger.Instance.headCollider.transform.rotation, 0.075f);
            }
        }

        public static void DisableFPC()
        {
            if (TPC != null)
            {
                TPC.GetComponent<Camera>().fieldOfView = 60f;
                TPC.gameObject.transform.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = wasenabled;
            }
        }
        private static bool wasenabled = true;

        public static void ForceLagGame()
        {
            foreach (GameObject g in UnityEngine.Object.FindObjectsByType<GameObject>(0)) { }
        }

        public static Quaternion lastHeadQuat = Quaternion.identity;
        public static Quaternion lastLHQuat = Quaternion.identity;
        public static Quaternion lastRHQuat = Quaternion.identity;

        public static bool lastTagLag = false;
        public static int tagLagFrames = 0;

        public static void TagLagDetector()
        {
            if (PhotonNetwork.InRoom && !PhotonNetwork.IsMasterClient)
            {
                if (Quaternion.Angle(Classes.RigManager.GetVRRigFromPlayer(PhotonNetwork.MasterClient).headMesh.transform.rotation, lastHeadQuat) <= 0.01f && Quaternion.Angle(Classes.RigManager.GetVRRigFromPlayer(PhotonNetwork.MasterClient).leftHandTransform.rotation, lastLHQuat) <= 0.01f && Quaternion.Angle(Classes.RigManager.GetVRRigFromPlayer(PhotonNetwork.MasterClient).rightHandTransform.rotation, lastRHQuat) <= 0.01f)
                {
                    tagLagFrames++;
                }
                else
                {
                    tagLagFrames = 0;
                }

                lastLHQuat = Classes.RigManager.GetVRRigFromPlayer(PhotonNetwork.MasterClient).leftHandTransform.rotation;
                lastRHQuat = Classes.RigManager.GetVRRigFromPlayer(PhotonNetwork.MasterClient).rightHandTransform.rotation;
                lastHeadQuat = Classes.RigManager.GetVRRigFromPlayer(PhotonNetwork.MasterClient).headMesh.transform.rotation;

                bool thereIsTagLag = tagLagFrames > 512;
                if (thereIsTagLag && !lastTagLag)
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=red>TAG LAG</color><color=grey>]</color> <color=white>There is currently tag lag.</color>");
                }
                if (!thereIsTagLag && lastTagLag)
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=green>TAG LAG</color><color=grey>]</color> <color=white>There is no longer tag lag.</color>");
                }
                lastTagLag = thereIsTagLag;
            }
            else
            {
                if (lastTagLag)
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=green>TAG LAG</color><color=grey>]</color> <color=white>There is no longer tag lag.</color>");
                }
                lastTagLag = false;
            }
        }

        private static float keyboardDelay = 0f;
        public static void PCButtonClick()
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                Physics.Raycast(ray, out var Ray, 512f, NoInvisLayerMask());
                GorillaPressableButton possibly = Ray.collider.GetComponentInParent<GorillaPressableButton>();
                if (possibly)
                {
                    typeof(GorillaPressableButton).GetMethod("OnTriggerEnter", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(possibly, new object[] { GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHandTriggerCollider").GetComponent<Collider>() });
                }
                GorillaKeyboardButton possibler = Ray.collider.GetComponentInParent<GorillaKeyboardButton>();
                if (possibler && Time.time > keyboardDelay)
                {
                    keyboardDelay = Time.time + 0.1f;
                    GameEvents.OnGorrillaKeyboardButtonPressedEvent.Invoke(possibler.Binding);
                }
                GorillaPlayerLineButton possiblest = Ray.collider.GetComponentInParent<GorillaPlayerLineButton>();
                if (possiblest && Time.time > keyboardDelay)
                {
                    keyboardDelay = Time.time + 0.1f;
                    typeof(GorillaPlayerLineButton).GetMethod("OnTriggerEnter", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(possiblest, new object[] { GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHandTriggerCollider").GetComponent<Collider>() });
                }
            }
        }

        public static void OpiumWareRoom()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("<$OpiumWare_" + PluginInfo.Version + ">", JoinType.Solo);
        }
    }
}
