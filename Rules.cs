using System.Collections.Generic;
using System.Linq;
using System;
namespace PokerBot
{
    class Rules
    {
        public int HighCard(Flop flop, Player player)
        {
            int score = 0;
            foreach (var card in player.Hand)
            {
                if (card.Value > score)
                {
                    score = card.Value;
                }
            }
            foreach (var card in flop.Hand)
            {
                if (card.Value > score)
                {
                    score = card.Value;
                }
            }
            return score;
        }

        public void Pair(Flop flop, Player player)
        {
            var hand = flop.Hand.Concat(player.Hand);

            var results = hand.GroupBy(card => card.Name)
            .OrderByDescending(grp => grp.Count())
            .ThenBy(grp => grp.Key);

            foreach (var item in results)
            {
                if (item.Count() > 1)
                {
                    Console.WriteLine("\nPlayer {0} :", player.Id);
                    Console.WriteLine("{0} ({1})", item.Key, item.Count());
                }
                // else
                // {
                //     Console.WriteLine("\nPlayer {0} :", player.Id);
                //     Console.WriteLine("no pair");
                // }
            }
        }

        public void TwoPair()
        {

        }

        public void ThreeOfAKind() { }

        public void Straight() { }

        public bool Flush(Flop flop, Player player)
        {
            var hand = flop.Hand.Concat(player.Hand);
            string[] types = new string[4] { "heart", "pike", "clover", "tile" };

            foreach (var type in types)
            {
                List<Card> flush = new List<Card>();
                foreach (var card in hand)
                {
                    if (card.Color == "pike")
                    {
                        flush.Add(card);
                        if (flush.Count() == 5)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void FullHouse() { }

        public void FourOfAKind() { }

        public void StraightFlush() { }

        public void RoyalFlush() { }
    }
}