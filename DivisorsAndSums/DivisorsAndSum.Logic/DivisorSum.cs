using System;
using System.Linq;
using System.Collections.Generic;

namespace DivisorsAndSum.Logic
{
    public class DivisorSum
    {
        private readonly int _amount;
        private readonly List<string> _equations;
        private IEnumerable<int> _divisors;

        public string Result { get; private set; }

        public DivisorSum(int amount)
        {
            _amount = amount;
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
            _divisors = Enumerable
                .Range(1, possibleValue / 2)
                .Where(p => possibleValue % p == 0);

        private void GenerateResult() => Result = string.Join("\n", _equations);
    }
}