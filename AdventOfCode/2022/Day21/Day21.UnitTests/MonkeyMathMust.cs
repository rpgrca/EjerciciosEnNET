using Day21.Logic;
using static Day21.UnitTests.Constants;

namespace Day21.UnitTests;

public class MonkeyMathMust
{
    [Theory]
    [InlineData("root: 5 + 2", 7)]
    [InlineData("root: 3 * 5", 15)]
    [InlineData("root: 3 - 5", -2)]
    [InlineData("root: 10 / 5", 2)]
    public void Test1(string input, int expectedRoot)
    {
        var sut = new MonkeyMath(input);
        Assert.Equal(expectedRoot, sut.Root);
    }
}