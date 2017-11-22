using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    public class Card
    {
        private Tuple<string, string> kind;

        public Card(string suit, string value)
        {
            this.kind = new Tuple<string, string>(suit, value);
        }

        public string GetSuit ()
        {
            return kind.Item1;
        }

        public string GetValue ()
        {
            return kind.Item2;
        }
    }
}
