using System;
using Xunit;
using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests
{
    public class FullCaveMapMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidMap(string map)
        {
            var exception = Assert.Throws<ArgumentException>(() => new FullCaveMap(map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Fact]
        public void CalculateFullMapCorrectly()
        {
            var sut = new FullCaveMap(SAMPLE_MAP);
            Assert.Equal(50, sut.Width);
        }

        [Fact]
        public void VerifyHorizontalCorrectness()
        {
            var sut = new FullCaveMap(SAMPLE_MAP);
            Assert.Equal("11637517422274862853338597396444961841755517295286", sut.GetHorizontalLine(0));
            Assert.Equal("67554889357866599146897761125791887223681299833479", sut.GetHorizontalLine(49));
        }

        [Fact]
        public void VerifyVerticalCorrectness()
        {
            var sut = new FullCaveMap(SAMPLE_MAP);
            Assert.Equal("11237113122234822423334593353444561446455567255756", sut.GetVerticalLine(0));
            Assert.Equal("66345254557745636566885674767799678587881178969899", sut.GetVerticalLine(49));
        }

        [Fact]
        public void Test1()
        {
            var sut = new FullCaveMap(SAMPLE_MAP);
            Assert.Equal(315, sut.GetPathLevel());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new FullCaveMap(REAL_MAP);
            Assert.Equal(3063, sut.GetPathLevel());
        }
    }
}