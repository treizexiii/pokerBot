using System;
using System.Collections.Generic;
using System.Text;

namespace PokerBot
{
    class Player
    {
        public List<Card> Hand { get; set; }

        public int Id { get; set; }

        public Player(int id)
        {
            Hand = new List<Card>();
            Id = id;
        }

        public void ShowHand()
        {
            if (Hand.Count != 0)
            {
                Console.WriteLine("\nPlayer " + Id + ": ");
                foreach (Card card in Hand)
                {
                    Console.WriteLine(card.ToString());
                }
            }
        }
    }
}
