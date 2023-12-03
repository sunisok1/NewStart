using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.Utils;
using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameUI : UIBase
    {
        [SerializeField] Transform cardContent;
        [SerializeField] CardItem cardPrefab;
        void Awake()
        {
            GameEntry.EventManager.Subscribe(EventType.TurnSystem_CurrentPlayerNodeChanged, TurnSystem_CurrentPlayerNodeChanged);
        }

        private void TurnSystem_CurrentPlayerNodeChanged(object sender, EventArgs e)
        {
            TurnSystem_CurrentPlayerNodeChangedArgs args = e as TurnSystem_CurrentPlayerNodeChangedArgs;
            cardContent.DestroyAllChildren();
            List<Card> cards = args.Current.deck.GetCard('h');
            // Update UI with the new list of cards
            foreach (Card card in cards)
            {
                // Instantiate the card UI prefab
                CardItem cardUI = Instantiate(cardPrefab, cardContent);
                // Set the card information on the UI

            }
        }
    }
}