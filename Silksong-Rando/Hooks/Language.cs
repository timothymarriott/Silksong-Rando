using System;
using HarmonyLib;
using TeamCherry.Localization;

[HarmonyPatch(typeof(Language), nameof(Language.Get), new Type[] { typeof(string), typeof(string) })]
class Language_Get_Patch
{
    public static bool Prefix(ref string __result, string key, string sheetTitle)
    {
        if (sheetTitle == "Rando")
        {
            __result = key;
            return false;
        }

        return true;
    }
}

[HarmonyPatch(typeof(Language), nameof(Language.Has), new Type[] { typeof(string), typeof(string) })]
class Language_Has_Patch
{
    public static bool Prefix(ref bool __result, string key, string sheetTitle)
    {
        if (sheetTitle == "Rando")
        {
            __result = true;
            return false;
        }

        return true;
    }
}