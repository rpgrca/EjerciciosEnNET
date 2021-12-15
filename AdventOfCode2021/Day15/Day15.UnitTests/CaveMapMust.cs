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
            var exception = Assert.Throws<ArgumentException>(() => new CaveMap(map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_MAP, 10)]
        [InlineData(REAL_MAP, 100)]
        public void ParseMapCorrectly(string map, int expectedWidth)
        {
            var sut = new CaveMap(map);
            Assert.Equal(expectedWidth, sut.Width);
        }
    }
}
