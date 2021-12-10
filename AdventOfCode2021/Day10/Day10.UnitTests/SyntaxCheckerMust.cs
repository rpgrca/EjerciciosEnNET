using System;
using Xunit;
using Day10.Logic;

namespace Day10.UnitTests
{
    public class SyntaxCheckerMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Test1(string invalidCode)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SyntaxChecker(invalidCode));
            Assert.Equal("Invalid code", exception.Message);
        }
    }
}
