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

    [Fact]
    public void Test1()
    {
        var sut = new TuningTrouble("jpqm");
        Assert.Equal(4, sut.ProcessedForStartOfPacket);
    }
}