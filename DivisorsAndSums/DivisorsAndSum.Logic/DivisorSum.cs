using System.Linq;
using System.Collections.Generic;
using System;

namespace DivisorsAndSum.Logic
{
    public class DivisorSum
    {
        public class Builder
        {
            private int _amount;
            private Func<int, IEnumerable<int>> _divisorCalculator;

            public Builder UsingDivisorAlgorithm(Func<int, IEnumerable<int>> algorithm)
            {
                _divisorCalculator = algorithm;
                return this;
            }

            public Builder UpTo(int amount)
            {
                _amount = amount;
                return this;
            }

            public DivisorSum Build()
            {
                _divisorCalculator ??= v => Enumerable.Range(1, v / 2).Where(p => v % p == 0);
                return new DivisorSum(_amount, _divisorCalculator);
            }
        }

        private readonly int _amount;
        private readonly List<string> _equations;
        private IEnumerable<int> _divisors;
        private readonly Func<int, IEnumerable<int>> _calculateDivisorsFor;

        public string Result { get; private set; }

        private DivisorSum(int amount, Func<int, IEnumerable<int>> divisorCalculator)
        {
            _amount = amount;
            _calculateDivisorsFor = divisorCalculator;
            _equations = new List<string>();
            Calculate();
        }

        private void Calculate()
        {
            for (var possibleValue = 6; _equations.Count < _amount; possibleValue++)
            {
                CalculateDivisorsFor(possibleValue);
                AddEquationIfPossibleValueFulfillsCondition(possibleValue);
            }

            GenerateResult();
        }

        private void AddEquationIfPossibleValueFulfillsCondition(int possibleValue)
        {
            if (possibleValue == _divisors.Sum())
            {
                _equations.Add($"{string.Join(" + ", _divisors)} = {possibleValue}");
            }
        }

        private void CalculateDivisorsFor(int possibleValue) =>
            _divisors = _calculateDivisorsFor(possibleValue);

        private void GenerateResult() => Result = string.Join("\n", _equations);
    }
}