using System;
using System.Collections.Generic;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando.Locations;



public class BellshrineLocation : ItemLocation
{
    private static Dictionary<StateChangeSequence, BellshrineLocation> Replacements = new();
    private StateChangeSequence sequence;
    public BellshrineLocation(StateChangeSequence sequence)
    {
        this.sequence = sequence;
        
        

        if (RandoPlugin.GM.sceneName != "Belltown_Shrine")
        {
            Object.Destroy(FindGate().GetComponent<DeactivateIfPlayerdataTrue>());
            if (IsChecked())
            {
            
                FindGate().gameObject.SetActive(false);
            }
            else
            {
                FindGate().gameObject.SetActive(true);
            }
        }
        
    }

    public override string GetItem()
    {
        return "Bell_" + sequence.isCompleteBool;
    }

    public override void SetItem(string item)
    {
        Replacements.Add(sequence, this);
    }

    public override GameObject GetObj()
    {
        return sequence.gameObject;
    }

    public void Collect()
    {
        if (!IsChecked() && RandoPlugin.GM.sceneName != "Belltown_Shrine")
        {
            FindGate().Open();
        }
        AwardCollectable();
    }

    public Gate FindGate()
    {
        foreach (var gate in Object.FindObjectsByType<Gate>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            if (gate.name.StartsWith("bellshrine_gate_curved"))
            {
                return gate;
            }
        }

        return null;
    }

    public static void OnSetIsCompleteBool(StateChangeSequence sequence)
    {
        if (sequence == null)
        {
            RandoPlugin.Log.LogInfo("NULL SEQUENCE");
        }
        
        if (Replacements.ContainsKey(sequence))
        {
            Replacements[sequence].Collect();
        }
    }

}