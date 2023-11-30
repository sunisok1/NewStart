using UnityEngine;

namespace Assets.Scripts.Common.Utils
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        // 公共静态方法获取单例实例
        public static T Instance
        {
            get
            {
                instance ??= FindObjectOfType<T>();
                instance ??= new GameObject(typeof(T).Name).AddComponent<T>();
                return instance;
            }
        }

        // 保证MonoBehaviour的Awake方法在实例创建时被调用
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}