using System;
using GlobalEnums;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;



public class ShrineWeaverAbilityLocation : ItemLocation
{
    private PlayMakerFSM fsm;
    public ShrineWeaverAbilityLocation(PlayMakerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override string GetItem()
    {
        
        WeaverSpireAbility ability = (WeaverSpireAbility)fsm.FsmVariables.EnumVariables[0].Value;
        return "ability_" + ability.ToString();
    }

    public override void SetItem(string item)
    {
        base.SetItem(item);
        Object.Destroy(fsm.GetComponent<PlayMakerNPC>());
        Object.Destroy(fsm);
    }

    public override GameObject GetObj()
    {
        return fsm.gameObject;
    }

}