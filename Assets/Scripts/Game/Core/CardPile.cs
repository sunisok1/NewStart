using System;
using System.Collections.Generic;

public enum Suit
{
    None = 0,
    Diamond = 1,
    Heart = 2,
    Club = 3,
    Spade = 4
}

public class Card
{
    public int Id;
    public string Name;
    public Suit Suit { get; }
    public int Rank { get; }

    public Card(Suit suit, int rank)
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
    private readonly List<Card> cards = new();
    private readonly Random random = new();

    public CardPile(List<Card> cards)
    {
        this.cards = cards;
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
