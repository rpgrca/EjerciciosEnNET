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

    [Fact]
    public void Test1()
    {
        var sut = new GrovePositioningSystemDecryptor("0\n1\n2\n3\n4\n5\n6\n7\n8\n9\n10");
        sut.Mix(1);
        Assert.Collection(sut.CircularList,
            o1 => Assert.Equal(0, o1.Value),
            o2 => Assert.Equal(7, o2.Value),
            o3 => Assert.Equal(1, o3.Value),
            o4 => Assert.Equal(2, o4.Value),
            o5 => Assert.Equal(8, o5.Value),
            o6 => Assert.Equal(3, o6.Value),
            o7 => Assert.Equal(4, o7.Value),
            o8 => Assert.Equal(9, o8.Value),
            o9 => Assert.Equal(5, o9.Value),
            o10 => Assert.Equal(10, o10.Value),
            o11 => Assert.Equal(6, o11.Value));
    }

    [Fact]
    public void Test2()
    {
        var sut = new GrovePositioningSystemDecryptor("0\n-1\n-2\n-3\n-4\n-5\n-6\n-7\n-8\n-9\n-10");
        sut.Mix(1);
        Assert.Collection(sut.CircularList,
            o1 => Assert.Equal(0, o1.Value),
            o2 => Assert.Equal(-10, o2.Value),
            o3 => Assert.Equal(-9, o3.Value),
            o4 => Assert.Equal(-8, o4.Value),
            o5 => Assert.Equal(-7, o5.Value),
            o6 => Assert.Equal(-6, o6.Value),
            o7 => Assert.Equal(-5, o7.Value),
            o8 => Assert.Equal(-4, o8.Value),
            o9 => Assert.Equal(-3, o9.Value),
            o10 => Assert.Equal(-2, o10.Value),
            o11 => Assert.Equal(-1, o11.Value));
    }

    [Fact]
    public void WhenNumberEndsOnePositionAfterAfullCircle()
    {
        var sut = new GrovePositioningSystemDecryptor("0\n15\n6\n15\n-7\n15\n3");
        sut.Mix(1);
        Assert.Collection(sut.CircularList,
            o1 => Assert.Equal(0, o1.Value),
            o2 => Assert.Equal(15, o2.Value),
            o3 => Assert.Equal(-7, o3.Value),
            o4 => Assert.Equal(3, o4.Value),
            o5 => Assert.Equal(6, o5.Value),
            o6 => Assert.Equal(15, o6.Value),
            o7 => Assert.Equal(15, o7.Value));
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new GrovePositioningSystemDecryptor(PUZZLE_INPUT);
        sut.Mix(1);
        Assert.NotEqual(-7832, sut.SumOfThousands);
        Assert.True(4475 < sut.SumOfThousands);
        Assert.Equal(8721, sut.SumOfThousands);
    }
}