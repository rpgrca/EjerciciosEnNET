using System.IO;
using Xunit;
using SquareAndSum.Logic;

namespace SquareAndSum.UnitTests
{
    public class SquareAndSumMust
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 2 }, 9)]
        [InlineData(new int[] { 1, 2 }, 5)]
        [InlineData(new int[] { 5, 3, 4 }, 50)]
        public void ReturnSumOfSquaredValues(int[] values, int expectedValue) =>
            Assert.Equal(expectedValue, new Logic.SquareAndSum(values).Value);
    }
}
