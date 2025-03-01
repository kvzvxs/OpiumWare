using System.Diagnostics;
using UnityEngine;
using static kennMenu.Menu.Main;
using static kennMenu.Settings;
using static kennMenu.Menu.Buttons;
using kennMenu.Classes;
using kennMenu.Menu;
using kennMenu.Notifications;

namespace kennMenu.Mods
{
    internal class SettingsMods
    {
        public static void EnterSettings()
        {
            buttonsType = 1;
            pageNumber = 0;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
            pageNumber = 0;
        }

        public static void SafetySettings()
        {
            buttonsType = 3;
            pageNumber = 0;
        }

        public static void PlayerSettings()
        {
            buttonsType = 4;
            pageNumber = 0;
        }

        public static void VisualSettings()
        {
            buttonsType = 5;
            pageNumber = 0;
        }

        public static void MovementSettings()
        {
            buttonsType = 6;
            pageNumber = 0;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 7;
            pageNumber = 0;
        }

        public static void OverpoweredSettings()
        {
            buttonsType = 8;
            pageNumber = 0;
        }

        public static void MasterSettings()
        {
            buttonsType = 9;
            pageNumber = 0;
        }

        public static void ExperimentalSettings()
        {
            buttonsType = 10;
            pageNumber = 0;
        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void BothHandsOn()
        {
            bothHands = true;
        }

        public static void BothHandsOff()
        {
            bothHands = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void QuitGame()
        {
            Application.Quit();
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

        public static void JoinDiscord()
        {
            Process.Start(serverLink);
        }

        public static void Panic()
        {
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled)
                    {
                        Toggle(v.buttonText);
                    }
                }
            }
            NotifiLib.ClearAllNotifications();
        }

        // public static void DisableGhostview()
        // {
        //      disableGhostview = true;
        // }

        // public static void EnableGhostview()
        // {
        //      disableGhostview = false;
        // }

        // public static void LegacyGhostview()
        // {
        //      legacyGhostview = true;
        // }

        // public static void NewGhostview()
        // {
        //      legacyGhostview = false;
        // }
    }
}
