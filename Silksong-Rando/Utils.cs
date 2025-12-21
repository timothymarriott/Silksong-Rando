using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx.Logging;
using Silksong_Rando;
using UnityEngine;


public static class Utils
{
    public static ManualLogSource Logger;
    private static Dictionary<string, Sprite> Images = new Dictionary<string, Sprite>();
    public static Sprite LoadSprite(string id, float pixelsPerUnit = 64f)
    {
        if (!Images.ContainsKey(id))
        {
            return Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 4, 4), Vector2.one * 0.5f, pixelsPerUnit);
        }
        return Images[id];
    }

    public static void LoadResources()
    {
        string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        

        foreach (string res in resourceNames)
        {
            RandoPlugin.Log.LogInfo("Loading resource " + res);
            if (res.StartsWith("Silksong-Rando.Images."))
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
        }
    }
}