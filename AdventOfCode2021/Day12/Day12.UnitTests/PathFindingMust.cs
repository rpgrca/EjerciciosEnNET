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
            var exception = Assert.Throws<ArgumentException>(() => PathFinding.CreateWithoutRepetition(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SMALL_SAMPLE_CAVE, 6, 1, 3)]
        [InlineData(MEDIUM_SAMPLE_CAVE, 7, 2, 3)]
        public void ParseMapCorrectly(string input, int expectedCaveCount, int expectedLargeCaveCount, int expectedSmallCaveCount)
        {
            var sut = PathFinding.CreateWithoutRepetition(input);
            Assert.True(sut.HasExactlyCaves(expectedCaveCount));
            Assert.True(sut.HasExactlyLargeCaves(expectedLargeCaveCount));
            Assert.True(sut.HasExactlySmallCaves(expectedSmallCaveCount));
        }

        [Theory]
        [InlineData(SMALL_SAMPLE_CAVE, 10)]
        [InlineData(MEDIUM_SAMPLE_CAVE, 19)]
        [InlineData(LARGE_SAMPLE_CAVE, 226)]
        public void FindAllPathsCorrectly(string map, int expectedPaths)
        {
            var sut = PathFinding.CreateWithoutRepetition(map);
            Assert.Equal(expectedPaths, sut.Paths);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = PathFinding.CreateWithoutRepetition(REAL_CAVE);
            Assert.Equal(5157, sut.Paths);
        }

        [Theory]
        [InlineData(SMALL_SAMPLE_CAVE, 36)]
        [InlineData(MEDIUM_SAMPLE_CAVE, 103)]
        [InlineData(LARGE_SAMPLE_CAVE, 3509)]
        public void FindAllPathsCorrectly_WhenOneSmallCaveCanBeVisitedTwice(string map, int expectedPaths)
        {
            var sut = PathFinding.CreateWithAtMostOneRepetion(map);
            Assert.Equal(expectedPaths, sut.Paths);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = PathFinding.CreateWithAtMostOneRepetion(REAL_CAVE);
            Assert.Equal(144309, sut.Paths);
        }
    }
}