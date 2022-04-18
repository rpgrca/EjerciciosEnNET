using System.Linq;

namespace SquareAndSum.Logic
{
    public class SquareAndSum
    {
        private int[] _values;
        private int _sumOfSquaredValues;

        public SquareAndSum(int[] values)
        {
            _values = values;

            CalculateSquareValues();
            SumSquaredValues();
        }

        private void CalculateSquareValues() =>
            _values = _values.Select(v => v * v).ToArray();

        private void SumSquaredValues() =>
            _sumOfSquaredValues = _values.Sum();

        public int Value => _sumOfSquaredValues;
    }
}