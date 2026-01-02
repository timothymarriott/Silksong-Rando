using System;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using PrepatcherPlugin;
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
    private MossberryLocationType locType;
    private PlayMakerFSM fsm;
    private HealthManager? aspid;
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
        Object.Destroy(fsm.GetComponent<PersistentBoolItem>());
        if (locType == MossberryLocationType.Vine)
        {
            if (SaveData.Instance.CollectedChecks.Contains(GetLocationID()))
            {
                fsm.gameObject.SetActive(false);
            }
            fsm.fsm.GetState("Init").InsertLambdaMethod(4, fin =>
            {
                var state = fsm.fsm.GetGameObjectVariable("Fruit").Value.GetComponent<PlayMakerFSM>().fsm.GetState("Collect");
                state.RemoveAction(2);
                state.InsertLambdaMethod(2, (giveFin) =>
                {
                    AwardCollectable();
                    giveFin();
                });
                fin();
            });
        }
        else if (locType == MossberryLocationType.Aspid)
        {
            RandoPlugin.Log.LogInfo(aspid);
            RandoPlugin.Log.LogInfo(fsm);
            var state = fsm.fsm.GetState("Collect");
            state.RemoveAction(2);
            state.InsertLambdaMethod(2, (fin) =>
            {
                AwardCollectable();
                fin();
            });
        }
        
    }

    public override GameObject GetObj()
    {
        if (locType == MossberryLocationType.Vine)
            return fsm.gameObject;
        if (locType == MossberryLocationType.Aspid)
            return aspid!.gameObject;
        return fsm.gameObject;
    }

    public static void InstallHooks()
    {
        
        PlayerDataVariableEvents.OnGetBool += ((_, name, current) =>
        {
            if (RandoPlugin.Instance.GameMode.Enabled)
            {
                
                if (name == "mosstownAspidBerryCollected")
                {
                    return SaveData.Instance.CollectedChecks.Contains("Bone_05b|Mossberry");
                }

                if (name == "bonegraveAspidBerryCollected")
                {
                    return SaveData.Instance.CollectedChecks.Contains("Bonegrave|Mossberry");
                }

                if (name == "bonetownAspidBerryCollected")
                {
                    return SaveData.Instance.CollectedChecks.Contains("Bonetown|Mossberry");
                }

                
            }
            
            return current;
        });
    
    }

}