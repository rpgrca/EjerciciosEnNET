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

    [Theory]
    [InlineData("L 3\nR 3", 3)]
    [InlineData("R 3\nL 3", 3)]
    [InlineData("U 3\nD 3", 3)]
    [InlineData("D 3\nU 3", 3)]
    public void CalculateTailPositionsCorrectly_WhenSteppingOnPreviousVisitedPosition(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new RopeBridge(SAMPLE_INPUT);
        Assert.Equal(13, sut.VisitedPositions);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new RopeBridge(PUZZLE_INPUT);
        Assert.Equal(6087, sut.VisitedPositions);
    }

    [Theory]
    [InlineData("R 1", 1)]
    [InlineData("R 2", 1)]
    [InlineData("R 9", 1)]
    [InlineData("R 10", 2)]
    [InlineData("R 11", 3)]
    public void CalculateTailPositionsCorrectly_WhenMultipleKnotsExist(string input, int expectedVisitedPositions)
    {
        var sut = new RopeBridge(input, 10);
        Assert.Equal(expectedVisitedPositions, sut.VisitedPositions);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new RopeBridge(SAMPLE_INPUT, 10);
        Assert.Equal(1, sut.VisitedPositions);
    }

    [Fact]
    public void SolveLongSampleCorrectly()
    {
        var sut = new RopeBridge(LONG_SAMPLE_INPUT, 10);
        Assert.Equal(36, sut.VisitedPositions);
    }
}