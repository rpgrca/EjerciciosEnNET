using System;
using System.Linq;
using System.Collections.Generic;

namespace Day1.Logic
{
    public class MeasureIncrements
    {
        private readonly List<int> _depths;

        public int Increments { get; }

        public MeasureIncrements(string depths, int windowSize)
        {
            _depths = depths.Split("\n").Select(p => int.Parse(p)).ToList();
            Increments = CountSlidingWindowIncrements(windowSize);
        }

        private int CountSlidingWindowIncrements(int measure)
        {
            var previousValue = int.MaxValue;
            var counter = 0;

            for (var index = 0; index < _depths.Count - (measure - 1); index++)
            {
                var currentValue = _depths.Skip(index).Take(measure).Sum();
                if (currentValue > previousValue)
                {
                    counter++;
                }

                previousValue = currentValue;
            }

            return counter;
        }
    }
}