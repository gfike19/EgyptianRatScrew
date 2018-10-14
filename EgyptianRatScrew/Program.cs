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
        static void Main(string[] args)
        {
            List<Player> player_list = Util.GetPlayers();
            int player_count = player_list.Count;

            Player user = player_list[0];

            Console.WriteLine("Players are: ");
            foreach(Player p in player_list)
            {
                Console.WriteLine(p.GetName());
            }
            Console.Write("\n");

            // deal to all players
            Util.Deal(player_list);

            Console.WriteLine("Hands have been dealt.\n");

            Player pile = new Player();
            ConsoleKeyInfo cki;
            int idx = 0;
            do
            {
                Card c = null;

                while (Console.KeyAvailable == false)
                {
                    c = player_list[idx].Draw();
                    Console.WriteLine(player_list[idx].GetName() + " played " + c.GetValueAndSuit());
                    pile.AddToHand(c);
                    Thread.Sleep(1000);
                    idx ++;
                    idx %= player_count;
                }

                cki = Console.ReadKey(true);
                //if (cki.Key == ConsoleKey.Spacebar)
                //{
                //    Console.Write("User slapped on: ");

                //    List<Card> cards = pile.DiscardHand();
                //    //TODO check to see if cards is valid slap, burn two if not
                //    foreach (Card d in cards)
                //    {
                //        Console.Write(d.GetValueAndSuit() + ", ");

                //        user.AddToHand(d);
                //    }
                //    Console.Write("\n");
                //}

                if (cki.Key == ConsoleKey.Spacebar)
                {

                    if (Slaps.IsSandwhich(pile.GetHand()))
                    {
                        List<Card> cards = pile.DiscardHand();
                        Console.Write("User slapped on: ");
                        foreach (Card d in cards)
                        {
                            Console.Write(d.GetValueAndSuit() + ", ");

                            user.AddToHand(d);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Not a valid slap.");
                        List<Card> cards = user.Discard(2);
                        pile.AddToHand(cards);
                    }
                }


            } while (cki.Key != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }
}