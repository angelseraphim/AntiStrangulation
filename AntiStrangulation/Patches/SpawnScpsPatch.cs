using HarmonyLib;
using LabApi.Features.Console;
using PlayerRoles;
using PlayerRoles.RoleAssign;
using LabApi.Features.Wrappers;

namespace AntiStrangulation.Patches
{
    [HarmonyPatch(typeof(ScpSpawner), nameof(ScpSpawner.SpawnScps))]
    internal static class SpawnScpsPatch
    {
        private static bool Prefix(int targetScpNumber)
        {
            // Only spawn SCP-3114 if there are enough players in the server and the spawn chance is met
            if (Plugin.config.DisableAutoSpawn || Plugin.config.MinimumPlayers > Player.Count ||
                Plugin.random.Next(0, 100) >= Plugin.config.SpawnChance)
                return true;

            ScpSpawner.EnqueuedScps.Clear();
            ScpSpawner.EnqueuedScps.Add(RoleTypeId.Scp3114);

            for (var i = 0; i < targetScpNumber - 1; i++)
            {
                ScpSpawner.EnqueuedScps.Add(ScpSpawner.NextScp);
            }

            var chosenPlayers = ScpPlayerPicker.ChoosePlayers(targetScpNumber);
            foreach (var role in ScpSpawner.EnqueuedScps.ToArray())
            {
                Logger.Debug(role.ToString(), Plugin.config.Debug);

                ScpSpawner.EnqueuedScps.Remove(role);
                ScpSpawner.AssignScp(chosenPlayers, role, ScpSpawner.EnqueuedScps);
            }

            return false;
        }
    }
}