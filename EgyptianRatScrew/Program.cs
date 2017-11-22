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
            string[] names = {"Noah", "Emma", "Liam", "Olivia", "William", "Ava",
            "Mason", "Sophia", "James", "Isabellla"};

            Deck deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("How many players are there? ");
            int player_count = int.Parse(Console.ReadLine());
            List<Player> player_list = new List<Player>();

            //how get truly random numbers
            var rnd = new Random();
            int r = rnd.Next(player_count);


            //creates players
            while(player_list.Count() < player_count)
            {
                string name = names[r];
                Player p = new Player(name);
            }

            while(deck.Count() > 0)
            {
                foreach(Player p in player_list)
                {

                }
            }
        }
    }
}
