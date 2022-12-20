using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests;

public class GrovePositioningSystemDecryptorMust
{
    [Fact]
    public void Test1()
    {
        var sut = new GrovePositioningSystemDecryptor(SAMPLE_INPUT);
        Assert.Collection(sut.OriginalValues,
            o1 => Assert.Equal(1, o1),
            o2 => Assert.Equal(2, o2),
            o3 => Assert.Equal(-3, o3),
            o4 => Assert.Equal(3, o4),
            o5 => Assert.Equal(-2, o5),
            o6 => Assert.Equal(0, o6),
            o7 => Assert.Equal(4, o7));
    }
}