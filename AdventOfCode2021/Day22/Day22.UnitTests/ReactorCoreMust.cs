using System;
using Day22.Logic;
using Xunit;

namespace Day22.UnitTests
{
    public class ReactorCoreMustst
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidSteps(string invalidSteps)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ReactorCore(invalidSteps));
            Assert.Equal("Invalid steps", exception.Message);
        }
    }
}
