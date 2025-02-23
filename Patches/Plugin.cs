using BepInEx;
using System.ComponentModel;

namespace opiumMenu.Patches
{
    [Description(opiumMenu.PluginInfo.Description)]
    [BepInPlugin(opiumMenu.PluginInfo.GUID, opiumMenu.PluginInfo.Name, opiumMenu.PluginInfo.Version)]
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
