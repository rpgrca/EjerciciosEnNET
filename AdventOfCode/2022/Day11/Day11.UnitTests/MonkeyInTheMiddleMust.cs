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

    [Theory]
    [MemberData(nameof(SampleRoundsFeeder))]
    public void ExecuteOneRoundCorrectly(int rounds, int[] items0, int[] items1)
    {
        var sut = MonkeyInTheMiddle.CreateForFirstPuzzle(SAMPLE_INPUT, rounds);
        Assert.Collection(sut.Monkeys,
            m0 => Assert.Equal(items0, m0.Items),
            m1 => Assert.Equal(items1, m1.Items),
            m2 => Assert.Empty(m2.Items),
            m3 => Assert.Empty(m3.Items));
    }

    public static IEnumerable<object[]> SampleRoundsFeeder()
    {
        yield return new object[] { 1, new[] { 20, 23, 27, 26 }, new[] { 2080, 25, 167, 207, 401, 1046 } };
        yield return new object[] { 2, new[] { 695, 10, 71, 135, 350 }, new[] { 43, 49, 58, 55, 362 } };
        yield return new object[] { 3, new[] { 16, 18, 21, 20, 122 }, new[] { 1468, 22, 150, 286, 739 } };
        yield return new object[] { 4, new[] { 491, 9, 52, 97, 248, 34 }, new[] { 39, 45, 43, 258 } };
        yield return new object[] { 5, new[] { 15, 17, 16, 88, 1037 }, new[] { 20, 110, 205, 524, 72 } };
        yield return new object[] { 6, new[] { 8, 70, 176, 26, 34 }, new[] { 481, 32, 36, 186, 2190 } };
        yield return new object[] { 7, new[] { 162, 12, 14, 64, 732, 17 }, new[] { 148, 372, 55, 72 } };
        yield return new object[] { 8, new[] { 51, 126, 20, 26, 136 }, new[] { 343, 26, 30, 1546, 36 } };
        yield return new object[] { 9, new[] { 116, 10, 12, 517, 14 }, new[] { 108, 267, 43, 55, 288 } };
        yield return new object[] { 10, new[] { 91, 16, 20, 98 }, new[] { 481, 245, 22, 26, 1092, 30 } };
        yield return new object[] { 15, new[] { 83, 44, 8, 184, 9, 20, 26, 102 }, new[] { 110, 36 } };
        yield return new object[] { 20, new[] { 10, 12, 14, 26, 34 }, new[] { 245, 93, 53, 199, 115 } };
    }
}