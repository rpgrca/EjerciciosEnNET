using System;
using System.Collections.Generic;

namespace Day6.Logic
{
    public class AgeModel
    {
        public AgeModel(string ages)
        {
            if (ages is null)
            {
                throw new ArgumentException("Invalid age list");
            }

            Ages = new List<int> { int.Parse(ages) };
        }

        public List<int> Ages { get; set; }
    }
}
