using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    public Vector2Int bounds;
    public List<Tile> tiles;
    public Tilemap tilemap;

    void Start()
    {
        for (int x = -bounds.x; x < bounds.x; x++)
        {
            for(int y= -bounds.y; y<bounds.y;y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), tiles[Random.Range(0, tiles.Count-1)]);
            }
        }
        
    }
}
