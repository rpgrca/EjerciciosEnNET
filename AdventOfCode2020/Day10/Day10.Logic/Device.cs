using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day10.Logic
{

    public class Device
    {
        private readonly List<long> _joltages;

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
                    if (joltage - previousJoltage == 1)
                    {
                        diffOfOne++;
                    }

                    if (joltage - previousJoltage == 3)
                    {
                        diffOfThree++;
                    }

                    ChainOfAdapters.Add(joltage);
                    previousJoltage = joltage;
                }
                else
                {
                    break;
                }
            }

            DifferenceMultiplied = diffOfOne * (diffOfThree + 1);
        }

        public long CalculateChains()
        {
            var chain = ChainOfAdapters.ConvertAll(p => p);
            chain.Insert(0, 0);
            chain.Add(chain.Last() + 3);

            var splitted = new List<List<long>>();
            var subList = new List<long>();
            for (int i = 0; i < chain.Count - 1; i++)
            {
                subList.Add(chain[i]);
                if (chain[i + 1] - chain[i] == 3)
                {
                    splitted.Add(subList);
                    subList = new List<long>();
                }
            }

            splitted.Add(subList);

            double total = 1;
            foreach (var subList2 in splitted.Where(p => p.Count > 2))
            {
                if (subList2.Last() - subList2.First() > 3)
                {
                    total *= 7;
                }
                else
                {
                    total *= Math.Pow(2, subList2.Count - 2);
                }
            }

            return (long)total;
        }

        /*private void PrintList(List<int> list)
        {
                    list.ForEach(p => Console.Write($"{p}, "));
                    Console.Write("\n");
        }*/

        private int RecursivelyCountChains(List<int> chain, int startingIndex = 1)
        {
            var count = 1;
            for (int index = startingIndex; index < chain.Count - 1; index++)
            {
                if (chain[index + 1] - chain[index - 1] <= 3)
                {
                    var list = chain.Where((_, i) => i != index).ToList();
                    //PrintList(list);
                    count += RecursivelyCountChains(list, index);
                }
            }

            return count;
        }

        public long BuiltInJoltageAdapterRating { get; }
        public List<long> ChainOfAdapters { get; private set; }
        public long DifferenceMultiplied { get; private set; }
    }
}