using System.Linq;
using System;
using System.Collections.Generic;

namespace Day3.Logic
{
    public class DiagnosticReport
    {
        private readonly List<string> _values;

        public int PowerConsumption { get; private set; }
        public List<List<string>> FilteredValues { get; }
        public int OxygenRating { get; }
        public int Co2Rating { get; }
        public int LifeSupportRating { get; }

        public DiagnosticReport(string reportInput)
        {
            if (string.IsNullOrWhiteSpace(reportInput))
            {
                throw new ArgumentException("Invalid report");
            }

            _values = reportInput.Split("\n").ToList();

            var gammaValue = string.Empty;
            var epsilonValue = string.Empty;
            for (var index = _values[0].Length - 1; index >= 0; index--)
            {
                var ones = 0;

                foreach (var value in _values)
                {
                    ones += value[index] - '0';
                }

                if (_values.Count - ones > ones)
                {
                    gammaValue = "0" + gammaValue;
                    epsilonValue = "1" + epsilonValue;
                }
                else
                {
                    gammaValue = "1" + gammaValue;
                    epsilonValue = "0" + epsilonValue;
                }
            }

            CalculatePowerConsumption(gammaValue, epsilonValue);
        }

        private void CalculatePowerConsumption(string gammaValue, string epsilonValue)
        {
            var gammaRate = Convert.ToInt32(gammaValue, 2);
            var epsilonRate = Convert.ToInt32(epsilonValue, 2);
            PowerConsumption = gammaRate * epsilonRate;
        }

        public DiagnosticReport(string reportInput, bool useSecond)
        {
            _values = reportInput.Split("\n").ToList();

            FilteredValues = new List<List<string>>();

            List<string> currentSet = _values;

            for (var index = 0; index < _values[0].Length; index++)
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
                else
                {
                    currentSet = teamOne;
                    FilteredValues.Add(teamOne);
                }

                if (currentSet.Count == 1)
                {
                    OxygenRating = Convert.ToInt32(currentSet[0], 2);
                    break;
                }
            }

            currentSet = _values;

            for (var index = 0; index < _values[0].Length; index++)
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

                if (ones > zeroes)
                {
                    currentSet = teamZero;
                }
                else if (ones < zeroes)
                {
                    currentSet = teamOne;
                }
                else
                {
                    currentSet = teamZero;
                }

                if (currentSet.Count == 1)
                {
                    Co2Rating = Convert.ToInt32(currentSet[0], 2);
                    break;
                }
            }

            LifeSupportRating = OxygenRating * Co2Rating;
        }
    }
}