using System;

namespace CountSquares.Logic
{
    public class Kata
    {
        public static int CountSquares(int cuts)
        {
            if (cuts == 0) return 1;
            return (int)(Math.Pow(cuts + 1, 3) - Math.Pow(cuts - 1, 3));
        }
    }
}