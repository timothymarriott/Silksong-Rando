using HarmonyLib;
using Silksong.Rando;
using Silksong.Rando.Map;

namespace Silksong.Rando.Hooks;

[HarmonyPatch(typeof(GameMap), nameof(GameMap.Start))]
class GameMap_Start_Patch
{
    public static void Postfix(GameMap __instance)
    {
        RandoMap.instance.CreateLocationPins();
        GameManager.instance.UpdateGameMapWithPopup();
    }
}