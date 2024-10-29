using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles.Spectating;
using System;

namespace AntiStrangulation
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "AntiStrangulation";
        public override string Name => "AntiStrangulation";
        public override string Author => "angelseraphim.";
        public override Version RequiredExiledVersion => new Version(8, 9, 11);

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
