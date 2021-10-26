using System;
using Xunit;

namespace MarsRover.UnitTests
{
    public class MarsRoverMust
    {
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(15, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 15)]
        public void Test0(int x, int y)
        {
            var exception = Assert.Throws<Exception>(() => new MarsRover('N', x, y, GetEmptyMap()));
            Assert.Equal("Invalid coordinate", exception.Message);
        }

        [Fact]
        public void Test01()
        {
            var exception = Assert.Throws<Exception>(() => new MarsRover('N', 0, 0, null));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Fact]
        public void Test02()
        {
            var map = new[,]
            {
                { 0, 0 },
                { 0, 0 }
            };
            var exception = Assert.Throws<Exception>(() => new MarsRover('N', 0, 0, map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Fact]
        public void Test03()
        {
            var map = new[,]
            {
                { 0, 0 },
                { 0, 0 },
                { 0, 0 },
                { 0, 0 },
                { 0, 0 },
                { 0, 0 },
                { 0, 0 },
                { 0, 0 },
                { 0, 0 },
                { 0, 0 }
            };
            var exception = Assert.Throws<Exception>(() => new MarsRover('N', 0, 0, map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Theory]
        [InlineData('N')]
        [InlineData('S')]
        [InlineData('W')]
        [InlineData('E')]
        public void ReturnSameDirectionAsInitialized(char expectedDirection)
        {
            var rover = new MarsRover(expectedDirection, 0, 0, GetEmptyMap());
            var direction = rover.GetDirection();
            Assert.Equal(expectedDirection, direction);
        }

        [Theory]
        [InlineData('n')]
        [InlineData('z')]
        [InlineData(' ')]
        public void ThrowException_WhenInitializedWithInvalidDirection(char invalidDirection)
        {
            var exception = Assert.Throws<Exception>(() => new MarsRover(invalidDirection, 0, 0, null));
            Assert.Equal("Invalid command", exception.Message);
        }

        [Fact]
        public void AddTwoToY_WhenFacingNorthAndMovingForwardTwice()
        {
            var rover = GetRover();
            rover.SendCommand("F");

            rover.SendCommand("F");
            Assert.Equal(4, rover.GetY());
            Assert.Equal(2, rover.GetX());
        }

        private static MarsRover GetRover() => new MarsRover('N', 2, 2, GetEmptyMap());

        private static int[,] GetEmptyMap() => new[,] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

        [Theory]
        [InlineData("F", 3)]
        [InlineData("FF", 4)]
        [InlineData("FFF", 5)]
        [InlineData("B", 1)]
        [InlineData("BB", 0)]
        public void UpdatePositionCorrectly_WhenMovingForwardOrBackward(string commands, int expectedY)
        {
            var rover = GetRover();
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
            var rover = GetRover();
            rover.SendCommand(commands);
            Assert.Equal(expectedDirection, rover.GetDirection());
        }

        [Theory]
        [InlineData("LF", 1)]
        [InlineData("LFF", 0)]
        [InlineData("LFFF", 9)]
        public void Test1(string commands, int expectedX)
        {
            var rover = GetRover();
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
            var rover = GetRover();
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
            var rover = GetRover();
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
            var rover = GetRover();
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
            var rover = GetRover();
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
            var rover = GetRover();
            rover.SendCommand(commands);
            Assert.Equal(2, rover.GetY());
            Assert.Equal(expectedX, rover.GetX());
        }

        [Fact]
        public void Test7()
        {
            var rover = new MarsRover('N', 0, 0, GetEmptyMap());
            rover.SendCommand("B");
            Assert.Equal(9, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test8()
        {
            var rover = new MarsRover('W', 9, 0, GetEmptyMap());
            rover.SendCommand("B");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test9()
        {
            var rover = new MarsRover('E', 0, 0, GetEmptyMap());
            rover.SendCommand("B");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(9, rover.GetX());
        }

        [Fact]
        public void Test10()
        {
            var rover = new MarsRover('S', 0, 9, GetEmptyMap());
            rover.SendCommand("B");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test11()
        {
            var rover = new MarsRover('N', 0, 9, GetEmptyMap());
            rover.SendCommand("F");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test12()
        {
            var rover = new MarsRover('W', 0, 0, GetEmptyMap());
            rover.SendCommand("F");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(9, rover.GetX());
        }

        [Fact]
        public void Test13()
        {
            var rover = new MarsRover('E', 9, 0, GetEmptyMap());
            rover.SendCommand("F");
            Assert.Equal(0, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test14()
        {
            var rover = new MarsRover('S', 0, 0, GetEmptyMap());
            rover.SendCommand("F");
            Assert.Equal(9, rover.GetY());
            Assert.Equal(0, rover.GetX());
        }

        [Fact]
        public void Test15()
        {
            var rover = new MarsRover('N', 0, 0, GetEmptyMap());
            rover.SendCommand("FFFFFRFFF");
            Assert.Equal(5, rover.GetY());
            Assert.Equal(3, rover.GetX());
        }

        [Fact]
        public void Test16()
        {
            var rover = new MarsRover('N', 0, 0, GetMapWithObstacleAt_1_0());
            var exception = Assert.Throws<Exception>(() => rover.SendCommand("FFFFFRFFF"));
            Assert.Equal("Obstacle found", exception.Message);
            Assert.Equal(0, rover.GetX());
            Assert.Equal(0, rover.GetY());
            Assert.Equal('N', rover.GetDirection());
        }

        private static int[,] GetMapWithObstacleAt_1_0() => new[,] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

        [Fact]
        public void Test17()
        {
            var rover = new MarsRover('N', 0, 0, GetMapWithObstacleAt_2_0());
            var exception = Assert.Throws<Exception>(() => rover.SendCommand("FFFFFRFFF"));
            Assert.Equal("Obstacle found", exception.Message);
            Assert.Equal(0, rover.GetX());
            Assert.Equal(1, rover.GetY());
            Assert.Equal('N', rover.GetDirection());
        }

        private static int[,] GetMapWithObstacleAt_2_0() => new[,] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

        [Fact]
        public void Test18()
        {
            var rover = new MarsRover('N', 0, 0, GetMapWithObstacleAt_0_1());
            var exception = Assert.Throws<Exception>(() => rover.SendCommand("RF"));
            Assert.Equal("Obstacle found", exception.Message);
            Assert.Equal(0, rover.GetX());
            Assert.Equal(0, rover.GetY());
            Assert.Equal('E', rover.GetDirection());
        }

        private static int[,] GetMapWithObstacleAt_0_1() => new[,] {
                { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

        [Fact]
        public void Test19()
        {
            var rover = new MarsRover('N', 0, 0, GetMapWithObstacleAt_9_0());
            var exception = Assert.Throws<Exception>(() => rover.SendCommand("LF"));
            Assert.Equal("Obstacle found", exception.Message);
            Assert.Equal(0, rover.GetX());
            Assert.Equal(0, rover.GetY());
            Assert.Equal('W', rover.GetDirection());
        }

        private static int[,] GetMapWithObstacleAt_9_0() => new[,] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

        [Fact]
        public void Test20()
        {
            var rover = new MarsRover('N', 0, 0, GetMapWithObstacleAt_0_9());
            var exception = Assert.Throws<Exception>(() => rover.SendCommand("B"));
            Assert.Equal("Obstacle found", exception.Message);
            Assert.Equal(0, rover.GetX());
            Assert.Equal(0, rover.GetY());
            Assert.Equal('N', rover.GetDirection());
        }

        private static int[,] GetMapWithObstacleAt_0_9() => new[,] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
    }
}