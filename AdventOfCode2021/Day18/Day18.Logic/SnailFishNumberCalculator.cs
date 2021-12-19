using System.Linq;
using System;
using System.Collections.Generic;
using Day18.Logic.Visitors;
using Day18.Logic.Numbers;
using Day18.Logic.Reducers;

namespace Day18.Logic
{
    public class SnailFishNumberCalculator
    {
        private readonly string _homework;
        private readonly List<SnailFishNumber> _numbers;

        public SnailFishNumber Result { get; private set; }

        public SnailFishNumberCalculator(string homework)
        {
            if (string.IsNullOrWhiteSpace(homework))
            {
                throw new ArgumentException("Invalid homework");
            }

            _numbers = new List<SnailFishNumber>();
            _homework = homework;

            Parse();

            Result = _numbers[0];
        }

        private void Parse()
        {
            foreach (var snailNumber in _homework.Split("\n"))
            {
                var expression = new SnailFishNumberParser(snailNumber);
                _numbers.Add(expression.Value);
            }
        }

        public void AddNumbers()
        {
            var result = _numbers[0];

            foreach (var operand in _numbers.Skip(1))
            {
                bool reduced = false;
                var sum = new SnailFishNumber(result, operand);

                var visitor = new ReorderRegularNumberVisitor();
                sum.Accept(visitor);

                do
                {
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

        public void FindLargestMagnitude()
        {
            var largestMagnitude = 0;

            foreach (var number in _numbers)
            {
                for (var index = 0; index < _numbers.Count; index++)
                {
                    if (number == _numbers[index])
                    {
                        continue;
                    }

                    var calculator = new SnailFishNumberCalculator($"{number}\n{_numbers[index]}");
                    calculator.AddNumbers();
                    var magnitude = calculator.Result.GetMagnitude();

                    if (magnitude > largestMagnitude)
                    {
                        largestMagnitude = magnitude;
                        Result = calculator.Result;
                    }
                }
            }
        }
    }
}