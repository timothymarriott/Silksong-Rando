using HarmonyLib;

namespace Silksong.Rando.Locations.Hooks;

[HarmonyPatch(typeof(CollectableItemPickup), nameof(CollectableItemPickup.Start))]
class CollectableItemPickup_Start_Patch
{
    public static void Prefix(CollectableItemPickup __instance)
    {
        if (!(__instance.item is RandoItem) && !RandoPlugin.Instance.PickupsToIgnore.Contains(__instance) && (__instance.item.name != "Trobbio Quill Red") && (__instance.item.name != "Shiny Bell Goomba"))
        {
            CollectableItemPickupLocation loc = new CollectableItemPickupLocation(__instance);
            loc.AddToCurrentScene();
        }
    }
}