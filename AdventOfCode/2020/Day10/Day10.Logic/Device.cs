using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day10.Logic
{
    public class Device
    {
        private readonly List<long> _joltages;

        public long BuiltInJoltageAdapterRating { get; }
        public List<long> ChainOfAdapters { get; private set; }
        public long DifferenceMultiplied { get; private set; }

        public Device(long[] joltages)
        {
            _joltages = joltages.ToList();
            BuiltInJoltageAdapterRating = _joltages.Max() + 3;
            _joltages.Add(0);
            _joltages.Add(BuiltInJoltageAdapterRating);
            ChainOfAdapters = new List<long>();
        }

        public void CalculateChain()
        {
            ChainOfAdapters = new List<long>();

            var diffOfThree = 0;
            var diffOfOne = 0;
            var previousJoltage = 0L;

            foreach (var joltage in _joltages.OrderBy(p => p))
            {
                switch (joltage - previousJoltage)
                {
                    case 1:
                        diffOfOne++;
                        break;

                    case 3:
                        diffOfThree++;
                        break;
                }

                ChainOfAdapters.Add(joltage);
                previousJoltage = joltage;
            }

            DifferenceMultiplied = diffOfOne * diffOfThree;
        }

        public long CalculateAmountOfPossibleChains()
        {
            var total = 1D;
            var start = 0;

            for (var index = 0; index < ChainOfAdapters.Count - 1; index++)
            {
                if (ChainOfAdapters[index + 1] - ChainOfAdapters[index] == 3)
                {
                    if (index - start >= 2)
                    {
                        total *= Math.Pow(2, index - start - 1) -
                            ((ChainOfAdapters[index] - ChainOfAdapters[start] > 3)? 1 : 0);
                    }

                    start = index + 1;
                }
            }

            return (long)total;
        }
    }
}