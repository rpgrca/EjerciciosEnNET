using System.Collections.Generic;

namespace AdventOfGame2020.Day15.Logic
{
    public class MemoryGame
    {
        private readonly List<int> _startingNumbers;
        private readonly Dictionary<int, int> _numbers;
        private int _index;
        private int _lastNumber;

        public MemoryGame(int[] startingNumbers)
        {
            _startingNumbers = new List<int>(startingNumbers);
            _numbers = new Dictionary<int, int>();
            _index = 0;
            _lastNumber = -1;
        }

        private int Next()
        {
            var nextNumber = _numbers.ContainsKey(_lastNumber)
                ? _index - _numbers[_lastNumber]
                : 0;

            _numbers[_lastNumber] = _index++;
            _lastNumber = nextNumber;

            return _lastNumber;
        }

        public int CalculateFor(int index)
        {
            var nextNumber = 0;

            if (index < _startingNumbers.Count + 1)
            {
                return _startingNumbers[index - 1];
            }
            else
            {
                _startingNumbers.ForEach(n => _numbers.Add(n, ++_index));
                _lastNumber = _startingNumbers[^1];

                index -= _startingNumbers.Count;
                while (index > 0)
                {
                    nextNumber = Next();
                    index--;
                }

                return nextNumber;
            }
        }
    }
}