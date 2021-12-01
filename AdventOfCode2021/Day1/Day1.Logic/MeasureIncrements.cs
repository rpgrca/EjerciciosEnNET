using System;
using System.Linq;
using System.Collections.Generic;

namespace Day1.Logic
{
    public class MeasureIncrements
    {
        private readonly List<int> _depths;

        public int Increments { get; private set; }
        public int ThreeMeasureSlidingWindowIncrements { get; private set; }

        public MeasureIncrements(string depths)
        {
            _depths = depths.Split("\n").Select(p => int.Parse(p)).ToList();
            CountIncrements();
            CountThreeMeasureSlidingWindowIncrements();
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

        private void CountThreeMeasureSlidingWindowIncrements()
        {
            var previousValue = int.MaxValue;
            var counter = 0;

            for (var index = 0; index < _depths.Count - 2; index++)
            {
                var currentValue = _depths[index] + _depths[index+1] + _depths[index+2];
                if (currentValue > previousValue)
                {
                    counter++;
                }

                previousValue = currentValue;
            }

            ThreeMeasureSlidingWindowIncrements = counter;
        }
    }
}