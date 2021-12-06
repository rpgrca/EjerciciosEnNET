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
            var spawnFishes = new List<int>();
            for (var index = 0; index < Ages.Count; index++)
            {
                _ages[index]--;
                if (_ages[index] < 0)
                {
                    _ages[index] = 6;
                    spawnFishes.Add(8);
                }
            }

            _ages.AddRange(spawnFishes);
        }
    }
}
