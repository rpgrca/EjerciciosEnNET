using Day9.Logic;
using static Day9.UnitTests.Constants;

namespace Day9.UnitTests;

public class RopeBridgeMust
{
    [Theory]
    [InlineData("R 1", 1)]
    [InlineData("R 2", 2)]
    [InlineData("R 1\nR 1", 2)]
    [InlineData("R 4", 4)]
    public void CalculateTailPositionsCorrectly_WhenHeadMovesRight(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }

    [Theory]
    [InlineData("L 1", 1)]
    [InlineData("L 2", 2)]
    [InlineData("L 1\nL 1", 2)]
    public void CalculateTailPositionsCorrectly_WhenHeadMovesLeft(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }

    [Theory]
    [InlineData("U 1", 1)]
    [InlineData("U 2", 2)]
    [InlineData("U 1\nU 1", 2)]
    public void CalculateTailPositionsCorrectly_WhenHeadMovesUp(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }

    [Theory]
    [InlineData("D 1", 1)]
    [InlineData("D 2", 2)]
    [InlineData("D 1\nD 1", 2)]
    public void CalculateTailPositionsCorrectly_WhenHeadMovesDown(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }

    [Theory]
    [InlineData("R 1\nL 1", 1)]
    [InlineData("L 1\nR 1", 1)]
    [InlineData("L 1\nR 2", 1)]
    [InlineData("L 1\nR 3", 2)]
    [InlineData("L 1\nU 1", 1)]
    [InlineData("L 1\nU 2\nL 1", 2)] // diagonal up-left when moving up
    [InlineData("L 1\nU 1\nL 1\nU 1", 2)] // diagonal up-left when moving left
    [InlineData("R 1\nU 2\nR 1", 2)] // diagonal up-right when moving up
    [InlineData("R 1\nU 1\nR 1\nU 1", 2)] // diagonal up-right when moving right
    [InlineData("U 1\nD 1", 1)]
    [InlineData("L 1\nD 1", 1)]
    [InlineData("U 1\nD 3", 2)]
    [InlineData("L 1\nD 2\nL 1", 2)] // diagonal down-left when moving down
    [InlineData("L 1\nD 1\nL 1\nD 1", 2)] // diagonal down-left when moving left
    [InlineData("R 1\nD 2\nR 1", 2)] // diagonal down-right when moving down
    [InlineData("R 1\nD 1\nR 1\nD 1", 2)] // diagonal down-right when moving right
    public void CalculateTailPositionsCorrectly_WhenMixingDirections(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }
}