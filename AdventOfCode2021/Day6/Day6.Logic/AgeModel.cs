using System.Linq;
using System;
using System.Collections.Generic;

namespace Day6.Logic
{
    public class AgeModel
    {
        private readonly string _ages;

        public List<int> Ages { get; }

        public AgeModel(string ages)
        {
            if (string.IsNullOrWhiteSpace(ages))
            {
                throw new ArgumentException("Invalid age list");
            }

            _ages = ages;
            Ages = new List<int>();

            Parse();
        }

        private void Parse() =>
            Ages.AddRange(_ages.Split(",").Select(p => int.Parse(p)));
    }
}
