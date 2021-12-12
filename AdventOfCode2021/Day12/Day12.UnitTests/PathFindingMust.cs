using System;
using Day12.Logic;
using Xunit;

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
            var exception = Assert.Throws<ArgumentException>(() => new PathFinding(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }
    }
}
