namespace Day2.UnitTests;

using Logic;
using static Day2.UnitTests.Constants;

public class StrategyGuideMust
{
    [Fact]
    public void Test1()
    {
        var sut = new StrategyGuide("A Y");
        Assert.Equal(8, sut.TotalScore);
    }

    [Fact]
    public void Test2()
    {
        var sut = new StrategyGuide("A Y\nB X");
        Assert.Equal(9, sut.TotalScore);
    }
}