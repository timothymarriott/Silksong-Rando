using HarmonyLib;
using Silksong_Rando;
using Silksong_Rando.Map;

[HarmonyPatch(typeof(GameMap), nameof(GameMap.Start))]
class GameMap_Start_Patch
{
    public static void Postfix(GameMap __instance)
    {
        RandoMap.instance.CreateLocationPins();
        GameManager.instance.UpdateGameMapWithPopup();
    }
}