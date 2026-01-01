using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx.Logging;
using UnityEngine;

namespace Silksong.Rando;

public class ModResources : MonoBehaviour
{
    public static ManualLogSource Logger;
    private static Dictionary<string, Sprite> Images = new Dictionary<string, Sprite>();
    private static Dictionary<string, string> Data = new Dictionary<string, string>();
    
    public Font trajanBold;
    public Font trajanNormal;
    public Font arial;
    
    public static Sprite LoadSprite(string id, float pixelsPerUnit = 64f)
    {
        if (!Images.TryGetValue(id, out var sprite))
        {
            return Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 4, 4), Vector2.one * 0.5f, pixelsPerUnit);
        }
        return sprite;
    }

    public static string LoadData(string id)
    {
        #if DEBUG

        return File.ReadAllText(Path.Combine(@"E:\Games\Silksong\Mods\Silksong-Rando\Silksong.Rando\Resources", id + ".json"));

#else
        if (!Data.TryGetValue(id, out var text))
        {
            throw new KeyNotFoundException(id);
        }

        return text;
#endif
    }

    public static Stream GetResourceStream(string id)
    {
        string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        const string dataPrefix = "Silksong.Rando.Resources.";

        foreach (string res in resourceNames)
        {
            if (res.EndsWith(".json") && res.StartsWith("Silksong.Rando.Resources."))
            {
                string relativeName = res.Substring(dataPrefix.Length).Replace(".json", "").Replace(".png", "");
                string internalName = relativeName.Replace('.', '/');
                if (internalName == id)
                {
                    return Assembly.GetExecutingAssembly().GetManifestResourceStream(res);
                }
            }
        }

        throw new FileNotFoundException();
    }

    public static AssetBundle LoadAssetBundle(string id)
    {
        string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        const string dataPrefix = "Silksong.Rando.Resources.";

        foreach (string res in resourceNames)
        {
            if (res.EndsWith(".bundle") && res.StartsWith("Silksong.Rando.Resources."))
            {
                string relativeName = res.Substring(dataPrefix.Length).Replace(".bundle", "");
                string internalName = relativeName.Replace('.', '/');
                if (internalName == id)
                {
                    var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(res);
                    using var ms = new MemoryStream();
                    stream.CopyTo(ms);
                    byte[] data = ms.ToArray();

                    return AssetBundle.LoadFromMemory(data);
                }
            }
        }

        throw new FileNotFoundException();
    }

    public static ModResources LoadResources(ManualLogSource logger)
    {
        Logger = logger;
        string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        
        const string imagePrefix = "Silksong.Rando.Resources.Images.";
        const string dataPrefix = "Silksong.Rando.Resources.";

        foreach (string res in resourceNames)
        {
            if (res.EndsWith(".png") && res.StartsWith(imagePrefix))
            {
                try
                {
                    string relativeName = res.Substring(imagePrefix.Length).Replace(".png", "");
                    string internalName = relativeName.Replace('.', '/');
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
                string relativeName = res.Substring(dataPrefix.Length).Replace(".json", "");
                string internalName = relativeName.Replace('.', '/');
                Data.Add(internalName, Assembly.GetExecutingAssembly().LoadEmbeddedText(res));
            }
        }

        return RandoPlugin.instance.gameObject.AddComponent<ModResources>();
    }

    private void Update()
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
    }

    public static Font GetFont()
    {
        return RandoPlugin.instance.resources.arial;
    }

    public static GUIStyle GetLabelStyle()
    {
        return new GUIStyle()
        {
            fontSize = 30,
            fontStyle = FontStyle.Normal,
            normal = new GUIStyleState()
            {
                textColor = Color.white
            }
        };
    }
}