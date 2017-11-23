using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    public class Deck : IEnumerable
    {
        private List<Card> set;
        private int count;

        public Deck()
        {
            this.set = new List<Card>();

            string[] suits = { "hearts", "clubs", "diamonds", "spades" };
            List<string> vals = new List<string>{"ace", "king", "queen", "jack",
            "2", "3", "4", "5", "6", "7", "8", "9", "10"};

            foreach(string suit in suits)
            {
                foreach(string val in vals)
                {
                   Card c = new Card(suit, val);
                    this.set.Add(c);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)set).GetEnumerator();
        }

        public void Shuffle ()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = 25;
            
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card value = this.set[k];
                this.set[k] = this.set[n];
                this.set[n] = value;
            }
        }

        public int GetCount ()
        {
            return this.set.Count();
        }

        public Card Draw ()
        {
            Card c = this.set.First();
            set.Remove(c);
            return c;
        }
    }
}
