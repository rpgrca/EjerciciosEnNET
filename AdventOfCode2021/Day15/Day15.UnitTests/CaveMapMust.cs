using System;
using Xunit;
using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests
{
    public class CaveMapMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidMap(string map)
        {
            var exception = Assert.Throws<ArgumentException>(() => CaveMap.CreateWithOptimizedSearch(map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_MAP, 10)]
        [InlineData(REAL_MAP, 100)]
        public void ParseMapCorrectly(string map, int expectedWidth)
        {
            var sut = CaveMap.CreateWithOptimizedSearch(map);
            Assert.Equal(expectedWidth, sut.Width);
        }

        [Fact]
        public void FindLowestRiskPath_WhenUsingAsmallMap()
        {
            const string map = "1163\n1381\n2136\n3694";
            var sut = CaveMap.CreateWithOptimizedSearch(map);
            Assert.Equal(17, sut.GetPathLevel());
        }

        [Fact]
        public void FindLowestRiskPath_WhenUsingSampleMap()
        {
            var sut = CaveMap.CreateWithOptimizedSearch(SAMPLE_MAP);
            Assert.Equal(40, sut.GetPathLevel());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = CaveMap.CreateWithOptimizedSearch(REAL_MAP);
            Assert.True(sut.GetPathLevel() < 829);
            Assert.Equal(824, sut.GetPathLevel());
        }
    }
}