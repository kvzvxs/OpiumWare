using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace opiumMenu.Mods.Spammers
{
    internal class Projectile
    {
        public static void SnowSpam()
        {
            if (ControllerInputPoller.instance.rightGrab) // Right Hand Press
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 70f; // How fast projectile moves forward
                int proj = -675036877; // Projectile
                int trail = -1; // Projectile Trail
                var col = new Color(0f, 0f, 0f); // red green blue
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab) // Left Hand Press
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 70f; // How fast projectile moves forward
                int proj = -675036877; // Projectile
                int trail = -1; // Projectile Trail
                var col = new Color(0f, 0f, 0f); // red green blue
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void IceSpam()
        {
            if (ControllerInputPoller.instance.rightGrab) // Right Hand Press
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 70f; // How fast projectile moves forward
                int proj = -1671677000; // Projectile
                int trail = -1277277056; // Projectile Trail
                var col = new Color(0f, 0f, 0f); // red green blue
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab) // Left Hand Press
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 70f; // How fast projectile moves forward
                int proj = -1671677000; // Projectile
                int trail = -1277277056; // Projectile Trail
                var col = new Color(0f, 0f, 0f); // red green blue
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        public static void SpiderSpam()
        {
            if (ControllerInputPoller.instance.rightGrab) // Right Hand Press
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 70f; // How fast projectile moves forward
                int proj = -790645151; // Projectile
                int trail = -1232128945; // Projectile Trail
                var col = new Color(255, 255, 255); // red green blue
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
            if (ControllerInputPoller.instance.leftGrab) // Left Hand Press
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 70f; // How fast projectile moves forward
                int proj = -790645151; // Projectile
                int trail = -1232128945; // Projectile Trail
                var col = new Color(255, 255, 255); // red green blue
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }

        private static void LaunchProjectile(int projHash, int trailHash, Vector3 pos, Vector3 vel, Color col)
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
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
        }

        public static void GrabBat()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
        }
    }
}
