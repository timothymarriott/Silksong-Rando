using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;

[Serializable]
public class ItemLocationData
{
    public float RoomSizeX;
    public float RoomSizeY;
    public float PositionInSceneX;
    public float PositionInSceneY;
}

public abstract class ItemLocation
{

    public ItemLocationData locationData = new();

    public abstract string GetItem();

    public string GetLocationID()
    {
        return (GameManager.instance.sceneName + "|" + GetItem());
    }
    
    public void AddToCurrentScene()
    {
        locationData.RoomSizeX = GameManager.instance.tilemap.width;
        locationData.RoomSizeY = GameManager.instance.tilemap.height;
        var pos = GetPosition();
        locationData.PositionInSceneX = pos.x;
        locationData.PositionInSceneY = pos.y;
        RandoPlugin.instance.ItemLocations.TryAdd(GetLocationID(), this);
        
        RandoPlugin.Log.LogInfo(GetLocationID());
        if (RandoPlugin.instance.ItemReplacements.ContainsKey(GetLocationID()))
        {
            SetItem(RandoPlugin.instance.ItemReplacements[GetLocationID()]);
        }
        else
        {
            SetItem($"");
        }
    }

    public virtual Vector2 GetPosition()
    {
        return GetObj().transform.position;
    }
    
    public abstract GameObject GetObj();

    public virtual void SetItem(string item)
    {
        var res = CreateItemPickup(item);
        res.transform.position = GetObj().transform.position;
    }

    public CollectableItemPickup CreateItemPickup(string item)
    {

        GameObject obj = Object.Instantiate(GlobalSettings.Gameplay.CollectableItemPickupPrefab.gameObject);
        CollectableItemPickup pickup = obj.GetComponent<CollectableItemPickup>();
        RandoPlugin.instance.PickupsToIgnore.Add(pickup);
        
        
        pickup.SetItem(RandoPlugin.GetCollectableItem(item));

        return pickup;
    }
    
}