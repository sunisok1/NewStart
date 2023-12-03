using System;
using System.Collections.Generic;

public class Card
{
    public string Suit { get; }
    public string Rank { get; }

    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

public class CardPile
{
    private List<Card> cards = new List<Card>();
    private Random random = new Random();

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public Card DrawCard()
    {
        if (cards.Count == 0)
        {
            Console.WriteLine("No cards left in the pile.");
            return null;
        }

        int index = random.Next(cards.Count);
        Card drawnCard = cards[index];
        cards.RemoveAt(index);

        return drawnCard;
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
}
