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
    [InlineData("pppw: 5\nroot: pppw + sjmn\nsjmn: 2", 7)]
    [InlineData("pppw: 3\nroot: pppw * sjmn\nsjmn: 5", 15)]
    [InlineData("pppw: 3\nroot: pppw - sjmn\nsjmn: 5", -2)]
    [InlineData("pppw: 10\nroot: pppw / sjmn\nsjmn: 2", 5)]
    [InlineData("pppw: 5\nsjmn: 2\nroot: pppw + sjmn", 7)]
    [InlineData("pppw: 3\nsjmn: 5\nroot: pppw * sjmn", 15)]
    [InlineData("pppw: 3\nsjmn: 5\nroot: pppw - sjmn", -2)]
    [InlineData("pppw: 10\nsjmn: 2\nroot: pppw / sjmn", 5)]
    public void Test1(string input, int expectedRoot)
    {
        var sut = new MonkeyMath(input);
        Assert.Equal(expectedRoot, sut.Root);
    }

    [Fact]
    public void Test2()
    {
        var sut = new MonkeyMath("root: pppw + sjmn\npppw: cczh / lfqf\ncczh: 4\nlfqf: 2\nsjmn: 5");
        Assert.Equal(7, sut.Root);
    }

    [Fact]
    public void Test3()
    {
        var sut = new MonkeyMath(SAMPLE_INPUT);
        Assert.Equal(152, sut.Root);
    }
}