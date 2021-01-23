using System;
namespace BiValuedArray
{
    public class Solution
    {
        public int ObtainLargerValue(int current, int maximum) =>
            current > maximum? current : maximum;

        public int solution(int[] A)
        {
            var maximumLength = 0;
            var currentLength = 2;

            if (A.Length >= 2)
            {
                var values = (A[0], A[1]);

                for (var index = 2; index < A.Length; index++)
                {
                    if (values.Item1 == A[index] || values.Item2 == A[index])
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (values.Item1 == values.Item2)
                        {
                            values = (values.Item2, A[index]);
                            currentLength++;
                        }
                        else
                        {
                            maximumLength = ObtainLargerValue(currentLength, maximumLength);

                            values = (A[index - 1], A[index]);
                            currentLength = 2;
                        }
                    }
                }

                maximumLength = ObtainLargerValue(currentLength, maximumLength);
            }

            return maximumLength;
        }
    }

    public class SolutionAsObjectOriented
    {
        private readonly int[] _array;
        private int _maximumLength;
        private int _currentLength;
        private (int, int) _pair;
        private int _index;

        public SolutionAsObjectOriented(int[] array)
        {
            _array = array;
            InitializeCurrentLength();
        }

        public int UpdateMaximumValue() =>
            _maximumLength = _currentLength > _maximumLength
                ? _currentLength
                : _maximumLength;

        public int Calculate()
        {
            if (InputArrayHasMinimumLength())
            {
                ExtractFirstPairOfValues();

                for (_index = 2; _index < _array.Length; _index++)
                {
                    if (CurrentValueBelongsToPair())
                    {
                        AddOneToCurrentLength();
                    }
                    else
                    {
                        if (PairMembersAreIdentical())
                        {
                            AddCurrentValueToPair();
                            AddOneToCurrentLength();
                        }
                        else
                        {
                            UpdateMaximumValue();
                            AddCurrentValueShiftingValuesInPair();
                            InitializeCurrentLength();
                        }
                    }
                }

                UpdateMaximumValue();
            }

            return _maximumLength;
        }

        private void InitializeCurrentLength() => _currentLength = 2;

        private void AddCurrentValueShiftingValuesInPair() => _pair = (_array[_index - 1], _array[_index]);

        private void AddCurrentValueToPair() => _pair = (_pair.Item2, _array[_index]);

        private bool PairMembersAreIdentical() => _pair.Item1 == _pair.Item2;

        private void AddOneToCurrentLength() => _currentLength++;

        private bool CurrentValueBelongsToPair() => _pair.Item1 == _array[_index] || _pair.Item2 == _array[_index];

        private void ExtractFirstPairOfValues() => _pair = (_array[0], _array[1]);

        private bool InputArrayHasMinimumLength() => _array.Length >= 2;
    }
}