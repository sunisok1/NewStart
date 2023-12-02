using Assets.Scripts.Common.Manager;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : UIBase
{
    [SerializeField] Button StartGameButton;

    public override void OnPush(params object[] objs)
    {
        // 添加按钮点击事件
        StartGameButton.onClick.AddListener(OnStartGameButtonClick);
    }

    // 开始游戏按钮点击事件
    private void OnStartGameButtonClick()
    {
        Debug.Log("Start Game Button Clicked!");
        GameEntry.GameManager.ChangeGameState(GameManager.GameState.Game);
    }
}
