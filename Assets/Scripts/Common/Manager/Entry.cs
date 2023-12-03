using System;
using System.Collections.Generic;
using Assets.Scripts.Common.Manager;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.Utils;

public partial class Entry : MonoSingleton<Entry>
{
    private static readonly Dictionary<Type, MgrBase> Managers = new();

    /// <summary>
    /// 获取一个管理器
    /// </summary>
    public static TManager GetManager<TManager>() where TManager : MgrBase
    {
        if (Managers.TryGetValue(typeof(TManager), out MgrBase manager))
        {
            return manager as TManager;
        }
        return CreateManager<TManager>();
    }

    /// <summary>
    /// 创建一个管理器
    /// </summary>
    private static TManager CreateManager<TManager>() where TManager : MgrBase
    {
        TManager manager = Activator.CreateInstance<TManager>() ?? throw new Exception("创建管理器失败...");
        Managers.Add(typeof(TManager), manager);
        manager.Init();
        return manager;
    }

    /// <summary>
    /// 销毁所有的管理器
    /// </summary>
    protected virtual void OnDestroy()
    {
        foreach (var manager in Managers.Values)
        {
            manager.ShutDown();
        }
        Managers.Clear();
    }
}
