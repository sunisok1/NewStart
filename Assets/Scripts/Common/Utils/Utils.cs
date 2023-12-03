using UnityEngine;

namespace Assets.Scripts.Common.Utils
{
    public static class Utils
    {
        /// <summary>
        /// Destroy all child objects of the current GameObject.
        /// </summary>
        public static void DestroyAllChildren<T>(this T t) where T : Component
        {
            foreach (Transform child in t.transform)
            {
                Object.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Set the active state of the GameObject.
        /// </summary>
        public static void SetActive<T>(this T t, bool active) where T : Component
        {
            t.SetActive(active);
        }
    }
}