using System;
using Xunit;
using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests
{
    public class ImageEnhancementMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ImageEnhancement(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_INPUT, 5, 5)]
        [InlineData(REAL_INPUT, 100, 100)]
        public void BeInitializedCorrectly(string input, int expectedWidth, int expectedHeight)
        {
            var sut = new ImageEnhancement(input);
            Assert.Equal(512, sut.Algorithm.Length);
            Assert.Equal(expectedWidth, sut.ImageWidth);
            Assert.Equal(expectedHeight, sut.ImageHeight);
        }
    }
}
