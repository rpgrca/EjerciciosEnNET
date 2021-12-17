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
        [InlineData(SAMPLE_TARGET_AREA, 20, 30, -10, -5)]
        [InlineData(REAL_TARGET_AREA, 195, 238, -93, -67)]
        public void BeInitializedCorrectly(string targetArea, int expectedMinimumX, int expectedMaximumX, int expectedMinimumY, int expectedMaximumY)
        {
            var sut = new Launcher(targetArea);
            Assert.Equal((expectedMinimumX, expectedMaximumX), sut.RangeX);
            Assert.Equal((expectedMinimumY, expectedMaximumY), sut.RangeY);
        }

        [Fact]
        public void AcceptInitialVelocity()
        {
            var sut = new Launcher(SAMPLE_TARGET_AREA);
            sut.InitialVelocity(7, 2);
            Assert.True(sut.IsProbePositionedAt(0, 0));
            Assert.True(sut.IsCurrentVelocityEqualTo(7, 2));
        }

        [Theory]
        [InlineData(7, 2, 1, 7, 2, 6, 1)]
        [InlineData(7, 2, 2, 13, 3, 5, 0)]
        [InlineData(7, 2, 3, 18, 3, 4, -1)]
        [InlineData(7, 2, 4, 22, 2, 3, -2)]
        [InlineData(7, 2, 5, 25, 0, 2, -3)]
        [InlineData(7, 2, 6, 27, -3, 1, -4)]
        [InlineData(7, 2, 7, 28, -7, 0, -5)]
        [InlineData(6, 3, 1, 6, 3, 5, 2)]
        [InlineData(6, 3, 2, 11, 5, 4, 1)]
        [InlineData(6, 3, 3, 15, 6, 3, 0)]
        [InlineData(6, 3, 4, 18, 6, 2, -1)]
        [InlineData(6, 3, 5, 20, 5, 1, -2)]
        [InlineData(6, 3, 6, 21, 3, 0, -3)]
        [InlineData(6, 3, 7, 21, 0, 0, -4)]
        [InlineData(6, 3, 8, 21, -4, 0, -5)]
        [InlineData(6, 3, 9, 21, -9, 0, -6)]
        [InlineData(9, 0, 1, 9, 0, 8, -1)]
        [InlineData(9, 0, 2, 17, -1, 7, -2)]
        [InlineData(9, 0, 3, 24, -3, 6, -3)]
        [InlineData(9, 0, 4, 30, -6, 5, -4)]
        [InlineData(17, -4, 1, 17, -4, 16, -5)]
        [InlineData(17, -4, 2, 33, -9, 15, -6)]
        [InlineData(17, -4, 3, 48, -15, 14, -7)]
        [InlineData(17, -4, 4, 62, -22, 13, -8)]
        public void ExecuteStepCorrectly(int initialX, int initialY, int steps, int expectedPositionX, int expectedPositionY,
            int expectedVelocityX, int expectedVelocityY)
        {
            var sut = new Launcher(SAMPLE_TARGET_AREA);
            sut.InitialVelocity(initialX, initialY);
            sut.Step(steps);
            Assert.True(sut.IsProbePositionedAt(expectedPositionX, expectedPositionY));
            Assert.True(sut.IsCurrentVelocityEqualTo(expectedVelocityX, expectedVelocityY));
        }

        [Theory]
        [InlineData(7, 2, 7)]
        [InlineData(6, 3, 9)]
        [InlineData(9, 0, 4)]
        [InlineData(17, -4, -1)]
        public void FindWhetherProbeReachesTargetArea(int initialX, int initialY, int expectedSteps)
        {
            var sut = new Launcher(SAMPLE_TARGET_AREA);
            sut.InitialVelocity(initialX, initialY);
            Assert.Equal(expectedSteps, sut.CountStepsUntilHittingTargetArea());
        }
    }
}