using System.Collections.Generic;
using Day18.Logic.Numbers;

namespace Day18.Logic
{
    public class SnailFishNumberParser
    {
        private string _leftOver;
        private readonly List<Number> _discoveredNumbers;
        private int _order;

        public SnailFishNumber Value { get; private set; }
        public int Magnitude { get; private set; }

        public SnailFishNumberParser(string snailFishNumber)
        {
            _leftOver = snailFishNumber;
            _discoveredNumbers = new List<Number>();

            Parse();
        }

        private void Parse()
        {
            Value = (SnailFishNumber)ParseNumber();
        }

        private void Consume(char toConsume)
        {
            if (_leftOver[0] != toConsume)
            {
                throw new System.Exception($"Expected {toConsume}");
            }

            _leftOver = _leftOver[1..];
        }

        private void Consume(int amount)
        {
            _leftOver = _leftOver[amount..];
        }

        private Number ParseNumber()
        {
            Number leftNumber, rightNumber;

            if (_leftOver[0] == '[')
            {
                Consume('[');
                leftNumber = ParseNumber();
                Consume(',');
                rightNumber = ParseNumber();
                Consume(']');

                return new SnailFishNumber(leftNumber, rightNumber);
            }

            var index = 0;
            while (_leftOver[index] >= '0' && _leftOver[index] <= '9')
            {
                index++;
            }

            var number = new RegularNumber(int.Parse(_leftOver[0..index]), _order++);
            Consume(index);

            return number;
        }
    }
}