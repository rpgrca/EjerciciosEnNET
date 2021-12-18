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
            Result = Numbers[0];
        }

        private void Parse()
        {
            foreach (var snailNumber in _homework.Split("\n"))
            {
                var expression = new SnailFishNumberParser(snailNumber);
                Numbers.Add((SnailFishNumber)expression.Value);
            }
        }

        public void AddNumbers()
        {
            Result = new SnailFishNumber(Numbers[0], Numbers[1]);
        }
    }
}