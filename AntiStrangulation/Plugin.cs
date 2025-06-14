using HarmonyLib;
using LabApi.Loader.Features.Plugins;
using System;

namespace AntiStrangulation
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "AntiStrangulation";
        public override string Description => "AntiStrangulation";
        public override string Author => "angelseraphim.";
        public override Version Version => new Version(2, 3, 0);
        public override Version RequiredApiVersion => new Version(1, 0, 2);

        internal static Config config;
        internal static Random random;

        private Harmony harmony;

        public override void Enable()
        {
            config = Config;
            random = new Random();
            harmony = new Harmony(Name);

            harmony.PatchAll();
        }

        public override void Disable()
        {
            harmony.UnpatchAll();

            config = null;
            random = null;
            harmony = null;
        }
    }
}
