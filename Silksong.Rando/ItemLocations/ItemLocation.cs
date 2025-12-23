using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;

[Serializable]
public class ItemLocationData
{
    public string locationType;
    public string item;
    public string scene;
    public float positionInSceneX;
    public float positionInSceneY;

    public Vector2 PositionInScene => new Vector2(positionInSceneX, positionInSceneY);
}

public abstract class ItemLocation
{

    public ItemLocationData locationData = new();

    public abstract string GetItem();

    public string GetLocationID()
    {
        return (RandoPlugin.GM.sceneName + "|" + GetItem());
    }
    
    public void AddToCurrentScene()
    {
        locationData.locationType = GetType().Name;
        locationData.item = GetItem();
        locationData.scene = RandoPlugin.GM.sceneName;
        var pos = GetPosition();
        locationData.positionInSceneX = pos.x;
        locationData.positionInSceneY = pos.y;
        if (LocationFinder.IsSearching)
            LocationFinder.ItemLocations.TryAdd(GetLocationID(), this);

        if (RandoPlugin.instance.GameMode.Enabled)
        {
            if (RandoPlugin.instance.ItemReplacements.ContainsKey(GetLocationID()))
            {
                SetItem(RandoPlugin.instance.ItemReplacements[GetLocationID()]);
            }
            else
            {
                SetItem(GetItem());
            }
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