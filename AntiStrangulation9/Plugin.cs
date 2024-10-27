using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp3114;
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
            Exiled.Events.Handlers.Scp3114.Strangling += OnStrangling;
            harmony.PatchAll();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            plugin = null;
            Exiled.Events.Handlers.Scp3114.Strangling -= OnStrangling;
            harmony.UnpatchAll();
            base.OnDisabled();
        }

        private void OnStrangling(StranglingEventArgs ev) => ev.IsAllowed = false;
    }
}
