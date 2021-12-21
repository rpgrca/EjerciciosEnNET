using Xunit;
using Day17.Logic;

namespace Day17.UnitTests
{
    public class ProbeMust
    {
        [Fact]
        public void AcceptInitialVelocity()
        {
            var probe = new Probe(7, 2);
            Assert.True(probe.IsPositionedAt(0, 0));
            Assert.True(probe.IsCurrentVelocityEqualTo(7, 2));
        }

        [Fact]
        public void CheckPositionCorrectly()
        {
            var probe = new Probe(7, 2);
            Assert.False(probe.IsPositionedAt(0, 1));
            Assert.False(probe.IsPositionedAt(1, 0));
        }

        [Fact]
        public void CheckVelocityCorrectly()
        {
            var probe = new Probe(7, 2);
            Assert.False(probe.IsCurrentVelocityEqualTo(7, 1));
            Assert.False(probe.IsCurrentVelocityEqualTo(6, 2));
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
        [InlineData(7, 9, 1, 7, 9, 6, 8)]
        [InlineData(7, 9, 2, 13, 17, 5, 7)]
        [InlineData(7, 9, 3, 18, 24, 4, 6)]
        [InlineData(7, 9, 4, 22, 30, 3, 5)]
        [InlineData(7, 9, 5, 25, 35, 2, 4)]
        [InlineData(7, 9, 6, 27, 39, 1, 3)]
        [InlineData(7, 9, 7, 28, 42, 0, 2)]
        [InlineData(7, 9, 8, 28, 44, 0, 1)]
        [InlineData(7, 9, 9, 28, 45, 0, 0)]
        [InlineData(7, 9, 10, 28, 45, 0, -1)]
        [InlineData(7, 9, 11, 28, 44, 0, -2)]
        [InlineData(7, 9, 12, 28, 42, 0, -3)]
        [InlineData(7, 9, 13, 28, 39, 0, -4)]
        [InlineData(7, 9, 14, 28, 35, 0, -5)]
        [InlineData(7, 9, 15, 28, 30, 0, -6)]
        [InlineData(7, 9, 16, 28, 24, 0, -7)]
        [InlineData(7, 9, 17, 28, 17, 0, -8)]
        [InlineData(7, 9, 18, 28, 9, 0, -9)]
        [InlineData(7, 9, 19, 28, 0, 0, -10)]
        [InlineData(7, 9, 20, 28, -10, 0, -11)]
        [InlineData(-2, 3, 1, -2, 3, -1, 2)]
        [InlineData(-2, 3, 2, -3, 5, 0, 1)]
        [InlineData(-2, 3, 3, -3, 6, 0, 0)]
        public void ExecuteStepCorrectly(int initialX, int initialY, int steps, int expectedPositionX, int expectedPositionY,
            int expectedVelocityX, int expectedVelocityY)
        {
            var sut = new Probe(initialX, initialY);
            sut.Step(steps);
            Assert.True(sut.IsPositionedAt(expectedPositionX, expectedPositionY));
            Assert.True(sut.IsCurrentVelocityEqualTo(expectedVelocityX, expectedVelocityY));
        }
    }
}