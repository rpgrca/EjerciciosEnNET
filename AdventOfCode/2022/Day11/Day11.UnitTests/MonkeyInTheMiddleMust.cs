using Day11.Logic;
using static Day11.UnitTests.Constants;

namespace Day11.UnitTests;

public class MonkeyInTheMiddleMust
{
    [Fact]
    public void LoadSampleMonkeyItemsCorrectly()
    {
        var sut = MonkeyInTheMiddle.CreateForFirstPuzzle(SAMPLE_INPUT, 0);
        Assert.Collection(sut.Monkeys,
            m0 =>
            {
                Assert.Collection(m0.Items,
                    i1 => Assert.Equal(79, i1),
                    i2 => Assert.Equal(98, i2));
            },
            m1 =>
            {
                Assert.Collection(m1.Items,
                    i1 => Assert.Equal(54, i1),
                    i2 => Assert.Equal(65, i2),
                    i3 => Assert.Equal(75, i3),
                    i4 => Assert.Equal(74, i4));
            },
            m2 =>
            {
                Assert.Collection(m2.Items,
                    i1 => Assert.Equal(79, i1),
                    i2 => Assert.Equal(60, i2),
                    i3 => Assert.Equal(97, i3));
            },
            m3 =>
            {
                Assert.Collection(m3.Items,
                    i1 => Assert.Equal(74, i1));
            });
    }

    [Fact]
    public void ExecuteRoundCorrectly()
    {
        var sut = MonkeyInTheMiddle.CreateForFirstPuzzle(SAMPLE_INPUT, 1);
        Assert.Collection(sut.Monkeys,
            m0 => Assert.Equal(new[] { 20, 23, 27, 26 }, m0.Items),
            m1 => Assert.Equal(new[] { 2080, 25, 167, 207, 401, 1046 }, m1.Items),
            m2 => Assert.Empty(m2.Items),
            m3 => Assert.Empty(m3.Items));
    }
}