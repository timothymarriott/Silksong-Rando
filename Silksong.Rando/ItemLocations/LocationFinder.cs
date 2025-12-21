using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Silksong.Rando.Data;
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
                SceneLoader.ExecuteLoad(GameScenes.SceneNames, (scene, i) =>
                {
                    RandoPlugin.Log.LogInfo($"Searching {scene} ({i}/{GameScenes.SceneNames.Count}) found {ItemLocations.Count} locations.");
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