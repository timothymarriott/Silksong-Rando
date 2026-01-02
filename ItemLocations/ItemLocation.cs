using System;
using Newtonsoft.Json;
using Silksong.Rando.Map;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;

[Serializable]
public class ItemLocationData
{
    public string locationType = "";
    public string item = "";
    public string scene = "";

    public Vector2 PositionInScene = new Vector2(0, 0);

    public string GetID()
    {
        return scene + "|" + item;
    }
}

public abstract class ItemLocation
{

    public ItemLocationData locationData = new();

    public abstract string GetItem();

    private string replacement = "";

    public string GetLocationID()
    {
        return (RandoPlugin.GM.sceneName + "|" + GetItem());
    }
    
    public void AddToCurrentScene()
    {
        locationData.locationType = GetType().Name;
        locationData.item = GetItem();
        locationData.scene = RandoPlugin.GM.sceneName;
        locationData.PositionInScene = GetPosition();
        if (LocationFinder.IsSearching)
            LocationFinder.ItemLocations.TryAdd(GetLocationID(), this);

        if (RandoPlugin.Instance.GameMode.Enabled)
        {
            if (RandoPlugin.Instance.ItemReplacements.ContainsKey(GetLocationID()))
            {
                if (!SaveData.Instance.CollectedChecks.Contains(GetLocationID()))
                {
                    SetReplacement(RandoPlugin.Instance.ItemReplacements[GetLocationID()]);
                }
                else
                {
                    SetReplacement("Already Collected");
                }
                
            }
        }
        
    }

    public void SetReplacement(string id)
    {
        replacement = id;
        RandoPlugin.Log.LogInfo(GetLocationID() + " -> " + (RandoPlugin.Instance.Map.mode == MapMode.Spoiler ? replacement : "SPOILERS") + (IsChecked() ? " checked" : " unchecked"));
        SetItem(id);
    }

    public virtual Vector2 GetPosition()
    {
        return GetObj().transform.position;
    }
    
    public abstract GameObject GetObj();

    public virtual void SetItem(string item)
    {
        if (!IsChecked())
        {
            var res = CreateItemPickup(item);
            res.transform.position = GetObj().transform.position;
        }
    }

    public void AwardCollectable()
    {
        if (!IsChecked())
        {
            RandoPlugin.GetCollectableItem(replacement, GetLocationID()).Get(1);
        }
    }

    protected bool IsChecked()
    {
        return SaveData.Instance.CollectedChecks.Contains(GetLocationID());
    }

    public CollectableItemPickup CreateItemPickup(string item)
    {

        GameObject obj = Object.Instantiate(GlobalSettings.Gameplay.CollectableItemPickupPrefab.gameObject);
        CollectableItemPickup pickup = obj.GetComponent<CollectableItemPickup>();
        RandoPlugin.Instance.PickupsToIgnore.Add(pickup);
        
        
        pickup.SetItem(RandoPlugin.GetCollectableItem(item, GetLocationID()));

        return pickup;
    }
    
}