using Assets.Scripts.Common.UI;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Common.Manager
{
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
}