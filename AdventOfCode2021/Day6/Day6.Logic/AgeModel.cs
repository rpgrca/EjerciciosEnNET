using System.Linq;
using System;
using System.Collections.Generic;

namespace Day6.Logic
{
    public class AgeModel
    {
        private readonly string _inputAges;
        private List<int> _ages;

        public List<int> Ages => _ages;

        public AgeModel(string ages)
        {
            if (string.IsNullOrWhiteSpace(ages))
            {
                throw new ArgumentException("Invalid age list");
            }

            _inputAges = ages;

            Parse();
        }

        private void Parse() =>
            _ages = _inputAges.Split(",").Select(p => int.Parse(p)).ToList();

        public void NextDay()
        {
            _ages[0]--;
            if (_ages[0] < 0)
            {
                _ages[0] = 6;
                _ages.Add(8);
            }
        }
    }
}
