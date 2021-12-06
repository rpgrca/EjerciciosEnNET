using System.Linq;
using System;
using System.Collections.Generic;

namespace Day6.Logic
{
    public class AgeModel
    {
        private readonly string _inputAges;
        private readonly long[] _ages;

        public AgeModel(string ages)
        {
            if (string.IsNullOrWhiteSpace(ages))
            {
                throw new ArgumentException("Invalid age list");
            }

            _inputAges = ages;
            _ages = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Parse();
        }

        private void Parse()
        {
            foreach (var age in _inputAges.Split(",").Select(p => int.Parse(p)))
            {
                _ages[age]++;
            }
        }

        public void Advance(int days)
        {
            for (var day = 0; day < days; day++)
            {
                var fishesSpawning = _ages[0];

                _ages[0] = _ages[1];
                _ages[1] = _ages[2];
                _ages[2] = _ages[3];
                _ages[3] = _ages[4];
                _ages[4] = _ages[5];
                _ages[5] = _ages[6];
                _ages[6] = _ages[7] + fishesSpawning;
                _ages[7] = _ages[8];
                _ages[8] = fishesSpawning;
           }
        }

        public long FishCount() => _ages.Sum();
    }
}
