using System.Data;
using System;
using System.Linq;

namespace Day1.Logic
{
    public class MeasureIncrements
    {
        private readonly int[] _depths;

        public int Total { get; private set; }

        public MeasureIncrements(string depths, int windowSize)
        {
            _depths = depths.Split("\n").Select(p => int.Parse(p)).ToArray();
            CountSlidingWindowIncrementsFor(windowSize);
        }

        private void CountSlidingWindowIncrementsFor(int measure)
        {
            var previousValue = int.MaxValue;

            for (var index = 0; index < _depths.Length - (measure - 1); index++)
            {
                var currentValue = _depths[index..(index + measure)].Sum();
                Total += currentValue > previousValue? 1 : 0;

                previousValue = currentValue;
            }
        }
    }
}