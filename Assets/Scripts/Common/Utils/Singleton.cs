namespace Assets.Scripts.Common.Utils
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance;

        // 私有构造函数，防止外部实例化
        private Singleton() { }

        // 公共静态方法获取单例实例
        public static T Instance
        {
            get
            {
                instance ??= new T();
                return instance;
            }
        }
    }
}