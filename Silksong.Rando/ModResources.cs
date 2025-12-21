using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx.Logging;
using UnityEngine;

namespace Silksong.Rando;

public static class ModResources
{
    public static ManualLogSource Logger;
    private static Dictionary<string, Sprite> Images = new Dictionary<string, Sprite>();
    private static Dictionary<string, string> Data = new Dictionary<string, string>();
    public static Sprite LoadSprite(string id, float pixelsPerUnit = 64f)
    {
        if (!Images.TryGetValue(id, out var sprite))
        {
            return Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 4, 4), Vector2.one * 0.5f, pixelsPerUnit);
        }
        return sprite;
    }

    public static void LoadResources()
    {
        string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        

        foreach (string res in resourceNames)
        {
            if (res.EndsWith(".png") && res.StartsWith("Silksong.Rando.Resources.Images"))
            {
                try
                {
                    string[] split = res.Split('.');
                    string internalName = split[split.Length - 2];
                    Images.Add(internalName, Assembly.GetExecutingAssembly().LoadEmbeddedSprite(res));

                    Logger.LogInfo("Loaded image: " + internalName);
                }
                catch (Exception e)
                {
                    Logger.LogInfo("Failed to load image: " + res + "\n" + e.ToString());
                }
            }

            if (res.EndsWith(".json") && res.StartsWith("Silksong.Rando.Resources."))
            {
                string[] split = res.Split('.');
                string internalName = split[^2];
                Data.Add(internalName, Assembly.GetExecutingAssembly().LoadEmbeddedText(res));
            }
        }
    }
}