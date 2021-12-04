using System;
using Xunit;
using Day2.Logic;
using static Day2.UnitTests.Constants;

namespace Day2.UnitTests
{
    public class SubmarineMust
    {
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void ThrowException_WhenCourseIsInvalid(string invalidCourse)
        {
            var exception = Assert.Throws<ArgumentException>(() => Submarine.CreateSimpleSubmarineFor(invalidCourse));
            Assert.Equal("Invalid course", exception.Message);
        }

        [Fact]
        public void BeInitializedCorrectly_WhenUsingSimpleMode()
        {
            var sut = Submarine.CreateSimpleSubmarineFor("up 0");
            Assert.Equal(0, sut.Multiplier);
        }

        [Theory]
        [InlineData("forward 5\ndown 1", 5)]
        [InlineData("forward 5\ndown 1\nforward 8", 13)]
        [InlineData("forward 5\ndown 1\nforward 8\nforward 2", 15)]
        public void CalculateHorizontalPositionCorrectly_WhenUsingSimpleMode(string course, int expectedMultiplier)
        {
            var sut = Submarine.CreateSimpleSubmarineFor(course);
            Assert.Equal(expectedMultiplier, sut.Multiplier);
        }

        [Theory]
        [InlineData("forward 1\ndown 5", 5)]
        [InlineData("forward 1\ndown 5\nforward 0\nup 3", 2)]
        public void CalculateDepthCorrectly_WhenUsingSimpleMode(string course, int expectedMultiplier)
        {
            var sut = Submarine.CreateSimpleSubmarineFor(course);
            Assert.Equal(expectedMultiplier, sut.Multiplier);
        }

        [Fact]
        public void SolveFirstSample_WhenUsingSimpleMode()
        {
            var sut = Submarine.CreateSimpleSubmarineFor(SAMPLE_COURSE);
            Assert.Equal(150, sut.Multiplier);
        }

        [Fact]
        public void SolveFirstPuzzle_WhenUsingSimpleMode()
        {
            var sut = Submarine.CreateSimpleSubmarineFor(REAL_COURSE);
            Assert.Equal(1692075, sut.Multiplier);
        }

        [Fact]
        public void BeInitializedCorrectly_WhenUsingComplexMode()
        {
            var sut = Submarine.CreateComplexSubmarineFor("up 0");
            Assert.Equal(0, sut.Multiplier);
        }

        [Theory]
        [InlineData("forward 5\ndown 1\nforward 1", 6 * 1)]
        [InlineData("forward 5\ndown 1\nforward 1\nforward 8", 14 * (1 + 8))]
        [InlineData("forward 5\ndown 1\nforward 1\nforward 8\nforward 2", 16 * ( 1 + 8 + 2))]
        public void CalculateHorizontalPositionCorreclty_WhenUsingComplexMode(string course, int expectedMultiplier)
        {
            var sut = Submarine.CreateComplexSubmarineFor(course);
            Assert.Equal(expectedMultiplier, sut.Multiplier);
        }

        [Fact]
        public void SolveSecondSample_WhenUsingComplexMode()
        {
            var sut = Submarine.CreateComplexSubmarineFor(SAMPLE_COURSE);
            Assert.Equal(900, sut.Multiplier);
        }

        [Fact]
        public void SolveSecondPuzzle_WhenUsingComplexMode()
        {
            var sut = Submarine.CreateComplexSubmarineFor(REAL_COURSE);
            Assert.Equal(1749524700, sut.Multiplier);
        }
    }
}