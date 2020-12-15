using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfGame2020.Day15.Logic
{
    public class MemoryGame
    {
        private readonly int[] _startingNumbers;
        private readonly List<int> _numbers;
        private int _index;

        public MemoryGame(int[] startingNumbers)
        {
            _startingNumbers = startingNumbers;
            _numbers = new List<int>();
            _index = 0;
        }

        public int Next()
        {
            var nextNumber = 0;

            if (_index < _startingNumbers.Length)
            {
                nextNumber = _startingNumbers[_index++];
            }
            else
            {
                var lastNumber = _numbers[^1];

                nextNumber = _numbers.Count(p => p == lastNumber);
                if (nextNumber == 1)
                {
                    nextNumber = 0;
                }
                else
                {
                    for (var i = _numbers.Count - 2; i >= 0; i--)
                    {
                        if (_numbers[i] == lastNumber)
                        {
                            nextNumber = _numbers.Count - (i + 1);
                            break;
                        }
                    }
                }
            }

            _numbers.Add(nextNumber);
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