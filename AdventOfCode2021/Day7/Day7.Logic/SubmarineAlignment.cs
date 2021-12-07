using System.Linq;
using System;
using System.Collections.Generic;

namespace Day7.Logic
{
    public class SubmarineAlignment
    {
        private readonly string _input;
        private List<int> _positions;

        public int BestPosition { get; private set; }

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
            BestPosition = _positions[0];
        }
    }
}
