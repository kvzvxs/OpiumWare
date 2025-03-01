using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using GorillaGameModes;
using UnityEngine.InputSystem;
using UnityEngine;
using static kennMenu.Menu.Main;
using static kennMenu.Mods.Master;
using static kennMenu.Classes.RigManager;
using static kennMenu.Mods.Overpowered;

using Photon.Realtime;
using Photon.Pun;
using kennMenu.Notifications;
using kennMenu.Classes;
using HarmonyLib;

namespace kennMenu.Mods
{
    internal class Overpowered
    {
        public static void TagGunMod()
        {
            if (GameMode.ActiveGameMode.GameType() == GameModeType.Infection)
            {
                if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitinfo))
                    {
                        if (Mouse.current.rightButton.isPressed)
                        {
                            Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                            Physics.Raycast(ray, out hitinfo, 100);
                        }

                        GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        GunSphere.transform.position = hitinfo.point;
                        GunSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        GunSphere.GetComponent<Renderer>().material.color = Color.white;
                        GameObject.Destroy(GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(GunSphere.GetComponent<Collider>());

                        VRRig player = hitinfo.collider.GetComponent<VRRig>();

                        if (player != null)
                        {
                            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || UnityInput.Current.GetMouseButton(0))
                            {
                                GameObject.Destroy(GunSphere, Time.deltaTime);
                                GunSphere.GetComponent<Renderer>().material.color = GorillaTagger.Instance.offlineVRRig.playerColor;

                                GorillaTagger.Instance.offlineVRRig.enabled = false;

                                GorillaTagger.Instance.offlineVRRig.transform.position = player.transform.position;

                                for (int i = 0; i < 4; i++)
                                {
                                    GorillaGameModes.GameMode.ReportTag(player.OwningNetPlayer);
                                }
                            }
                            else
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                            }
                        }
                        else
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                    }
                }
                if (GunSphere != null)
                {
                    GameObject.Destroy(GunSphere, Time.deltaTime);
                }
            }
        }
        private static GameObject GunSphere;

        public static void TagAll()
        {
            foreach (var vrrig in GorillaParent.instance.vrrigs)
                if (!vrrig.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                    GorillaTagger.Instance.leftHandTransform.position = vrrig.transform.position;
                }
        }

        private static float tagCooldown;

        public static void TagAura()
        {
            if (tagCooldown <= Time.time)
            {
                GorillaParent.instance.vrrigs.ForEach(d =>
                {
                    if (!d.isOfflineVRRig && !IsTagged(d) && d.CheckDistance(GorillaTagger.Instance.offlineVRRig.transform.position, 6f))
                    {
                        GorillaGameModes.GameMode.ReportTag(d.Creator);
                        RPCProtection();
                    }
                });
                Debug.Log("attempted tag");
                tagCooldown = Time.time + 0.5f;
            }
        }

        public static void TagSelf()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                AddInfected(PhotonNetwork.LocalPlayer);
                NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>You have been tagged.</color>");
                GetIndex("Tag Self").enabled = false;
            }
            else
            {
                if (InfectedList().Contains(PhotonNetwork.LocalPlayer))
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>You have been tagged.</color>");
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GetIndex("Tag Self").enabled = false;
                }
                else
                {
                    foreach (VRRig rig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(rig))
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;

                            GorillaTagger.Instance.offlineVRRig.transform.position = rig.rightHandTransform.position;
                            GorillaTagger.Instance.myVRRig.transform.position = rig.rightHandTransform.position;
                            if (GetIndex("Obnoxious Tag").enabled)
                            {
                                Quaternion rotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, 360), 0));
                                GorillaTagger.Instance.offlineVRRig.transform.rotation = rotation;
                                GorillaTagger.Instance.myVRRig.transform.rotation = rotation;

                                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));
                                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(UnityEngine.Random.Range(-10f, 10f) / 10f, UnityEngine.Random.Range(-10f, 10f) / 10f, UnityEngine.Random.Range(-10f, 10f) / 10f);
                                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(UnityEngine.Random.Range(-10f, 10f) / 10f, UnityEngine.Random.Range(-10f, 10f) / 10f, UnityEngine.Random.Range(-10f, 10f) / 10f);

                                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));
                                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));

                                GorillaTagger.Instance.offlineVRRig.leftIndex.calcT = 0f;
                                GorillaTagger.Instance.offlineVRRig.leftMiddle.calcT = 0f;
                                GorillaTagger.Instance.offlineVRRig.leftThumb.calcT = 0f;

                                GorillaTagger.Instance.offlineVRRig.leftIndex.LerpFinger(1f, false);
                                GorillaTagger.Instance.offlineVRRig.leftMiddle.LerpFinger(1f, false);
                                GorillaTagger.Instance.offlineVRRig.leftThumb.LerpFinger(1f, false);

                                GorillaTagger.Instance.offlineVRRig.rightIndex.calcT = 0f;
                                GorillaTagger.Instance.offlineVRRig.rightMiddle.calcT = 0f;
                                GorillaTagger.Instance.offlineVRRig.rightThumb.calcT = 0f;

                                GorillaTagger.Instance.offlineVRRig.rightIndex.LerpFinger(1f, false);
                                GorillaTagger.Instance.offlineVRRig.rightMiddle.LerpFinger(1f, false);
                                GorillaTagger.Instance.offlineVRRig.rightThumb.LerpFinger(1f, false);
                            }
                        }
                    }
                }
            }
        }

        public static void TagBot()
        {
            if (rightSecondary)
            {
                GetIndex("Tag Bot").enabled = false;
            }
            if (PhotonNetwork.InRoom)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    bool isInfectedPlayers = false;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig))
                        {
                            isInfectedPlayers = true;
                            break;
                        }
                    }
                    if (isInfectedPlayers)
                    {
                        GetIndex("Tag Self").method.Invoke();
                        GetIndex("Tag All").enabled = false;
                    }
                }
                else
                {
                    bool isInfectedPlayers = false;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig))
                        {
                            isInfectedPlayers = true;
                            break;
                        }
                    }
                    if (isInfectedPlayers)
                    {
                        GetIndex("Tag All").enabled = true;
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static bool IsTagged(VRRig rig)
        {
            return rig.mainSkin.material.name.ToLower().Contains("fected");
        }
    }
}
