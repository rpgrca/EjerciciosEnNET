using Day25.Logic;
using static Day25.UnitTests.Constants;

namespace Day25.UnitTests;

public class SnafuNumberMust
{
    [Theory]
    [InlineData("1=-0-2", 1747)]
    public void Test1(string input, int expectedValue)
    {
        var sut = new SnafuNumber(input);
        Assert.Equal(expectedValue, sut.Value);
    }

    [Fact]
    public void SolveFirstSample()
    {
        Assert.Equal(4890, SAMPLE_INPUT.Split("\n").Select(p => new SnafuNumber(p).Value).Sum());
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        Assert.Equal(30535047052797, PUZZLE_INPUT.Split("\n").Select(p => new SnafuNumber(p).Value).Sum());
    }
}