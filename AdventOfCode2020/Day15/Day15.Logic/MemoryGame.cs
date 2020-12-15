using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfGame2020.Day15.Logic
{
    public class MemoryGame
    {
        private readonly int[] _startingNumbers;
        private readonly Dictionary<int, int> _numbers;
        private int _index;
        private int _lastNumber;

        public MemoryGame(int[] startingNumbers)
        {
            _startingNumbers = startingNumbers;
            _numbers = new Dictionary<int, int>();
            _index = 0;
            _lastNumber = -1;
        }

        public int Next()
        {
            var nextNumber = 0;

            if (_index < _startingNumbers.Length)
            {
                nextNumber = _startingNumbers[_index];

                if (_lastNumber != -1)
                {
                    _numbers[_lastNumber] = _index;
                }
            }
            else
            {
                if (_numbers.ContainsKey(_lastNumber))
                {
                    nextNumber = _index - _numbers[_lastNumber];
                }
                else
                {
                    nextNumber = 0;
                }

                _numbers[_lastNumber] = _index;
            }

            _index++;
            _lastNumber = nextNumber;
            return nextNumber;
        }

        public int Next(int times)
        {
            var nextNumber = 0;

            while (times > 0)
            {
                nextNumber = Next();
                times--;
            }

            return nextNumber;
        }
    }
}