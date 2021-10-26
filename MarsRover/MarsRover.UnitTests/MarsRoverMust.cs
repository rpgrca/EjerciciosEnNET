using System;
using Xunit;

namespace MarsRover.UnitTests
{
    public class MarsRoverMust
    {
        [Theory]
        [InlineData('N')]
        [InlineData('S')]
        [InlineData('W')]
        [InlineData('E')]
        public void ReturnSameDirectionAsInitialized(char expectedDirection)
        {
            var rover = new MarsRover(expectedDirection, 0, 0);
            var direction = rover.GetDirection();
            Assert.Equal(expectedDirection, direction);
        }

        [Theory]
        [InlineData('n')]
        [InlineData('z')]
        [InlineData(' ')]
        public void ThrowException_WhenInitializedWithInvalidDirection(char invalidDirection)
        {
            var exception = Assert.Throws<Exception>(() => new MarsRover(invalidDirection, 0, 0));
            Assert.Equal("Invalid command", exception.Message);
        }

        [Fact]
        public void AddTwoToY_WhenFacingNorthAndMovingForwardTwice()
        {
            var rover = new MarsRover('N', 0, 0);
            rover.SendCommand("F");

            rover.SendCommand("F");
            Assert.Equal(2, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Theory]
        [InlineData("F", 3)]
        [InlineData("FF", 4)]
        [InlineData("FFF", 5)]
        [InlineData("B", 1)]
        [InlineData("BB", 0)]
        public void UpdatePositionCorrectly_WhenMovingForwardOrBackward(string commands, int expectedY)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(expectedY, rover.GetY());
            Assert.Equal(2, rover.GetX());
        }

        [Theory]
        [InlineData("L", 'W')]
        [InlineData("LL", 'S')]
        [InlineData("LLL", 'E')]
        [InlineData("LLLL", 'N')]
        [InlineData("R", 'E')]
        [InlineData("RR", 'S')]
        [InlineData("RRR", 'W')]
        [InlineData("RRRR", 'N')]
        public void UpdateDirectionCorrectly_WhenRotatingLeftOrRight(string commands, char expectedDirection)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(expectedDirection, rover.GetDirection());
        }
    }
}