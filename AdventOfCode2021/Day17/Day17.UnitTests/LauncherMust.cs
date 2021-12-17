using System;
using Day17.Logic;
using Xunit;

namespace Day17.UnitTests
{
    public class LauncherMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidInput(string invalidVelocity)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Launcher(invalidVelocity));
            Assert.Equal("Invalid velocity", exception.Message);
        }
    }
}