using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Silksong.Rando.Data.Extractors
{
    
    [Serializable]
    public class SceneInfo
    {
        public float width;
        public float height;

        public Vector2 Size => new(width, height);
    }
    
    public class SceneDumper : MonoBehaviour
    {
        
        

        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T) && Input.GetKey(KeyCode.F11))
            {
                RandoPlugin.Log.LogInfo("Starting to laod scene sizes");
                Dictionary<string, SceneInfo> sceneSizes = new Dictionary<string, SceneInfo>();
                SceneLoader.ExecuteLoad(GameScenes.SceneNames, (scene, i) =>
                {
                    RandoPlugin.Log.LogInfo($"Searching {scene} ({i}/{GameScenes.SceneNames.Count})");
                    try
                    {
                        sceneSizes.Add(scene, new SceneInfo()
                        {
                            width = RandoPlugin.GM.tilemap.width,
                            height = RandoPlugin.GM.tilemap.height
                        });
                    }
                    catch (Exception e)
                    {
                        RandoPlugin.Log.LogError(e);
                    }
                
                }, () =>
                {
                    File.WriteAllText(Application.persistentDataPath + "\\rando\\scenes.json", JsonConvert.SerializeObject(sceneSizes, Formatting.Indented));
                });
            }
        }
    }
}