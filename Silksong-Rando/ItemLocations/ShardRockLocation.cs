using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong_Rando;



public class ShardRockLocation : ItemLocation
{
    private BreakableHolder rock;
    public ShardRockLocation(BreakableHolder rock)
    {
        this.rock = rock;
    }
    
    public override string GetItem()
    {
        return "shardrock_" + rock.persistent.itemData.ID;
    }
    
    public override GameObject GetObj()
    {
        return rock.gameObject;
    }

    public override void SetItem(string item)
    {
        base.SetItem(item);
        Object.Destroy(rock.gameObject);
    }
}
