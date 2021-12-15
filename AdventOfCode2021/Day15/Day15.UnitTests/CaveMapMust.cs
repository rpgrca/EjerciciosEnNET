using System;
using Xunit;
using Day15.Logic;

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
    }
}
