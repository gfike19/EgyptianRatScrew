using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    class Player
    {
        private List<Card> hand = new List<Card>();
        private string name;

        public Player (string name) {
            this.name = name;
        }

        public string GetName ()
        {
            return this.name;
        }

        public List<Card> GetHand ()
        {
            return this.hand;
        }

        public int CountHand ()
        {
            return hand.Count();
        }

        public void AddToHand (Card c)
        {
            this.hand.Add(c);
        }

        public void AddToHand(List<Card> pile)
        {
            foreach(Card c in pile)
            {
                this.hand.Add(c);
            }
        }

        public Card Draw ()
        {
            Card c = this.hand.First();
            this.hand.Remove(c);
            return c;
        }


    }
}
