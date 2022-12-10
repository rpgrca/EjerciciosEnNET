using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests;

public class CathodeRayTubeMust
{
    [Theory]
    [InlineData("", 1)]
    [InlineData("noop", 1)]
    [InlineData("addx 1\nnoop", 2)]
    [InlineData("noop\naddx 3\naddx -5", -1)]
    public void ExecuteInstructionsCorrectly(string input, int expectedValue)
    {
        var sut = new CathodeRayTube(input, Array.Empty<int>());
        Assert.Equal(expectedValue, sut.X);
    }

    [Fact]
    public void CalculateSignalStrengthCorrectly1()
    {
        var sut = new CathodeRayTube("noop\naddx 3\naddx -5", new[] { 1, 4 });
        Assert.Equal(17, sut.SignalStrength);
    }

    [Fact]
    public void CalculateSignalStrengthCorrectly2()
    {
        var sut = new CathodeRayTube("noop\naddx 3\naddx -5", new[] { 4, 5 });
        Assert.Equal(36, sut.SignalStrength);
    }

}