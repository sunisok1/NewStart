using Assets.Scripts.Common.Manager;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Common.UI
{
    public class UIManager : ManagerBase
    {
        /// 根节点，即UIRoot 
        private Transform uiRoot;
        /// fixed界面的节点 
        private Transform fixedRoot;
        /// normal界面的节点
        private Transform normalRoot;
        /// popUp界面的节点
        private Transform popUpRoot;

        // 分别缓存已经加载的三种UI，被加载过不代表正在显示
        private readonly Stack<UIBase> allFixedUI = new();
        private readonly Stack<UIBase> allNormalUI = new();
        private readonly Stack<UIBase> allPopUpUI = new();

        /// 这里记录了所有已经被加载的UI，其实就是上面三个之和
        private readonly Dictionary<Type, UIBase> uiLoaded = new();

        /// 当前打开的UI
        private UIBase currentUI = null;

        #region 管理器生命周期

        public override void Init()
        {
            // 保存各个节点的信息
            if (uiRoot == null)
            {
                uiRoot = GameEntry.Instance.transform.Find("UIRoot");
                fixedRoot = uiRoot.Find("Fixed");
                normalRoot = uiRoot.Find("Normal");
                popUpRoot = uiRoot.Find("PopUp");
                if (fixedRoot == null || normalRoot == null || popUpRoot == null)
                {
                    throw new Exception("==== UI节点初始化失败 ===");
                }
            }
        }
        #endregion

        #region 接口方法

        public void OpenUI<T>() where T : UIBase
        {
            // 如果这个UI还没被加载，那需要先加载
            if (!uiLoaded.TryGetValue(typeof(T), out var ui))
            {
                ui = LoadUI<T>();
            }
            // 显示UI
            ShowUI(ui);
        }
        /// <summary>
        /// 关闭当前UI，注意此方法只关闭当前打开的最顶层UI
        /// </summary>
        public void CloseCurrent()
        {
            if (currentUI == null)
            {
                Debug.LogError("没有可以关闭的界面");
                return;
            }

            PopFromStack(GetStack(currentUI.type));
        }
        #endregion

        #region 工具方法

        /// <summary>
        /// 加载UI
        /// </summary>
        private T LoadUI<T>() where T : UIBase
        {
            T prefab = Resources.Load<T>($"UI/{typeof(T)}") ?? throw new Exception($"加载{typeof(T)}失败");
            T ui = UnityEngine.Object.Instantiate(prefab.gameObject).GetComponent<T>();
            uiLoaded.Add(typeof(T), ui);
            // 根据UI类型，存放到不同的节点中
            ui.transform.SetParent(ui.type switch
            {
                UIType.Fixed => fixedRoot,
                UIType.Normal => normalRoot,
                UIType.PopUp => popUpRoot,
                _ => throw new NotImplementedException(),
            }, false);
            return ui;
        }
        /// <summary>
        /// 显示UI 
        /// </summary>
        private void ShowUI(UIBase ui)
        {
            PushToStack(ui, GetStack(ui.type));
        }

        /// <summary>
        /// 将UI加入对应栈，并真正的控制当前UI的显示隐藏逻辑
        /// </summary>
        private void PushToStack(UIBase ui, Stack<UIBase> stack)
        {
            // 打开一个新的UI，当前UI必然被冻结，但未必会隐藏，打开Normal会隐藏Normal但不会隐藏Fixed
            if (currentUI != null)
            {
                // 冻结当前的界面
                currentUI.Freeze();
                // 如果打开的不是Pop界面，且打开的界面和当前界面是同类型的，那才需要关闭当前的界面
                if (ui.type != UIType.PopUp && ui.type == currentUI.type)
                {
                    currentUI.Close();
                    currentUI.gameObject.SetActive(false);
                }
            }
            if (!ui.gameObject.activeSelf)
            {
                ui.gameObject.SetActive(true);
            }
            ui.Show();
            stack.Push(ui);
            currentUI = ui;
        }

        /// <summary>
        /// 将UI从对应链表中移除，并真正的控制当前UI的关闭 
        /// </summary>
        private void PopFromStack(Stack<UIBase> stack)
        {
            // 首先关闭并冻结当前的UI
            currentUI.Close();
            currentUI.Freeze();
            currentUI.gameObject.SetActive(false);
            // 栈顶UI出栈，其实就是currentUI
            stack.Pop();
            // 然后尝试获取当前UI栈中的上一个UI
            if (stack.Count >= 1)
            {
                currentUI = stack.Peek();
                // 注意，如果当前栈是Pop栈，那么我们关闭顶层的弹窗是不需要重新激活上一个弹窗的，因为Pop类型UI之间不会相互关闭，我们只需要解冻就好
                if (stack != allPopUpUI)
                {
                    currentUI.Show();
                    currentUI.gameObject.SetActive(true);
                }
                currentUI.UnFreeze();
            }
            // 如果当前栈里没有UI了，那就获取上一个栈中的UI
            else
            {
                // 如果当前栈是Pop，那么currentUI就是Noraml栈中的最后一个元素，其余同理
                // 另外，因为不同类型的UI之间也不会相互关闭，所以我们也只需要解冻就好
                if (stack == allPopUpUI)
                {
                    currentUI = allNormalUI.Peek();
                    currentUI.UnFreeze();
                }
                else if (stack == allNormalUI)
                {
                    currentUI = allFixedUI.Peek();
                    currentUI.UnFreeze();
                }
                else
                {
                    currentUI = null;
                }
            }
        }
        private Stack<UIBase> GetStack(UIType type) => type switch
        {
            UIType.Fixed => allFixedUI,
            UIType.Normal => allNormalUI,
            UIType.PopUp => allPopUpUI,
            _ => throw new NotImplementedException(),
        };
        #endregion
    }
    public enum UIType
    {
        /// <summary>
        /// 固定类型，一般作为背景
        /// </summary>
        Fixed,
        /// <summary>
        /// 普通窗口，一般窗口都用这个
        /// </summary>
        Normal,
        /// <summary>
        /// 弹窗，可以在某些窗口上弹出的窗口
        /// </summary>
        PopUp
    }
}
