using System;
using System.Linq;

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
            var repeatedValue = 0;
            var repeatedValueCount = 0;

            if (A.Length >= 2)
            {
                var values = (A[0], A[1]);

                for (var index = 2; index < A.Length; index++)
                {
                    if (values.Item1 == A[index] || values.Item2 == A[index])
                    {
                        currentLength++;
                        if (A[index] == A[index - 1])
                        {
                            repeatedValue = A[index];
                            repeatedValueCount++;
                        }
                    }
                    else
                    {
                        if (values.Item1 == values.Item2)
                        {
                            values = (values.Item2, A[index]);
                            currentLength++;

                            if (A[index] == A[index - 1])
                            {
                                repeatedValue = A[index];
                                repeatedValueCount++;
                            }
                        }
                        else
                        {
                            maximumLength = ObtainLargerValue(currentLength, maximumLength);
                            values = (A[index - 1], A[index]);

                            currentLength = 2 + (values.Item1 == repeatedValue? repeatedValue - 1 : 0);
                            repeatedValue = 0;
                            repeatedValueCount = 0;
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
        private (int, int) _currentLength;
        private (int, int) _pair;
        private int _index;

        public int Result => _maximumLength;

        public SolutionAsObjectOriented(int[] array)
        {
            _array = array;
            _maximumLength = 0;
            InitializeCurrentLengthOfAPair();
            InitializeIndexToStartWithFirstElementOfPair();
        }

        private void InitializeCurrentLengthOfAPair() => _currentLength = (1, 1);

        private void InitializeIndexToStartWithFirstElementOfPair() => _index = 1;

        public void Calculate()
        {
            if (! InputArrayHasMinimumLength())
            {
                return;
            }

            ExtractFirstPairOfValues();

            while (ThereAreValuesToProcess())
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
                        AccumulateIntoSinglePair();
                        ShiftCurrentLengthOfAPair();
                    }
                    else
                    {
                        UpdateMaximumValueWhenNecessary();
                        AddCurrentValueShiftingValuesInPair();
                        ShiftCurrentLengthOfAPair();
                    }
                }
            }

            UpdateMaximumValueWhenNecessary();
        }

        private bool InputArrayHasMinimumLength() => _array.Length >= 2;

        private void ExtractFirstPairOfValues() => _pair = (_array[0], _array[1]);

        private bool ThereAreValuesToProcess() => ++_index < _array.Length;

        private bool CurrentValueBelongsToPair() => _pair.Item1 == _array[_index] || _pair.Item2 == _array[_index];

        private void AddOneToCurrentLength()
        {
            if (_array[_index] == _pair.Item1)
            {
                _currentLength.Item1++;
            }
            else
            {
                _currentLength.Item2++;
            }
        }

        private bool PairMembersAreIdentical() => _pair.Item1 == _pair.Item2;

        private void AddCurrentValueToPair() => _pair = (_pair.Item2, _array[_index]);

        private void AccumulateIntoSinglePair() => _currentLength.Item1 += _currentLength.Item2;

        public int UpdateMaximumValueWhenNecessary() =>
            _maximumLength = _currentLength.Item1 + _currentLength.Item2 > _maximumLength
                ? _currentLength.Item1 + _currentLength.Item2
                : _maximumLength;

        private void AddCurrentValueShiftingValuesInPair() => _pair = (_array[_index - 1], _array[_index]);

        private void ShiftCurrentLengthOfAPair() => _currentLength = (_currentLength.Item2, 1);
    }
}