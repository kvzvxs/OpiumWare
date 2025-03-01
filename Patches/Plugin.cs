using BepInEx;
using System.ComponentModel;

namespace kennMenu.Patches
{
    [Description(kennMenu.PluginInfo.Description)]
    [BepInPlugin(kennMenu.PluginInfo.GUID, kennMenu.PluginInfo.Name, kennMenu.PluginInfo.Version)]
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
