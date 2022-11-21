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
            var exception = Assert.Throws<ArgumentException>(() => CaveMap.CreateWithBigMapperAndOptimizedSearch(map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Fact]
        public void CalculateFullMapCorrectly()
        {
            var sut = CaveMap.CreateWithBigMapperAndOptimizedSearch(SAMPLE_MAP);
            Assert.Equal(50, sut.Width);
            Assert.Equal(50, sut.Height);
        }

        [Fact]
        public void SolveSecondExample()
        {
            var sut = CaveMap.CreateWithBigMapperAndOptimizedSearch(SAMPLE_MAP);
            Assert.Equal(315, sut.GetPathLevel());
        }

#if !CI_CONTEXT
        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = CaveMap.CreateWithBigMapperAndOptimizedSearch(REAL_MAP);
            Assert.Equal(3063, sut.GetPathLevel());
        }
#endif
    }
}