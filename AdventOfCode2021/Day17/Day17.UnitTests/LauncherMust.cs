using System;
using Xunit;
using Day17.Logic;

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

        [Theory]
        [InlineData(7, 2, 7)]
        [InlineData(6, 3, 9)]
        [InlineData(9, 0, 4)]
        [InlineData(17, -4, -1)]
        [InlineData(7, 9, 20)]
        public void FindWhetherProbeReachesTargetArea(int initialX, int initialY, int expectedSteps)
        {
            var launcher = new Launcher(SAMPLE_TARGET_AREA);
            var probe = new Probe(initialX, initialY);
            Assert.Equal(expectedSteps, launcher.CountStepsUntilHittingTargetArea(probe));
        }

        [Fact]
        public void FindHighestPointCorrectly()
        {
            var sut = new Launcher(SAMPLE_TARGET_AREA);
            sut.CalculateBestShoot();
            Assert.Equal(45, sut.HighestPointAbleToReach);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Launcher(REAL_TARGET_AREA);
            sut.CalculateBestShoot();
            Assert.Equal(4278, sut.HighestPointAbleToReach);
        }

        [Fact]
        public void FindAllValidInitialVelocities()
        {
            var sut = new Launcher(SAMPLE_TARGET_AREA);
            sut.CalculateAllShoots();
            Assert.Equal(112, sut.AmountOfShootsAbleToHitTargetArea);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Launcher(REAL_TARGET_AREA);
            sut.CalculateAllShoots();
            Assert.Equal(1994, sut.AmountOfShootsAbleToHitTargetArea);
        }
    }
}