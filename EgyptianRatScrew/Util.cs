using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    abstract class Util
    {
        public static List<Player> GetPlayers ()
        {
            //other player names
            string[] names = {"Noah", "Emma", "Liam", "Olivia", "William", "Ava",
            "Mason", "Sophia", "James", "Isabellla"};

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

            return player_list;
        }

        public static void Deal (List<Player> player_list)
        {
            Deck deck = new Deck();
            deck.Shuffle();

            while (deck.GetCount() > 0)
            {
                foreach (Player p in player_list)
                {
                    Card c = deck.Draw();
                    p.AddToHand(c);
                }
            }
        }
    }
}
