using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using GorillaGameModes;
using UnityEngine.InputSystem;
using UnityEngine;

namespace opiumMenu.Mods
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

        public static void TagAuraMod()
        {
            if (GameMode.ActiveGameMode.GameType() == GameModeType.Infection)
            {
                float tagDistance = 3f;
                Vector3 forwardDirection = GorillaTagger.Instance.offlineVRRig.head.rigTarget.forward;

                VRRig closestPlayer = null;
                float closestDistance = Mathf.Infinity;

                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    Vector3 targetPosition = vrrig.headMesh.transform.position;
                    Vector3 playerPosition = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
                    Vector3 toTarget = targetPosition - playerPosition;

                    float playerDistance = toTarget.magnitude;

                    if (!vrrig.mainSkin.material.name.Contains("fected") && playerDistance < tagDistance && Vector3.Dot(forwardDirection, toTarget.normalized) > 0)
                    {
                        if (playerDistance < closestDistance)
                        {
                            closestPlayer = vrrig;
                            closestDistance = playerDistance;
                        }
                    }
                }
            }
        }

        public static void ForceTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = true;
        }

        public static void NoTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = false;
        }
    }
}
