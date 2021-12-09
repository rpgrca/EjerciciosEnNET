using System;
using Xunit;
using Day9.Logic;

namespace Day9.UnitTests
{
    public class HeightMapMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new HeightMap(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }
    }
}
