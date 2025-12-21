using HarmonyLib;
using Silksong_Rando;

[HarmonyPatch(typeof(BreakableHolder), nameof(BreakableHolder.Start))]
class BreakableHolder_Start_Patch
{
    public static void Prefix(BreakableHolder __instance)
    {
        RandoPlugin.Log.LogInfo(__instance.persistent.ItemData.ID);
        if (__instance.persistent.ItemData.ID.StartsWith("Shell Shard"))
        {
            ShardRockLocation loc = new ShardRockLocation(__instance);
            loc.AddToCurrentScene();
        }
    }
}