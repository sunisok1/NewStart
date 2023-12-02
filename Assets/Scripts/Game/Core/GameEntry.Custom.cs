using Assets.Scripts.Common.Manager;
using Assets.Scripts.Game;
using UnityEngine;

public partial class GameEntry
{
    private void Start()
    {
        UIManager = GetManager<UIManager>();
        GameManager = GetManager<GameManager>();
        EventManager = GetManager<EventManager>();
        UIManager.OpenUI<MenuUI>();
    }

    public static UIManager UIManager;
    public static GameManager GameManager;
    public static EventManager EventManager;
}
