using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;



public class BrollyLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public BrollyLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        return "Brolly";
    }

    public override void SetItem(string item)
    {
        var state = fsm.GetState("Msg");
        state.RemoveAction(3);
        state.RemoveAction(2);
        state.RemoveAction(1);
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
        state.AddAction(new Wait()
        {
            time = 0.5f,
            realTime = false
        });
        state.RemoveTransitionsTo("Fade Up");
        state.AddTransition("FINISHED", "Fade Up");
            
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}