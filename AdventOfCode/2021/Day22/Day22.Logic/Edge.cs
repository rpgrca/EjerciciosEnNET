namespace Day22.Logic
{
    public struct Edge
    {
        public readonly (int X, int Y, int Z) From;
        public readonly (int X, int Y, int Z) To;

        public Edge((int X, int Y, int Z) from, (int X, int Y, int Z) to)
        {
            From = from;
            To = to;
        }

        public static bool operator ==(Edge left, Edge right) => left.Equals(right);

        public static bool operator != (Edge left, Edge right) => !left.Equals(right);

        public override bool Equals(object obj)
        {
            if (obj is Edge other)
            {
                return (From == other.From && To == other.To) || (From == other.To && To == other.From);
            }

            return false;
        }
    }
}