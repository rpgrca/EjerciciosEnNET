using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace Day18.Logic
{
    public class SnailFishNumberCalculator
    {
        private readonly string _homework;

        public List<SnailFishNumber> Numbers { get; }
        public SnailFishNumber Result { get; private set; }

        public SnailFishNumberCalculator(string homework)
        {
            if (string.IsNullOrWhiteSpace(homework))
            {
                throw new ArgumentException("Invalid homework");
            }

            Numbers = new List<SnailFishNumber>();
            _homework = homework;

            Parse();
        }

        private void Parse()
        {
            var expression = new SnailFishNumberParser(_homework);
            Numbers.Add((SnailFishNumber)expression.Value);

            Result = Numbers[0];
        }
    }
}