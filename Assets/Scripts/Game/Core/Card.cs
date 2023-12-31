using System;

namespace Assets.Scripts.Game.Core
{
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
        public Suit Suit;
        public int Rank;
        public string ResName;

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}