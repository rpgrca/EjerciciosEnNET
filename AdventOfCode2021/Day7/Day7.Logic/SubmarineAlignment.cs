using System.Linq;
using System;
using System.Collections.Generic;

namespace Day7.Logic
{
    public class SubmarineAlignment
    {
        private readonly string _input;
        private List<int> _positions;

        public int MinimumFuelConsumption { get; private set; }

        public SubmarineAlignment(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;

            Parse();
        }

        private void Parse()
        {
            _positions = _input.Split(",").Select(p => int.Parse(p)).ToList();

            var min = _positions.Min();
            var max = _positions.Max();
            MinimumFuelConsumption = _positions.Sum();

            for (var index = min; index <= max; index++)
            {
                var offset = _positions.Sum(p => Math.Abs(p - index));
                if (offset < MinimumFuelConsumption)
                {
                    MinimumFuelConsumption = offset;
                }
            }
        }
    }
}
