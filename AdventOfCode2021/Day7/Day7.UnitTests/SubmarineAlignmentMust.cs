using System;
using Xunit;
using Day7.Logic;

namespace Day7.UnitTests
{
    public class SubmarineAlignmentMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Test1(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SubmarineAlignment(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }
    }
}
