using Day6.Logic;
using static Day6.UnitTests.Constants;

namespace Day6.UnitTests;

public class TuningTroubleMust
{
    [Fact]
    public void ThrowException_WhenNoStartOfPacketIsDetected()
    {
        var exception = Assert.Throws<Exception>(() => new TuningTrouble("mjqj", 4));
        Assert.Equal("Could not find start of packet", exception.Message);
    }

    [Theory]
    [InlineData("jpqm", 4)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void DetectStartOfPacketCorrectly(string input, int expectedLength)
    {
        var sut = new TuningTrouble(input, 4);
        Assert.Equal(expectedLength, sut.ProcessedLength);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new TuningTrouble(SAMPLE_INPUT, 4);
        Assert.Equal(7, sut.ProcessedLength);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new TuningTrouble(PUZZLE_INPUT, 4);
        Assert.Equal(1155, sut.ProcessedLength);
    }

    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void DetectStartOfMessageCorrectly(string input, int expectedLength)
    {
        var sut = new TuningTrouble(input, 14);
        Assert.Equal(expectedLength, sut.ProcessedLength);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new TuningTrouble(SAMPLE_INPUT, 14);
        Assert.Equal(19, sut.ProcessedLength);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new TuningTrouble(PUZZLE_INPUT, 14);
        Assert.Equal(2789, sut.ProcessedLength);
    }
}