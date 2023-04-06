using System.Collections.Generic;
using Rizing.Abstract;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class ConveyorTile : RuleTile, ITile {

    private readonly List<Vector3Int> directions = new List<Vector3Int> {
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, -1, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(-1, 0, 0),
    };
    
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject instantiatedGameObject) {
        var data = instantiatedGameObject.GetComponent<ConveyorData>();
        data.position = position;
        data.direction = Vector3Int.zero;
        
        
        var parent_tilemap = data.transform.parent.GetComponent<Tilemap>();
        
        foreach (var dir in directions) {
            if(!(parent_tilemap.GetTile(position + dir) is ConveyorTile)) continue;
            
            var conveyorData = parent_tilemap.GetInstantiatedObject(position + dir).GetComponent<ConveyorData>();
            conveyorData.direction = dir * -1;
        }
        
        return base.StartUp(position, tilemap, instantiatedGameObject);
    }
    
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData) {
        tileData.sprite = m_DefaultSprite;
        tileData.gameObject = m_DefaultGameObject;
    }
}
