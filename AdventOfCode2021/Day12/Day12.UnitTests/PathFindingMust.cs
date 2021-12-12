using System;
using Day12.Logic;
using Xunit;
using static Day12.UnitTests.Constant;

namespace Day12.UnitTests
{
    public class PathFindingMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new PathFinding(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SMALL_SAMPLE_CAVE, 6, 1, 3)]
        [InlineData(MEDIUM_SAMPLE_CAVE, 7, 2, 3)]
        public void ParseMapCorrectly(string input, int expectedCaveCount, int expectedLargeCaveCount, int expectedSmallCaveCount)
        {
            var sut = new PathFinding(input);
            Assert.Equal(expectedCaveCount, sut.CaveCount);
            Assert.Equal(expectedLargeCaveCount, sut.LargeCaveCount);
            Assert.Equal(expectedSmallCaveCount, sut.SmallCaveCount);
        }

        [Fact]
        public void FindAllPathsCorrectly()
        {
            var sut = new PathFinding(SMALL_SAMPLE_CAVE);
            Assert.Equal(10, sut.Paths);
        }
    }
}
