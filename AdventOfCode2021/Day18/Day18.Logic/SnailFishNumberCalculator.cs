using System.Linq;
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
                Numbers.Add(expression.Value);
            }
        }

        public void AddNumbers()
        {
            var result = Numbers[0];
            var loops = 0;

            foreach (var operand in Numbers.Skip(1))
            {
                bool reduced = false;
                var sum = new SnailFishNumber(result, operand);

                var visitor = new ReorderRegularNumberVisitor();
                sum.Accept(visitor);

                do
                {
                    loops++;
                    reduced = false;

                    var exploder = new SnailFishNumberExploder(sum);
                    if (exploder.CanReduce())
                    {
                        sum = exploder.Apply();
                        reduced = true;
                    }
                    else
                    {
                        var splitter = new SnailFishNumberSplitter(sum);
                        if (splitter.CanReduce())
                        {
                            sum = splitter.Apply();
                            reduced = true;
                        }
                    }
                }
                while (reduced);

                result = sum;
            }

            Result = result;
        }
    }
}