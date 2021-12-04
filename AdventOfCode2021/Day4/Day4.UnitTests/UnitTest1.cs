using System;
using Xunit;
using Day4.Logic;

namespace Day4.UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Test1(string invalidBoards)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Bingo(invalidBoards));
            Assert.Equal("Invalid boards", exception.Message);
        }
    }
}
