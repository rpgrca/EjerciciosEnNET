using System;
using Day20.Logic;
using Xunit;

namespace Day20.UnitTests
{
    public class ImageEnhancementMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Test1(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ImageEnhancement(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }
    }
}
