using HarmonyLib;
using UnityEngine;

namespace Silksong.Rando.Hooks
{
    #if DEV
    [HarmonyPatch]
    public class AnimatorHooks
    {
        public static bool IsStartComplete;
        
        [HarmonyPatch(typeof(AnimatorStateInfo), nameof(AnimatorStateInfo.shortNameHash), MethodType.Getter)]
        [HarmonyPrefix]
        public static bool GetShortNameHash(ref int __result)
        {
            if (IsStartComplete)
            {
                __result = Animator.StringToHash("LoadingIcon");
                return false;
            }

            return true;

        }
        
    }

    [HarmonyPatch]
    public class StartManagerHooks
    {
        [HarmonyPatch(typeof(StartManager), nameof(StartManager.Start))]
        [HarmonyPostfix]
        public static void Start(ref StartManager __instance)
        {
            AnimatorHooks.IsStartComplete = true;
        }
    }
    #endif
}