using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace EgyptianRatScrew
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Player> player_list = Util.GetPlayers();

            Player user = player_list[0];

            Console.WriteLine("Players are: ");
            foreach (Player p in player_list)
            {
                Console.WriteLine(p.GetName());
            }
            Console.Write("\n");

            // deal to all players
            Util.Deal(player_list);

            Console.WriteLine("Hands have been dealt.\n");

            Player pile = new Player();
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            bool winnerPresent = IsWinnerPresent(player_list);
            int idx = 0;
            do
            {
                while (Console.KeyAvailable == false)
                {
                    Card c = player_list[idx].Draw();
                    Console.WriteLine(player_list[idx].GetName() + " played " + c.GetValueAndSuit());
                    pile.AddToHand(c);
                    Thread.Sleep(1000);
                    idx++;
                    idx %= player_list.Count;
                }

                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Spacebar)
                {
                    List<Card> cards = pile.DiscardHand();
                    Console.Write("User slapped on: ");
                    foreach (Card d in cards)
                    {
                        Console.Write(d.GetValueAndSuit() + ", ");
                        user.AddToHand(d);
                    }
                    Console.Write("\n");
                }
            } while (cki.Key != ConsoleKey.Escape);

            Console.ReadLine();
        }

        public static bool IsWinnerPresent(List<Player> playerList)
        {
            foreach (Player p in playerList)
            {
                if (p.CountHand() == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}