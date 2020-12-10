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
        }

        public void CalculateChain()
        {
            ChainOfAdapters = new List<long>();

            var diffOfThree = 0;
            var diffOfOne = 0;
            var previousJoltage = 0L;
            foreach (var joltage in _joltages.OrderBy(p => p))
            {
                if (joltage <= previousJoltage + 3)
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
                else
                {
                    break;
                }
            }

            ChainOfAdapters.Insert(0, 0);
            ChainOfAdapters.Add(ChainOfAdapters.Last() + 3);

            DifferenceMultiplied = diffOfOne * (diffOfThree + 1);
        }

        public long CalculateAmountOfPossibleChains()
        {
            var subList = new List<long>();
            var total = 1D;

            for (int i = 0; i < ChainOfAdapters.Count - 1; i++)
            {
                subList.Add(ChainOfAdapters[i]);
                if (ChainOfAdapters[i + 1] - ChainOfAdapters[i] == 3)
                {
                    if (subList.Count > 2)
                    {
                        total *= (subList[^1] - subList[0] > 3)
                            ? 7
                            : Math.Pow(2, subList.Count - 2);
                    }

                    subList.Clear();
                }
            }

            return (long)total;
        }
    }
}