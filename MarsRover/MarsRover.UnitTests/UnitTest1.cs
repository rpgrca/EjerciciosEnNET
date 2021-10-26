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
    }

    public class MarsRover
    {
        private readonly char _direction;

        public MarsRover(char direction, int x, int y)
        {
            if (direction == 'N' || direction == 'S' || direction == 'E' || direction == 'W')
            {
                _direction = direction;
            }
            else
            {
                throw new Exception("Invalid command");
            }
        }

        public char GetDirection()
        {
            return _direction;
        }
    }
}
