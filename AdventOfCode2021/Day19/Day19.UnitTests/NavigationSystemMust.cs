using System;
using Xunit;
using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests
{
    public class NavigationSystemMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new NavigationSystem(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Fact]
        public void CreateBeaconsAccordingToInputData()
        {
            var sut = new NavigationSystem(SAMPLE_COORDINATES);
            Assert.Equal(4, sut.Scanners.Count);
        }
    }
}