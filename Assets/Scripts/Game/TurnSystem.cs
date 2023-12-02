using Assets.Scripts.Common.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class TurnSystem : MonoSingleton<TurnSystem>
    {
        private readonly LinkedList<Player> playerList = new();
        private LinkedListNode<Player> currentPlayerNode;

        // Property to get the current player
        public Player CurrentPlayer => currentPlayerNode.Value;

        public void StartGame()
        {
            // Initialize your player list and set the current player
            // For example, assuming you have a list of Player objects:
            // playerList = new LinkedList<Player>(yourListOfPlayers);

            // Start the game by setting the current player to the first player in the list
            if (playerList.Count > 0)
            {
                currentPlayerNode = playerList.First;
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
            currentPlayerNode = currentPlayerNode.Next ?? playerList.First;

            // You can perform any actions related to the turn change here
            Debug.Log($"Next turn: {CurrentPlayer.data}");
        }

        public void AddPlayer(Player player)
        {
            // Add a player to the list
            playerList.AddLast(player);
        }

        public void RemovePlayer(Player player)
        {
            // Remove a player from the list
            playerList.Remove(player);

            // If the removed player was the current player, move to the next player
            if (playerList.Count > 0 && currentPlayerNode.Value == player)
            {
                MoveNext();
            }
        }
    }
}
