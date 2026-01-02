using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using Generated;
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

[BepInPlugin(Id, Name, BuildConstants.Version)]
[BepInDependency("org.silksong-modding.datamanager")]
[BepInDependency("dervorce.hkss.gamemodemanager")]
[BepInDependency("io.github.flibber-hk.filteredlogs", BepInDependency.DependencyFlags.SoftDependency)]
public class RandoPlugin : BaseUnityPlugin, ISaveDataMod<SaveData>
{
    
    
    
    public const string Id = "com.lem00ns.Silksong.Rando";
    public const string Name = "Randomiser";
    
    private static RandoPlugin? instance;
    public static RandoPlugin Instance
    {
        get
        {
            if (instance == null)
            {
                throw new Exception("Randomiser not intialized");
            }
            return instance;
        }
        set => instance = value;
    }

    public static GameManager GM => GameManager.SilentInstance;

    private ModResources? modResources;
    public ModResources Resources
    {
        get
        {
            if (modResources == null)
            {
                throw new Exception("Resources not intialized");
            }
            return modResources;
        }
        set => modResources = value;
    }

    private SceneLoader? sceneLoader;
    public SceneLoader SceneLoader
    {
        get
        {
            if (sceneLoader == null)
            {
                throw new Exception("Scene loader not intialized");
            }
            return sceneLoader;
        }
        set => sceneLoader = value;
    }

    
    private RandoMap? map;
    public RandoMap Map
    {
        get
        {
            if (map == null)
            {
                throw new Exception("Rando map not intialized");
            }
            return map;
        }
        set => map = value;
    }
    
    public LogicFile? logic;

    public LogicFile Logic
    {
        get
        {
            if (logic == null)
            {
                throw new Exception("Logic not loaded");
            }

            return logic;
        }
        set => logic = value;
    }

    public long versionStatus;
    private string versionStatusText = "";
    private bool versionOutOfDate;
    private string latestVersion = "";
    
    SaveData? ISaveDataMod<SaveData>.SaveData
    {
        get => SaveData.Instance;
        set => SaveData.Instance = value;
    }
    
    public static ManualLogSource Log => Instance.Logger;
    public Dictionary<string, string> ItemReplacements => SaveData.Instance.ItemReplacements;

    public List<CollectableItemPickup> PickupsToIgnore = new();

    private GameModeManager.GameModeData? gameMode;
    
    public GameModeManager.GameModeData GameMode
    {
        get
        {
            if (gameMode == null)
            {
                throw new Exception("Game mode not loaded");
            }

            return gameMode;
        }
        set => gameMode = value;
    }

    public Dictionary<string, SavedItem> AddressableItems = new();

    public bool ShowSceneDebug;

    public bool PrintPlayerDataChanges;
    
    private void Awake()
    {
        Instance = this;
        FilteredLogs.API.ApplyFilter((args =>
        {
            return args.Source.SourceName == "Unity Log" || args.Source == Logger;
        }));
        
        #if DEV
        ConsoleMover.Move();
        #endif
        Resources = gameObject.AddComponent<RandoResources>();
        ModResources.LoadResources();
        
        GameScenes.Load();
        SceneLoader = SceneLoader.Setup();
        Map = gameObject.AddComponent<RandoMap>();
        gameObject.AddComponent<LocationFinder>();
        gameObject.AddComponent<SceneDumper>();

        logic = ModResources.LoadData<LogicFile>("logic");
        
        GameMode = GameModeManagerPlugin.Instance.Manager.Init(
            this,
            "Randomiser",
            "Basic randomiser"
        );
        
        MossberryLocation.InstallHooks();
        CollectableItemPickupLocation.InstallHooks();
        
        VersionInfo.FetchInfo(((status, statusText, outOfDate, latest) =>
        {
            latestVersion = latest;
            versionOutOfDate = outOfDate;
            versionStatusText = statusText;
            versionStatus = status;
        }));

        PlayerDataVariableEvents.OnSetBool += (pd, fieldName, value) =>
        {
            if (pd.GetBool(fieldName) != value && PrintPlayerDataChanges)
            {
                Log.LogInfo(fieldName + " = " + value);
            }
            return value;
        };

        PlayerDataVariableEvents.OnGetBool += ((_, fieldName, current) =>
        {
            if (fieldName.StartsWith("CHECKED_"))
            {
                return SaveData.Instance.CollectedChecks.Contains(fieldName.Substring("CHECKED_".Length));
            }
            return current;
        });

    }

    private void Start()
    {
        new Harmony(Id).PatchAll(typeof(RandoPlugin).Assembly);
        
    }

    private void OnGUI()
    {
        if (!GM) return;

        GUI.skin.font = ModResources.GetFont();

        List<(string txt, Color color)> DebugTexts = new();

        void AddColoredLine(string txt, Color color)
        {
            DebugTexts.Add((txt, color));
        }

        void AddLine(string txt)
        {
            AddColoredLine(txt, Color.white);
        }
        
        AddLine("Randomiser by Lem00ns - alpha v" + BuildConstants.Version + " - Expect Bugs!");


        if (versionStatus == 0)
        {
            AddLine("Fetching latest version info...");
        } else if (versionStatus == 200)
        {
            if (versionOutOfDate)
            {
                AddColoredLine($"Randomiser out of date, latest version is {latestVersion} your version is {BuildConstants.Version} please update the mod.", Color.red);
            }
        }
        else
        {
            AddColoredLine(versionStatusText, Color.red);
        }
        
        

        if (ShowSceneDebug)
        {
            AddLine(GM.GetSceneNameString());
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
                    AddLine($"{nearest.name} - {nearestDistance}m");
                }
            }

            
            if (PlayerData.instance.isInventoryOpen)
            {
                AddLine($"{Map.mode} map.");
            }
        }

        for (int i = 0; i < DebugTexts.Count; i++)
        {
            var style = ModResources.GetLabelStyle();
            GUI.contentColor = DebugTexts[i].color;
            GUI.Label(new Rect(10f, Screen.height - (40f + i * 30), 100, 100), DebugTexts[i].txt, style);
        }
    }
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && Input.GetKey(KeyCode.F11))
        {
            PrintPlayerDataChanges = !PrintPlayerDataChanges;
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
                bundles.Add(b.name, b.GetAllAssetNames().ToList());
            }
        
            File.WriteAllText(Application.persistentDataPath + "/rando/bundles.json", JsonConvert.SerializeObject(bundles, Formatting.Indented));

        }
        
    }
    
    AssetBundle? FindBundleContaining(string req)
    {
        foreach (var bundle in AssetBundle.GetAllLoadedAssetBundles())
        {  
            foreach (var asset in bundle.GetAllAssetNames())
            {
                if (asset.Contains(req))
                {
                    return bundle;
                }
            }
        }
        return null;
    }

    public void LoadFakeCollectables()
    {
        
        AddressableItems.Clear();

        AssetBundle bundle = FindBundleContaining("Fake Collectables")!;
        var collectables = bundle.LoadAllAssets<FakeCollectable>();
        foreach (var fakeCollectable in collectables)
        {
            AddressableItems.Add(fakeCollectable.name, fakeCollectable);
        }
    }
    
    private void OnDestroy()
    {
        if (Instance == this)
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

        if (Instance.AddressableItems.ContainsKey(target))
        {
            return RandoItem.Wrap(target, check, Instance.AddressableItems[target]);
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
            callback = _ =>
            {
                GM.playerData.hasBrolly = true;
            };
        }

        if (target == "Faydown")
        {
            builder.SetDisplayName("Faydown Cloak");
            builder.SetIcon("FaydownCloak");
            callback = _ =>
            {
                GM.playerData.hasDoubleJump = true;
            };
        }

        if (target.StartsWith("Bell_"))
        {
            builder.SetDisplayName("Bell Shrine Rung");
            builder.SetIcon("Bell");
            var value = target.Substring("Bell_".Length);
            callback = _ =>
            {
                GM.playerData.SetBool(value, true);
            };
        }
        
        if (target == "melody_Vault")
        {
            builder.SetDisplayName("Vaultkeeper's Melody");
            builder.SetIcon("VaultkeepersMelody");
            callback = _ =>
            {
                GM.playerData.HasMelodyLibrarian = true;
            };
        }
        if (target == "melody_Conductor")
        {
            builder.SetDisplayName("Conductor's Melody");
            builder.SetIcon("ConductorsMelody");
            callback = _ =>
            {
                GM.playerData.HasMelodyConductor = true;
            };
        }
        if (target == "melody_Architect")
        {
            builder.SetDisplayName("Architects's Melody");
            builder.SetIcon("ArchitectsMelody");
            callback = _ =>
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
                    callback = _ =>
                    {
                        GM.playerData.hasHarpoonDash = true;
                    };
                    break;
                case WeaverSpireAbility.Needolin:
                    builder.SetDisplayName("Needolin");
                    builder.SetIcon("Icon_SS_Needolin");
                    callback = _ =>
                    {
                        GM.playerData.hasNeedolin = true;
                    };
                    break;
                case WeaverSpireAbility.Sprint:
                    builder.SetDisplayName("Swift Step");
                    builder.SetIcon("Icon_SS_Swift_Step");
                    callback = _ =>
                    {
                        GM.playerData.hasDash = true;
                    };
                    break;
                case WeaverSpireAbility.SuperJump:
                    builder.SetDisplayName("Silk Soar");
                    builder.SetIcon("Icon_SS_Silk_Soar");
                    callback = _ =>
                    {
                        GM.playerData.hasSuperJump = true;
                    };
                    break;
                case WeaverSpireAbility.Walljump:
                    builder.SetDisplayName("Cling Grip");
                    builder.SetIcon("Icon_SS_Cling_Grip");
                    callback = _ =>
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

        foreach (var itm in Instance.CollectableCache)
        {
            if (itm.target == target && itm.check == check)
            {
                return Object.Instantiate(itm.itm);
            }
        }
        
        var res = CreateCollectableItem(target, check);
        
        Instance.CollectableCache.Add((target, check, res));
        
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