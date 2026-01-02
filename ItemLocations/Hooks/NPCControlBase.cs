using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;

namespace Silksong.Rando.Locations.Hooks;

#if DEV

[HarmonyPatch]
class NPCControlBase_Hook
{


    public static List<ShopOwner> checkedOwners = new();
    
    [HarmonyPatch(typeof(NPCControlBase), nameof(NPCControlBase.Start))]
    [HarmonyPrefix]
    public static void Start(NPCControlBase __instance)
    {
        
        ShopOwner shop = null;
        __instance.TryGetComponent(out shop);
        if (__instance.transform.parent != null && __instance.transform.parent.GetComponent<ShopOwner>() != null)
        {
            shop = __instance.transform.parent.GetComponent<ShopOwner>();
        }
        
        if (shop && !checkedOwners.Contains(shop))
        {
            checkedOwners.Add(shop);
            var list = Object.Instantiate(shop.stockList);
            

            for (int i = 0; i < list.shopItems.Length; i++)
            {
                list.shopItems[i] = Object.Instantiate(list.shopItems[i]);
            }
            
            foreach (var item in list.shopItems)
            {
                if (!item.name.Contains("Shard Pouch") && !item.name.Contains("Rosary String"))
                {
                    var loc = new ShopItemLocation(shop, item);
                    loc.AddToCurrentScene();
                    loc.SetReplacement("Brolly");
                }
            }


            shop.stockList = list;
        }
        
    }
}
#endif