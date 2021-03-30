using System.Linq;
using System.Collections.Generic;
using System;

namespace PrimeNumber.Logic
{
    public class PrimeNumber : IClassifier
    {
        private int _value;
        private List<int> _possibleDivisors;
        private List<int> _previousDivisors;
        private int _possibleDivisor;
        private bool ValueHasADivisor { get; set; }

        public bool IsClassificationOf(int value)
        {
            if (value <= 0) return false;
            if (value <= 2) return true;

            _value = value;
            CalculatePossibleDivisorsUntilSquareRootOfValue();
            CreatePreviousDivisorsList();
            while (PossibleDivisorsExist())
            {
                TakeFirstPossibleDivisor();
                AnyPreviousDivisorCanDividePossibleDivisor(
                    yes: () => DiscardPossibleDivisor(),
                    no: () => {
                        IsValueDivisibleByPossibleDivisor(
                            yes: () => ValueHasADivisor = true,
                            no: () => {
                                AddPossibleDivisorToListOfPreviousDivisors();
                                DiscardPossibleDivisor();
                            });
                    }
                );

                if (ValueHasADivisor) return false;
            }

            return true;
        }

        private void CalculatePossibleDivisorsUntilSquareRootOfValue() =>
            _possibleDivisors = Enumerable.Range(2, (int)Math.Sqrt(_value)).ToList();

        private void CreatePreviousDivisorsList() =>
            _previousDivisors = new List<int>();

        private bool PossibleDivisorsExist() =>
            _possibleDivisors.Count > 0;

        private void TakeFirstPossibleDivisor() =>
            _possibleDivisor = _possibleDivisors[0];

        private void AnyPreviousDivisorCanDividePossibleDivisor(Action yes, Action no)
        {
            if (_previousDivisors.Any(p => _possibleDivisor % p == 0))
                yes();
            else
                no();
        }

        private void DiscardPossibleDivisor() =>
            _possibleDivisors.RemoveAt(0);

        private void IsValueDivisibleByPossibleDivisor(Action yes, Action no)
        {
            if (_value % _possibleDivisor == 0)
                yes();
            else
                no();
        }

        private void AddPossibleDivisorToListOfPreviousDivisors() =>
            _previousDivisors.Add(_possibleDivisor);
    }
}