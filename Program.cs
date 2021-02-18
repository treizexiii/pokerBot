using System.Linq;
using System;

namespace PokerBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(5);
            var rules = new Rules();

            game.Shuffle();

            game.Distribute(2);

            foreach (Player player in game.Players)
            {
                player.ShowHand();
            }

            game.GiveFlop();

            game.Flop.ShowFlop();

            Console.WriteLine("\n" + rules.HighCard(game.Flop, game.Players.FirstOrDefault(p => p.Id == 1)));

            foreach (var player in game.Players)
            {
                rules.Pair(game.Flop, player);
            }
        }
    }
}
