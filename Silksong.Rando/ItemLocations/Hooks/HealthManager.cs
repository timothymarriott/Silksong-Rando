using System.Linq;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;

namespace Silksong.Rando.Locations.Hooks;

[HarmonyPatch(typeof(HealthManager), nameof(HealthManager.Start))]
class HealthManager_Start_Patch
{
    public static void Prefix(HealthManager __instance)
    {
        if (__instance.gameObject.name.StartsWith("Aspid Collector"))
        {
            RandoPlugin.Log.LogInfo(__instance.gameObject.name + "AAA");
            for (int i = 0; i < __instance.transform.childCount; i++) 
            {
                if (__instance.transform.GetChild(i).gameObject.name == "Mossberry Pickup")
                {
                    RandoPlugin.Log.LogInfo("We ballin");
                    MossberryLocation loc = new MossberryLocation(__instance, __instance.transform.GetChild(i).GetComponent<PlayMakerFSM>());
                    loc.AddToCurrentScene();
                }
            }
        }
        
    }
}