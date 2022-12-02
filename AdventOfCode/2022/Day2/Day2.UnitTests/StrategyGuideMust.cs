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
        var sut = StrategyGuide.CreateForFirstPart(input);
        Assert.Equal(expectedPoints, sut.TotalScore);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = StrategyGuide.CreateForFirstPart(PUZZLE_INPUT);
        Assert.Equal(11150, sut.TotalScore);
    }

    [Theory]
    [InlineData("A Y", 4)]
    [InlineData("A Y\nB X", 5)]
    [InlineData(SAMPLE_INPUT, 12)]
    public void SolveSecondSampleCorrectly(string input, int expectedPoints)
    {
        var sut = StrategyGuide.CreateForSecondPart(input);
        Assert.Equal(expectedPoints, sut.TotalScore);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = StrategyGuide.CreateForSecondPart(PUZZLE_INPUT);
        Assert.Equal(8295, sut.TotalScore);
    }
}