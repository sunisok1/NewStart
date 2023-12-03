using Assets.Scripts.Common.Manager;
using Assets.Scripts.Common.Utils;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoSingleton<InputHandler>
{
    [SerializeField] Button Confirm;
    [SerializeField] Button Cancel;
    [SerializeField] Button EndUse;

    private void Start()
    {
        Confirm.onClick.AddListener(() => Entry.EventMgr.InvokeEvent(EventType.Input_Confirm, this, EventArgs.Empty));
        Cancel.onClick.AddListener(() => Entry.EventMgr.InvokeEvent(EventType.Input_Cancel, this, EventArgs.Empty));
        EndUse.onClick.AddListener(() => Entry.EventMgr.InvokeEvent(EventType.Input_EndUse, this, EventArgs.Empty));
    }
}
