using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Common.Manager;

public class ResMgr : MgrBase
{
    // 资源缓存
    private readonly Dictionary<string, Object> resourceCache = new();

    // 缓存容量
    public const int cacheCapacity = 50;

    // 加载资源
    public T Load<T>(string resourcePath) where T : Object
    {
        if (resourceCache.ContainsKey(resourcePath))
        {
            return resourceCache[resourcePath] as T;
        }
        else
        {
            T loadedResource = Resources.Load<T>(resourcePath);
            if (loadedResource != null)
            {
                CacheResource(resourcePath, loadedResource);
                return loadedResource;
            }
            else
            {
                Debug.LogError("Resource not found: " + resourcePath);
                return null;
            }
        }
    }

    // 缓存资源
    private void CacheResource(string resourcePath, Object resource)
    {
        if (resourceCache.Count >= cacheCapacity)
        {
            // 如果缓存已满，移除最早加载的资源
            string oldestKey = resourceCache.Keys.GetEnumerator().Current;
            resourceCache.Remove(oldestKey);
        }

        resourceCache.Add(resourcePath, resource);
    }

    // 清空缓存
    public void ClearCache()
    {
        resourceCache.Clear();
    }
}
