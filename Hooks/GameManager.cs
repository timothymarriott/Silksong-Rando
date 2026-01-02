using System;
using System.Collections.Generic;
using HarmonyLib;
using Newtonsoft.Json;
using Silksong.Rando.Locations;
using Silksong.Rando.Logic;

namespace Silksong.Rando.Hooks
{
    [HarmonyPatch]
    public class GameManagerHooks
    {

        [HarmonyPatch(typeof(GameManager), nameof(GameManager.BeginSceneTransition), new Type[] { typeof(GameManager.SceneLoadInfo) })]
        [HarmonyPostfix]
        public static void BeginSceneTransition(GameManager __instance, GameManager.SceneLoadInfo info)
        {
            if (RandoPlugin.Instance.GameMode.Enabled)
            {
                if (info.SceneName == "Opening_Sequence" && SaveData.Instance.RandoSeed == -1)
                {
                    int seed = UnityEngine.Random.Range(0, int.MaxValue);
                    RandoPlugin.Log.LogInfo($"Starting rando with seed {seed}");
                    SaveData.Instance.RandoSeed = seed;
                    SaveData.Instance.ItemReplacements = RandoPlugin.Instance.Logic.GenerateSeed(seed);
                }
                
            }
        }
        
        [HarmonyPatch(typeof(GameManager), nameof(GameManager.ClearSaveFile), new Type[] { typeof(int), typeof(Action<bool>) })]
        [HarmonyPostfix]
        public static void ClearSaveFile(GameManager __instance, int saveSlot, Action<bool> callback)
        {
            if (RandoPlugin.Instance.GameMode.Enabled)
            {
                SaveData.Clear();
            }
        }
        
        [HarmonyPatch(typeof(GameManager), nameof(GameManager.Start))]
        [HarmonyPostfix]
        public static void Start(GameManager __instance)
        {
            RandoPlugin.Instance.LoadFakeCollectables();
        }
        
    }
}