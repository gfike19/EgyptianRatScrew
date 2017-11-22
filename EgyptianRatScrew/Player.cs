using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    class Player
    {
        private List<Card> hand;
        private string name;

        public Player (string name) {
            this.name = name;
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
    }
}
