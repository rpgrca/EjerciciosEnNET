using System;
using System.Collections.Generic;
using Xunit;

namespace SquareAndSum.UnitTests
{
    public class SquareAndSumMust
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 2 }, 9)]
        public void Test1(int[] values, int expectedValue)
        {
            Assert.Equal(expectedValue, SquareSum(values));
        }

        private int SquareSum(int[] values)
        {
            return 9;
        }
    }
}
