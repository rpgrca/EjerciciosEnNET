using System.Collections.Generic;

namespace Day3.Logic
{
    public class PowerConsumption : Report
    {
        private List<string> _values;
        private int[] _amountOfOnes;
        private int _gammaRate;
        private int _epsilonRate;

        public override Report With(List<string> values)
        {
            _values = values;
            _amountOfOnes = new int[_values[0].Length];

            ClassifyValues();
            CalculateGammaAndEpsilonRates();
            CalculatePowerConsumption();

            return this;
        }

        private void ClassifyValues() =>
            _values.ForEach(v => {
                var index = 0;

                foreach (var character in v)
                {
                    _amountOfOnes[index++] += character - '0';
                }
            });

        private void CalculateGammaAndEpsilonRates()
        {
            foreach (var value in _amountOfOnes)
            {
                var bit = _values.Count > value * 2 ? 1 : 0;

                _gammaRate = (_gammaRate << 1) | (~bit & 1);
                _epsilonRate = (_epsilonRate << 1) | (bit & 1);
            }
        }

        private void CalculatePowerConsumption() =>
            Value = _gammaRate * _epsilonRate;
    }
}