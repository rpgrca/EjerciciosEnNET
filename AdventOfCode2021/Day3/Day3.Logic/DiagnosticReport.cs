using System.Linq;
using System;
using System.Collections.Generic;

namespace Day3.Logic
{
    public class DiagnosticReport
    {
        private readonly string _reportInput;
        private readonly List<string> _values;

        public int GammaRate { get; }
        public int EpsilonRate { get; }
        public int PowerConsumption { get; }
        public List<List<string>> FilteredValues { get; }

        public DiagnosticReport(string reportInput)
        {
            if (string.IsNullOrWhiteSpace(reportInput))
            {
                throw new ArgumentException("Invalid report");
            }

            _reportInput = reportInput;
            _values = _reportInput.Split("\n").ToList();

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

        public DiagnosticReport(string reportInput, bool useSecond)
        {
            _reportInput = reportInput;
            _values = _reportInput.Split("\n").ToList();
            FilteredValues = new List<List<string>>();

            List<string> currentSet = _values;

            for (var index = 0; index < 3; index++)
            {
                var zeroes = 0;
                var ones = 0;
                var teamZero = new List<string>();
                var teamOne = new List<string>();

                foreach (var value in currentSet)
                {
                    if (value[index] == '0')
                    {
                        zeroes++;
                        teamZero.Add(value);
                    }
                    else
                    {
                        ones++;
                        teamOne.Add(value);
                    }
                }

                if (zeroes > ones)
                {
                    currentSet = teamZero;
                    FilteredValues.Add(teamZero);
                }
                else if (zeroes < ones)
                {
                    currentSet = teamOne;
                    FilteredValues.Add(teamOne);
                }
            }
        }
    }
}