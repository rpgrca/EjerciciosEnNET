using System.Linq;
using System.Collections.Generic;
using System;

namespace PrimeNumber.Logic
{
    public class PrimeNumber : IClassifier
    {
        public bool IsClassificationOf(int value)
        {
            if (value <= 0) return false;
            if (value <= 2) return true;

            var possibleDivisors = Enumerable.Range(2, (int)Math.Sqrt(value)).ToList();
            var previousDivisors = new List<int>();
            while (possibleDivisors.Count > 0)
            {
                if (previousDivisors.Any(p => possibleDivisors[0] % p == 0))
                {
                    possibleDivisors.RemoveAt(0);
                    continue;
                }

                if (value % possibleDivisors[0] == 0)
                {
                    return false;
                }

                previousDivisors.Add(possibleDivisors[0]);
            }

            return true;
        }
    }
}