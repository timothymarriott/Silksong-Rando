using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using GlobalEnums;
using HarmonyLib;
using Newtonsoft.Json;
using PrepatcherPlugin;
using Silksong.DataManager;
using Silksong.Rando.Map;
using Silksong.FsmUtil;
using Silksong.Rando.Data;
using Silksong.Rando.Data.Extractors;
using TeamCherry.Localization;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Silksong.Rando.Locations;
using Silksong.Rando.Logic;
using SkongGamemodes;

namespace Silksong.Rando;

[BepInPlugin(Id, Name, Version)]
[BepInDependency("org.silksong-modding.datamanager")]
[BepInDependency("dervorce.hkss.gamemodemanager")]
public class RandoPlugin : BaseUnityPlugin, ISaveDataMod<SaveData>
{
    
    
    
    public const string Id = "com.lem00ns.Silksong.Rando";
    public const string Name = "Randomiser";
    public const string Version = "0.0.1";
    
    public static RandoPlugin instance;
    
    public static GameManager GM;

    public ModResources resources;
    public SceneLoader sceneLoader;

    public Logic.LogicFile logic;
    
    SaveData? ISaveDataMod<SaveData>.SaveData
    {
        get => SaveData.Instance;
        set => SaveData.Instance = value;
    }
    
    public static ManualLogSource Log => instance.Logger;
    public Dictionary<string, string> ItemReplacements => SaveData.Instance.ItemReplacements;

    public List<CollectableItemPickup> PickupsToIgnore = new();

    public GameModeManager.GameModeData GameMode;
    
    
    
    private void Awake()
    {
        instance = this;
        
        ConsoleMover.Move();
        resources = ModResources.LoadResources(Logger);
        GameScenes.Load();
        sceneLoader = SceneLoader.Setup();
        gameObject.AddComponent<RandoMap>();
        gameObject.AddComponent<LocationFinder>();
        gameObject.AddComponent<SceneDumper>();

        logic = LogicFile.Load("logic");
        
        GameMode = GameModeManagerPlugin.Instance.Manager.Init(
            this,
            "Randomiser",
            "Basic randomiser"
        );
        
    }

    private void Start()
    {
        new Harmony(Id).PatchAll(typeof(RandoPlugin).Assembly);
    }

    private void OnGUI()
    {
        if (!GM) return;

        GUI.skin.font = ModResources.GetFont();
        GUI.Label(new Rect(0, Screen.height - 30f, 100, 100), GM.GetSceneNameString(), ModResources.GetLabelStyle());
    }
    
    private void Update()
    {
        if (GameManager.SilentInstance && !GM)
        {
            GM = GameManager.instance;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            foreach (var collectableItem in CollectableItemManager.Instance.masterList)
            {
                try
                {
                    Log.LogInfo(collectableItem.GetDisplayName(CollectableItem.ReadSource.Inventory).ToString());
                    Log.LogInfo("  - GetPopup" + collectableItem.GetIcon(CollectableItem.ReadSource.GetPopup).rect.size);
                    Log.LogInfo("  - Inventory" + collectableItem.GetIcon(CollectableItem.ReadSource.Inventory).rect.size);
                    Log.LogInfo("  - Tiny" + collectableItem.GetIcon(CollectableItem.ReadSource.Tiny).rect.size);
                }
                catch
                {
                    
                }
                
            }
        }
        
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
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
        
        if (target.EndsWith(" Map"))
        {
            builder.SetIcon("Icons/Item/Map");
        }
        else
        {
            builder.SetIcon("missing");
        }
        
        
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
                    builder.SetIcon("Icon_SS_Clawline");
                    callback = item =>
                    {
                        GM.playerData.hasHarpoonDash = true;
                    };
                    break;
                case WeaverSpireAbility.Needolin:
                    builder.SetDisplayName("Needolin");
                    builder.SetIcon("Icon_SS_Needolin");
                    callback = item =>
                    {
                        GM.playerData.hasNeedolin = true;
                    };
                    break;
                case WeaverSpireAbility.Sprint:
                    builder.SetDisplayName("Swift Step");
                    builder.SetIcon("Icon_SS_Swift_Step");
                    callback = item =>
                    {
                        GM.playerData.hasDash = true;
                    };
                    break;
                case WeaverSpireAbility.SuperJump:
                    builder.SetDisplayName("Silk Soar");
                    builder.SetIcon("Icon_SS_Silk_Soar");
                    callback = item =>
                    {
                        GM.playerData.hasSuperJump = true;
                    };
                    break;
                case WeaverSpireAbility.Walljump:
                    builder.SetDisplayName("Cling Grip");
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


    
}


public class SaveData
{
    private static SaveData? _instance;

    [AllowNull]
    public static SaveData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }
        internal set
        {
            _instance = value;
        }
    }

    public int RandoSeed { get; set; } = -1;
    public Dictionary<string, string> ItemReplacements { get; set; } = [];
}