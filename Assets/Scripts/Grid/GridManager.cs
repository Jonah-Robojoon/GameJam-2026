using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] public Grid grid;

    public Dictionary<Vector3Int, TileData> GridDataMap = new Dictionary<Vector3Int, TileData>();


    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CalculateGridBasedOnTileMap();
    }

    public void CalculateGridBasedOnTileMap()
    {
        // make all the tiles in the tilemap walkable and not occupied
        BoundsInt bounds = tilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(pos)) continue;

            TileData data = new TileData(
                false
            );
            GridDataMap[pos] = data;
        }
    }
}
