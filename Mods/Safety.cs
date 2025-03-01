using System;
using System.Collections.Generic;
using System.Text;
using kennMenu.Notifications;
using Photon.Pun;
using UnityEngine;
using static kennMenu.Menu.Main;
using static kennMenu.Classes.RigManager;

namespace kennMenu.Mods
{
    internal class Safety
    {
        public static void AntiReportD()
        {
            foreach (GorillaPlayerScoreboardLine line in UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>())
            {
                if (line.linePlayer.UserId == PhotonNetwork.LocalPlayer.UserId)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (Vector3.Distance(vrrig.leftHandTransform.position, line.reportButton.transform.position) < 0.3f)
                        {
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectUsingSettings();
                        }
                        if (Vector3.Distance(vrrig.rightHandTransform.position, line.reportButton.transform.position) < 0.3f)
                        {
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectUsingSettings();
                        }
                    }
                }
            }
        }

        public static void AntiReportR()
        {
            foreach (GorillaPlayerScoreboardLine line in UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>())
            {
                if (line.linePlayer.UserId == PhotonNetwork.LocalPlayer.UserId)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (Vector3.Distance(vrrig.leftHandTransform.position, line.reportButton.transform.position) < 0.3f)
                        {
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectUsingSettings();
                        }
                        if (Vector3.Distance(vrrig.rightHandTransform.position, line.reportButton.transform.position) < 0.3f)
                        {
                            PhotonNetwork.Reconnect();
                            PhotonNetwork.ConnectUsingSettings();
                        }
                    }
                }
            }
        }

        public static void AntiReportN()
        {
            foreach (GorillaPlayerScoreboardLine line in UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>())
            {
                if (line.linePlayer.UserId == PhotonNetwork.LocalPlayer.UserId)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (Vector3.Distance(vrrig.leftHandTransform.position, line.reportButton.transform.position) < 0.3f)
                        {
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectUsingSettings();
                        }
                        if (Vector3.Distance(vrrig.rightHandTransform.position, line.reportButton.transform.position) < 0.3f)
                        {
                            NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> " + GetPlayerFromVRRig(vrrig).NickName + " is reporting you.");
                            PhotonNetwork.ConnectUsingSettings();
                        }
                    }
                }
            }
        }

        public static void NoFingers()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
        }
    }
}
