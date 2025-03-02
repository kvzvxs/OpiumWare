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
using static OpiumWare.Menu.Main;
using static Unity.Collections.Unicode;

namespace OpiumWare.Mods.Spammers
{
    internal class Projectile
    {
        public static void SnowballGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -675036877;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -675036877;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void WaterBalloonGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -1674517839;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -1674517839;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void IceGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -1671677000;
                int trail = -1277271056;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -1671677000;
                int trail = -1277271056;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void SlingshotGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -820530352;
                int trail = 1432124712;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -820530352;
                int trail = 1432124712;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void DeadshotGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = 693334698;
                int trail = 163790326;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = 693334698;
                int trail = 163790326;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void CloudGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = 1511318966;
                int trail = 16948542;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = 1511318966;
                int trail = 16948542;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void CupidGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = 825718363;
                int trail = 1848916225;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = 825718363;
                int trail = 1848916225;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void ElfGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = 1705139863;
                int trail = -67783235;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = 1705139863;
                int trail = -67783235;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void RockGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -622368518;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -622368518;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void PepperGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -1280105888;
                int trail = -748577108;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -1280105888;
                int trail = -748577108;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void SpiderGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -790645151;
                int trail = -1232128945;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -790645151;
                int trail = -1232128945;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void SquareGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -666337545;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -666337545;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void RoundGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -160604350;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -160604350;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void RollGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -1433633837;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -1433633837;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void CandyCaneGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = 2061412059;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = 2061412059;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void CoalGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -1433634409;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -1433634409;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void LaunchProjectile(int projHash, int trailHash, Vector3 pos, Vector3 vel, Color col)
        {
            var projectile = ObjectPools.instance.Instantiate(projHash).GetComponent<SlingshotProjectile>();
            if (trailHash != -1)
            {
                var trail = ObjectPools.instance.Instantiate(trailHash).GetComponent<SlingshotProjectileTrail>();
                trail.AttachTrail(projectile.gameObject, false, false);
            }
            var counter = 0;
            projectile.Launch(pos, vel, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, col);
        }

        public static void GrabBug()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void GrabBat()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }
    }
}