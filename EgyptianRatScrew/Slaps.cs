using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    class Slaps
    {
        public static bool IsSandwhich(List<Card> cards)
        {
            if (cards.Count == 3)
            {
                Card a = cards[0];
                Card b = cards[2];

                if (a == b)
                {
                    return true;
                }
                else
                    return false;
            }

            return false;
        }

        public static bool IsDouble(Card c, Card d)
        {
            if (c.GetValue() == d.GetValue())
            {
                return true;
            }
            return false;
        }
    }
}
