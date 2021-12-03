using System.Linq;
using System;
using System.Collections.Generic;

namespace Day3.Logic
{
    public class DiagnosticReport
    {
        private readonly List<string> _values;
        private int _gammaRate;
        private int _epsilonRate;
        private int[] _amountOfOnes;
        private int _oxygenRating;
        private int _co2Rating;

        public int PowerConsumption { get; private set; }
        public int LifeSupportRating { get; private set; }

        public DiagnosticReport(string reportInput)
        {
            if (string.IsNullOrWhiteSpace(reportInput))
            {
                throw new ArgumentException("Invalid report");
            }

            _values = reportInput.Split("\n").ToList();
        }

        public void PreparePowerConsumptionReport()
        {
            _amountOfOnes = new int[_values[0].Length];

            ClassifyValues();
            CalculateGammaAndEpsilonRates();
            CalculatePowerConsumption();
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
            PowerConsumption = _gammaRate * _epsilonRate;

        public void PrepareLifeSupportRating()
        {
            CalculateOxygenRating();
            CalculateCo2Rating();
            CalculateLifeSupport();
        }

        private void CalculateOxygenRating() =>
            _oxygenRating = Calculate((z, o) => z.Count > o.Count ? z : o);

        private int Calculate(Func<List<string>, List<string>, List<string>> nextSetCallback)
        {
            var currentSet = _values;

            for (var index = 0; index < _values[0].Length && currentSet.Count > 1; index++)
            {
                var zeroValues = new List<string>();
                var oneValues = new List<string>();

                currentSet.ForEach(v => (v[index] == '0' ? zeroValues : oneValues).Add(v));
                currentSet = nextSetCallback(zeroValues, oneValues);
            }

            return Convert.ToInt32(currentSet[0], 2);
        }

        private void CalculateCo2Rating() =>
            _co2Rating = Calculate((z, o) => z.Count > o.Count ? o : z);

        private void CalculateLifeSupport() =>
            LifeSupportRating = _oxygenRating * _co2Rating;
    }
}