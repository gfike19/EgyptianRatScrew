using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO test adding cards to one players hand
            string[] names = {"Noah", "Emma", "Liam", "Olivia", "William", "Ava",
            "Mason", "Sophia", "James", "Isabellla"};

            Deck deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("What's you name? ");
            string uname = Console.ReadLine();

            Player user = new Player(uname);

            Console.WriteLine("How many people are playing with you? ");
            int player_count = int.Parse(Console.ReadLine());
            List<Player> player_list = new List<Player>();
            player_list.Add(user);

            //TODO how get truly random numbers
            var rnd = new Random();
            


            //creates players
            for(int i =0; i < player_count; i++)
            {
                int r = rnd.Next(player_count);
                string name = names[r];
                Player p = new Player(name);
            }

            //TODO find way to deal to all players
            while(deck.GetCount() > 0)
            {
                foreach(Player p in player_list)
                {
                    Card c = deck.Draw();
                    p.AddToHand(c);
                }
            }

            foreach(Player p in player_list)
            {
                Console.WriteLine(p.GetName());
            }

            Console.ReadLine();
        }
    }
}
