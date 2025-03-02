using BepInEx;
using System.ComponentModel;

namespace OpiumWare.Patches
{
    [Description(OpiumWare.PluginInfo.Description)]
    [BepInPlugin(OpiumWare.PluginInfo.GUID, OpiumWare.PluginInfo.Name, OpiumWare.PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void OnEnable()
        {
            Menu.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            Menu.RemoveHarmonyPatches();
        }
    }
}
