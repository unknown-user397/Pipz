using BepInEx;
using BepInEx.Logging;
using HarmonyLib;


namespace ModularUpgrades.Pipz
{
    /// <summary>
    /// Template mod plugin - copy this to create new mods
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class PipzPlugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;
        private Harmony _harmony;

        private void Awake()
        {
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            // Apply Harmony patches
            _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(typeof(PipzPlugin).Assembly);
            
            Logger.LogInfo("Harmony patches applied successfully!");
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }
    }

    public static class PluginInfo
    {
        public const string PLUGIN_GUID = "com.ostranauts.Pipz";
        public const string PLUGIN_NAME = "Pipz Mod";
        public const string PLUGIN_VERSION = "0.1.0";
    }
}


