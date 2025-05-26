using HarmonyLib;
using PlayerRoles.RoleAssign;
using PlayerRoles;
using System.Collections.Generic;

namespace AntiStrangulation.Patches
{
    [HarmonyPatch(typeof(ScpSpawner), nameof(ScpSpawner.AssignScp))]
    internal class ScpSpawnerPatch
    {
        private static bool Prefix(List<ReferenceHub> chosenPlayers, RoleTypeId scp, List<RoleTypeId> otherScps)
        {
            if (Plugin.config.DisableAutoSpawn && scp == RoleTypeId.Scp3114)
                return false;

            return true;
        }
    }
}
