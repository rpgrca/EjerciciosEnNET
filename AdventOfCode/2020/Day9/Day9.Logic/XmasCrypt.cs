using System.Collections.Generic;

namespace AdventOfCode2020.Day9.Logic
{
    public class XmasCrypt
    {
        private readonly List<long> _preamble;
        public long InvalidValue { get; private set; } = -1;

        public XmasCrypt(long[] initializationData, int preambleLength)
        {
            _preamble = new List<long>(initializationData[0..preambleLength]);

            if (initializationData.Length > preambleLength)
            {
                foreach (var nextValue in initializationData[preambleLength..])
                {
                    if (! Append(nextValue))
                    {
                        break;
                    }
                }
            }
        }

        public bool IsValid(long nextValue)
        {
            for (var i = 0; i < _preamble.Count - 1; i++)
            {
                for (var j = i + 1; j < _preamble.Count; j++)
                {
                    if (nextValue == _preamble[i] + _preamble[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Append(long nextValue)
        {
            if (IsValid(nextValue))
            {
                _preamble.RemoveAt(0);
                _preamble.Add(nextValue);
                return true;
            }
            else
            {
                InvalidValue = nextValue;
                return false;
            }
        }
    }
}