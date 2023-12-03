using Assets.Scripts.Game.Core;
using System;

public enum EventType
{
    TurnSystem_AddPlayer,
    TurnSystem_CurrentPlayerNodeChanged
}

public class TurnSystem_CurrentPlayerNodeChangedArgs : EventArgs
{
    public Player Previous;
    public Player Current;
}