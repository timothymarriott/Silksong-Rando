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
using PrepatcherPlugin;
using RandomizerCore.Extensions;
using Silksong.Rando.Map;
using Silksong.FsmUtil;
using TeamCherry.Localization;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Silksong.Rando.Locations;

namespace Silksong.Rando;

[BepInPlugin(Id, Name, Version)]
[BepInDependency("org.silksong-modding.datamanager")]
public class RandoPlugin : BaseUnityPlugin
{
    
    public const string Id = "com.lem00ns.Silksong.Rando";
    public const string Name = "Randomiser";
    public const string Version = "0.0.1";
    
    public static RandoPlugin instance;

    public static ManualLogSource Log => instance.Logger;

    public Dictionary<string, ItemLocation> ItemLocations = new();

    public Dictionary<string, ItemLocationData> ItemLocationData = new();
    
    public Dictionary<string, string> ItemReplacements = new();

    public List<CollectableItemPickup> PickupsToIgnore = new();

    public static GameManager GM;

    public ModResources resources;
    
    private void Awake()
    {
        instance = this;
        
        ConsoleMover.Move();
        resources = ModResources.LoadResources(Logger);
        gameObject.AddComponent<RandoMap>();
        
        string replacementText = File.ReadAllText(Application.persistentDataPath + "\\rando\\replacements.json");
        var replacements = JsonConvert.DeserializeObject<Dictionary<string, string>>(replacementText);
        if (replacements != null)
        {
            ItemReplacements = replacements;
        }
        
        string locationDataText = File.ReadAllText(Application.persistentDataPath + "\\rando\\locations.json");
        var locationData = JsonConvert.DeserializeObject<Dictionary<string, ItemLocationData>>(locationDataText);
        if (locationData != null)
        {
            ItemLocationData = locationData;
        }
    }

    private void Start()
    {
        new Harmony(Id).PatchAll(typeof(RandoPlugin).Assembly);
    }

    private void OnGUI()
    {
        if (GM == null) return;

        GUI.skin.font = ModResources.GetFont();
        GUI.Label(new Rect(0, Screen.height - 30f, 100, 100), GM.GetSceneNameString(), ModResources.GetLabelStyle());
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

        var builder = RandoItemBuilder.Create(target, target);
        builder.SetDisplayName("Invalid Item");
        builder.SetDescription("Internal Item for the randomiser");
        builder.SetMaxAmount(int.MaxValue);
        builder.SetIcon("missing");
        builder.SetTinyIcon("missing");
        
        
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
                        GM.playerData.hasHarpoonDash = true;
                    };
                    break;
                case WeaverSpireAbility.Needolin:
                    builder.SetDisplayName("Needolin");
                    builder.SetTinyIcon("Icon_SS_Needolin");
                    builder.SetIcon("Icon_SS_Needolin");
                    callback = item =>
                    {
                        GM.playerData.hasNeedolin = true;
                    };
                    break;
                case WeaverSpireAbility.Sprint:
                    builder.SetDisplayName("Swift Step");
                    builder.SetTinyIcon("Icon_SS_Swift_Step");
                    builder.SetIcon("Icon_SS_Swift_Step");
                    callback = item =>
                    {
                        GM.playerData.hasDash = true;
                    };
                    break;
                case WeaverSpireAbility.SuperJump:
                    builder.SetDisplayName("Silk Soar");
                    builder.SetTinyIcon("Icon_SS_Silk_Soar");
                    builder.SetIcon("Icon_SS_Silk_Soar");
                    callback = item =>
                    {
                        GM.playerData.hasSuperJump = true;
                    };
                    break;
                case WeaverSpireAbility.Walljump:
                    builder.SetDisplayName("Cling Grip");
                    builder.SetTinyIcon("Icon_SS_Cling_Grip");
                    builder.SetIcon("Icon_SS_Cling_Grip");
                    callback = item =>
                    {
                        GM.playerData.hasWalljump = true;
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
        GM.ReturnToMainMenuNoSave();
    }

    
    
    private void Update()
    {

        if (GameManager.SilentInstance != null && GM == null)
        {
            GM = GM;
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
    
}