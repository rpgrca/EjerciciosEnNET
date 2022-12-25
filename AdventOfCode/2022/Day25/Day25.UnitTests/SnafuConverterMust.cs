using Day25.Logic;
using static Day25.UnitTests.Constants;

namespace Day25.UnitTests;

public class SnafuConverterMust
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "1=")]
    [InlineData(4, "1-")]
    [InlineData(5, "10")]
    [InlineData(6, "11")]
    [InlineData(7, "12")]
    [InlineData(8, "2=")]
    [InlineData(9, "2-")]
    [InlineData(10, "20")]
    [InlineData(15, "1=0")]
    [InlineData(20, "1-0")]
    [InlineData(2022, "1=11-2")]
    [InlineData(12345, "1-0---0")]
    public void ConvertFromNumberCorrectly(long input, string expectedValue)
    {
        var sut = new SnafuConverter(input);
        Assert.Equal(expectedValue, sut.Value);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new SnafuConverter(4890);
        Assert.Equal("2=-1=0", sut.Value);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new SnafuConverter(30535047052797);
        Assert.Equal("2=001=-2=--0212-22-2", sut.Value);
    }
}
