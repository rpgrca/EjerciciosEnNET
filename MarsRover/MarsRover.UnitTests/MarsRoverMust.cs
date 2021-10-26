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

        [Theory]
        [InlineData("LF", 1)]
        [InlineData("LFF", 0)]
        [InlineData("LFFF", 9)]
        public void Test1(string commands, int expectedX)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(expectedX, rover.GetX());
            Assert.Equal(2, rover.GetY());
        }

        [Theory]
        [InlineData("LLF", 1)]
        [InlineData("LLFF", 0)]
        [InlineData("LLFFF", 9)]
        public void Test2(string commands, int expectedY)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(expectedY, rover.GetY());
            Assert.Equal(2, rover.GetX());
        }

        [Theory]
        [InlineData("LLLF", 3)]
        [InlineData("LLLFF", 4)]
        [InlineData("LLLFFF", 5)]
        public void Test3(string commands, int expectedX)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(2, rover.GetY());
            Assert.Equal(expectedX, rover.GetX());
        }

        [Theory]
        [InlineData("LB", 3)]
        [InlineData("LBB", 4)]
        [InlineData("LBBB", 5)]
        public void Test4(string commands, int expectedX)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(expectedX, rover.GetX());
            Assert.Equal(2, rover.GetY());
        }

        [Theory]
        [InlineData("LLB", 3)]
        [InlineData("LLBB", 4)]
        [InlineData("LLBBB", 5)]
        public void Test5(string commands, int expectedY)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(expectedY, rover.GetY());
            Assert.Equal(2, rover.GetX());
        }

        [Theory]
        [InlineData("LLLB", 1)]
        [InlineData("LLLBB", 0)]
        [InlineData("LLLBBB", 9)]
        [InlineData("RRRBBB", 5)]
        public void Test6(string commands, int expectedX)
        {
            var rover = new MarsRover('N', 2, 2);
            rover.SendCommand(commands);
            Assert.Equal(2, rover.GetY());
            Assert.Equal(expectedX, rover.GetX());
        }

        [Fact]
        public void Test7()
        {
            var rover = new MarsRover('N', 0, 0);
            rover.SendCommand("B");
            Assert.Equal(9, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test8()
        {
            var rover = new MarsRover('W', 9, 0);
            rover.SendCommand("B");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test9()
        {
            var rover = new MarsRover('E', 0, 0);
            rover.SendCommand("B");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(9, rover.GetX());
        }

        [Fact]
        public void Test10()
        {
            var rover = new MarsRover('S', 0, 9);
            rover.SendCommand("B");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test11()
        {
            var rover = new MarsRover('N', 0, 9);
            rover.SendCommand("F");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test12()
        {
            var rover = new MarsRover('W', 0, 0);
            rover.SendCommand("F");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(9, rover.GetX());
        }

        [Fact]
        public void Test13()
        {
            var rover = new MarsRover('E', 9, 0);
            rover.SendCommand("F");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test14()
        {
            var rover = new MarsRover('S', 0, 0);
            rover.SendCommand("F");
            Assert.Equal(9, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }
    }
}