using System;
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
            Entry.EventMgr.Subscribe(EventType.TurnSystem_AddPlayer, TurnSystem_AddPlayer);
        }

        private void TurnSystem_AddPlayer(object sender, EventArgs args)
        {
            int x = UnityEngine.Random.Range(0, width);
            int y = UnityEngine.Random.Range(0, height);
            Vector3Int cellPosition = new(x, y, 0);
            playersContainer.SetTile(cellPosition, playerTile);
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
