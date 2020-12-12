using Xunit;
using AdventOfCode.Day12.Logic;

namespace AdventOfCode.Day12.UnitTests
{
    public class ShipMust
    {
        [Fact]
        public void FaceEast_WhenInitialized()
        {
            var sut = new Ship("F0", (0, 1, 0, 0));
            Assert.True(sut.IsFacing(Action.E));
        }

        [Theory]
        [InlineData("F10", 10, Action.E)]
        [InlineData("F10\nN3", 13, Action.E)]
        [InlineData("F10\nN3\nF7", 20, Action.E)]
        [InlineData("F10\nN3\nF7\nR90", 20, Action.S)]
        [InlineData("F10\nN3\nF7\nR90\nF11", 25, Action.S)]
        public void Test1(string instructions, int expectedDistance, Action expectedFacing)
        {
            var sut = new Ship(instructions, (0, 1, 0, 0));
            sut.ExecuteInstructions();

            Assert.Equal(expectedDistance, sut.ManhattanDistance);
            Assert.True(sut.IsFacing(expectedFacing));
        }

        [Theory]
        [InlineData("R90", Action.S)]
        [InlineData("R180", Action.W)]
        [InlineData("R270", Action.N)]
        [InlineData("L90", Action.N)]
        [InlineData("L180", Action.W)]
        [InlineData("L270", Action.S)]
        public void RotateCorrectly_WhenLeftOrRightInstructionsAreGiven(string instructions, Action expectedFacing)
        {
            var sut = new Ship(instructions, (0, 1, 0, 0));
            sut.ExecuteInstructions();

            Assert.True(sut.IsFacing(expectedFacing));
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Ship(PuzzleData.PUZZLE_DATA, (0, 1, 0, 0));
            sut.ExecuteInstructions();

            Assert.Equal(1319, sut.ManhattanDistance);
        }

        [Theory]
        [InlineData("F10", 110)]
        [InlineData("F10\nN3", 110)]
        [InlineData("F10\nN3\nF7", 208)]
        [InlineData("F10\nN3\nF7\nR90", 208)]
        [InlineData("F10\nN3\nF7\nR90\nF11", 286)]
        public void Test3(string instructions, int expectedDistance)
        {
            var sut = new ShipWithWaypoint(instructions, (1, 10, 0, 0));
            sut.ExecuteInstructions();

            Assert.Equal(expectedDistance, sut.ManhattanDistance);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new ShipWithWaypoint(PuzzleData.PUZZLE_DATA, (1, 10, 0, 0));
            sut.ExecuteInstructions();

            Assert.Equal(62434, sut.ManhattanDistance);
        }
    }
}