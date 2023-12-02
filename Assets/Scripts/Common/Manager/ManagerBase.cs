namespace Assets.Scripts.Common.Manager
{
    /// <summary>
    /// 模块管理基类
    /// </summary>
    public abstract class ManagerBase
    {
        protected ManagerBase() { }
        /// 初始化模块
        public virtual void Init() { }

        /// 模块更新
        public virtual void Update(float time) { }

        /// 关闭模块
        public virtual void ShutDown() { }
    }
}
