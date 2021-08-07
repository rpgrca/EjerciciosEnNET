using System;

namespace CountSquares.Logic
{
    public class Kata
    {
        public static int CountSquares(int cuts)
        {
            if (cuts == 1)
                return (int)Math.Pow(cuts + 1, 3);

            if (cuts == 2)
                return (int)Math.Pow(cuts + 1, 3) - 1;

            return 1;
        }
    }
}
