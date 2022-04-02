using System.Collections.Generic;
using Day18.Logic.Numbers;

namespace Day18.Logic
{
    public class SnailFishNumberParser
    {
        private readonly List<Number> _discoveredNumbers;
        private string _leftover;
        private int _order;

        public SnailFishNumber Value { get; private set; }

        public SnailFishNumberParser(string snailFishNumber)
        {
            _leftover = snailFishNumber;
            _discoveredNumbers = new List<Number>();

            Parse();
        }

        private void Parse() => Value = (SnailFishNumber)ParseNumber();

        private void Consume(char _) => _leftover = _leftover[1..];

        private void Consume(int amount) => _leftover = _leftover[amount..];

        private Number ParseNumber()
        {
            Number leftValue, rightValue;

            if (_leftover[0] == '[')
            {
                Consume('[');
                leftValue = ParseNumber();
                Consume(',');
                rightValue = ParseNumber();
                Consume(']');

                return new SnailFishNumber(leftValue, rightValue);
            }

            var index = 0;
            while (_leftover[index] >= '0' && _leftover[index] <= '9')
            {
                index++;
            }

            var number = new RegularNumber(int.Parse(_leftover[0..index]), _order++);
            Consume(index);

            return number;
        }
    }
}