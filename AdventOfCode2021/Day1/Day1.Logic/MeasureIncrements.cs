using System;
using System.Linq;
using System.Collections.Generic;

namespace Day1.Logic
{
    public class MeasureIncrements
    {
        private readonly IEnumerable<int> _depths;

        public int Increments { get; private set; }

        public MeasureIncrements(string depths)
        {
            _depths = depths.Split("\n").Select(p => int.Parse(p));
            CountIncrements();
        }

        private void CountIncrements()
        {
            var previousValue = int.MaxValue;
            var counter = 0;

            foreach (var value in _depths)
            {
                if (value > previousValue)
                {
                    counter++;
                }

                previousValue = value;
            }

            Increments = counter;
        }
    }
}