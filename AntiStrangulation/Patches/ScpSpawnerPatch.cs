using HarmonyLib;
using PlayerRoles.RoleAssign;
using PlayerRoles;
using System.Collections.Generic;

namespace AntiStrangulation.Patches
{
    [HarmonyPatch(typeof(ScpSpawner), nameof(ScpSpawner.AssignScp))]
    internal class ScpSpawnerPatch
    {
        public static bool Prefix(RoleTypeId scp, List<RoleTypeId> otherScps)
        {
            bool Is3114 = Plugin.plugin.Config.ShouldSpawn ? false : scp == RoleTypeId.Scp3114;
            return !Is3114;
        }
    }
}
