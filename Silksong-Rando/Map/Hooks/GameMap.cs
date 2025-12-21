using HarmonyLib;
using Silksong_Rando;
using Silksong_Rando.Map;

[HarmonyPatch(typeof(GameMap), nameof(GameMap.Start))]
class GameMap_Start_Patch
{
    public static void Postfix(GameMap __instance)
    {
        RandoMap.instance.CreateLocationPins();
        foreach (var scene in GameScenes.Scenes)
        {
            GameManager.instance.playerData.scenesMapped.Add(scene);
        }
        
        GameManager.instance.playerData.mapAllRooms = true;
        GameManager.instance.UpdateGameMapWithPopup();

    }
}