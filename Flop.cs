using System.Collections.Generic;
using System;

namespace PokerBot
{
    class Flop
    {
        public List<Card> Hand { get; set; }

        public Flop()
        {
            Hand = new List<Card>();
        }

        public void ShowFlop()
        {
            if (Hand.Count != 0)
            {
                Console.WriteLine("\nFlop : ");
                foreach (Card card in Hand)
                {
                    Console.WriteLine(card.ToString());
                }
            }
        }
    }
}