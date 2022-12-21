using Day21.Logic;
using static Day21.UnitTests.Constants;

namespace Day21.UnitTests;

public class MonkeyMathMust
{
    [Theory]
    [InlineData("root: pppw + sjmn\npppw: 5\nsjmn: 2", 7)]
    [InlineData("root: pppw * sjmn\npppw: 3\nsjmn: 5", 15)]
    [InlineData("root: pppw - sjmn\npppw: 3\nsjmn: 5", -2)]
    [InlineData("root: pppw / sjmn\npppw: 10\nsjmn: 2", 5)]
    public void Test1(string input, int expectedRoot)
    {
        var sut = new MonkeyMath(input);
        Assert.Equal(expectedRoot, sut.Root);
    }
}