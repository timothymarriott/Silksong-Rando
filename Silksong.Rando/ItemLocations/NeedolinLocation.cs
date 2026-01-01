using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;



public class NeedolinLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public NeedolinLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        return "ability_Needolin";
    }

    public override void SetItem(string item)
    {
        var state = fsm.GetState("Get Needolin");
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
            
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}