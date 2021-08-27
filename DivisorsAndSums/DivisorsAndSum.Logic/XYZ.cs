using System.Linq;
using System.Collections.Generic;

namespace DivisorsAndSum.Logic
{
    public class XYZ
    {
        private readonly int _amount;

        public string Result { get; internal set; }

        public XYZ(int v)
        {
            _amount = v;
            Calculate();
        }

        private void Calculate()
        {
            var results = new List<string>();
            for (var possibleValue = 6; results.Count < _amount; possibleValue++)
            {
                var divisors = Enumerable
                    .Range(1, possibleValue - 1)
                    .Where(p => possibleValue % p == 0)
                    .ToList();

                if (possibleValue == divisors.Sum())
                {
                    var equation = string.Join(" + ", divisors);
                    results.Add(equation + $" = {possibleValue}");
                }
            }

            Result = string.Join("\n", results);
        }
    }
}
