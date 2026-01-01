using System;
using System.Collections.Generic;
using TeamCherry.Localization;
using UnityEngine;

namespace Silksong.Rando;

public class RandoItem : CollectableItemBasic
{
    public string targetItem;
    public string check;

    public SavedItem wrapped = null;
    
    public delegate void OnCollectedCallback(RandoItem item);
    public OnCollectedCallback? CollectCallback;
    public override void OnCollected()
    {
        base.OnCollected();
        RandoPlugin.Log.LogInfo("Collected " + targetItem);
        Rando.SaveData.Instance.CollectedChecks.Add(check);
        if (wrapped != null)
        {
            Take(showCounter:false);
            RandoPlugin.Log.LogInfo("Giving wrapped item: " + wrapped.name + " at " + check + "(" + (wrapped is RandoItem itm ? itm.check : "vanilla wrapped") + ")");
            
            wrapped.Get(false);
        }
        else
        {
            if (CollectCallback != null)
                CollectCallback(this);
        }
        
        
        RandoPlugin.instance.map.Refresh();

    }

    public static RandoItem Wrap(string targetItem, string check, SavedItem template)
    {
        RandoItemBuilder res = RandoItemBuilder.Create(targetItem, check);
        res.result.name = targetItem + "_wrap";
        res.result.icon = template.GetPopupIcon();
        res.result.tinyIcon = template.GetPopupIcon();
        if (template is RandoItem itm)
        {
            itm.check = check;
        }
        res.result.wrapped = template;
        res.SetDisplayName(template.GetPopupName());
        return res.Build();
    }
}

public class RandoItemBuilder : DataBuilder<RandoItem>
{

    private static List<RandoItemBuilder> created = new();
    
    
    public static RandoItemBuilder Create(string targetItem, string check)
    {
        RandoItemBuilder res = new RandoItemBuilder();
        res.result = ScriptableObject.CreateInstance<RandoItem>();
        res.result.name = targetItem;
        res.result.targetItem = targetItem;
        res.result.isHidden = true;
        res.result.check = check;
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
        if (sprite == null)
            return this;

        const int MaxSize = 120;

        int srcWidth = (int)sprite.rect.width;
        int srcHeight = (int)sprite.rect.height;

        // If it already fits, don't touch it
        if (srcWidth <= MaxSize && srcHeight <= MaxSize)
        {
            result.icon = sprite;
            result.tinyIcon = sprite;
            return this;
        }

        // Compute downscale factor (never upscale)
        float scale = Mathf.Min(
            (float)MaxSize / srcWidth,
            (float)MaxSize / srcHeight
        );

        int dstWidth = Mathf.RoundToInt(srcWidth * scale);
        int dstHeight = Mathf.RoundToInt(srcHeight * scale);

        // Extract source pixels
        Texture2D srcTex = sprite.texture;
        Rect r = sprite.rect;
        Color[] pixels = srcTex.GetPixels(
            (int)r.x,
            (int)r.y,
            (int)r.width,
            (int)r.height
        );

        // Create scaled texture
        Texture2D dstTex = new Texture2D(dstWidth, dstHeight, srcTex.format, false);
        dstTex.filterMode = FilterMode.Bilinear;

        // Manual scale
        for (int y = 0; y < dstHeight; y++)
        {
            for (int x = 0; x < dstWidth; x++)
            {
                float u = x / (float)(dstWidth - 1);
                float v = y / (float)(dstHeight - 1);

                int sx = Mathf.RoundToInt(u * (srcWidth - 1));
                int sy = Mathf.RoundToInt(v * (srcHeight - 1));

                dstTex.SetPixel(x, y, pixels[sy * srcWidth + sx]);
            }
        }

        dstTex.Apply();

        Sprite scaledSprite = Sprite.Create(
            dstTex,
            new Rect(0, 0, dstWidth, dstHeight),
            new Vector2(0.5f, 0.5f),
            sprite.pixelsPerUnit
        );

        result.icon = scaledSprite;
        result.tinyIcon = scaledSprite;
        return this;
    }

    
    public RandoItemBuilder SetIcon(string icon)
    {
        return SetIcon(ModResources.LoadSprite(icon));
    }
    
    public RandoItemBuilder SetTinyIcon(Sprite sprite)
    {
        result.tinyIcon = sprite;
        return this;
    }
    
    public RandoItemBuilder SetTinyIcon(string icon)
    {
        return SetTinyIcon(ModResources.LoadSprite(icon));
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