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
        var sut = HillClimbingAlgorithm.CreateSingleStartingPoint(input);
        Assert.Equal(expectedValue, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = HillClimbingAlgorithm.CreateSingleStartingPoint(SAMPLE_INPUT);
        Assert.Equal(31, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = HillClimbingAlgorithm.CreateSingleStartingPoint(PUZZLE_INPUT);
        Assert.Equal(520, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = HillClimbingAlgorithm.CreateMultipleStartingPoints(SAMPLE_INPUT);
        Assert.Equal(29, sut.FewestStepsToTarget);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = HillClimbingAlgorithm.CreateMultipleStartingPoints(PUZZLE_INPUT);
        Assert.Equal(508, sut.FewestStepsToTarget);
    }
}