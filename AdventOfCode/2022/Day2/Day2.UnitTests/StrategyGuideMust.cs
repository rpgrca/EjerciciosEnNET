namespace Day2.UnitTests;

using Logic;
using static Day2.UnitTests.Constants;

public class StrategyGuideMust
{
    [Theory]
    [InlineData("A Y", 8)]
    [InlineData("A Y\nB X", 9)]
    [InlineData(SAMPLE_INPUT, 15)]
    public void Test1(string input, int expectedPoints)
    {
        var sut = new StrategyGuide(input);
        Assert.Equal(expectedPoints, sut.TotalScore);
    }
}