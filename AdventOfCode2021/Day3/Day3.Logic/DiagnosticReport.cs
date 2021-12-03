using System;
using System.Collections.Generic;

namespace Day3.Logic
{
    public class DiagnosticReport
    {
        private readonly string _reportInput;
        private readonly string[] _values;

        public int GammaRate { get; }
        public int EpsilonRate { get; }
        public int PowerConsumption { get; }

        public DiagnosticReport(string reportInput)
        {
            if (string.IsNullOrWhiteSpace(reportInput))
            {
                throw new ArgumentException("Invalid report");
            }

            _reportInput = reportInput;
            _values = _reportInput.Split("\n");

            var gammaValue = string.Empty;
            var epsilonValue = string.Empty;
            for (var index = 0; index < _values[0].Length; index++)
            {
                var zeroes = 0;
                var ones = 0;

                foreach (var value in _values)
                {
                    if (value[_values[0].Length - 1 - index] == '0')
                    {
                        zeroes++;
                    }
                    else
                    {
                        ones++;
                    }
                }

                if (zeroes > ones)
                {
                    gammaValue = "0" + gammaValue;
                    epsilonValue = "1" + epsilonValue;
                }
                else if (zeroes < ones)
                {
                    gammaValue = "1" + gammaValue;
                    epsilonValue = "0" + epsilonValue;
                }
            }

            GammaRate = Convert.ToInt32(gammaValue, 2);
            EpsilonRate = Convert.ToInt32(epsilonValue, 2);
            PowerConsumption = GammaRate * EpsilonRate;
        }
    }
}