using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando;



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
        RandoPlugin.Log.LogInfo("Setting item to " + item);
        pickup.SetItem(RandoPlugin.GetCollectableItem(item));
    }
}
