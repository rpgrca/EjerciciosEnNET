using System;
using System.Collections.Generic;

namespace Day3.Logic
{
    public class LifeSupport : Report
    {
        private List<string> _values;
        private int _oxygenRating;
        private int _co2Rating;

        public override Report With(List<string> values)
        {
            _values = values;

            CalculateOxygenRating();
            CalculateCo2Rating();
            CalculateLifeSupport();

            return this;
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
            Value = _oxygenRating * _co2Rating;
    }
}