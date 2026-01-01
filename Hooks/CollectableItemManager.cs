using System;
using System.Collections.Generic;
using HarmonyLib;
using Newtonsoft.Json;
using Silksong.Rando.Locations;
using Silksong.Rando.Logic;

namespace Silksong.Rando.Hooks
{
    [HarmonyPatch]
    public class CollectableItemManagerHooks
    {

        public static List<string> cachedItems = new();
        
        [HarmonyPatch(typeof(CollectableItemManager), nameof(CollectableItemManager.Awake))]
        [HarmonyPrefix]
        public static void BeginSceneTransition(CollectableItemManager __instance)
        {
            var locationData = JsonConvert.DeserializeObject<Dictionary<string, ItemLocationData>>(ModResources.LoadData("locations"));


            if (cachedItems.Count != locationData.Count)
            {
                cachedItems.Clear();
                foreach (var loc in locationData)
                {
                    cachedItems.Add(RandoPlugin.GetCollectableItem(loc.Value.item, loc.Key).name);
                }
            }
            
           
        }

        [HarmonyPatch(typeof(CollectableItemManager), nameof(CollectableItemManager.IsItemInMasterList), typeof(string))]
        [HarmonyPrefix]
        public static bool IsItemInMasterList(CollectableItemManager __instance, ref bool __result, string itemName)
        {
            if (cachedItems.Contains(itemName))
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
}