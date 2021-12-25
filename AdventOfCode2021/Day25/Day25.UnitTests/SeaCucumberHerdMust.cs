using System;
using Xunit;
using Day25.Logic;

namespace Day25.UnitTests
{
    public class SeaCucumberHerdMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidSeafloor(string invalidSeafloor)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SeaCucumberHerd(invalidSeafloor));
            Assert.Equal("Invalid seafloor", exception.Message);
        }
    }
}
