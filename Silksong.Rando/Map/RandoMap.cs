using System.Collections.Generic;
using Newtonsoft.Json;
using PrepatcherPlugin;
using Silksong.Rando.Data;
using Silksong.Rando.Locations;
using UnityEngine;

namespace Silksong.Rando.Map;

public class RandoMap : MonoBehaviour
{
    public static GameManager GM => RandoPlugin.GM;

    public static RandoMap instance;
    
    private void Awake()
    {
        instance = this;

        PlayerDataVariableEvents.OnGetBool += (pd, fieldName, current) =>
        {
            if (fieldName == nameof(PlayerData.mapAllRooms))
            {
                return true;
            }
            return current;
        };

        PlayerDataVariableEvents<PlayerData.MapBoolList>.OnGetVariable += (pd, fieldName, current) =>
        {
            RandoPlugin.Log.LogInfo(fieldName);
            return current;
        };
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public enum PinColor
    {
        Black = 0,
        Red = 1,
        Yellow = 2,
        White = 3,
        Bronze = 4
    }
    
    public void CreateMapPin(ItemLocationData loc)
    {
        GM.gameMap.GetSceneInfo(loc.scene, GM.gameMap.GetMapZoneFromSceneName(loc.scene), out GameMapScene scene, out var scnobj, out var pos);
        Vector2 position = GM.gameMap.GetMapPosition(loc.PositionInScene, scene, scnobj, pos, GameScenes.Scenes[loc.scene].Size);

        Transform parent = GM.gameMap.compassIcon.transform.parent;
        
        for (int i = 0; i < GM.gameMap.compassIcon.transform.parent.childCount; i++)
        {
            if (GM.gameMap.compassIcon.transform.parent.GetChild(i).gameObject.name == "Map Markers")
            {
                parent = GM.gameMap.compassIcon.transform.parent.GetChild(i);
            }
        }
        
        

        PinColor color = PinColor.Black;

        if (RandoPlugin.instance.logic.HasCheck(loc.scene + "|" + loc.item))
        {
            color = PinColor.White;
        }
        
        GameObject obj = Instantiate(parent.GetChild((int)color).gameObject, parent);

        obj.transform.localScale = Vector3.one * 0.4f;

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        SavedItem itm = RandoPlugin.GetCollectableItem(loc.item);
        sr.sprite = itm.GetPopupIcon();
        
        
        obj.transform.SetLocalPosition2D(new Vector3(position.x, position.y, -1f));
        if (!obj.activeSelf)
            obj.SetActive(true);
    }

    public void CreateLocationPins()
    {
        var locationData = JsonConvert.DeserializeObject<Dictionary<string, ItemLocationData>>(ModResources.LoadData("locations"));

        foreach (var (id, data) in locationData)
        {
            CreateMapPin(data);
        }
    }

    
}
