using HarmonyLib;
using OpiumWare.Mods;
using System;
using UnityEngine;
using static OpiumWare.Menu.Main;

namespace OpiumWare.Patches
{
    [HarmonyPatch(typeof(LegalAgreements), "PostUpdate")]
    public class TOSPatch
    {
        public static bool enabled = false;
        private static bool Prefix(LegalAgreements __instance)
        {
            if (enabled)
            {
                __instance.TurnPage(999);
                Traverse.Create(__instance).Field("controllerBehaviour").Field("buttonDown").SetValue(true);
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(ModIOTermsOfUse), "PostUpdate")]
    public class TOSPatch2
    {
        private static bool Prefix(LegalAgreements __instance)
        {
            if (TOSPatch.enabled)
            {
                __instance.TurnPage(999);
                Traverse.Create(__instance).Field("controllerBehaviour").Field("buttonDown").SetValue(true);
                return false;
            }
            return true;
        }
    }
}
