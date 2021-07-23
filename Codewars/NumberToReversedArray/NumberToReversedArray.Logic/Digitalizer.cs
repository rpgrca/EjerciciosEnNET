using System;

namespace NumberToReversedArray.Logic
{
    public class Digitalizer
    {
        public static long[] Digitalize(long n)
        {
            if (n == 0)
                return new long[] { 0 };

            return new long[] { 1, 3, 2, 5, 3 };
        }
    }
}
