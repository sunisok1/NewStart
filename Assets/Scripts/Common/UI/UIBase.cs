using Assets.Scripts.Common.Manager;
using UnityEngine;

namespace Assets.Scripts.Common.UI
{
    public abstract class UIBase : MonoBehaviour
    {
        #region Public

        /// 窗口类型，默认是Normal
        public UIType type = UIType.Normal;

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            Load();
        }

        private void OnDestroy()
        {
            UnLoad();
        }

        #endregion

        #region 生命周期

        /// <summary>
        /// 加载UI，类似于Awake()，多用于初始化
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// 卸载UI，类似于OnDestroy()，多用于卸载
        /// </summary>
        public abstract void UnLoad();

        /// <summary>
        /// 会在UI管理器中被统一调用，用于更新
        /// </summary>
        public virtual void OnUpdate()
        {

        }

        /// <summary>
        /// 打开UI
        /// </summary>
        public virtual void Show()
        {

        }

        /// <summary>
        /// 关闭UI
        /// </summary>
        public virtual void Close()
        {

        }

        /// <summary>
        /// 冻结UI
        /// </summary>
        public virtual void Freeze()
        {

        }

        /// <summary>
        /// 解冻UI
        /// </summary>
        public virtual void UnFreeze()
        {

        }

        #endregion
    }
}