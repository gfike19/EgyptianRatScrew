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
            //other player names
            string[] names = {"Noah", "Emma", "Liam", "Olivia", "William", "Ava",
            "Mason", "Sophia", "James", "Isabellla"};

            Deck deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("What's you name? ");
            string uname = Console.ReadLine();
            Player user = new Player(uname);

            //adds user to player_list upon initilization, user is always player one
            List<Player> player_list = new List<Player>
            {
                user
            };

            Console.WriteLine("How many people are playing with you? ");
            int player_count = int.Parse(Console.ReadLine());
            List<Player> computer = new List<Player>();
            
            //seed for random numvers
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            provider.GetBytes(byteArray);

            //creates players
            for (int i = 0; i < player_count; i++)
            {
                var r = BitConverter.ToUInt32(byteArray, 0) % player_count;
                string name = names[r];
                Player p = new Player(name);
                player_list.Add(p);
                computer.Add(p);
            }

            // deal to all players
            while (deck.GetCount() > 0)
            {
                foreach (Player p in player_list)
                {
                    Card c = deck.Draw();
                    p.AddToHand(c);
                }
            }

            //gets array of how many cards each player has
            int[] player_hand_count =  (from player in player_list
            select player.CountHand()).ToArray();
            

            foreach (Player p in player_list)
            {
                
                
                do
                {

                    while (!Console.KeyAvailable)
                    {
                        // Do something
                        Card  c = p.Draw();
                        Console.WriteLine(c.GetValue() + " of " + c.GetSuit());
                        Thread.Sleep(1000);
                        List<Card> pile;
                        pile.Add(c);

                    }

                    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        user_input += i;
                        Console.WriteLine("The user took " + (i - 1));
                    }
                } while (!player_hand_count.Contains(52));
            }
        }
    }
}