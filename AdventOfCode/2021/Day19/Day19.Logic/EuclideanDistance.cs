using System;

namespace Day19.Logic
{
    public class EuclideanDistance
    {
        private readonly (int X, int Y, int Z) _from;
        private readonly (int X, int Y, int Z) _to;

        public double Distance { get; private set; }

        public EuclideanDistance((int X, int Y, int Z) from, (int X, int Y, int Z) to)
        {
            _from = from;
            _to = to;

            Calculate();
        }

        private void Calculate() => 
            Distance = Math.Sqrt(Math.Pow(_from.X - _to.X, 2) + Math.Pow(_from.Y - _to.Y, 2) + Math.Pow(_from.Z - _to.Z, 2));
    }
}