using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Silksong.Rando.Locations;

namespace Silksong.Rando;

public class RandoResources : ModResources
{

    private static Dictionary<string, ItemLocationData>? locationDataCache;
    
    public static Dictionary<string, ItemLocationData> ReadLocationsData()
    {
        locationDataCache ??= JsonConvert.DeserializeObject<Dictionary<string, ItemLocationData>>(LoadData("locations"));
        
        if (locationDataCache == null)
        {
            throw new Exception("No location data.");
        }
        
        return locationDataCache;
    }
    
}
