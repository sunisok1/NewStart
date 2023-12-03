using Assets.Scripts.Common.Manager;
using Assets.Scripts.Game.Core;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameMgr : MgrBase
    {
        public enum GameState
        {
            Start,
            Game
            // Add more states as needed
        }


        public GameState CurrentGameState { get; private set; }

        // Call this method to change the game state and load the associated scene
        public void ChangeGameState(GameState newState)
        {
            CurrentGameState = newState;

            Entry.UIMgr.CloseAll();
            // You can perform additional actions or setup based on the game state here
            switch (newState)
            {
                case GameState.Start:
                    Entry.UIMgr.OpenUI<MenuUI>();
                    break;
                case GameState.Game:
                    Entry.UIMgr.OpenUI<GameUI>();
                    Entry.CameraController.Init();
                    MapSystem gridSystem = Resources.Load<MapSystem>(ViewConst.Core_Map_MapSystem);
                    Object.Instantiate(gridSystem.gameObject);
                    Entry.TurnSystem.StartGame();
                    break;
                default:
                    break;
            }
        }
    }
}