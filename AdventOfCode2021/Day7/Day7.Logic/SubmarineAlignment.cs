using System.Linq;
using System;
using System.Collections.Generic;

namespace Day7.Logic
{
    public sealed class SubmarineAlignment
    {
        private readonly string _input;
        private IEnumerable<int> _positions;

        public int MinimumFuelConsumption { get; private set; }
        public Func<int, int> ConsumptionCallback { get; }

        public static SubmarineAlignment CreateWithConstantConsumption(string input) => new(input, p => p);

        public static SubmarineAlignment CreateWithIncrementalConsumption(string input) => new(input, p => p * (p + 1) / 2);

        private SubmarineAlignment(string input, Func<int, int> consumptionCallback)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
            ConsumptionCallback = consumptionCallback;

            Parse();
            CalculateMinimumFuelConsumption();
        }

        private void Parse() => _positions = _input.Split(",").Select(p => int.Parse(p));

        private void CalculateMinimumFuelConsumption()
        {
            var min = _positions.Min();
            var max = _positions.Max();

            MinimumFuelConsumption = Enumerable
                .Range(min, max - min + 1)
                .Min(p => _positions.Sum(x => ConsumptionCallback(Math.Abs(x - p))));
        }
    }
}