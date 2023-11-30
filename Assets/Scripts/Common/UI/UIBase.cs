using Assets.Scripts.Common.Manager;
using UnityEngine;

namespace Assets.Scripts.Common.UI
{
    public abstract class UIBase : MonoBehaviour
    {
        #region Public

        /// 窗口类型，默认是Normal
        public UIType type { get; protected set; } = UIType.Normal;

        #endregion
        #region 生命周期
        /// <summary>
        /// 会在UI管理器中被统一调用，用于更新
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// 打开UI
        /// </summary>
        public virtual void OnPush(params object[] objs) { }

        /// <summary>
        /// 关闭UI
        /// </summary>
        public virtual void OnPop() { }

        /// <summary>
        /// 冻结UI
        /// </summary>
        public virtual void OnFreeze() { }

        /// <summary>
        /// 解冻UI
        /// </summary>
        public virtual void OnUnFreeze() { }
        #endregion
    }
}