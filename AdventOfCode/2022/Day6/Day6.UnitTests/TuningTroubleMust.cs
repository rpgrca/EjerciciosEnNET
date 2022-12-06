using Day6.Logic;

namespace Day6.UnitTests;

public class TuningTroubleMust
{
    [Fact]
    public void ThrowException_WhenNoStartOfPacketIsDetected()
    {
        var exception = Assert.Throws<Exception>(() => new TuningTrouble("mjqj"));
        Assert.Equal("Could not find start of packet", exception.Message);
    }

    [Theory]
    [InlineData("jpqm", 4)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    public void DetectStartOfPacketCorrectly(string input, int expectedLength)
    {
        var sut = new TuningTrouble(input);
        Assert.Equal(expectedLength, sut.ProcessedForStartOfPacket);
    }
}