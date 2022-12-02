namespace Day2.UnitTests;

using Logic;
using static Day2.UnitTests.Constants;

public class StrategyGuideMust
{
    [Theory]
    [InlineData("A Y", 8)]
    [InlineData("A Y\nB X", 9)]
    [InlineData(SAMPLE_INPUT, 15)]
    public void SolveSampleCorrectly(string input, int expectedPoints)
    {
        var sut = new StrategyGuide(input);
        Assert.Equal(expectedPoints, sut.TotalScore);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new StrategyGuide(PUZZLE_INPUT);
        Assert.Equal(11150, sut.TotalScore);
    }
}