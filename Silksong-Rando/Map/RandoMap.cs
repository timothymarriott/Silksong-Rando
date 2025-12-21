using UnityEngine;

namespace Silksong_Rando.Map;

public class RandoMap : MonoBehaviour
{
    public static GameManager GM => RandoPlugin.GM;

    public static RandoMap instance;
    
    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    
    public void CreateMapPin(Vector2 positionInScene, string sceneName, Vector2 sceneSize)
    {
        GM.gameMap.GetSceneInfo(sceneName, GM.gameMap.GetMapZoneFromSceneName(sceneName), out GameMapScene scene, out var scnobj, out var pos);
        Vector2 position = GM.gameMap.GetMapPosition(positionInScene, scene, scnobj, pos, sceneSize);

        Transform parent = GM.gameMap.compassIcon.transform.parent;
        
        for (int i = 0; i < GM.gameMap.compassIcon.transform.parent.childCount; i++)
        {
            if (GM.gameMap.compassIcon.transform.parent.GetChild(i).gameObject.name == "Map Markers")
            {
                parent = GM.gameMap.compassIcon.transform.parent.GetChild(i);
            }
        }
        
        GameObject obj = Instantiate(parent.GetChild(0).gameObject, parent);
        
        obj.transform.SetLocalPosition2D((Vector2) new Vector3(position.x, position.y, -1f));
        if (!obj.activeSelf)
            obj.SetActive(true);
    }

    public void CreateLocationPins()
    {
        foreach (var replacement in RandoPlugin.instance.ItemReplacements)
        {
            if (RandoPlugin.instance.ItemLocationData.ContainsKey(replacement.Key))
            {
                var data = RandoPlugin.instance.ItemLocationData[replacement.Key];
                CreateMapPin(new Vector2(data.PositionInSceneX, data.PositionInSceneY), replacement.Key.Split("|")[0], new Vector2(data.RoomSizeX, data.RoomSizeY));
            }
        }
    }

    
}
