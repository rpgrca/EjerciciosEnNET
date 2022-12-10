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

    [Theory]
    [MemberData(nameof(SignalStrengthSamples))]
    public void CalculateSignalStrengthCorrectly1(string input, int[] samples, int expectedValue)
    {
        var sut = new CathodeRayTube(input, samples);
        Assert.Equal(expectedValue, sut.SignalStrength);
    }

    public static IEnumerable<object[]> SignalStrengthSamples()
    {
        yield return new object[] { "noop\naddx 3\naddx -5", new int[] { 1, 4 }, 17 };
        yield return new object[] { "noop\naddx 3\naddx -5", new int[] { 4, 5}, 36 };
        yield return new object[] { SAMPLE_INPUT, new[] { 20 }, 420 };
        yield return new object[] { SAMPLE_INPUT, new[] { 60 }, 1140 };
        yield return new object[] { SAMPLE_INPUT, new[] { 100 }, 1800 };
        yield return new object[] { SAMPLE_INPUT, new[] { 140 }, 2940 };
        yield return new object[] { SAMPLE_INPUT, new[] { 180 }, 2880 };
        yield return new object[] { SAMPLE_INPUT, new[] { 220 }, 3960 };
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new CathodeRayTube(SAMPLE_INPUT, new[] { 20, 60, 100, 140, 180, 220 });
        Assert.Equal(13140, sut.SignalStrength);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new CathodeRayTube(PUZZLE_INPUT, new[] { 20, 60, 100, 140, 180, 220 });
        Assert.Equal(14060, sut.SignalStrength);
    }

    [Fact]
    public void Test1()
    {
        var sut = new CathodeRayTube(SAMPLE_INPUT, Array.Empty<int>());
        Assert.StartsWith("##..##..##..##..##..##..##..##..##..##..\n", sut.Output);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new CathodeRayTube(SAMPLE_INPUT, Array.Empty<int>());
        Assert.Equal(@"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
", sut.Output);
    }

}