using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksong.Rando;



public class GeoRockLocation : ItemLocation
{
    private GeoRock rock;
    public GeoRockLocation(GeoRock rock)
    {
        this.rock = rock;
    }
    
    public override string GetItem()
    {
        return "georock_" + rock.geoRockData.id + "_" + rock.BreakableType;
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