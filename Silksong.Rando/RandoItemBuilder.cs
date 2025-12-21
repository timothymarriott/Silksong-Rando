using System;
using System.Collections.Generic;
using TeamCherry.Localization;
using UnityEngine;

namespace Silksong.Rando;

public class RandoItem : CollectableItemBasic
{
    public string targetItem;
    public delegate void OnCollectedCallback(RandoItem item);
    public OnCollectedCallback? CollectCallback;
    public override void OnCollected()
    {
        base.OnCollected();
        RandoPlugin.Log.LogInfo("Collected " + targetItem);
        if (CollectCallback != null)
            CollectCallback(this);

    }
}

public class RandoItemBuilder : DataBuilder<RandoItem>
{

    private static List<RandoItemBuilder> created = new();

    public const string LANG_SHEET = "ITEM_MOD";

    
    
    public static RandoItemBuilder Create(string name, string targetItem)
    {
        RandoItemBuilder res = new RandoItemBuilder();
        res.result = ScriptableObject.CreateInstance<RandoItem>();
        res.result.name = name;
        res.result.targetItem = targetItem;
        res.result.isHidden = true;
        res.Setup();
        
        created.Add(res);
        
        return res;
    }

    private void Setup()
    {
        result.isAlwaysUnlocked = true;
        result.displayButtonPrompt = false;
        result.useResponses = new CollectableItemBasic.UseResponse[]
        {
            new ()
            {
                UseType = CollectableItem.UseTypes.None,
            }
        };

        result.setExtraPlayerDataBools = new PlayerDataBoolOperation[0];
        result.setExtraPlayerDataInts = new PlayerDataIntOperation[0];
    }

    public RandoItemBuilder SetMaxAmount(int amount)
    {
        result.customMaxAmount = amount;
        return this;
    }
    
    public RandoItemBuilder SetDisplayName(string name)
    {
        return SetDisplayName("Rando", name);
    }
    
    public RandoItemBuilder SetDisplayName(string sheet, string key)
    {
        return SetDisplayName(new LocalisedString(sheet, key));
    }
    
    public RandoItemBuilder SetDisplayName(LocalisedString name)
    {
        result.displayName = name;
        return this;
    }
    
    public RandoItemBuilder SetDescription(string description)
    {
        return SetDescription("Rando", description);
    }
    
    public RandoItemBuilder SetDescription(string sheet, string key)
    {
        return SetDescription(new LocalisedString(sheet, key));
    }
    
    public RandoItemBuilder SetDescription(LocalisedString description)
    {
        result.description = description;
        return this;
    }
    
    public RandoItemBuilder SetIcon(Sprite sprite)
    {
        result.icon = sprite;
        return this;
    }
    
    public RandoItemBuilder SetIcon(string icon)
    {
        return SetIcon(Utils.LoadSprite(icon));
    }
    
    public RandoItemBuilder SetTinyIcon(Sprite sprite)
    {
        result.tinyIcon = sprite;
        return this;
    }
    
    public RandoItemBuilder SetTinyIcon(string icon)
    {
        return SetTinyIcon(Utils.LoadSprite(icon));
    }

    public RandoItemBuilder SetCollectCallback(RandoItem.OnCollectedCallback action)
    {
        result.CollectCallback = action;
        return this;
    }

    public RandoItem Build()
    {
        if (IsBuilt) return result;
        IsBuilt = true;
        CollectableItemManager.Instance.masterList.Add(result);
        return result;
    }
    
}