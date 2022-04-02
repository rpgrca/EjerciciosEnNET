using Xunit;
using AdventOfCode.Day12.Logic;

namespace AdventOfCode.Day12.UnitTests
{
    public class ShipMust
    {
        [Theory]
        [InlineData("F10", 10)]
        [InlineData("F10\nN3", 13)]
        [InlineData("F10\nN3\nF7", 20)]
        [InlineData("F10\nN3\nF7\nR90", 20)]
        [InlineData("F10\nN3\nF7\nR90\nF11", 25)]
        public void Test1(string instructions, int expectedDistance)
        {
            var sut = new Ship(instructions);
            sut.ExecuteInstructions();

            Assert.Equal(expectedDistance, sut.ManhattanDistance);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Ship(PuzzleData.PUZZLE_DATA);
            sut.ExecuteInstructions();

            Assert.Equal(1319, sut.ManhattanDistance);
        }
    }
}