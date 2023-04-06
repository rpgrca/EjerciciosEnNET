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
            for (var i = 4; i <= _top; i++)
            {
                if (!IsPrime(i))
                {
                    CompositeNumbers.Add(i);
                }
            }
        }
    
        private static bool IsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}