using HarmonyLib;
using Mirror;
using PlayerRoles.PlayableScps.Scp3114;
using static PlayerRoles.PlayableScps.Scp3114.Scp3114Strangle;

namespace AntiStrangulation.Patches
{
    [HarmonyPatch(typeof(Scp3114Strangle), nameof(Scp3114Strangle.ProcessAttackRequest))]

    public class Scp3114Patch
    {
        static bool Prefix(Scp3114Strangle __instance, NetworkReader reader, ref StrangleTarget? __result)
        {
            __result = default;
            return false;
        }
    }
}