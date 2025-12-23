using System.Linq;
using HarmonyLib;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;

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

        if (__instance.name == "Big Flower")
        {
            PollipBulbLocation loc = new PollipBulbLocation(__instance.transform.GetChild(1).GetComponent<PlayMakerFSM>());
            loc.AddToCurrentScene();
        }

        if (__instance.name == "moss_berry_fruit")
        {
            MossberryLocation loc = new MossberryLocation(__instance);
            loc.AddToCurrentScene();
        }

        if (__instance.name == "Spinner Boss" && __instance.FsmName == "Control")
        {
            var loc = new NeedolinLocation(__instance);
            loc.AddToCurrentScene();
        }

        if (__instance.name == "Seamstress" && __instance.FsmName == "Dialogue")
        {
            var loc = new BrollyLocation(__instance);
            loc.AddToCurrentScene();
        }

        if (__instance.name == "Librarian" && __instance.FsmName == "Dialogue" &&
            __instance.GetState("Open Relic Board") != null)
        {
            var loc = new VaultMelodyLocation(__instance);
            loc.AddToCurrentScene();
        }
        
        

        if (__instance.name == "puzzle cylinders" && __instance.FsmName == "Cylinder States")
        {
            var loc = new ArchitectMelodyLocation(__instance);
            loc.AddToCurrentScene();
        }

        if (__instance.name == "Last Conductor NPC" && __instance.FsmName == "Dialogue")
        {
            var loc = new ConductorMelodyLocation(__instance);
            loc.AddToCurrentScene();
        }

    }
}