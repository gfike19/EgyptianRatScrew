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

        public int CountHand ()
        {
            return hand.Count();
        }

        public void AddToHand (Card c)
        {
            this.hand.Add(c);
        }

        public Card Draw ()
        {
            return hand.First();
        }

        public bool IsSandwhich(Card c, Card d, Card e)
        {
            if(c.GetValue() == e.GetValue())
            {
                return true;
            }
            return false;
        }

        public bool IsDouble(Card c, Card d)
        {
            if(c.GetValue() == d.GetValue())
            {
                return true;
            }
            return false;
        }
    }
}
