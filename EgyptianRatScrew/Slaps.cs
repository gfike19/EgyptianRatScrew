using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    class Slaps
    {
        public static bool IsSandwhich(Card c, Card d, Card e)
        {
            if (c.GetValue() == e.GetValue())
            {
                return true;
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

        /**public static bool IsFourRow (Card c, Card d, Card e, Card f)
        {
            string[] vals = { c.GetValue(), d.GetValue(), e.GetValue(), f.GetValue() };

            if(vals[0] == vals[1] + 1 && vals[1] == vals[2] + 1 && vals[2] == vals[3] +1 )
        } **/
    }
}
