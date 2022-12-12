using Day12.Logic;
using static Day12.UnitTests.Constants;

namespace Day12.UnitTests;

public class HillClimbingAlgorithmMust
{
    [Theory]
    [InlineData("SabcdefghijklmnopqrstuvwxyzE", 27)]
    [InlineData("S\na\nb\nc\nd\ne\nf\ng\nh\ni\nj\nk\nl\nm\nn\no\np\nq\nr\ns\nt\nu\nv\nw\nx\ny\nz\nE", 27)]
    public void FindStepsCorrectly_WhenMapIsLineal(string input, int expectedValue)
    {
        var sut = new HillClimbingAlgorithm(input);
        Assert.Equal(expectedValue, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new HillClimbingAlgorithm(SAMPLE_INPUT);
        Assert.Equal(31, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new HillClimbingAlgorithm(PUZZLE_INPUT);
        Assert.Equal(520, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new HillClimbingAlgorithm(SAMPLE_INPUT, true);
        Assert.Equal(29, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new HillClimbingAlgorithm(PUZZLE_INPUT, true);
        Assert.Equal(508, sut.FewestStepsToTarget);
    }
}