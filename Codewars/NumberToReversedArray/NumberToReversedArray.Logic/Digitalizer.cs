using System;
using System.Linq;

namespace NumberToReversedArray.Logic
{
    public class Digitalizer
    {
        public static long[] Digitalize(long n) =>
            n.ToString().Select(p => long.Parse($"{p}")).Reverse().ToArray();
    }
}
