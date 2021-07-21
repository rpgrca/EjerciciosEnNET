using System;
using System.Linq;

namespace SquareAndSum.Logic
{
    public class SquareAndSum
    {
        public int SquareSum(int[] values) => values.Sum(p => p * p);
    }
}
