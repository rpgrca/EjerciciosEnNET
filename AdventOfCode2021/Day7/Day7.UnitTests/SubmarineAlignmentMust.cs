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
        public void ThrowException_WhenInitializedWithInvalidData(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SubmarineAlignment(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }

        [Fact]
        public void Test2()
        {
            var sut = new SubmarineAlignment("3");
            Assert.Equal(3, sut.BestPosition);
        }
    }
}
