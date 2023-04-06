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
            if (value < 2) return true;
            
            for (int i = 2; i <= Math.Sqrt(value); i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }
        
            return true;
        }
    }
}