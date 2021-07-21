using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SquareAndSum.UnitTests
{
    public class SquareAndSumMust
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 2 }, 9)]
        [InlineData(new int[] { 1, 2 }, 5)]
        public void Test1(int[] values, int expectedValue)
        {
            Assert.Equal(expectedValue, SquareSum(values));
        }

        private int SquareSum(int[] values) => values.Sum(p => p * p);
    }
}
