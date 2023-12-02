using Assets.Scripts.Common.Manager;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.Utils;
using Assets.Scripts.Game.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class GameManager : ManagerBase
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

            GameEntry.UIManager.CloseAll();
            // You can perform additional actions or setup based on the game state here
            switch (newState)
            {
                case GameState.Start:
                    GameEntry.UIManager.OpenUI<MenuUI>();
                    break;
                case GameState.Game:
                    MapSystem gridSystem = Resources.Load<MapSystem>(ViewConst.Prefabs_Core_Map_MapSystem);
                    Object.Instantiate(gridSystem.gameObject);
                    TurnSystem.Instance.AddPlayer(PlayerFactory.CreatePlayer("测试_1"));
                    TurnSystem.Instance.AddPlayer(PlayerFactory.CreatePlayer("测试_2"));
                    TurnSystem.Instance.AddPlayer(PlayerFactory.CreatePlayer("测试_3"));
                    break;
                default:
                    break;
            }
        }
    }
}