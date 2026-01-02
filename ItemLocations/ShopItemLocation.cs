using System;
using System.Collections.Generic;
using HarmonyLib;
using TeamCherry.Localization;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;


#if DEV
public class ShopItemLocation : ItemLocation
{

    public ShopOwner shop;
    public ShopItem item;

    private string oldItem;
    
    public ShopItemLocation(ShopOwner shop, ShopItem item)
    {
        this.item = item;
        this.shop = shop;
        if (item.savedItem == null)
            oldItem = item.name;
        else oldItem = item.savedItem.name;
    }
    
    public override string GetItem()
    {
        RandoPlugin.Log.LogInfo("Got item " + oldItem + " from " + shop.name + " " + item.name);
        return oldItem;
    }
    
    public override GameObject GetObj()
    {
        return shop.gameObject;
    }

    public override void SetItem(string newItem)
    {
        
        RandoPlugin.Log.LogInfo("Setting " + shop.name + " " + item.name + "(" + GetLocationID() + ") to " + newItem);
        
        var collectable = RandoPlugin.GetCollectableItem(newItem, GetLocationID());
        item.playerDataBoolName = "CHECKED_" + GetLocationID();
        item.savedItem = null;
        
        if (collectable is CollectableItem col)
        {
            item.displayName = new LocalisedString("Rando", col.GetDisplayName(CollectableItem.ReadSource.Shop));
            item.description = new LocalisedString("Rando", col.GetDescription(CollectableItem.ReadSource.Shop));
            item.itemSprite = col.GetIcon(CollectableItem.ReadSource.Shop);
            item.itemSpriteScale = 1;
        }
        else
        {
            item.displayName = new LocalisedString("Rando", collectable.GetPopupName());
            item.description = new LocalisedString("Rando", "");
            item.itemSprite = collectable.GetPopupIcon();
            item.itemSpriteScale = 1;
        }

        item.onPurchase = new UnityEvent();
        item.onPurchase.AddListener(() =>
        {
            AwardCollectable();
        });
        /*
        if (item.extraAppearConditions.TestGroups.Length == 0)
        {
            item.extraAppearConditions.TestGroups =
            [
                new PlayerDataTest.TestGroup()
                {
                    Tests =
                    [
                        new PlayerDataTest.Test()
                        {
                            FieldName = "CHECKED_" + GetLocationID(),
                            Type = PlayerDataTest.TestType.Bool
                        }
                    ]
                }
            ];
        }
        else
        {
            List<PlayerDataTest.TestGroup> groups = new();
            foreach (var testGroup in item.extraAppearConditions.TestGroups)
            {
                groups.Add(new PlayerDataTest.TestGroup()
                {
                    Tests = testGroup.Tests.AddToArray(new PlayerDataTest.Test()
                    {
                        FieldName = "CHECKED_" + GetLocationID(),
                        Type = PlayerDataTest.TestType.Bool
                    })
                });
            }

            item.extraAppearConditions.TestGroups = groups.ToArray();
        }
        */


    }
}
#endif