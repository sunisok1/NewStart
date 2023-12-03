using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;

public enum EventType
{
    TurnSystem_AddPlayer,
    TurnSystem_CurrentPlayerNodeChanged,
    Player_DrawCards,
    Input_Confirm,
    Input_Cancel,
    Input_EndUse
}

public class TurnSystem_CurrentPlayerNodeChangedArgs : EventArgs
{
    public Player Previous;
    public Player Current;
}
public class Player_DrawCardsArgs : EventArgs
{
    public List<Card> Cards;
}