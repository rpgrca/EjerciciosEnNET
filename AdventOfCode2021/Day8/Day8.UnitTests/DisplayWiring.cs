using System;
using Xunit;
using Day8.Logic;

namespace Day8.UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Test1(string invalidWiring)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DisplayWiring(invalidWiring));
            Assert.Equal("Invalid wiring", exception.Message);
        }
    }
}
