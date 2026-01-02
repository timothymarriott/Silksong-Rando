using HarmonyLib;

namespace Silksong.Rando.Map.Hooks;

[HarmonyPatch(typeof(GameMap), nameof(GameMap.Start))]
class GameMap_Start_Patch
{
    public static void Postfix(GameMap __instance)
    {
        RandoMap.Instance.CreateLocationPins();
        RandoPlugin.GM.UpdateGameMapWithPopup();
    }
}