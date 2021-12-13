using System;
using Day13.Logic;
using Xunit;

namespace Day13.UnitTests
{
    public class OrigamiMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidInstructions(string invalidInstructions)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Origami(invalidInstructions));
            Assert.Equal("Invalid instructions", exception.Message);
        }
    }
}
