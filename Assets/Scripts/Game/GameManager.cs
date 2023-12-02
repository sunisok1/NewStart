using Assets.Scripts.Common.Manager;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameManager : MonoSingleton<GameManager>
{
    public enum GameState
    {
        Menu,
        InGame
        // Add more states as needed
    }

    private void Start()
    {
        GameEntry.GetManager<UIManager>().OpenUI<MenuUI>();
    }

    public GameState CurrentGameState { get; private set; }

    // Call this method to change the game state and load the associated scene
    public void ChangeGameState(GameState newState)
    {
        CurrentGameState = newState;

        // Load the scene based on the game state
        SceneManager.LoadScene(newState.ToString());

        // You can perform additional actions or setup based on the game state here
    }
}
