using System;
using HarmonyLib;
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
            if (RandoPlugin.instance.GameMode.Enabled)
            {
                if (info.SceneName == "Opening_Sequence" && SaveData.Instance.RandoSeed == -1)
                {
                    
                    int seed = UnityEngine.Random.Range(0, int.MaxValue);
                    RandoPlugin.Log.LogInfo($"Starting rando with seed {seed}");
                    SaveData.Instance.RandoSeed = seed;
                    SaveData.Instance.ItemReplacements = RandoPlugin.instance.logic.GenerateSeed(seed);
                }
                
            }
        }
        
    }
}