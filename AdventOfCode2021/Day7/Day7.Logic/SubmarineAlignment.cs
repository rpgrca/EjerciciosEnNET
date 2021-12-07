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
            CalculateMinimumFuelConsumption();
        }

        public SubmarineAlignment(string input, bool v)
        {
            _input = input;

            Parse();

            var min = _positions.Min();
            var max = _positions.Max();
            MinimumFuelConsumption = int.MaxValue;

            for (var index = min; index <= max; index++)
            {
                var offset = _positions.Sum(p => Math.Abs(CalculateOffset(p, index)));
                if (offset < MinimumFuelConsumption)
                {
                    MinimumFuelConsumption = offset;
                }
            }
        }

        private int CalculateOffset(int actualPosition, int proposedPosition)
        {
            if (actualPosition == proposedPosition)
                return 0;

            int result = 0;
            if (actualPosition > proposedPosition)
            {
                for (var index = proposedPosition; index < actualPosition; index++)
                {
                    result += index - proposedPosition + 1;
                }
            }
            else
            {
                for (var index = actualPosition; index < proposedPosition; index++)
                {
                    result += index - actualPosition + 1;
                }
            }

            return result;
        }

        private void Parse() =>
            _positions = _input.Split(",").Select(p => int.Parse(p)).ToList();

        private void CalculateMinimumFuelConsumption()
        {
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