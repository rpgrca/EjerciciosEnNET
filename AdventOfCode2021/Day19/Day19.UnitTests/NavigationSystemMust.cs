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

        [Theory]
        [InlineData(SAMPLE_COORDINATES, 5)]
        [InlineData(REAL_COORDINATES, 26)]
        public void CreateBeaconsAccordingToInputData(string coordinates, int expectedScanners)
        {
            var sut = new NavigationSystem(coordinates);
            Assert.Equal(expectedScanners, sut.Scanners.Count);
        }
    }
}