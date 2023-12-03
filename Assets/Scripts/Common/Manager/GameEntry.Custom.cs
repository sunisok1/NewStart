using Assets.Scripts.Common.Manager;
using Assets.Scripts.Game;
using UI;
using UnityEngine;

public partial class GameEntry
{
    private void Start()
    {
        UIManager = GetManager<UIManager>();
        GameManager = GetManager<GameManager>();
        EventManager = GetManager<EventManager>();
        ConfigManager = GetManager<ConfigManager>();

        UIManager.OpenUI<MenuUI>();
        CameraController = transform.Find("CameraController").GetComponent<CameraController>();
    }

    public static UIManager UIManager;
    public static GameManager GameManager;
    public static EventManager EventManager;
    public static ConfigManager ConfigManager;

    public static CameraController CameraController;
}
