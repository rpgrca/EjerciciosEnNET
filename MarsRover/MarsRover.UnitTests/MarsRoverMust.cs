using System;
using System.Collections.Generic;
using Xunit;
using MarsRover.Logic;

namespace MarsRover.UnitTests
{
    public class MarsRoverMust
    {
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(15, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 15)]
        public void ThrowException_WhenAnInvalidCoordinateIsSupplied(int x, int y)
        {
            var exception = Assert.Throws<Exception>(() => new Logic.MarsRover('N', x, y, CreateEmptyMap()));
            Assert.Equal("Invalid coordinate", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenNullMapIsProvided()
        {
            var exception = Assert.Throws<Exception>(() => new Logic.MarsRover('N', 0, 0, null));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenMapLackingHeightIsProvided()
        {
            var map = new[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            var exception = Assert.Throws<Exception>(() => new Logic.MarsRover('N', 0, 0, map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenMapLackingWidthIsProvided()
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
            var exception = Assert.Throws<Exception>(() => new Logic.MarsRover('N', 0, 0, map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Theory]
        [InlineData('N')]
        [InlineData('S')]
        [InlineData('W')]
        [InlineData('E')]
        public void ReturnSameDirectionAsInitialized(char expectedDirection)
        {
            var rover = new Logic.MarsRover(expectedDirection, 0, 0, CreateEmptyMap());
            var direction = rover.GetDirection();
            Assert.Equal(expectedDirection, direction);
        }

        [Theory]
        [InlineData('n')]
        [InlineData('z')]
        [InlineData(' ')]
        public void ThrowException_WhenInitializedWithInvalidDirection(char invalidDirection)
        {
            var exception = Assert.Throws<Exception>(() => new Logic.MarsRover(invalidDirection, 0, 0, null));
            Assert.Equal("Invalid command", exception.Message);
        }

        [Fact]
        public void AddTwoToY_WhenFacingNorthAndMovingForwardTwice()
        {
            var rover = CreateRover();
            rover.SendCommand("F");

            rover.SendCommand("F");
            Assert.Equal(4, rover.GetY());
            Assert.Equal(2, rover.GetX());
        }

        private static Logic.MarsRover CreateRover() => new('N', 2, 2, CreateEmptyMap());

        private static int[,] CreateEmptyMap() => new[,] {
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
        [InlineData("F", 2, 3)]
        [InlineData("FF", 2, 4)]
        [InlineData("FFF", 2, 5)]
        [InlineData("B", 2, 1)]
        [InlineData("BB", 2, 0)]
        [InlineData("FFFFFRFFF", 5, 7)]
        public void UpdatePositionCorrectly_WhenMovingForwardOrBackward(string commands, int expectedX, int expectedY)
        {
            var rover = CreateRover();
            rover.SendCommand(commands);
            Assert.Equal(expectedX, rover.GetX());
            Assert.Equal(expectedY, rover.GetY());
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
            var rover = CreateRover();
            rover.SendCommand(commands);
            Assert.Equal(expectedDirection, rover.GetDirection());
        }

        [Theory]
        [InlineData("LF", 1, 2)]
        [InlineData("LFF", 0, 2)]
        [InlineData("LLF", 2, 1)]
        [InlineData("LLFF", 2, 0)]
        [InlineData("LLLF", 3, 2)]
        [InlineData("LLLFF", 4, 2)]
        [InlineData("LLLFFF", 5, 2)]
        [InlineData("LB", 3, 2)]
        [InlineData("LBB", 4, 2)]
        [InlineData("LBBB", 5, 2)]
        [InlineData("LLB", 2, 3)]
        [InlineData("LLBB", 2, 4)]
        [InlineData("LLBBB", 2, 5)]
        [InlineData("LLLB", 1, 2)]
        [InlineData("LLLBB", 0, 2)]
        public void UpdatePositionCorrectly_WhenTurningLeftAndMovingForwardOrBackward(string commands, int expectedX, int expectedY)
        {
            var rover = CreateRover();
            rover.SendCommand(commands);
            Assert.Equal(expectedY, rover.GetY());
            Assert.Equal(expectedX, rover.GetX());
        }

        [Theory]
        [InlineData('N', 0, 0, "B", 0, 9)]
        [InlineData('W', 9, 0, "B", 0, 0)]
        [InlineData('E', 0, 0, "B", 9, 0)]
        [InlineData('S', 0, 9, "B", 0, 0)]
        [InlineData('N', 0, 9, "F", 0, 0)]
        [InlineData('W', 0, 0, "F", 9, 0)]
        [InlineData('E', 9, 0, "F", 0, 0)]
        [InlineData('S', 0, 0, "F", 0, 9)]
        public void ClipCorrectlyToTheOtherSideOfTheMap(char initialDirection, int initialX, int initialY, string command, int expectedX, int expectedY)
        {
            var rover = new Logic.MarsRover(initialDirection, initialX, initialY, CreateEmptyMap());
            rover.SendCommand(command);
            Assert.Equal(expectedY, rover.GetY());
            Assert.Equal(expectedX, rover.GetX());
        }

        [Fact]
        public void Test16()
        {
            var rover = new Logic.MarsRover('N', 0, 0, GetMapWithObstacleAt_1_0());
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
            var rover = new Logic.MarsRover('N', 0, 0, GetMapWithObstacleAt_2_0());
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
            var rover = new Logic.MarsRover('N', 0, 0, GetMapWithObstacleAt_0_1());
            var exception = Assert.Throws<Exception>(() => rover.SendCommand("RF"));
            Assert.Equal("Obstacle found", exception.Message);
            Assert.Equal(0, rover.GetX());
            Assert.Equal(0, rover.GetY());
            Assert.Equal('E', rover.GetDirection());
        }

        [Theory]
        [MemberData(nameof(GetSpecialCases))]
        public void Test1(int initialX, int initialY, string commands, int [,] map, char expectedDirection)
        {
            var rover = new Logic.MarsRover('N', initialX, initialY, map);
            var exception = Assert.Throws<Exception>(() => rover.SendCommand(commands));
            Assert.Equal("Obstacle found", exception.Message);
            Assert.Equal(initialX, rover.GetX());
            Assert.Equal(initialY, rover.GetY());
            Assert.Equal(expectedDirection, rover.GetDirection());
        }

        public static IEnumerable<object[]> GetSpecialCases()
        {
            yield return new object[] { 0, 0, "RF", GetMapWithObstacleAt_0_1(), 'E' };
            yield return new object[] { 0, 0, "LF", GetMapWithObstacleAt_9_0(), 'W' };
            yield return new object[] { 0, 0, "B", GetMapWithObstacleAt_0_9(), 'N' };
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