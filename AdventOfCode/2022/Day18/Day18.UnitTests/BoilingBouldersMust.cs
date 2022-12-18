using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class BoilingBouldersMust
{
    [Theory]
    [InlineData("1,1,1", 6)]
    public void Test1(string input, int expectedSurface)
    {
        var sut = new BoilingBoulders("1,1,1");
        Assert.Equal(expectedSurface, sut.SurfaceArea);
    }
}