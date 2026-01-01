using System;
using System.Collections;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Silksong.Rando
{
    public class SceneLoader : MonoBehaviour
    {
        private static ManualLogSource Log => RandoPlugin.Log;
        
        public static SceneLoader Setup()
        {
            return RandoPlugin.instance.gameObject.AddComponent<SceneLoader>();
        }

        public static void ExecuteLoad(List<string> scenes, OnSceneCallback OnScene, Action? OnComplete = null)
        {
            RandoPlugin.instance.sceneLoader.StartCoroutine(RandoPlugin.instance.sceneLoader.LoadAll(scenes, OnScene, OnComplete));
        }
        
        public bool IsLoading = false;

        public delegate void OnSceneCallback(string scene, int index);
        
        public IEnumerator LoadAll(List<string> scenes, OnSceneCallback OnScene, Action? OnComplete = null)
        {
            Log.LogInfo($"Starting task on {scenes.Count} scenes.");
            if (!IsLoading)
            {
                IsLoading = true;
                GameCameras.instance.mainCamera.GetComponent<tk2dCamera>().ZoomFactor = 0.3f;
                TimeManager.TimeScale = 0;
                Time.timeScale = 0;
                for (int i = 0; i < scenes.Count; i++)
                {
            
                    string scn = scenes[i];
                    var task = Addressables.LoadSceneAsync("Scenes/" + scn, LoadSceneMode.Single, true);
                    while (!task.IsDone)
                    {
                        yield return null;
                    }
                    yield return null;

                    if (OnScene != null)
                    {
                        OnScene(scn, i);
                    }
                
                    yield return null;
                }
                TimeManager.TimeScale = 1;
                Time.timeScale = 1;
                IsLoading = false;
                RandoPlugin.GM.ReturnToMainMenuNoSave();

                if (OnComplete != null)
                    OnComplete();
            }
        }
    }
}