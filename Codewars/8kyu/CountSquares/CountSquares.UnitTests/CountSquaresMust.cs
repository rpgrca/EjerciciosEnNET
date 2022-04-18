using Xunit;
using CountSquares.Logic;

namespace CountSquares.UnitTests
{
    public class CountSquaresMust
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 8)]
        [InlineData(2, 26)]
        [InlineData(4, 98)]
        [InlineData(5, 152)]
        [InlineData(16, 1538)]
        [InlineData(23, 3176)]
        public void ReturnCorrectCountOfSquaresWithPaint(int cuts, int expectedCount) =>
            Assert.Equal(expectedCount, Kata.CountSquares(cuts));
    }
}