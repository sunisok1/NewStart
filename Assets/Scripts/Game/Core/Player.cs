using Assets.Scripts.Game.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Core
{
    public enum SexType
    {
        Male,
        Female,
        Other
    }

    public enum CountryType
    {
        Qun,
        Wei,
        Shu,
        Wu
    }

    public struct PlayerData
    {
        public string Name;
        public SexType Sex;
        public CountryType Country;
        public int MaxHp;
        public int Hp;
        public bool IsLinked;
    }

    public class PlayerCardDeck
    {
        private readonly List<Card> HandCards = new();
        private readonly List<Card> EquipmentCards = new(5);
        private readonly List<Card> JudgmentCards = new();
        public List<Card> GetCard(char area)
        {
            return char.ToLower(area) switch
            {
                'e' => EquipmentCards,
                'h' => HandCards,
                'j' => JudgmentCards,
                _ => throw new ArgumentException("Invalid area character. Use 'e' for Equipment, 'h' for Hand, or 'j' for Judgment."),
            };
        }

        public void AddHandCards(List<Card> cards)
        {
            HandCards.AddRange(cards);
        }
    }

    public class Player
    {
        public PlayerData data;
        public readonly PlayerCardDeck deck = new();

        public void Draw(int num)
        {
            List<Card> cards = Entry.TurnSystem.cardPile.DrawCards(num);
            deck.AddHandCards(cards);
            Player_DrawCardsArgs args = new()
            {
                Cards = cards
            };
            Entry.EventMgr.InvokeEvent(EventType.Player_DrawCards, this, args);
        }
    }
}