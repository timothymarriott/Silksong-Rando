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



        var gate = FindGate();
        if (RandoPlugin.GM.sceneName != "Belltown_Shrine" && gate != null)
        {
            Object.Destroy(gate.GetComponent<DeactivateIfPlayerdataTrue>());
            if (IsChecked())
            {
            
                gate.gameObject.SetActive(false);
            }
            else
            {
                gate.gameObject.SetActive(true);
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
        var gate = FindGate();
        if (!IsChecked() && RandoPlugin.GM.sceneName != "Belltown_Shrine" && gate != null)
        {
            gate.Open();
        }
        AwardCollectable();
    }

    public Gate? FindGate()
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
            throw new ArgumentNullException(nameof(sequence));
        }
        
        if (Replacements.TryGetValue(sequence, out BellshrineLocation? value))
        {
            value.Collect();
        }
    }

}