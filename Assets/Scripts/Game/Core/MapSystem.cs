using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Game.Core
{
    public class MapSystem : MonoBehaviour
    {
        [SerializeField] Tilemap background;
        [SerializeField] Tilemap playersContainer;
        [SerializeField] TileBase bgTile;
        [SerializeField] TileBase playerTile;
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
                    background.SetTile(cellPosition, bgTile);
                    GameObject instantiatedObject = background.GetInstantiatedObject(cellPosition);
                    GridSingle gridSingle = instantiatedObject.GetComponent<GridSingle>();
                    gridSingle.UpdateInfomation(cellPosition);
                }
            }
        }
    }
}
