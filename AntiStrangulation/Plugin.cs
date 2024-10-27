using Exiled.API.Features;
using HarmonyLib;

namespace AntiStrangulation
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "AntiStrangulation";
        public override string Name => "AntiStrangulation";
        public override string Author => "angelseraphim.";

        public static Plugin plugin;
        public static Harmony harmony;
        public override void OnEnabled()
        {
            plugin = this;
            harmony = new Harmony("AntiStrangulation");
            harmony.PatchAll();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            plugin = null;
            harmony.UnpatchAll();
            base.OnDisabled();
        }
    }
}
