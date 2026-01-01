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
        fsm.GetState("Final Bind Burst").RemoveAction(3);
        
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
            PlayerData.instance.spinnerDefeated = true;
            HeroController.instance.SetSilkRegenBlocked(true);
            PlayerData.instance.disableInventory = false;
            fin();
        });
        state.AddAction(new Wait()
        {
            time = 1f,
            realTime = false
        });
        
        state.AddAction(new QueueMemoryFullHeal());
        state.AddAction(new ToolsCutsceneControl()
        {
            SetInCutscene = false
        });
        

        var transition = fsm.GetState("To Memory Scene").GetAction<BeginSceneTransition>(2);
        transition.sceneName = "Belltown_Shrine";
        transition.entryGateName = "door_wakeOnGround";

    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}