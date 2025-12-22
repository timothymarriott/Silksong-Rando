using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;



public class PollipBulbLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public PollipBulbLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        return "Shell Flower";
    }

    public override void SetItem(string item)
    {
        fsm.fsm.GetState("Collect").GetAction<CollectableItemCollect>(6).Item.RawValue =
            RandoPlugin.GetCollectableItem(item);
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}