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

/*
    [Theory]
    [InlineData("[9]\n[[8,7,6]]", 0)]
    public void HandleListsCorrectly(string input, int expectedSum)
    {
        var sut = new DistressSignalDecoder(input);
        Assert.Equal(expectedSum, sut.SumOfCorrectIndexes);
    }*/
}