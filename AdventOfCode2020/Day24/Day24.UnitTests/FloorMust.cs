using Xunit;
using AdventOfCode2020.Day24.Logic;

namespace AdventOfCode2020.Day24.UnitTests
{
    public class FloorMust
    {
        [Fact]
        public void CountBlackTilesCorrectly()
        {
            const string data = PuzzleData.SAMPLE_DATA;

            var sut = new Floor(data);
            Assert.Equal(10, sut.CountBlackTiles());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Floor(PuzzleData.PUZZLE_DATA);
            Assert.Equal(473, sut.CountBlackTiles());
        }

        [Theory]
        [InlineData(1, 15)]
        [InlineData(2, 12)]
        [InlineData(3, 25)]
        [InlineData(4, 14)]
        [InlineData(5, 23)]
        [InlineData(6, 28)]
        [InlineData(7, 41)]
        [InlineData(8, 37)]
        [InlineData(9, 49)]
        [InlineData(10, 37)]
        [InlineData(20, 132)]
        [InlineData(30, 259)]
        [InlineData(40, 406)]
        [InlineData(50, 566)]
        [InlineData(60, 788)]
        [InlineData(70, 1106)]
        [InlineData(80, 1373)]
        [InlineData(90, 1844)]
        [InlineData(100, 2208)]
        public void CountBlackTilesCorrectly_WhenFlippingADeterminedAmountOfTimes(int flips, int expectedBlackTilesCount)
        {
            const string data = PuzzleData.SAMPLE_DATA;

            var sut = new Floor(data);
            sut.Flips(flips);
            Assert.Equal(expectedBlackTilesCount, sut.CountBlackTiles());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Floor(PuzzleData.PUZZLE_DATA);
            sut.Flips(100);
            Assert.Equal(4070, sut.CountBlackTiles());
        }
    }
}