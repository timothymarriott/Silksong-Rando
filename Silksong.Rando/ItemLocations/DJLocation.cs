using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;



public class DJLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public DJLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        return "Faydown";
    }

    public override void SetItem(string item)
    {

        var checkState = fsm.GetState("Has DJ?");
        checkState.RemoveAction(0);
        checkState.AddLambdaMethod((fin) =>
        {
            if (IsChecked())
            {
                fsm.Fsm.Event(checkState.GetTransitionEvent(0));
            }
            else
            {
                fsm.Fsm.Event(checkState.GetTransitionEvent(1));
            }
            
        });

        var state = fsm.GetState("Msg");
        state.RemoveAction(13);
        state.RemoveAction(12);
        state.RemoveAction(11);
        state.AddAction(new Wait()
        {
            time = 0.5f,
            realTime = false
        });
        state.AddLambdaMethod((fin) =>
        {
            AwardCollectable();
            fin();
        });
        state.RemoveTransitionsTo("Fade Back Pause");
        state.AddTransition("FINISHED", "Fade Back Pause");

    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}