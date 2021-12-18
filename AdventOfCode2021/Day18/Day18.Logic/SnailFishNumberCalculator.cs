using System;
using System.Collections.Generic;

namespace Day18.Logic
{

    public class SnailFishNumberCalculator
    {
        private readonly string _homework;

        public List<SnailFishNumber> Expressions { get; }

        public SnailFishNumberCalculator(string homework)
        {
            if (string.IsNullOrWhiteSpace(homework))
            {
                throw new ArgumentException("Invalid homework");
            }

            Expressions = new List<SnailFishNumber>();
            _homework = homework;


            Parse();
        }

        private void Parse()
        {
            var expression = new SnailFishNumberParser(_homework);
            Expressions.Add((SnailFishNumber)expression.Value);
        }
    }
}