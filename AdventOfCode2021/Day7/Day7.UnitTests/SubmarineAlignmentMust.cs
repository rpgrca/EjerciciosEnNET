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

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        public void Test2(int position)
        {
            var sut = new SubmarineAlignment(position.ToString());
            Assert.Equal(position, sut.BestPosition);
        }
    }
}