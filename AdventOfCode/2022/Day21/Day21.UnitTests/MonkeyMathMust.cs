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
    public void SolveFirstSample()
    {
        var sut = new MonkeyMath(SAMPLE_INPUT);
        Assert.Equal(152, sut.Root);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new MonkeyMath(PUZZLE_INPUT);
        Assert.Equal(145167969204648, sut.Root);
    }
}

public class MonkeyHumanMathMust
{
    [Theory]
    [InlineData("root: pppw + humn\npppw: 5\nhumn: 2", 5)]
    [InlineData("root: pppw + zczc\nzczc: petr - humn\npppw: 5\nhumn: 2\npetr: 12", 7)]
    [InlineData("root: pppw - zczc\nzczc: petr + humn\npppw: 16\nhumn: 2\npetr: 12", 4)]
    [InlineData("root: pppw * zczc\nzczc: petr * humn\npppw: 36\nhumn: 3\npetr: 12", 3)]
    [InlineData("root: pppw / zczc\nzczc: petr / humn\npppw: 48\nhumn: 16\npetr: 48", 1)]
    [InlineData("root: humn + pppw\npppw: 5\nhumn: 2", 5)]
    [InlineData("root: pppw + zczc\nzczc: humn - petr\npppw: 5\nhumn: 2\npetr: 12", 17)]
    [InlineData("root: pppw - zczc\nzczc: humn + petr\npppw: 16\nhumn: 2\npetr: 12", 4)]
    [InlineData("root: pppw * zczc\nzczc: humn * petr\npppw: 36\nhumn: 3\npetr: 12", 3)]
    [InlineData("root: pppw / zczc\nzczc: humn / petr\npppw: 48\nhumn: 16\npetr: 48", 2304)]
    public void Test1(string input, int expectedRoot)
    {
        var sut = new MonkeyHumanMath(input);
        Assert.Equal(expectedRoot, sut.Root);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new MonkeyHumanMath(SAMPLE_INPUT);
        Assert.Equal(301, sut.Root);
    }
}