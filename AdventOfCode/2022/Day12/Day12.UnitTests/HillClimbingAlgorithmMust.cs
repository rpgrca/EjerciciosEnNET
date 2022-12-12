using Day12.Logic;
using static Day12.UnitTests.Constants;

namespace Day12.UnitTests;

public class HillClimbingAlgorithmMust
{
    [Theory]
    [InlineData("SE", 1)]
    [InlineData("SaE", 2)]
    [InlineData("SabE", 3)]
    public void FindSteps_WhenMapIsHorizontal(string input, int expectedValue)
    {
        var sut = new HillClimbingAlgorithm(input);
        Assert.Equal(expectedValue, sut.FewestStepsToTarget);
    }

    [Theory]
    [InlineData("S\nE", 1)]
    [InlineData("S\na\nE", 2)]
    public void FindSteps_WhenMapIsVertical(string input, int expectedValue)
    {
        var sut = new HillClimbingAlgorithm(input);
        Assert.Equal(expectedValue, sut.FewestStepsToTarget);
    }

    [Theory]
    [InlineData("Sabc\nazzd\nzzzE", 5)]
    [InlineData("abcd\nSzze\nabzE", 6)]
    public void Test1(string input, int expectedValue)
    {
        var sut = new HillClimbingAlgorithm(input);
        Assert.Equal(expectedValue, sut.FewestStepsToTarget);
    }
}