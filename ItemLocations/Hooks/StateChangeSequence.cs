using System.Linq;
using HarmonyLib;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;

namespace Silksong.Rando.Locations.Hooks;

[HarmonyPatch]
class StateChangeSequence_Hook
{

    [HarmonyPatch(typeof(StateChangeSequence), nameof(StateChangeSequence.Start))]
    [HarmonyPrefix]
    public static void Start(StateChangeSequence __instance)
    {

        if (RandoPlugin.GM.sceneName == "Bellshrine_Enclave") return;

        if (__instance.name == "Bellshrine Sequence" || __instance.name == "Bellshrine Sequence Bellhart")
        {
            var loc = new BellshrineLocation(__instance);
            loc.AddToCurrentScene();
        }

    }

    [HarmonyPatch(typeof(StateChangeSequence), nameof(StateChangeSequence.IncrementState))]
    [HarmonyPostfix]
    public static void IncrementState(StateChangeSequence __instance)
    {
        if (RandoPlugin.GM.sceneName == "Bellshrine_Enclave") return;
        RandoPlugin.Log.LogInfo($"StateChangeSequence {__instance.name} incremented from {__instance.stateValue - 1} to {__instance.stateValue}");
    }

    [HarmonyPatch(typeof(StateChangeSequence), nameof(StateChangeSequence.SetIsCompleteBool))]
    [HarmonyPrefix]
    public static bool SetIsCompleteBool(StateChangeSequence __instance)
    {
        if (RandoPlugin.GM.sceneName == "Bellshrine_Enclave") return true;

        RandoPlugin.Log.LogInfo("StateChangeSequence " + __instance.name + " set " + __instance.isCompleteBool);
        if (RandoPlugin.instance.GameMode.Enabled)
        {
            BellshrineLocation.OnSetIsCompleteBool(__instance);
            return false;
        }
        
        
        return true;

    }
}