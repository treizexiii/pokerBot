using System;
using System.Collections.Generic;
using System.Text;

namespace PokerBot
{
    class Game
    {
        public List<Card> Cards { get; set; }
        public List<Card> ShuffleGame { get; set; }
        public List<Player> Players { get; set; }
        public Flop Flop { get; set; }

        private readonly string[] types = new string[4] { "heart", "pike", "clover", "tile" };
        private readonly string[] names = new string[13] { "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace" };

        public Game(int numbPlayers)
        {
            Cards = new List<Card>();
            ShuffleGame = new List<Card>();
            Players = new List<Player>();
            Flop = new Flop();
            for (int i = 1; i <= numbPlayers; i++)
            {
                Player player = new Player(i);
                Players.Add(player);
            }
            CreateCards();
        }

        private void CreateCards()
        {
            foreach (var type in types)
            {
                int value = 1;
                foreach (var name in names)
                {
                    Card card = new Card(name, value, type);
                    Cards.Add(card);
                    value += 1;
                }
            }
        }

        public void Shuffle()
        {
            do
            {
                Random rand = new Random();
                int draw = rand.Next(0, Cards.Count);
                ShuffleGame.Add(Cards[draw]);
                Cards.Remove(Cards[draw]);
            }
            while (Cards.Count != 0);
        }

        public void Distribute(int cardsGiven)
        {
            for (int i = 1; i <= cardsGiven; i++)
            {
                foreach (Player player in Players)
                {
                    player.Hand.Add(ShuffleGame[0]);
                    ShuffleGame.Remove(ShuffleGame[0]);
                }
            }
        }
        
        public void GiveFlop()
        {
            if (Flop.Hand.Count == 0)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Flop.Hand.Add(ShuffleGame[0]);
                    ShuffleGame.Remove(ShuffleGame[0]);
                }
            }
            else
            {
                Flop.Hand.Add(ShuffleGame[0]);
                ShuffleGame.Remove(ShuffleGame[0]);
            }
        }
    }
}
