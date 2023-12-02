using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Game.Core
{
    public class MapSystem : MonoBehaviour
    {
        [SerializeField] Tilemap tilemap;
        [SerializeField] TileBase tileBase;
        [SerializeField] int width = 20;
        [SerializeField] int height = 20;

        void Awake()
        {
            GenerateGrid();
        }

        void GenerateGrid()
        {
            // Loop through each cell in the grid and set the tile
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3Int cellPosition = new(x, y, 0);
                    tilemap.SetTile(cellPosition, tileBase);
                }
            }
        }
    }
}
