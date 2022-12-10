using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests;

public class CathodeRayTubeMust
{
    [Fact]
    public void Test1()
    {
        var sut = new CathodeRayTube("noop\naddx 3\naddx -5");
        Assert.Equal(-1, sut.X);
    }
}