using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;

namespace Silksong.Rando.Locations.Hooks;

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

        if (__instance.name == "Nectar Pickup")
        {
            PollipBulbLocation loc = new PollipBulbLocation(__instance);
            loc.AddToCurrentScene();
        }

    }
}