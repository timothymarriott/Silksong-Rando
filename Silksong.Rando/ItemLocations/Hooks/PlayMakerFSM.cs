using HarmonyLib;

namespace Silksong.Rando.Hooks;

[HarmonyPatch(typeof(PlayMakerFSM), nameof(PlayMakerFSM.Start))]
class PlayMakerFSM_Start_Patch
{
    public static void Prefix(PlayMakerFSM __instance)
    {
        if (__instance.name == "Shrine Weaver Ability")
        {
            ShrineWeaverAbilityLocation loc = new ShrineWeaverAbilityLocation(__instance);
            loc.AddToCurrentScene();
        }

    }
}