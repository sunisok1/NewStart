using Assets.Scripts.Common.Manager;
using Assets.Scripts.Common.Utils;
using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class TurnSystem : MgrBase
    {
        private readonly LinkedList<Player> playerList = new();
        private LinkedListNode<Player> currentPlayerNode;
        private CardPile cardPile;

        // Property to get the current player
        public Player CurrentPlayer => CurrentPlayerNode.Value;

        public LinkedListNode<Player> CurrentPlayerNode
        {
            get => currentPlayerNode;
            set
            {
                if (currentPlayerNode != value)
                {
                    TurnSystem_CurrentPlayerNodeChangedArgs args = new()
                    {
                        Previous = currentPlayerNode?.Value,
                        Current = value.Value
                    };
                    Entry.EventMgr.InvokeEvent(EventType.TurnSystem_CurrentPlayerNodeChanged, this, args);

                    currentPlayerNode = value;
                }
            }
        }

        public void StartGame()
        {
            // Initialize your player list and set the current player
            cardPile = new(Entry.ConfigMgr.GetConfig<List<Card>>("Cardpile"));
            Debug.Log(cardPile.RemainingCardsCount);
            AddPlayer(PlayerFactory.CreatePlayer("测试_1"));
            AddPlayer(PlayerFactory.CreatePlayer("测试_2"));
            AddPlayer(PlayerFactory.CreatePlayer("测试_3"));
            // Start the game by setting the current player to the first player in the list
            if (playerList.Count > 0)
            {
                CurrentPlayerNode = playerList.First;
            }
        }

        public void MoveNext()
        {
            if (playerList.Count == 0)
            {
                Debug.LogError("No players in the list. Cannot move to the next player.");
                return;
            }

            // Move to the next player in the list
            CurrentPlayerNode = CurrentPlayerNode.Next ?? playerList.First;

            // You can perform any actions related to the turn change here
            Debug.Log($"Next turn: {CurrentPlayer.data}");
        }

        public void AddPlayer(Player player)
        {
            // Add a player to the list
            playerList.AddLast(player);
            Entry.EventMgr.InvokeEvent(EventType.TurnSystem_AddPlayer, player, EventArgs.Empty);
        }

        public void RemovePlayer(Player player)
        {
            // Remove a player from the list
            playerList.Remove(player);

            // If the removed player was the current player, move to the next player
            if (playerList.Count > 0 && CurrentPlayerNode.Value == player)
            {
                MoveNext();
            }
        }
    }
}
