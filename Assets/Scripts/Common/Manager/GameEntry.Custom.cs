using Assets.Scripts.Common.Manager;
using Assets.Scripts.Game;
using Assets.Scripts.UI;
using UI;
using UnityEngine;

public partial class Entry
{

    public static UIMgr UIMgr;
    public static GameMgr GameMgr;
    public static EventMgr EventMgr;
    public static ConfigMgr ConfigMgr;
    public static ResMgr ResMgr;

    public static CameraController CameraController;
    public static TurnSystem TurnSystem;

    private void Start()
    {
        UIMgr = GetManager<UIMgr>();
        GameMgr = GetManager<GameMgr>();
        EventMgr = GetManager<EventMgr>();
        ConfigMgr = GetManager<ConfigMgr>();
        ResMgr = GetManager<ResMgr>();

        CameraController = transform.Find("CameraController").GetComponent<CameraController>();
        TurnSystem = GetManager<TurnSystem>();

        UIMgr.OpenUI<MenuUI>();
    }
}
