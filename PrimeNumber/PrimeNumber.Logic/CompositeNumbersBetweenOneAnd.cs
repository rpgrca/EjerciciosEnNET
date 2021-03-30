using System.Linq;
using System.Collections.Generic;
using System;

namespace PrimeNumber.Logic
{
    public class CompositeNumbersBetweenOneAnd
    {
        private readonly int _top;
        private readonly List<int> _discardedValues;
        public List<int> CompositeNumbers { get; }

        public CompositeNumbersBetweenOneAnd(int top)
        {
            _top = top;
            _discardedValues = new();
            CompositeNumbers = new();
            Calculate();
        }

        private void Calculate()
        {
            for (var index = 3; index <= _top - 1; index += 2)
            {
               foreach (var possibleDivisor in _discardedValues)
                {
                    if (index % possibleDivisor == 0)
                    {
                        CompositeNumbers.Add(index);
                        goto outer;
                    }
                }

                _discardedValues.Add(index);

            outer:;
                CompositeNumbers.Add(index + 1);
            }
        }
    }
}