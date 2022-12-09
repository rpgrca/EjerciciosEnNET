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
    [InlineData("R 1\nL 1", 1)]
    public void CalculateTailMovementCorrectly_WhenHeadMovesRight(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }

    [Theory]
    [InlineData("L 1", 1)]
    [InlineData("L 2", 2)]
    [InlineData("L 1\nR 1", 1)]
    [InlineData("L 1\nR 2", 1)]
    [InlineData("L 1\nR 3", 2)]
    public void CalculateTailMovementCorrectly_WhenHeadMovesLeft(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }
}