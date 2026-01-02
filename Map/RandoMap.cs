using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PrepatcherPlugin;
using Silksong.Rando.Data;
using Silksong.Rando.Locations;
using UnityEngine;

namespace Silksong.Rando.Map;

public enum MapMode
{
    No,
    Checks,
    Logic,
    Dev,
    Spoiler
}

public class RandoMap : MonoBehaviour
{
    public static GameManager GM => RandoPlugin.GM;

    private static RandoMap? instance;
    
    public static RandoMap Instance
    {
        get
        {
            if (instance == null)
            {
                throw new Exception("Map not setup.");
            }
            return instance;
        }
        set => instance = value;
    }

    public List<GameObject> CreatedMarkers = new List<GameObject>();

    public MapMode mode = MapMode.No;

    public List<string> AccessibleChecks = new();
    
    private void Awake()
    {
        Instance = this;

        PlayerDataVariableEvents.OnGetBool += (_, fieldName, current) =>
        {
            if (fieldName == nameof(PlayerData.mapAllRooms))
            {
                return true;
            }

            if (fieldName == nameof(PlayerData.hasQuill))
            {
                return true;
            }
            return current;
        };

    }

    private void Update()
    {
        if (PlayerData.instance != null)
            if (Input.GetKeyDown(KeyCode.T) && PlayerData.instance.isInventoryOpen)
            {
                mode = (MapMode)(((int)mode + 1) % Enum.GetNames(typeof(MapMode)).Length);
                Refresh();
            }
        
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.F11))
        {
            int seed = UnityEngine.Random.Range(0, int.MaxValue);
            RandoPlugin.Log.LogInfo($"Starting rando with seed {seed}");
            SaveData.Instance.RandoSeed = seed;
            SaveData.Instance.ItemReplacements = RandoPlugin.Instance.Logic.GenerateSeed(seed);
            Refresh();
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            instance = null;
        }
    }

    public void Refresh()
    {
        foreach (var marker in CreatedMarkers)
        {
            Destroy(marker);
        }
        
        CreateLocationPins();
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

        if (mode == MapMode.Checks || mode == MapMode.Logic || mode == MapMode.Spoiler)
        {
            if (!RandoPlugin.Instance.Logic.HasCheck(loc.GetID()))
            {
                return;
            }
        }
        
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

        if (RandoPlugin.Instance.Logic.HasCheck(loc.GetID()))
        {
            color = PinColor.White;
        }
        
        GameObject obj = Instantiate(parent.GetChild((int)color).gameObject, parent);
        
        CreatedMarkers.Add(obj);

        obj.transform.localScale = Vector3.one * 0.4f;

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

        if (mode == MapMode.Dev)
        {
            
            if (SaveData.Instance.ItemReplacements.ContainsKey(loc.GetID()))
            {
                SavedItem itm = RandoPlugin.GetCollectableItem(loc.item, loc.GetID());
                sr.sprite = itm.GetPopupIcon();
            }
            else
            {
                SavedItem itm = RandoPlugin.GetCollectableItem(loc.item, loc.GetID());
                sr.sprite = itm.GetPopupIcon();
                sr.color = Color.green;
            }
        

            if (!RandoPlugin.Instance.Logic.HasCheck(loc.scene + "|" + loc.item))
            {
                sr.color = Color.red;
            }
        }

        if (mode == MapMode.Spoiler)
        {
            if (SaveData.Instance.ItemReplacements.ContainsKey(loc.GetID()))
            {
                SavedItem itm = RandoPlugin.GetCollectableItem(SaveData.Instance.ItemReplacements[loc.GetID()], loc.GetID());
                sr.sprite = itm.GetPopupIcon();
            }
            else
            {
                SavedItem itm = RandoPlugin.GetCollectableItem(loc.item, loc.GetID());
                sr.sprite = itm.GetPopupIcon();
            }
        }
        
        if (mode == MapMode.Checks || mode == MapMode.Logic)
        {
            SavedItem itm = RandoPlugin.GetCollectableItem(loc.item, loc.GetID());
            sr.sprite = itm.GetPopupIcon();
        }
        
        if (mode == MapMode.Logic)
        {
            if (AccessibleChecks.Contains(loc.GetID()))
            {
                
            }
            else
            {
                sr.color *= new Color(1, 1, 1, 0.5f);
            }
        }
        
        
        
        if (SaveData.Instance.CollectedChecks.Contains(loc.GetID()))
        {
            
            sr.color *= new Color(1, 1, 1, 0f);
        }
        
        obj.transform.SetLocalPosition2D(new Vector3(position.x, position.y, -1f));
        if (!obj.activeSelf)
            obj.SetActive(true);
    }

    public void CreateLocationPins()
    {
        if (mode == MapMode.No) return;
        var locationData = RandoResources.ReadLocationsData();

        AccessibleChecks =
            RandoPlugin.Instance.Logic.GetAccessible(SaveData.Instance.ItemReplacements,
                SaveData.Instance.CollectedChecks);
        
        
        
        foreach (var (_, data) in locationData)
        {
            CreateMapPin(data);
        }
    }

    
}
