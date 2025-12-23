using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;

public class VaultMelodyLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public VaultMelodyLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        return "melody_Vault";
    }

    public override void SetItem(string item)
    {
        var giveFsm = fsm.GetState("Needolin").GetAction<RunFSM>(4).fsmTemplateControl;
        var giveState = giveFsm.RunFsm.GetState("Give Item");
        giveState.RemoveAction(0);
        giveState.AddAction(new Wait()
        {
            time = 0.5f,
            realTime = false
        });
        giveState.AddLambdaMethod((fin) =>
        {
            // Make sure to check if its already obtained.
            RandoPlugin.GetCollectableItem(item).Get(1, true);
            fin();
        });

        var uiState = giveFsm.RunFsm.GetState("UI Msg");
        uiState.RemoveAction(4);
        uiState.RemoveAction(3);
        uiState.RemoveAction(1);
        uiState.RemoveAction(0);
        uiState.RemoveTransitionsTo("Stop Needolin");
        uiState.AddTransition("FINISHED", "Stop Needolin");
            
            
        var stopstate = giveFsm.RunFsm.GetState("Stop Needolin");
        stopstate.RemoveTransitionsTo("Give Item");
        stopstate.AddTransition("FINISHED", "Give Item");
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}