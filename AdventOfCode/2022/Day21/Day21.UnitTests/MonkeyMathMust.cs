using Day21.Logic;
using static Day21.UnitTests.Constants;

namespace Day21.UnitTests;

public class MonkeyMathMust
{
    [Fact]
    public void Test1()
    {
        var sut = new MonkeyMath("root: 5 + 2");
        Assert.Equal(7, sut.Root);
    }
}