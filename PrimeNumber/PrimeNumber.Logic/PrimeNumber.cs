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
            if (value % 2 == 0) return false;

            for (var divisor = 3; divisor <= (int)Math.Sqrt(value); divisor += 2)
            {
                if (value % divisor == 0)
                {
                    return false;
                }
            }
        
            return true;
        }
    }
}