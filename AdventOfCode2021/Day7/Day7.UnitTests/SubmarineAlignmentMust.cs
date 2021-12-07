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
        [InlineData(3)]
        [InlineData(7)]
        public void Test2(int position)
        {
            var sut = new SubmarineAlignment(position.ToString());
            Assert.Equal(0, sut.MinimumFuelConsumption);
        }

        [Theory]
        [InlineData("3,3")]
        [InlineData("4,4")]
        public void Test3(string positions)
        {
            var sut = new SubmarineAlignment(positions);
            Assert.Equal(0, sut.MinimumFuelConsumption);
        }

        [Theory]
        [InlineData("3,5", 2)]
        [InlineData("3, 8", 5)]
        [InlineData("3, 8, 2", 6)]
        [InlineData("4, 5, 9, 1", 9)]
        public void Test4(string positions, int expectedValue)
        {
            var sut = new SubmarineAlignment(positions);
            Assert.Equal(expectedValue, sut.MinimumFuelConsumption);
        }

        [Fact]
        public void Test5()
        {
            var sut = new SubmarineAlignment(SAMPLE_POSITIONS);
            Assert.Equal(37, sut.MinimumFuelConsumption);
        }

        [Fact]
        public void Test6()
        {
            var sut = new SubmarineAlignment(REAL_POSITIONS);
            Assert.Equal(347011, sut.MinimumFuelConsumption);
        }

        [Fact]
        public void Test7()
        {
            var sut = new SubmarineAlignment(SAMPLE_POSITIONS, true);
            Assert.Equal(168, sut.MinimumFuelConsumption);
        }
    }
}