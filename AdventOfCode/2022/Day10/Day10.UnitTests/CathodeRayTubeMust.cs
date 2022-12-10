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
    public void Test1(string input, int expectedValue)
    {
        var sut = new CathodeRayTube(input);
        Assert.Equal(expectedValue, sut.X);
    }
}