using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class BoilingBouldersMust
{
    [Theory]
    [InlineData("1,1,1", 6)]
    [InlineData("1,1,1\n2,1,1", 10)]
    [InlineData("3,1,1\n1,1,1\n2,1,1", 14)]
    public void Test1(string input, int expectedSurface)
    {
        var sut = new BoilingBoulders(input);
        Assert.Equal(expectedSurface, sut.SurfaceArea);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new BoilingBoulders(SAMPLE_INPUT);
        Assert.Equal(64, sut.SurfaceArea);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new BoilingBoulders(PUZZLE_INPUT);
        Assert.True(2125 < sut.SurfaceArea);
        Assert.Equal(3526, sut.SurfaceArea);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new BoilingBoulders(SAMPLE_INPUT, false);
        Assert.Equal(58, sut.SurfaceArea);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new BoilingBoulders(PUZZLE_INPUT, false);
        Assert.True(2078 < sut.SurfaceArea);
        Assert.Equal(2090, sut.SurfaceArea);
    }
}