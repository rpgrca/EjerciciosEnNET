using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests;

public class GrovePositioningSystemDecryptorMust
{
    [Fact]
    public void LoadEncryptedValuesCorrectly()
    {
        var sut = new GrovePositioningSystemDecryptor(SAMPLE_INPUT);
        Assert.Collection(sut.CircularList,
            o1 => Assert.Equal(1, o1.Value),
            o2 => Assert.Equal(2, o2.Value),
            o3 => Assert.Equal(-3, o3.Value),
            o4 => Assert.Equal(3, o4.Value),
            o5 => Assert.Equal(-2, o5.Value),
            o6 => Assert.Equal(0, o6.Value),
            o7 => Assert.Equal(4, o7.Value));
    }

    [Fact]
    public void MixFileCorrectly()
    {
        var sut = new GrovePositioningSystemDecryptor(SAMPLE_INPUT);
        sut.Mix(1);
        Assert.Collection(sut.CircularList,
            o1 => Assert.Equal(1, o1.Value),
            o2 => Assert.Equal(2, o2.Value),
            o3 => Assert.Equal(-3, o3.Value),
            o4 => Assert.Equal(4, o4.Value),
            o5 => Assert.Equal(0, o5.Value),
            o6 => Assert.Equal(3, o6.Value),
            o7 => Assert.Equal(-2, o7.Value));
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new GrovePositioningSystemDecryptor(SAMPLE_INPUT);
        sut.Mix(1);
        Assert.Equal(3, sut.SumOfThousands);
    }
}