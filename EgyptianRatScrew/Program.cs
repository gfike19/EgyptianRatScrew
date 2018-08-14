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

            Console.WriteLine("What's your name? ");
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
            
            

            //creates players
            for (int i = 0; i < player_count; i++)
            {
                //seed for random numvers
                RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
                var byteArray = new byte[4];
                provider.GetBytes(byteArray);

                var r = BitConverter.ToUInt32(byteArray, 0) % player_count;
                string name = names[r];
                Player p = new Player(name);
                player_list.Add(p);
                computer.Add(p);
            }

            Console.WriteLine("Players are: ");
            foreach(Player p in player_list)
            {
                Console.WriteLine(p.GetName());
            }
            Console.Write("\n");

            // deal to all players
            while (deck.GetCount() > 0)
            {
                foreach (Player p in player_list)
                {
                    Card c = deck.Draw();
                    p.AddToHand(c);
                }
            }

            Console.WriteLine("Hands have been dealt.\n");

            //user is at index 0
            //actual play below

            //TODO make the pile a player? similar behavior
            //TODO identify what is needed for actual play, need to modularize code
            List <Card> pile = new List<Card>();
            //ConsoleKeyInfo cki;
            int idx = 0;
            do
            {
                Card c = null;

                while (!Console.KeyAvailable)
                {
                    c = player_list[idx].Draw();
                    Console.WriteLine(player_list[idx].GetName() + " played " + c.GetValueAndSuit());
                    pile.Add(c);
                    Thread.Sleep(1000);
                    idx ++;
                    idx %= player_count;
                }
                //cki = console.readkey(true);

                //if (cki.key == consolekey.spacebar)
                //{
                //    user.addtohand(pile);
                //}

                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.Write("User slapped on: ");

                    foreach (Card d in pile)
                    {
                        Console.Write(d.GetValueAndSuit() + ", ");
                        user.AddToHand(d);
                        pile.Remove(d);
                    }
                    Console.Write("\n");
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }
}