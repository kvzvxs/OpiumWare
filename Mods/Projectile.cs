using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;
using static NetworkSystem;
using static kennMenu.Menu.Main;

namespace kennMenu.Mods.Spammers
{
    internal class Projectile
    {
        public static float f;
        public static void SBSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-675036877);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void WBSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-1674517839);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void IceSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-1671677000);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1277271056;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void SlingshotSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-820530352);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = 1432124712;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void DeadshotSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(693334698);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = 163790326;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void CloudSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(1511318966);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = 16948542;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void CupidSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(825718363);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = 1848916225;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void ElfSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(1705139863);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -67783235;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void RockSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-622368518);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void PepperSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-1280105888);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -748577108;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void SpiderSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-790645151);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1232128945;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void SquareSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-666337545);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void RoundSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-160604350);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void RollSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-1433633837);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void CCSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(2061412059);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void CoalSpam()
        {
            if (f < Time.time)
            {
                f = Time.time + 0.05f;
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    GameObject hash = ObjectPools.instance.Instantiate(-1433634409);
                    SlingshotProjectile slingshotProjectile = hash.GetComponent<SlingshotProjectile>();
                    var trail = -1;
                    var attachtrail = ObjectPools.instance.Instantiate(trail).GetComponent<SlingshotProjectileTrail>();
                    var counter = 0;
                    var h = (Time.frameCount / 180f) % 1f;
                    slingshotProjectile.Launch(GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 65f, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, Color.HSVToRGB(h, 1f, 1f));
                    attachtrail.AttachTrail(hash, false, false);
                }
            }
        }

        public static void FastSnowballs()
        {
            GetProjectile("LMACE. LEFT.");
            foreach (SnowballThrowable snowball in snowballs)
            {
                snowball.linSpeedMultiplier = 10f;
                snowball.maxLinSpeed = 99999f;
                snowball.maxWristSpeed = 99999f;
            }
        }

        public static void WaterSplashHands()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (Time.time > splashDel)
                {
                    GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", RpcTarget.All, new object[]
                    {
                        GorillaTagger.Instance.rightHandTransform.position,
                        GorillaTagger.Instance.rightHandTransform.rotation,
                        4f,
                        100f,
                        true,
                        false
                    });
                    RPCProtection();
                    splashDel = Time.time + 0.1f;
                }
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (Time.time > splashDel)
                {
                    GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", RpcTarget.All, new object[]
                    {
                        GorillaTagger.Instance.leftHandTransform.position,
                        GorillaTagger.Instance.leftHandTransform.rotation,
                        4f,
                        100f,
                        true,
                        false
                    });
                    RPCProtection();
                    splashDel = Time.time + 0.1f;
                }
            }
        }

        public static void GrabBug()
        {
            if (rightGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void GrabBat()
        {
            if (rightGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }
    }
}
