using HarmonyLib;
using Silksong_Rando;

[HarmonyPatch(typeof(GeoRock), nameof(GeoRock.Start))]
class GeoRock_Start_Patch
{
    public static void Prefix(GeoRock __instance)
    {
        GeoRockLocation loc = new GeoRockLocation(__instance);
        loc.AddToCurrentScene();
    }
}