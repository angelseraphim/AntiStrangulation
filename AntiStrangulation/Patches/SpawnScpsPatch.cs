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

            ScpSpawner.EnqueuedScps.Clear();

            for (int i = 0; i < targetScpNumber; i++)
            {
                RoleTypeId nextRole = Plugin.random.Next(0, ScpSpawner.MaxSpawnableScps) == 0 && !ScpSpawner.EnqueuedScps.Contains(RoleTypeId.Scp3114)
                    ? RoleTypeId.Scp3114
                    : ScpSpawner.NextScp;

                if (!ScpSpawner.EnqueuedScps.Contains(nextRole) && ScpSpawner.EnqueuedScps.Count < ScpSpawner.MaxSpawnableScps)
                    ScpSpawner.EnqueuedScps.Add(nextRole);
            }

            List<ReferenceHub> chosenPlayers = ScpPlayerPicker.ChoosePlayers(targetScpNumber);

            foreach (RoleTypeId role in ScpSpawner.EnqueuedScps.ToArray())
            {
                Logger.Debug(role.ToString(), Plugin.config.Debug);

                ScpSpawner.EnqueuedScps.Remove(role);
                ScpSpawner.AssignScp(chosenPlayers, role, ScpSpawner.EnqueuedScps);
            }

            return false;
        }
    }
}
