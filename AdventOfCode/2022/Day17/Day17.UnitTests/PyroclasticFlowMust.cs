using Day17.Logic;
using static Day17.UnitTests.Constants;

namespace Day17.UnitTests;

public class PyroclasticFlowMust
{
    [Fact]
    public void Test1()
    {
        var sut = new PyroclasticFlow("<", 1);
        Assert.Equal(1, sut.Height);
    }
}