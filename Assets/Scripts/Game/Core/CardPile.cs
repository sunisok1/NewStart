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

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                if (discardPile.Count == 0)
                {
                    Debug.Log("No cards left in both the pile and discard pile.");
                    return null;
                }

                ShuffleDiscardPileIntoDeck();
            }

            Card drawnCard = cards[0];
            cards.RemoveAt(0);

            return drawnCard;
        }

        public List<Card> DrawCards(int numCards)
        {
            List<Card> drawnCards = new();

            for (int i = 0; i < numCards; i++)
            {
                Card drawnCard = DrawCard();
                if (drawnCard != null)
                {
                    drawnCards.Add(drawnCard);
                }
                else
                {
                    Debug.Log($"Attempted to draw {numCards} cards, but only {i} cards were available.");
                    break;
                }
            }

            return drawnCards;
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                // Swap cards[i] and cards[j]
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }
        }

        public int RemainingCardsCount => cards.Count;

        private void ShuffleDiscardPileIntoDeck()
        {
            Debug.Log("Shuffling discard pile into the deck.");
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