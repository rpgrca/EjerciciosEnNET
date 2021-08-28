using System.Linq;
using System.Collections.Generic;
using System;

namespace DivisorsAndSum.Logic
{
    public class DivisorSum
    {
        private static IEnumerable<int> ValuesGenerator()
        {
            for (var index = 6; ; index++) yield return index;
        }

        public class Builder
        {
            private int _amount;
            private Func<int, IEnumerable<int>> _divisorCalculator;
            private Func<IEnumerable<int>> _valuesGenerator;

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

            public Builder UsingGenerator(Func<IEnumerable<int>> generator)
            {
                _valuesGenerator = generator;
                return this;
            }

            public DivisorSum Build()
            {
                _divisorCalculator ??= v => Enumerable.Range(1, v / 2).Where(p => v % p == 0);
                _valuesGenerator ??= ValuesGenerator;
                return new DivisorSum(_amount, _valuesGenerator, _divisorCalculator);
            }
        }

        private readonly int _amount;
        private readonly List<string> _equations;
        private readonly IEnumerable<int> _valuesToTry;
        private readonly Func<int, IEnumerable<int>> _divisorCalculator;
        private IEnumerable<int> _divisors;

        public string Result { get; private set; }

        private DivisorSum(int amount, Func<IEnumerable<int>> valuesGenerator, Func<int, IEnumerable<int>> divisorCalculator)
        {
            _amount = amount;
            _divisorCalculator = divisorCalculator;
            _valuesToTry = valuesGenerator();
            _equations = new List<string>();
            Calculate();
        }

        private void Calculate()
        {
            foreach (var possibleValue in _valuesToTry)
            {
                CalculateDivisorsFor(possibleValue);
                AddEquationIfPossibleValueFulfillsCondition(possibleValue);

                if (FinishedObtainingValues()) break;
            }

            GenerateResult();
        }

        private bool FinishedObtainingValues() => _equations.Count >= _amount;

        private void AddEquationIfPossibleValueFulfillsCondition(int possibleValue)
        {
            if (possibleValue == _divisors.Sum())
            {
                _equations.Add($"{string.Join(" + ", _divisors)} = {possibleValue}");
            }
        }

        private void CalculateDivisorsFor(int possibleValue) =>
            _divisors = _divisorCalculator(possibleValue);

        private void GenerateResult() => Result = string.Join("\n", _equations);
    }
}