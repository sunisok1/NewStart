using Assets.Scripts.Common.Manager;
using Assets.Scripts.Game;
using UI;
using UnityEngine;

public partial class GameEntry
{

    public static UIManager UIManager;
    public static GameManager GameManager;
    public static EventManager EventManager;
    public static ConfigManager ConfigManager;

    public static CameraController CameraController;
    public static TurnSystem TurnSystem;

    private void Start()
    {
        UIManager = GetManager<UIManager>();
        GameManager = GetManager<GameManager>();
        EventManager = GetManager<EventManager>();
        ConfigManager = GetManager<ConfigManager>();

        CameraController = transform.Find("CameraController").GetComponent<CameraController>();
        TurnSystem = GetManager<TurnSystem>();

        UIManager.OpenUI<MenuUI>();
    }
}
