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
        Object.Destroy(fsm.transform.parent.GetComponent<PersistentBoolItem>());
        if (IsChecked())
        {
            fsm.transform.parent.gameObject.SetActive(false);
        }
        var state = fsm.fsm.GetState("Collect");
        state.RemoveAction(6);
        state.InsertLambdaMethod(6, (fin) =>
        {
            // Make sure to check if its already obtained.
            AwardCollectable();
            fin();
        });
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}