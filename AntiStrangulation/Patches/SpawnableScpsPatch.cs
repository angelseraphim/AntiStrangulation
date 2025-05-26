using HarmonyLib;
using LabApi.Features.Console;
using PlayerRoles;
using PlayerRoles.RoleAssign;

namespace AntiStrangulation.Patches
{
    [HarmonyPatch(typeof(ScpSpawner), nameof(ScpSpawner.SpawnableScps), MethodType.Getter)]
    internal static class SpawnableScpsPatch
    {
        private static void Postfix(ref PlayerRoleBase[] __result)
        {
            if (Plugin.config.DisableAutoSpawn)
                return;

            if (!PlayerRoleLoader.AllRoles.TryGetValue(RoleTypeId.Scp3114, out var playerRoleBase))
            {
                Logger.Warn("Scp3114 role base not found in PlayerRoleLoader.AllRoles");
                return;
            }

            if (__result.Contains(playerRoleBase))
            {
                Logger.Warn("Scp3114 role base already contains in PlayerRoleLoader.AllRoles");
                return;
            }

            var newList = new PlayerRoleBase[__result.Length + 1];
            __result.CopyTo(newList, 0);

            newList[__result.Length] = playerRoleBase;
            __result = newList;
        }
    }
}
