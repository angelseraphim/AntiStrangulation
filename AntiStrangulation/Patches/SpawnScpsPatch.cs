using HarmonyLib;
using LabApi.Features.Console;
using PlayerRoles;
using PlayerRoles.RoleAssign;
using System.Collections.Generic;

namespace AntiStrangulation.Patches
{
    [HarmonyPatch(typeof(ScpSpawner), nameof(ScpSpawner.SpawnScps))]
    internal static class SpawnScpsPatch
    {
        private static bool Prefix(int targetScpNumber)
        {
            if (Plugin.config.DisableAutoSpawn)
                return true;

            List<RoleTypeId> roles = new List<RoleTypeId>();

            ScpSpawner.EnqueuedScps.Clear();

            for (int i = 0; i < targetScpNumber; i++)
            {
                if (Plugin.random.Next(0, ScpSpawner.MaxSpawnableScps) < 2 && !roles.Contains(RoleTypeId.Scp3114))
                {
                    roles.Add(RoleTypeId.Scp3114);
                    continue;
                }

                roles.Add(ScpSpawner.NextScp);
            }

            foreach (RoleTypeId role in roles)
            {
                Logger.Info(role.ToString());
                ScpSpawner.EnqueuedScps.Add(role);
            }

            List<ReferenceHub> chosenPlayers = ScpPlayerPicker.ChoosePlayers(targetScpNumber);

            while (ScpSpawner.EnqueuedScps.Count > 0)
            {
                RoleTypeId scp = ScpSpawner.EnqueuedScps[0];
                ScpSpawner.EnqueuedScps.RemoveAt(0);
                ScpSpawner.AssignScp(chosenPlayers, scp, ScpSpawner.EnqueuedScps);
            }

            return false;
        }
    }
}
