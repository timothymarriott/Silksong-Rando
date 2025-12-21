using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using GlobalEnums;
using HarmonyLib;
using Newtonsoft.Json;
using RandomizerCore.Extensions;
using Silksong.FsmUtil;
using TeamCherry.Localization;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Silksong_Rando;

[BepInAutoPlugin(id: "io.github.timothymarriott.rando")]
public partial class RandoPlugin : BaseUnityPlugin
{
    public static RandoPlugin instance;

    public static ManualLogSource Log => instance.Logger;

    public Dictionary<string, ItemLocation> ItemLocations = new();

    public Dictionary<string, ItemLocationData> ItemLocationData = new();

    public int loadedScene = 0;

    public bool StartedLoading = false;

    public Dictionary<string, string> ItemReplacements = new();

    public List<CollectableItemPickup> PickupsToIgnore = new List<CollectableItemPickup>();
    
    public Font trajanBold;
    public Font trajanNormal;
    public Font arial;

    public static GameManager GM;
    
    private void Awake()
    {
        
        
        
        instance = this;
        
        ConsoleMover.Move();
        
        Utils.Logger = Logger;
        Utils.LoadResources();
        Logger.LogInfo($"Rando Loaded.");
        
        
        

        string replacementText = File.ReadAllText(Application.persistentDataPath + "\\rando\\replacements.json");

        ItemReplacements = JsonConvert.DeserializeObject<Dictionary<string, string>>(replacementText);
        ItemLocationData =
            JsonConvert.DeserializeObject<Dictionary<string, ItemLocationData>>(
                File.ReadAllText(Application.persistentDataPath + "\\rando\\locations.json"));


    }

    private void Start()
    {
        new Harmony(RandoPlugin.Id).PatchAll(typeof(RandoPlugin).Assembly);
        
    }

    private void OnGUI()
    {
        if (trajanBold == null || trajanNormal == null || arial == null)
        {
            foreach (Font f in Resources.FindObjectsOfTypeAll<Font>())
            {
            
                if (f != null && f.name == "TrajanPro-Bold")
                {
                    trajanBold = f;
                }

                if (f != null && f.name == "TrajanPro-Regular")
                {
                    trajanNormal = f;
                }

                //Just in case for some reason the computer doesn't have arial
                if (f != null && f.name == "Perpetua")
                {
                    arial = f;
                }
            }
        }
        if (GameManager.SilentInstance == null) return;

        GUI.skin.font = arial;
        GUI.Label(new Rect(0, Screen.height - 30f, 100, 100), GameManager.instance.GetSceneNameString(), new GUIStyle()
        {
            fontSize = 30,
            fontStyle = FontStyle.Normal,
            normal = new GUIStyleState()
            {
                textColor = Color.white
            }
        });
    }

    public static SavedItem GetCollectableItem(string target)
    {
        if (CollectableItemManager.Instance.masterList.GetByName(target) != null)
        {
            return CollectableItemManager.Instance.masterList.GetByName(target);
        }

        if (ToolItemManager.Instance.toolItems.GetByName(target) != null)
        {
            return ToolItemManager.Instance.toolItems.GetByName(target);
        }

        if (CollectableRelicManager.GetRelic(target) != null)
        {
            return CollectableRelicManager.GetRelic(target);
        }
        
        if (target.StartsWith("georock_"))
        {
            return CollectableItemManager.Instance.masterList.GetByName("Rosary_Set_Small");
        }

        if (target.StartsWith("shardrock_"))
        {
            return CollectableItemManager.Instance.masterList.GetByName("Shard Pouch");
        }

        var builder = GetRandoItem(target);
        
        RandoItem.OnCollectedCallback? callback = null;

        
        
        if (target.StartsWith("ability_"))
        {
            string abilitystr = target.Replace("ability_", "");
            WeaverSpireAbility ability = Enum.Parse<WeaverSpireAbility>(abilitystr);
            switch (ability)
            {
                case WeaverSpireAbility.Silkspear:
                    return ToolItemManager.GetToolByName("Silk Spear");
                case WeaverSpireAbility.RuneBomb:
                    return ToolItemManager.GetToolByName("Silk Bomb");
                case WeaverSpireAbility.SilkDash:
                    return ToolItemManager.GetToolByName("Silk Charge");
                case WeaverSpireAbility.SilkSphere:
                    return ToolItemManager.GetToolByName("Thread Sphere");
                case WeaverSpireAbility.HarpoonDash:
                    builder.SetDisplayName("Clawline");
                    builder.SetTinyIcon("Icon_SS_Clawline");
                    builder.SetIcon("Icon_SS_Clawline");
                    callback = item =>
                    {
                        GameManager.instance.playerData.hasHarpoonDash = true;
                    };
                    break;
                case WeaverSpireAbility.Needolin:
                    builder.SetDisplayName("Needolin");
                    builder.SetTinyIcon("Icon_SS_Needolin");
                    builder.SetIcon("Icon_SS_Needolin");
                    callback = item =>
                    {
                        GameManager.instance.playerData.hasNeedolin = true;
                    };
                    break;
                case WeaverSpireAbility.Sprint:
                    builder.SetDisplayName("Swift Step");
                    builder.SetTinyIcon("Icon_SS_Swift_Step");
                    builder.SetIcon("Icon_SS_Swift_Step");
                    callback = item =>
                    {
                        GameManager.instance.playerData.hasDash = true;
                    };
                    break;
                case WeaverSpireAbility.SuperJump:
                    builder.SetDisplayName("Silk Soar");
                    builder.SetTinyIcon("Icon_SS_Silk_Soar");
                    builder.SetIcon("Icon_SS_Silk_Soar");
                    callback = item =>
                    {
                        GameManager.instance.playerData.hasSuperJump = true;
                    };
                    break;
                case WeaverSpireAbility.Walljump:
                    builder.SetDisplayName("Cling Grip");
                    builder.SetTinyIcon("Icon_SS_Cling_Grip");
                    builder.SetIcon("Icon_SS_Cling_Grip");
                    callback = item =>
                    {
                        GameManager.instance.playerData.hasWalljump = true;
                    };
                    break;
            }
        }
        
        if (callback != null)
        {
            builder.SetCollectCallback(callback);
        }

        return builder.Build();
    }

    public static RandoItemBuilder GetRandoItem(string target)
    {
        var builder = RandoItemBuilder.Create(target, target);
        builder.SetDisplayName(target);
        builder.SetDescription("Cool Item");
        builder.SetMaxAmount(int.MaxValue);
        return builder;
    }

    public bool IsLoading = false;

    public IEnumerator LoadAll()
    {
        IsLoading = true;
        TimeManager.TimeScale = 0;
        Time.timeScale = 0;
        string lastScene = GameManager._instance.sceneName;
        for (int i = 0; i < GameScenes.Scenes.Count; i++)
        {
            
            string scn = GameScenes.Scenes[i];
            Log.LogInfo($"{scn} ({i}/{GameScenes.Scenes.Count}) {ItemLocations.Count} locations.");
            lastScene = scn;
            var task = Addressables.LoadSceneAsync("Scenes/" + scn, LoadSceneMode.Single, true);
            while (!task.IsDone)
            {
                yield return null;
            }
            yield return null;
            File.WriteAllLines(Application.persistentDataPath + "\\rando\\locations.txt", ItemLocations.Keys);
            Dictionary<string, ItemLocationData> locations = new();
            foreach (var loc in ItemLocations)
            {
                locations.Add(loc.Key, loc.Value.locationData);
            }
            File.WriteAllText(Application.persistentDataPath + "\\rando\\locations.json", JsonConvert.SerializeObject(locations, Formatting.Indented));
            yield return null;
        }
        TimeManager.TimeScale = 1;
        Time.timeScale = 1;
        IsLoading = false;
        GameManager.instance.ReturnToMainMenuNoSave();
    }

    public void CreateMapPin(Vector2 positionInScene, string sceneName, Vector2 sceneSize)
    {
        GM.gameMap.GetSceneInfo(sceneName, GM.gameMap.GetMapZoneFromSceneName(sceneName), out GameMapScene scene, out var scnobj, out var pos);
        Vector2 position = GM.gameMap.GetMapPosition(positionInScene, scene, scnobj, pos, sceneSize);

        Transform parent = GM.gameMap.compassIcon.transform.parent;
        
        for (int i = 0; i < GM.gameMap.compassIcon.transform.parent.childCount; i++)
        {
            if (GM.gameMap.compassIcon.transform.parent.GetChild(i).gameObject.name == "Map Markers")
            {
                parent = GM.gameMap.compassIcon.transform.parent.GetChild(i);
            }
        }
        
        GameObject obj = Instantiate(parent.GetChild(0).gameObject, parent);
        
        obj.transform.SetLocalPosition2D((Vector2) new Vector3(position.x, position.y, -1f));
        if (!obj.activeSelf)
            obj.SetActive(true);
    }

    public void CreateLocationPins()
    {
        foreach (var replacement in ItemReplacements)
        {
            if (ItemLocationData.ContainsKey(replacement.Key))
            {
                var data = ItemLocationData[replacement.Key];
                CreateMapPin(new Vector2(data.PositionInSceneX, data.PositionInSceneY), replacement.Key.Split("|")[0], new Vector2(data.RoomSizeX, data.RoomSizeY));
            }
        }
    }
    
    private void Update()
    {

        if (GameManager.SilentInstance != null && GM == null)
        {
            GM = GameManager.instance;
            
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            ConsoleMover.PrintConsoleRect();
        }
        if (Input.GetKeyDown(KeyCode.Y) && !IsLoading)
        {
            StartCoroutine(LoadAll());
        }

        

    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    
    public static List<T> FindObjectsOfTypeInScene<T>(
        Scene scene,
        bool includeInactive = false)
        where T : Component
    {
        var results = new List<T>();

        if (!scene.IsValid() || !scene.isLoaded)
            return results;

        foreach (var root in scene.GetRootGameObjects())
        {
            root.GetComponentsInChildren(includeInactive, results);
        }

        return results;
    }
    
    public static T FindObjectOfTypeInScene<T>(Scene scene, bool includeInactive = false)
        where T : Object
    {
        if (!scene.IsValid() || !scene.isLoaded)
            return null;

        var roots = scene.GetRootGameObjects();
        foreach (var root in roots)
        {
            var result = root.GetComponentInChildren<T>(includeInactive);
            if (result != null)
                return result;
        }

        return null;
    }
    
}

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
            SetItem($"Error(\"{GetLocationID()}\") No item set.");
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


public class ShrineWeaverAbilityLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public ShrineWeaverAbilityLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        
        WeaverSpireAbility ability = (WeaverSpireAbility)fsm.FsmVariables.EnumVariables[0].Value;
        return "ability_" + ability.ToString();
    }

    public override void SetItem(string item)
    {
        base.SetItem(item);
        Object.Destroy(fsm.GetComponent<PlayMakerNPC>());
        Object.Destroy(fsm);
        
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}

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

public class ShardRockLocation : ItemLocation
{
    private BreakableHolder rock;
    public ShardRockLocation(BreakableHolder rock)
    {
        this.rock = rock;
    }
    
    public override string GetItem()
    {
        return "shardrock_" + rock.persistent.itemData.ID;
    }
    
    public override GameObject GetObj()
    {
        return rock.gameObject;
    }

    public override void SetItem(string item)
    {
        base.SetItem(item);
        Object.Destroy(rock.gameObject);
    }
}

public class GeoRockLocation : ItemLocation
{
    private GeoRock rock;
    public GeoRockLocation(GeoRock rock)
    {
        this.rock = rock;
    }
    
    public override string GetItem()
    {
        return "georock_" + rock.geoRockData.id + "_" + rock.BreakableType;
    }
    
    public override GameObject GetObj()
    {
        return rock.gameObject;
    }

    public override void SetItem(string item)
    {
        base.SetItem(item);
        Object.Destroy(rock.gameObject);
    }
}

[HarmonyPatch(typeof(GameMap), nameof(GameMap.Start))]
class GameMap_Start_Patch
{
    public static void Postfix(GameMap __instance)
    {
        RandoPlugin.instance.CreateLocationPins();
        foreach (var scene in GameScenes.Scenes)
        {
            GameManager.instance.playerData.scenesMapped.Add(scene);
        }
        
        GameManager.instance.playerData.mapAllRooms = true;
        GameManager.instance.UpdateGameMapWithPopup();

    }
}


[HarmonyPatch(typeof(PlayMakerFSM), nameof(PlayMakerFSM.Start))]
class PlayMakerFSM_Start_Patch
{
    public static void Prefix(PlayMakerFSM __instance)
    {
        if (__instance.name == "Shrine Weaver Ability")
        {
            ShrineWeaverAbilityLocation loc = new ShrineWeaverAbilityLocation(__instance);
            loc.AddToCurrentScene();
        }

    }
}


[HarmonyPatch(typeof(CollectableItemPickup), nameof(CollectableItemPickup.Start))]
class CollectableItemPickup_Start_Patch
{
    public static void Prefix(CollectableItemPickup __instance)
    {
        if (!(__instance.item is RandoItem) && !RandoPlugin.instance.PickupsToIgnore.Contains(__instance))
        {
            CollectableItemPickupLocation loc = new CollectableItemPickupLocation(__instance);
            loc.AddToCurrentScene();
        }
    
    }
}

[HarmonyPatch(typeof(GeoRock), nameof(GeoRock.Start))]
class GeoRock_Start_Patch
{
    public static void Prefix(GeoRock __instance)
    {
        GeoRockLocation loc = new GeoRockLocation(__instance);
        loc.AddToCurrentScene();
    }
}

[HarmonyPatch(typeof(BreakableHolder), nameof(BreakableHolder.Start))]
class BreakableHolder_Start_Patch
{
    public static void Prefix(BreakableHolder __instance)
    {
        RandoPlugin.Log.LogInfo(__instance.persistent.ItemData.ID);
        if (__instance.persistent.ItemData.ID.StartsWith("Shell Shard"))
        {
            ShardRockLocation loc = new ShardRockLocation(__instance);
            loc.AddToCurrentScene();
        }
    }
}


[HarmonyPatch(typeof(Language), nameof(Language.Get), new Type[] { typeof(string), typeof(string) })]
class Language_Get_Patch
{
    public static bool Prefix(ref string __result, string key, string sheetTitle)
    {
        if (sheetTitle == "Rando")
        {
            __result = key;
            return false;
        }

        return true;
    }
}

[HarmonyPatch(typeof(Language), nameof(Language.Has), new Type[] { typeof(string), typeof(string) })]
class Language_Has_Patch
{
    public static bool Prefix(ref bool __result, string key, string sheetTitle)
    {
        if (sheetTitle == "Rando")
        {
            __result = true;
            return false;
        }

        return true;
    }
}
