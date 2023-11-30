using Assets.Scripts.Common.UI;
using UnityEngine;
using UnityEngine.UI;

public class BeginUI : UIBase
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

        // 在这里可以添加开始游戏的逻辑
    }
}
