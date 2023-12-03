using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Core
{
    public class CardPile
    {
        private readonly List<Card> cards = new();
        private readonly List<Card> discardPile = new();
        private readonly System.Random random = new();

        public CardPile(List<Card> cards)
        {
            this.cards.AddRange(cards);
        }

        public int RemainingCardsCount => cards.Count;

        public List<Card> DrawCards(int num)
        {
            List<Card> drawnCards = new();

            while (num > 0)
            {
                if (cards.Count == 0)
                {
                    // 牌堆没有剩余牌，将弃牌堆洗入牌堆
                    ShuffleDiscardPileIntoDeck();
                }

                // 从牌堆抽取一张牌
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                drawnCards.Add(drawnCard);

                num--;
            }

            return drawnCards;
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }
        }

        private void ShuffleDiscardPileIntoDeck()
        {
            Debug.Log("Shuffling discard pile into the deck.");
            if (discardPile.Count == 0)
            {
                throw new System.Exception("both cardpile and discardpile are empty");
            }
            cards.AddRange(discardPile);
            discardPile.Clear();
            Shuffle();
        }

        public void DiscardCard(Card card)
        {
            discardPile.Add(card);
        }
    }

}