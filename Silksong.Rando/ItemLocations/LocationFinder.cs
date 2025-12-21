using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Silksong.Rando.Locations
{
    public class LocationFinder : MonoBehaviour
    {
        public static Dictionary<string, ItemLocation> ItemLocations = new();

        public static bool IsSearching = false;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y) && !IsSearching)
            {
                IsSearching = true;
                SceneLoader.ExecuteLoad(GameScenes.Scenes, (scene, i) =>
                {
                    RandoPlugin.Log.LogInfo($"Searching {scene.name} ({i}/{GameScenes.Scenes.Count}) found {ItemLocations.Count} locations.");
                    File.WriteAllLines(Application.persistentDataPath + "\\rando\\locations.txt", ItemLocations.Keys);
                    Dictionary<string, ItemLocationData> locations = new();
                    foreach (var loc in ItemLocations)
                    {
                        locations.Add(loc.Key, loc.Value.locationData);
                    }
                    File.WriteAllText(Application.persistentDataPath + "\\rando\\locations.json", JsonConvert.SerializeObject(locations, Formatting.Indented));

                }, () =>
                {
                    IsSearching = false;
                });
            }
        }
    }
}