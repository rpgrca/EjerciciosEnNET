using System;
using Day17.Logic;
using Xunit;

namespace Day17.UnitTests
{
    public class LauncherMust
    {
        private const string SAMPLE_TARGET_AREA = "target area: x=20..30, y=-10..-5";
        private const string REAL_TARGET_AREA = "target area: x=195..238, y=-93..-67";

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
        [InlineData(SAMPLE_TARGET_AREA, 20, -5, 30, -10)]
        [InlineData(REAL_TARGET_AREA, 195, -67, 238, -93)]
        public void BeInitializedCorrectly(string targetArea, int expectedMinimumX, int expectedMinimumY, int expectedMaximumX, int expectedMaximumY)
        {
            var sut = new Launcher(targetArea);
            Assert.Equal((expectedMaximumX, expectedMaximumY), sut.Maximum);
            Assert.Equal((expectedMinimumX, expectedMinimumY), sut.Minimum);
        }

        [Fact]
        public void AcceptInitialVelocity()
        {
            var sut = new Launcher(SAMPLE_TARGET_AREA);
            sut.InitialVelocity(7, 2);
            Assert.True(sut.IsProbePositionedAt(0, 0));
            Assert.True(sut.IsCurrentVelocityEqualTo(7, 2));
        }
    }
}