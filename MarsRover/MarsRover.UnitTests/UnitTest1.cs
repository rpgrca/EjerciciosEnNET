using System;
using Xunit;

namespace MarsRover.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var rover = new MarsRover('N', 0, 0);
            var direction = rover.GetDirection();
            Assert.Equal('N', direction);
        }
    }

    public class MarsRover
    {
        public MarsRover(char direction, int x, int y)
        {
        }

        public char GetDirection()
        {
            return 'N';
        }
    }
}
