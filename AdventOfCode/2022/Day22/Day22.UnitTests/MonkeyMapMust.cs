using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests;

public class MonkeyMapMust
{
    [Fact]
    public void LoadMapCorrectly1()
    {
        var sut = new MonkeyMap(SAMPLE_INPUT);
        Assert.Equal(12, sut.Height);
        Assert.Equal(16, sut.Width);
    }
}