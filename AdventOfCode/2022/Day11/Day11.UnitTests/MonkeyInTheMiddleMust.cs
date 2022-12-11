using Day11.Logic;
using static Day11.UnitTests.Constants;

namespace Day11.UnitTests;

public class MonkeyInTheMiddleMust
{
    [Fact]
    public void LoadSampleMonkeyItemsCorrectly()
    {
        var sut = MonkeyInTheMiddle.CreateForFirstPuzzle(SAMPLE_INPUT);
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
}