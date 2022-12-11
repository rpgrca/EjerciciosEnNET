using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests;

public class CathodeRayTubeMust
{
    [Theory]
    [MemberData(nameof(SignalStrengthSamples))]
    public void CalculateSignalStrengthCorrectly(string input, int[] samples, int expectedValue)
    {
        var sut = new SignalStrengthInterrupt(samples);
        var device = new CathodeRayTube(input);
        device.Execute(sut);
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
        var sut = new SignalStrengthInterrupt(new[] { 20, 60, 100, 140, 180, 220 });
        var device = new CathodeRayTube(SAMPLE_INPUT);
        device.Execute(sut);
        Assert.Equal(13140, sut.SignalStrength);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new SignalStrengthInterrupt(new[] { 20, 60, 100, 140, 180, 220 });
        var device = new CathodeRayTube(PUZZLE_INPUT);
        device.Execute(sut);
        Assert.Equal(14060, sut.SignalStrength);
    }

    [Fact]
    public void DecodeFirstSampleLineCorrectly()
    {
        var sut = new DrawingInterrupt();
        var device = new CathodeRayTube(SAMPLE_INPUT);
        device.Execute(sut);
        Assert.StartsWith("##..##..##..##..##..##..##..##..##..##..\n", sut.Output);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new DrawingInterrupt();
        var device = new CathodeRayTube(SAMPLE_INPUT);
        device.Execute(sut);
        Assert.Equal(@"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
", sut.Output);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new DrawingInterrupt();
        var device = new CathodeRayTube(PUZZLE_INPUT);
        device.Execute(sut);
        Assert.Equal("###...##..###..#..#.####.#..#.####...##.\n" +
                     "#..#.#..#.#..#.#.#..#....#.#..#.......#.\n" +
                     "#..#.#..#.#..#.##...###..##...###.....#.\n" +
                     "###..####.###..#.#..#....#.#..#.......#.\n" +
                     "#....#..#.#....#.#..#....#.#..#....#..#.\n" +
                     "#....#..#.#....#..#.#....#..#.####..##..\n", sut.Output);
    }
}