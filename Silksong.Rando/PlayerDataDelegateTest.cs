using System;
using System.Reflection;
using MonoMod.RuntimeDetour;

namespace Silksong.Rando;

public class PlayerDataDelegateTestGroup : PlayerDataTest
{
    private static bool initialised;
    private static Hook? isFulfilledHook;

    public delegate bool IsFulfilledCallback(PlayerData data);

    private readonly IsFulfilledCallback callback;

    public PlayerDataDelegateTestGroup(IsFulfilledCallback callback)
    {
        this.callback = callback;

        if (!initialised)
        {
            initialised = true;
            HookIsFulfilled();
        }
    }

    private static void HookIsFulfilled()
    {
        var getter = typeof(PlayerDataTest).GetProperty("IsFulfilled", BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod();

        isFulfilledHook = new Hook(
            getter,
            new Func<Func<PlayerDataTest, bool>, PlayerDataTest, bool>(IsFulfilledDetour)
        );
        
    }

    private static bool IsFulfilledDetour(Func<PlayerDataTest, bool> orig, PlayerDataTest self)
    {
        if (self is PlayerDataDelegateTestGroup group)
        {
            return group.callback(RandoPlugin.GM.playerData);
        }
        return orig(self);
    }
}