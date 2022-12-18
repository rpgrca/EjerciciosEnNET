using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class BoilingBouldersMust
{
    [Theory]
    [InlineData("1,1,1", 6)]
    [InlineData("1,1,1\n2,1,1", 10)]
    public void Test1(string input, int expectedSurface)
    {
        var sut = new BoilingBoulders(input);
        Assert.Equal(expectedSurface, sut.SurfaceArea);
    }
}