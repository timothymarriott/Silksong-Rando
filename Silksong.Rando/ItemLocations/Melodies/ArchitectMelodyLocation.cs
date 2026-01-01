using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;

public class ArchitectMelodyLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public ArchitectMelodyLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        return "melody_Architect";
    }

    public override void SetItem(string item)
    {
        bool hasChecked = IsChecked();
            
        var notifyState = fsm.GetState("Wait For Notify");
            
        if (hasChecked)
        {
            notifyState.GetAction<PlayerDataVariableTest>(0).IsExpectedEvent = notifyState.GetTransitionEvent(2);
            notifyState.GetAction<PlayerDataVariableTest>(0).IsNotExpectedEvent = notifyState.GetTransitionEvent(2);
        }
        else
        {
            notifyState.GetAction<PlayerDataVariableTest>(0).IsExpectedEvent = null;
        }
            
        var state = fsm.GetState("Show Prompt");
        state.RemoveAction(0);
        state.AddAction(new Wait()
        {
            time = 1f,
            realTime = false
        });
        state.AddLambdaMethod((fin) =>
        {
            HeroController.instance.RelinquishControl();
            RandoPlugin.GM.playerData.disableInventory = false;
            AwardCollectable();
            HeroController.instance.RegainControl();
            fin();
        });
        state.RemoveTransitionsTo("Singing End");
        state.AddTransition("FINISHED", "Singing End");
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}