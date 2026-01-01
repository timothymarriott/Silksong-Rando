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

        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> RoomChecks = new();

        public static bool IsSearching = false;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y) && Input.GetKey(KeyCode.F11) && !IsSearching)
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

                    List<string> RoomGates = new();
                    foreach (var transition in TransitionPoint.TransitionPoints)
                    {
                        if (transition.gameObject.scene.name == scene)
                        {
                            RoomGates.Add(transition.name);
                        }
                    }

                    Dictionary<string, Dictionary<string, string>> trans =
                        new Dictionary<string, Dictionary<string, string>>();

                    foreach (var gate in RoomGates)
                    {
                        var dict = new Dictionary<string, string>();
                        foreach (var roomGate in RoomGates)
                        {
                            dict.Add(roomGate, "TRANSITION_NOTSET");
                        }
                        foreach (var loc in ItemLocations)
                        {
                            if (loc.Value.locationData.scene == scene)
                            {
                                dict.Add(loc.Value.locationData.item, "ITEM_NOTSET");
                            }
                        }
                        trans.Add(gate, dict);
                    }
                    
                    RoomChecks.Add(scene, trans);
                    File.WriteAllText(Application.persistentDataPath + "\\rando\\room_logic.json", JsonConvert.SerializeObject(RoomChecks, Formatting.Indented));


                }, () =>
                {
                    IsSearching = false;
                });
            }
        }
    }
}