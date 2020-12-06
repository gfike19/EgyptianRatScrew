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

        public Player()
        {
        }

        public string GetName ()
        {
            return name;
        }

        public List<Card> GetHand ()
        {
            return hand;
        }

        public int CountHand ()
        {
            return hand.Count();
        }

        public void AddToHand (Card c)
        {
            hand.Add(c);
        }

        public void AddToHand(List<Card> pile)
        {
            foreach(Card c in pile)
            {
                hand.Add(c);
            }
        }

        public Card Draw ()
        {
            Card c = hand.First();
            hand.Remove(c);
            return c;
        }

        public List<Card> DiscardHand ()
        {
            List<Card> cards = hand.Take(hand.Count).ToList();
            hand.Clear();
            return cards;
        }

        public List<Card>Discard (int num)
        {
            List<Card> cards = new List<Card>();

            for(int i = 0; i < num; i++)
            {
                Card c = hand[i];
                hand.Remove(c);
                cards.Add(c);
            }
            return cards;
        }
    }
}
