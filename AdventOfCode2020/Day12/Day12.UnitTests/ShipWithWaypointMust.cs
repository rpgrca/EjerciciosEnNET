using Xunit;
using AdventOfCode.Day12.Logic;

namespace AdventOfCode.Day12.UnitTests
{
    public class ShipWithWaypointMust
    {
        [Theory]
        [InlineData("F10", 110)]
        [InlineData("F10\nN3", 110)]
        [InlineData("F10\nN3\nF7", 208)]
        [InlineData("F10\nN3\nF7\nR90", 208)]
        [InlineData("F10\nN3\nF7\nR90\nF11", 286)]
        public void Test3(string instructions, int expectedDistance)
        {
            var sut = new ShipWithWaypoint(instructions);
            sut.ExecuteInstructions();

            Assert.Equal(expectedDistance, sut.ManhattanDistance);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new ShipWithWaypoint(PuzzleData.PUZZLE_DATA);
            sut.ExecuteInstructions();

            Assert.Equal(62434, sut.ManhattanDistance);
        }
    }
}