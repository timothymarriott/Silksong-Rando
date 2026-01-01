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
[BepInDependency("io.github.flibber-hk.filteredlogs", BepInDependency.DependencyFlags.SoftDependency)]
public class RandoPlugin : BaseUnityPlugin, ISaveDataMod<SaveData>
{
    
    
    
    public const string Id = "com.lem00ns.Silksong.Rando";
    public const string Name = "Randomiser";
    public const string Version = "0.1.2";
    
    public static RandoPlugin instance;
    
    public static GameManager GM;

    public ModResources resources;
    public SceneLoader sceneLoader;
    public RandoMap map;
    
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

    public Dictionary<string, SavedItem> AddressableItems = new();

    public bool ShowSceneDebug = false;
    
    
    private void Awake()
    {
        instance = this;
        FilteredLogs.API.ApplyFilter((args =>
        {
            return args.Source.SourceName == "Unity Log" || args.Source == Logger;
        }));
        
        #if DEV
        ConsoleMover.Move();
        #endif
        resources = ModResources.LoadResources(Logger);
        GameScenes.Load();
        sceneLoader = SceneLoader.Setup();
        map = gameObject.AddComponent<RandoMap>();
        gameObject.AddComponent<LocationFinder>();
        gameObject.AddComponent<SceneDumper>();

        logic = LogicFile.Load("logic");
        
        GameMode = GameModeManagerPlugin.Instance.Manager.Init(
            this,
            "Randomiser",
            "Basic randomiser"
        );
        
        MossberryLocation.InstallHooks();
        CollectableItemPickupLocation.InstallHooks();

    }

    private void Start()
    {
        new Harmony(Id).PatchAll(typeof(RandoPlugin).Assembly);
        
    }

    private void OnGUI()
    {
        if (!GM) return;

        GUI.skin.font = ModResources.GetFont();

        List<string> DebugTexts = new List<string>();
        
        
        DebugTexts.Add("Randomiser by Lem00ns - alpha v" + Version + " - Expect Bugs!");


        if (ShowSceneDebug)
        {
            DebugTexts.Add(GM.GetSceneNameString());
        }
        
        if (PlayerData.instance != null)
        {
            
            
            if (ShowSceneDebug)
            {
                TransitionPoint? nearest = null;
                float nearestDistance = float.MaxValue;
                foreach (var transitionPoint in TransitionPoint.TransitionPoints)
                {
                    if (transitionPoint.gameObject.scene.name == GM.GetSceneNameString())
                    {
                        float dist = Vector2.Distance(transitionPoint.transform.position, GM.hero_ctrl.transform.position);
                        if (dist < nearestDistance)
                        {
                            nearestDistance = dist;
                            nearest = transitionPoint;
                        }
                    }
                }

                if (nearest != null)
                {
                    DebugTexts.Add($"{nearest.name} - {nearestDistance}m");
                }
            }

            
            if (PlayerData.instance.isInventoryOpen)
            {
                DebugTexts.Add($"{map.mode} map.");
            }
        }

        for (int i = 0; i < DebugTexts.Count; i++)
        {
            GUI.Label(new Rect(10f, Screen.height - (40f + i * 30), 100, 100), DebugTexts[i], ModResources.GetLabelStyle());
        }
    }
    
    private void Update()
    {
        if (GameManager.SilentInstance && !GM)
        {
            GM = GameManager.instance;
        }

        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.F11))
        {
            ShowSceneDebug = !ShowSceneDebug;
        }

        if (Input.GetKeyDown(KeyCode.B) && Input.GetKey(KeyCode.F11))
        {
            Dictionary<string, List<string>> bundles = new Dictionary<string, List<string>>();
            foreach (var b in AssetBundle.GetAllLoadedAssetBundles())
            {
                try
                {
                    bundles.Add(b.name, b.GetAllAssetNames().ToList());
                }
                catch { }
            }
        
            File.WriteAllText(Application.persistentDataPath + "/rando/bundles.json", JsonConvert.SerializeObject(bundles, Formatting.Indented));

        }
        
    }
    
    AssetBundle FindBundleContaining(string req)
    {
        foreach (var bundle in AssetBundle.GetAllLoadedAssetBundles())
        {
            try
            {
                
                foreach (var asset in bundle.GetAllAssetNames())
                {
                    if (asset.Contains(req))
                    {
                        return bundle;
                    }
                }

            }
            catch
            {
            }
        }
        return null;
    }

    public void LoadFakeCollectables()
    {
        
        AddressableItems.Clear();

        AssetBundle bundle = FindBundleContaining("Fake Collectables");
        var collectables = bundle.LoadAllAssets<FakeCollectable>();
        foreach (var fakeCollectable in collectables)
        {
            AddressableItems.Add(fakeCollectable.name, fakeCollectable);
        }
    }
    
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public List<(string target, string check, SavedItem itm)> CollectableCache = new();

    private static SavedItem CreateCollectableItem(string target, string check)
    {
        if (CollectableItemManager.Instance.masterList.GetByName(target) != null)
        {
            return RandoItem.Wrap(target, check, CollectableItemManager.Instance.masterList.GetByName(target));
        }

        if (ToolItemManager.Instance.toolItems.GetByName(target) != null)
        {
            return RandoItem.Wrap(target, check, ToolItemManager.Instance.toolItems.GetByName(target));
        }

        if (CollectableRelicManager.GetRelic(target) != null)
        {
            return RandoItem.Wrap(target, check, CollectableRelicManager.GetRelic(target));
        }

        if (instance.AddressableItems.ContainsKey(target))
        {
            return RandoItem.Wrap(target, check, instance.AddressableItems[target]);
        }
        
        if (target.StartsWith("georock_"))
        {
            return RandoItem.Wrap(target, check, CollectableItemManager.Instance.masterList.GetByName("Rosary_Set_Small"));
        }

        var builder = RandoItemBuilder.Create(target, check);
        builder.SetDisplayName("Invalid Item");
        builder.SetDescription("Internal Item for the randomiser");
        builder.SetMaxAmount(int.MaxValue);
        
        if (target.EndsWith(" Map"))
        {
            builder.SetDisplayName(target);
            builder.SetIcon("Map");
        }
        else
        {
            builder.SetIcon("missing");
        }
        
        
        RandoItem.OnCollectedCallback? callback = null;

        if (target == "Brolly")
        {
            builder.SetDisplayName("Float Cloak");
            builder.SetIcon("DriftersCloak");
            callback = item =>
            {
                GM.playerData.hasBrolly = true;
            };
        }

        if (target == "Faydown")
        {
            builder.SetDisplayName("Faydown Cloak");
            builder.SetIcon("FaydownCloak");
            callback = item =>
            {
                GM.playerData.hasDoubleJump = true;
            };
        }
        
        if (target == "melody_Vault")
        {
            builder.SetDisplayName("Vaultkeeper's Melody");
            builder.SetIcon("VaultkeepersMelody");
            callback = item =>
            {
                GM.playerData.HasMelodyLibrarian = true;
            };
        }
        if (target == "melody_Conductor")
        {
            builder.SetDisplayName("Conductor's Melody");
            builder.SetIcon("ConductorsMelody");
            callback = item =>
            {
                GM.playerData.HasMelodyConductor = true;
            };
        }
        if (target == "melody_Architect")
        {
            builder.SetDisplayName("Architects's Melody");
            builder.SetIcon("ArchitectsMelody");
            callback = item =>
            {
                GM.playerData.HasMelodyArchitect = true;
            };
        }
        
        if (target.StartsWith("ability_"))
        {
            string abilitystr = target.Replace("ability_", "");
            WeaverSpireAbility ability = Enum.Parse<WeaverSpireAbility>(abilitystr);
            switch (ability)
            {
                case WeaverSpireAbility.Silkspear:
                    return RandoItem.Wrap(target, check, ToolItemManager.GetToolByName("Silk Spear"));
                case WeaverSpireAbility.RuneBomb:
                    return RandoItem.Wrap(target, check, ToolItemManager.GetToolByName("Silk Bomb"));
                case WeaverSpireAbility.SilkDash:
                    return RandoItem.Wrap(target, check, ToolItemManager.GetToolByName("Silk Charge"));
                case WeaverSpireAbility.SilkSphere:
                    return RandoItem.Wrap(target, check, ToolItemManager.GetToolByName("Thread Sphere"));
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
    
    public static SavedItem GetCollectableItem(string target, string check)
    {

        foreach (var itm in instance.CollectableCache)
        {
            if (itm.target == target && itm.check == check)
            {
                return itm.itm;
            }
        }
        
        var res = CreateCollectableItem(target, check);
        
        instance.CollectableCache.Add((target, check, res));
        
        return res;
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

    public static void Clear()
    {
        Instance = new();
    }

    public int RandoSeed { get; set; } = -1;
    public Dictionary<string, string> ItemReplacements { get; set; } = [];
    public List<string> CollectedChecks { get; set; } = [];
}