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
        public void ThrowException_WhenInitializedWithInvalidInput(string invalidTargetArea)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Launcher(invalidTargetArea));
            Assert.Equal("Invalid target area", exception.Message);
        }

        [Theory]
        [InlineData("target area: x=20..30, y=-10..-5", 20, -5, 30, -10)]
        public void BeInitializedCorrectly(string targetArea, int expectedMinimumX, int expectedMinimumY, int expectedMaximumX, int expectedMaximumY)
        {
            var sut = new Launcher(targetArea);
            Assert.Equal((expectedMaximumX, expectedMaximumY), sut.Maximum);
            Assert.Equal((expectedMinimumX, expectedMinimumY), sut.Minimum);
        }
    }
}