using System;
using System.Collections.Generic;
using System.Text;
using opiumMenu.Notifications;
using Photon.Pun;
using UnityEngine;

namespace opiumMenu.Mods
{
    internal class Safety
    {
        public static void AntiReportD()
        {
            foreach (GorillaPlayerScoreboardLine allScoreboardLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                if (allScoreboardLine.linePlayer.IsLocal)
                {
                    Transform transform = allScoreboardLine.reportButton.gameObject.transform;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.isOfflineVRRig)
                        {
                            float righthand = Vector3.Distance(vrrig.rightHandTransform.position, transform.position);
                            float lefthand = Vector3.Distance(vrrig.leftHandTransform.position, transform.position);
                            if (righthand <= .85f || lefthand <= .85f)
                            {
                                PhotonNetwork.Disconnect();
                                NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
                            }
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
