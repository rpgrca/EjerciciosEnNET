using Day13.Logic;
using static Day13.UnitTests.Constants;

namespace Day13.UnitTests;

public class DistressSignalDecoderMust
{
    [Theory]
    [InlineData("[1,1,1]\n[1,1,1,1]", 1)]
    [InlineData("[7,7,7,7]\n[7,7,7]", 0)]
    [InlineData("[1,1,3,1,1]\n[1,1,5,1,1]", 1)]
    [InlineData("[]\n[3]", 1)]
    [InlineData("[3]\n[]", 0)]
    public void HandleNumericValuesCorrectly(string input, int expectedSum)
    {
        var sut = new DistressSignalDecoder(input);
        Assert.Equal(expectedSum, sut.SumOfCorrectIndexes);
    }

    [Theory]
    [InlineData("[9]\n[[8,7,6]]", 0)]
    [InlineData("[[[]]]\n[[]]", 0)]
    [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]\n[1,[2,[3,[4,[5,6,0]]]],8,9]", 0)]
    [InlineData("[[4,4],4,4]\n[[4,4],4,4,4]", 1)]
    [InlineData("[[1],[2,3,4]]\n[[1],4]", 1)]
    public void HandleListsCorrectly(string input, int expectedSum)
    {
        var sut = new DistressSignalDecoder(input);
        Assert.Equal(expectedSum, sut.SumOfCorrectIndexes);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new DistressSignalDecoder(SAMPLE_INPUT);
        Assert.Equal(13, sut.SumOfCorrectIndexes);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new DistressSignalDecoder(PUZZLE_INPUT);
        Assert.Equal(5330, sut.SumOfCorrectIndexes);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new DistressSignalDecoder(SAMPLE_INPUT);
        Assert.Equal(140, sut.DecoderKey);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new DistressSignalDecoder(PUZZLE_INPUT);
        Assert.Equal(27648, sut.DecoderKey);
    }
}