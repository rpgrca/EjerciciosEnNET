using System;
using System.Collections.Generic;

namespace Day18.Logic
{
    public class SnailFishNumberCalculator
    {
        private readonly string _homework;

        public List<(int, int)> Expressions { get; }

        public SnailFishNumberCalculator(string homework)
        {
            if (string.IsNullOrWhiteSpace(homework))
            {
                throw new ArgumentException("Invalid homework");
            }

            Expressions = new List<(int, int)> { (1, 2) };
            _homework = homework;
        }
    }
}
