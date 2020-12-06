using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianRatScrew
{
    public class Card : IEquatable<Card>
    {
        private Tuple<string, string> kind;

        public Card(string suit, string value)
        {
            this.kind = new Tuple<string, string>(suit, value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public bool Equals(Card other)
        {
            return other != null &&
                   EqualityComparer<Tuple<string, string>>.Default.Equals(kind, other.kind);
        }

        public override int GetHashCode()
        {
            return -1383171141 + EqualityComparer<Tuple<string, string>>.Default.GetHashCode(kind);
        }

        public string GetSuit ()
        {
            return kind.Item1;
        }

        public string GetValue ()
        {
            return kind.Item2;
        }

        public string GetValueAndSuit ()
        {
            return kind.Item2 + " of " + kind.Item1;
        }

        public static bool operator ==(Card left, Card right)
        {
            return EqualityComparer<Card>.Default.Equals(left, right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }
    }
}
