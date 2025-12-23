using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;


public enum MossberryLocationType
{
    Vine,
    Aspid
}

public class MossberryLocation : ItemLocation
{
    private MossberryLocationType locType = MossberryLocationType.Vine;
    private PlayMakerFSM fsm = null;
    private HealthManager aspid = null;
    public MossberryLocation(PlayMakerFSM fsm)
    {
        locType = MossberryLocationType.Vine;
        this.fsm = fsm;
    }
    
    public MossberryLocation(HealthManager aspid, PlayMakerFSM fsm)
    {
        locType = MossberryLocationType.Aspid;
        this.aspid = aspid;
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        return "Mossberry";
    }

    public override void SetItem(string item)
    {
        if (locType == MossberryLocationType.Vine)
        {
            var obj = Object.Instantiate(fsm.fsm.GetState("Init").GetAction<CreateObject>(3).gameObject.Value, fsm.transform);
            obj.GetComponent<PlayMakerFSM>().fsm.GetState("Collect").GetAction<CollectableItemCollect>(2).Item.RawValue = RandoPlugin.GetCollectableItem(item);
            fsm.fsm.GetState("Init").GetAction<CreateObject>(3).gameObject.Value = obj;
        }
        else if (locType == MossberryLocationType.Aspid)
        {
            RandoPlugin.Log.LogInfo(aspid);
            RandoPlugin.Log.LogInfo(fsm);
            var state = fsm.fsm.GetState("Collect");
            var action = state.GetAction<CollectableItemCollect>(2);
            action.Item.RawValue = RandoPlugin.GetCollectableItem(item);
        }
        
    }

    public override GameObject GetObj()
    {
        if (locType == MossberryLocationType.Vine)
            return fsm.gameObject;
        if (locType == MossberryLocationType.Aspid)
            return aspid.gameObject;
        return fsm.gameObject;
    }

}