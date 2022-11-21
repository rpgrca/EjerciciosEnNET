using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AdventOfGame2020.Day15.Logic
{
    public class MemoryGame
    {
        private readonly int[] _startingNumbers;
        private readonly int[] _numbers;
        private int _index;
        private int _lastNumber;

        public MemoryGame(int[] startingNumbers, int maximumAmount)
        {
            _startingNumbers = startingNumbers;
            _numbers = new int[maximumAmount];
            _index = 0;
            _lastNumber = -1;
        }

        private void Next()
        {
            int value = _numbers[_lastNumber] != 0
                ? _index - _numbers[_lastNumber]
                : 0;

            _numbers[_lastNumber] = _index++;
            _lastNumber = value;
        }

        public int CalculateFor(int index)
        {
            if (index < _startingNumbers.Length + 1)
            {
                return _startingNumbers[index - 1];
            }
            else
            {
                _startingNumbers.ToList().ForEach(n => _numbers[n] = ++_index);
                _lastNumber = _startingNumbers[^1];

                index -= _startingNumbers.Length;
                while (index > 0)
                {
                    Next();
                    index--;

                }

                return _lastNumber;
            }
        }
    }
}