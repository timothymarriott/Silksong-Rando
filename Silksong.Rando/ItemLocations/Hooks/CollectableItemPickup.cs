using HarmonyLib;

namespace Silksong.Rando.Hooks;

[HarmonyPatch(typeof(CollectableItemPickup), nameof(CollectableItemPickup.Start))]
class CollectableItemPickup_Start_Patch
{
    public static void Prefix(CollectableItemPickup __instance)
    {
        if (!(__instance.item is RandoItem) && !RandoPlugin.instance.PickupsToIgnore.Contains(__instance))
        {
            CollectableItemPickupLocation loc = new CollectableItemPickupLocation(__instance);
            loc.AddToCurrentScene();
        }
    }
}