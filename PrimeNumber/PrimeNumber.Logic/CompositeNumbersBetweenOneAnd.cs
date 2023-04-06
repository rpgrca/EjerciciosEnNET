using System.Linq;
using System.Collections.Generic;
using System;

namespace PrimeNumber.Logic
{
    public class CompositeNumbersBetweenOneAnd
    {
        private readonly int _top;
        public List<int> CompositeNumbers { get; private set; }

        public CompositeNumbersBetweenOneAnd(int top)
        {
            _top = top;
            CompositeNumbers = new();
            Calculate();
        }

        private void Calculate()
        {
            for (var value = 3; value < _top; value += 2)
            {
                if (! IsPrime(value))
                {
                    CompositeNumbers.Add(value);
                }

                CompositeNumbers.Add(value + 1);
            }
        }
    
        private static bool IsPrime(int n)
        {
            for (var divisor = 3; divisor <= (int)Math.Sqrt(n); divisor += 2)
            {
                if (n % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}