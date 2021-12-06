using System.Linq;
using System;

namespace Day6.Logic
{
    public class AgeModel
    {
        private readonly string _inputAges;
        private readonly long[] _ages;
        private int _zeroIndex;

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
            foreach (var fish in _inputAges.Split(",").GroupBy(p => p))
            {
                _ages[int.Parse(fish.Key)] = fish.Count();
            }
        }

        public void Advance(int days)
        {
            for (var day = 0; day < days; day++)
            {
                var fishesSpawning = _ages[GetIndexOf(0)];
                AdvanceZeroIndex();

                _ages[GetIndexOf(6)] += fishesSpawning;
                _ages[GetIndexOf(8)] = fishesSpawning;
           }
        }

        private int GetIndexOf(int age) => (_zeroIndex + age) % 9;

        private void AdvanceZeroIndex() => _zeroIndex = (_zeroIndex + 1) % 9;

        public long CountAllFishes() => _ages.Sum();

        public long CountFishesWithAnAgeOf(int value) => _ages[GetIndexOf(value)];
    }
}