using System;
using Xunit;
using Day7.Logic;
using static Day7.UnitTests.Constants;

namespace Day7.UnitTests
{
    public class SubmarineAlignmentMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SubmarineAlignment(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }

        [Theory]
        [InlineData("3")]
        [InlineData("7")]
        public void ReturnZero_WhenThereIsOnlyOneElementInInput(string position)
        {
            var sut = new SubmarineAlignment(position);
            Assert.Equal(0, sut.MinimumFuelConsumption);
        }

        [Theory]
        [InlineData("3,3")]
        [InlineData("4,4")]
        public void ReturnZero_WhenAllElementsInInputAreAligned(string positions)
        {
            var sut = new SubmarineAlignment(positions);
            Assert.Equal(0, sut.MinimumFuelConsumption);
        }

        [Theory]
        [InlineData("3,5", 2)]
        [InlineData("3, 8", 5)]
        [InlineData("3, 8, 2", 6)]
        [InlineData("4, 5, 9, 1", 9)]
        [InlineData(SAMPLE_POSITIONS, 37)]
        public void CalculateMinimumFuelConsumptionCorrectly(string positions, int expectedValue)
        {
            var sut = new SubmarineAlignment(positions);
            Assert.Equal(expectedValue, sut.MinimumFuelConsumption);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new SubmarineAlignment(REAL_POSITIONS);
            Assert.Equal(347011, sut.MinimumFuelConsumption);
        }

        [Fact]
        public void CalculateMinimumFuelConsumptionCorrectly_WhenConsumptionIsIncremental()
        {
            var sut = new SubmarineAlignment(SAMPLE_POSITIONS, true);
            Assert.Equal(168, sut.MinimumFuelConsumption);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new SubmarineAlignment(REAL_POSITIONS, true);
            Assert.Equal(98363777, sut.MinimumFuelConsumption);
        }
    }
}