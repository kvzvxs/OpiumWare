using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using Oculus.Platform;
using opiumMenu.Classes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static opiumMenu.Menu.Main;

namespace opiumMenu.Mods
{
    internal class Movement
    {
        public static void Platforms()

        {
            if (ControllerInputPoller.instance.leftGrab && leftplat == null)
            {
                leftplat = CreatePlatformOnHand(GorillaTagger.Instance.leftHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrab && rightplat == null)
            {
                rightplat = CreatePlatformOnHand(GorillaTagger.Instance.rightHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrabRelease && rightplat != null)
            {
                rightplat.Disable();
                rightplat = null;
            }

            if (ControllerInputPoller.instance.leftGrabRelease && leftplat != null)
            {
                leftplat.Disable();
                leftplat = null;
            }
        }
        private static GameObject leftplat = null;
        private static GameObject rightplat = null;
        private static GameObject CreatePlatformOnHand(Transform handTransform)
        {
            GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);

            plat.transform.position = handTransform.position;
            plat.transform.rotation = handTransform.rotation;

            float h = (Time.frameCount / 180f) % 1f;
            plat.GetComponent<Renderer>().material.color = Color.black;
            plat.GetComponent<Renderer>().material.color = Color.white;
            return plat;
        } 

        public static void SpB()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.5f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 1.25f;
        }

        public static void MosaSpB()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 1.2f;
        }

        public static void ChangeFlySpeed()
        {
            flySpeedCycle++;
            if (flySpeedCycle > 4)
            {
                flySpeedCycle = 0;
            }

            float[] speedamounts = new float[] { 5f, 10f, 30f, 60f, 0.5f };
            flySpeed = speedamounts[flySpeedCycle];

            string[] speedNames = new string[] { "Slow", "Normal", "Fast", "Extra Fast", "Extra Slow" };
            GetIndex("Change Fly Speed").overlapText = "Change Fly Speed <color=grey>[</color><color=green>" + speedNames[flySpeedCycle] + "</color><color=grey>]</color>";
        }

        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || Keyboard.current.wKey.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * flySpeed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void Noclip()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5)
            {
                if (noclip == false)
                {
                    noclip = true;
                    UpdateClipColliders(false);
                }
            }
            else
            {
                if (noclip == true)
                {
                    noclip = false;
                    UpdateClipColliders(true);
                }
            }
        }

        public static void UpdateClipColliders(bool enabledd)
        {
            foreach (MeshCollider v in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                v.enabled = enabledd;
            }
        }

        public static void Drive()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
            }

            if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position -= GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 20f;
            }
        }

        public static void TpToStump()
        {
            input = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer").GetComponent<ControllerInputPoller>();
            if (GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").activeSelf == true)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = false;
                    }
                    GorillaLocomotion.Player.Instance.transform.position = new Vector3(-66.4848f, 11.8871f, -82.6619f);
                }
                else
                {
                    foreach (MeshCollider mesh in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        mesh.enabled = true;
                    }
                }
            }
        }
        static ControllerInputPoller input;
    }
}
