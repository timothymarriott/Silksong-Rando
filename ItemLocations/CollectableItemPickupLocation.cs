using System;
using PrepatcherPlugin;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;



public class CollectableItemPickupLocation : ItemLocation
{
    private CollectableItemPickup pickup;
    public CollectableItemPickupLocation(CollectableItemPickup pickup)
    {
        this.pickup = pickup;
    }

    public override string GetItem()
    {
        
        return pickup.item.name;
    }
    
    public override GameObject GetObj()
    {
        return pickup.gameObject;
    }

    public override void SetItem(string item)
    {
        if (IsChecked())
        {
            Object.Destroy(pickup.gameObject);
            return;
        }
        RandoPlugin.Log.LogInfo("Setting item to " + item);
        pickup.SetItem(RandoPlugin.GetCollectableItem(item, GetLocationID()));
    }

    public static void InstallHooks()
    {
        PlayerDataVariableEvents.OnGetInt += (pd, name, current) =>
        {
            if (name == nameof(PlayerData.dicePilgrimState) && RandoPlugin.instance.GameMode.Enabled)
            {
                return 1;
            }

            return current;
        };
    }
}
