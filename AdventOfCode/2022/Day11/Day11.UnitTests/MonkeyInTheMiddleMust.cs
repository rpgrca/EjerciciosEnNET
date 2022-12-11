using Day11.Logic;
using static Day11.UnitTests.Constants;

namespace Day11.UnitTests;

public class MonkeyInTheMiddleMust
{
    [Fact]
    public void LoadSampleMonkeyItemsCorrectly()
    {
        var loader = new MonkeysLoader(SAMPLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, 0);
        Assert.Collection(sut.Monkeys,
            m0 =>
            {
                Assert.Collection(m0.Items,
                    i1 => Assert.Equal(79, i1.WorryLevel),
                    i2 => Assert.Equal(98, i2.WorryLevel));
            },
            m1 =>
            {
                Assert.Collection(m1.Items,
                    i1 => Assert.Equal(54, i1.WorryLevel),
                    i2 => Assert.Equal(65, i2.WorryLevel),
                    i3 => Assert.Equal(75, i3.WorryLevel),
                    i4 => Assert.Equal(74, i4.WorryLevel));
            },
            m2 =>
            {
                Assert.Collection(m2.Items,
                    i1 => Assert.Equal(79, i1.WorryLevel),
                    i2 => Assert.Equal(60, i2.WorryLevel),
                    i3 => Assert.Equal(97, i3.WorryLevel));
            },
            m3 =>
            {
                Assert.Collection(m3.Items,
                    i1 => Assert.Equal(74, i1.WorryLevel));
            });
    }

    [Theory]
    [MemberData(nameof(SampleRoundsFeeder))]
    public void ExecuteRoundsCorrectly(int rounds, long[] items0, long[] items1)
    {
        var loader = new MonkeysLoader(SAMPLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, rounds);
        Assert.Collection(sut.Monkeys,
            m0 => Assert.Equal(items0, m0.ItemsAsWorries),
            m1 => Assert.Equal(items1, m1.ItemsAsWorries),
            m2 => Assert.Empty(m2.Items),
            m3 => Assert.Empty(m3.Items));
    }

    public static IEnumerable<object[]> SampleRoundsFeeder()
    {
        yield return new object[] { 1, new long[] { 20, 23, 27, 26 }, new long[] { 2080, 25, 167, 207, 401, 1046 } };
        yield return new object[] { 2, new long[] { 695, 10, 71, 135, 350 }, new long[] { 43, 49, 58, 55, 362 } };
        yield return new object[] { 3, new long[] { 16, 18, 21, 20, 122 }, new long[] { 1468, 22, 150, 286, 739 } };
        yield return new object[] { 4, new long[] { 491, 9, 52, 97, 248, 34 }, new long[] { 39, 45, 43, 258 } };
        yield return new object[] { 5, new long[] { 15, 17, 16, 88, 1037 }, new long[] { 20, 110, 205, 524, 72 } };
        yield return new object[] { 6, new long[] { 8, 70, 176, 26, 34 }, new long[] { 481, 32, 36, 186, 2190 } };
        yield return new object[] { 7, new long[] { 162, 12, 14, 64, 732, 17 }, new long[] { 148, 372, 55, 72 } };
        yield return new object[] { 8, new long[] { 51, 126, 20, 26, 136 }, new long[] { 343, 26, 30, 1546, 36 } };
        yield return new object[] { 9, new long[] { 116, 10, 12, 517, 14 }, new long[] { 108, 267, 43, 55, 288 } };
        yield return new object[] { 10, new long[] { 91, 16, 20, 98 }, new long[] { 481, 245, 22, 26, 1092, 30 } };
        yield return new object[] { 15, new long[] { 83, 44, 8, 184, 9, 20, 26, 102 }, new long[] { 110, 36 } };
        yield return new object[] { 20, new long[] { 10, 12, 14, 26, 34 }, new long[] { 245, 93, 53, 199, 115 } };
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var loader = new MonkeysLoader(SAMPLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, 20);
        Assert.Equal(10605UL, sut.MonkeyBusiness);
    }
/*
    [Fact]
    public void LoadPuzzleMonkeyItemsCorrectly()
    {
        var loader = new MonkeysLoader(PUZZLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, 0);
        Assert.Collection(sut.Monkeys,
            m0 =>
            {
                Assert.Collection(m0.Items,
                    i1 => Assert.Equal(74, i1.WorryLevel),
                    i2 => Assert.Equal(73, i2.WorryLevel),
                    i3 => Assert.Equal(57, i3.WorryLevel),
                    i4 => Assert.Equal(77, i4.WorryLevel),
                    i5 => Assert.Equal(74, i5.WorryLevel));
                Assert.True(m0.Test(new Item(19)));
                Assert.False(m0.Test(new Item(20)));
                Assert.Equal(143, m0.Operation(new Item(13)).WorryLevel);
            },
            m1 =>
            {
                Assert.Collection(m1.Items,
                    i1 => Assert.Equal(99, i1),
                    i2 => Assert.Equal(77, i2),
                    i3 => Assert.Equal(79, i3));
                Assert.True(m1.Test(202));
                Assert.False(m1.Test(201));
                Assert.Equal(21, m1.Operation(13));
            },
            m2 =>
            {
                Assert.Collection(m2.Items,
                    i1 => Assert.Equal(64, i1),
                    i2 => Assert.Equal(67, i2),
                    i3 => Assert.Equal(50, i3),
                    i4 => Assert.Equal(96, i4),
                    i5 => Assert.Equal(89, i5),
                    i6 => Assert.Equal(82, i6),
                    i7 => Assert.Equal(82, i7));
                Assert.True(m2.Test(33));
                Assert.False(m2.Test(10));
                Assert.Equal(14, m2.Operation(13));
            },
            m3 =>
            {
                Assert.Collection(m3.Items, i1 => Assert.Equal(88, i1));
                Assert.True(m3.Test(34));
                Assert.False(m3.Test(12));
                Assert.Equal(91, m3.Operation(13));
            },
            m4 =>
            {
                Assert.Collection(m4.Items,
                    i1 => Assert.Equal(80, i1),
                    i2 => Assert.Equal(66, i2),
                    i3 => Assert.Equal(98, i3),
                    i4 => Assert.Equal(83, i4),
                    i5 => Assert.Equal(70, i5),
                    i6 => Assert.Equal(63, i6),
                    i7 => Assert.Equal(57, i7),
                    i8 => Assert.Equal(66, i8));
                Assert.True(m4.Test(52));
                Assert.False(m4.Test(12));
                Assert.Equal(17, m4.Operation(13));
            },
            m5 =>
            {
                Assert.Collection(m5.Items,
                    i1 => Assert.Equal(81, i1),
                    i2 => Assert.Equal(93, i2),
                    i3 => Assert.Equal(90, i3),
                    i4 => Assert.Equal(61, i4),
                    i5 => Assert.Equal(62, i5),
                    i6 => Assert.Equal(64, i6));
                Assert.True(m5.Test(49));
                Assert.False(m5.Test(50));
                Assert.Equal(20, m5.Operation(13));
            },
            m6 =>
            {
                Assert.Collection(m6.Items,
                    i1 => Assert.Equal(69, i1),
                    i2 => Assert.Equal(97, i2),
                    i3 => Assert.Equal(88, i3),
                    i4 => Assert.Equal(93, i4));
                Assert.True(m6.Test(25));
                Assert.False(m6.Test(169));
                Assert.Equal(169, m6.Operation(13));
            },
            m7 =>
            {
                Assert.Collection(m7.Items,
                    i1 => Assert.Equal(59, i1),
                    i2 => Assert.Equal(80, i2));
                Assert.True(m7.Test(88));
                Assert.False(m7.Test(86));
                Assert.Equal(19, m7.Operation(13));
            });
    }*/

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var loader = new MonkeysLoader(PUZZLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, 20);
        Assert.Equal(69918UL, sut.MonkeyBusiness);
    }

    [Theory]
    [InlineData(1, 2, 4, 3, 6)]
    [InlineData(2, 6, 10, 3, 10)]
    [InlineData(3, 12, 14, 3, 16)]
    [InlineData(4, 16, 20, 3, 20)]
    [InlineData(5, 22, 24, 4, 26)]
    [InlineData(6, 26, 30, 4, 30)]
    [InlineData(7, 33, 33, 4, 37)]
    [InlineData(8, 36, 40, 4, 40)]
    [InlineData(9, 43, 43, 4, 47)]
    [InlineData(10, 46, 50, 4, 50)]
    [InlineData(11, 54, 52, 5, 58)]
    [InlineData(12, 56, 60, 5, 60)]
    [InlineData(13, 64, 62, 5, 68)]
    [InlineData(14, 67, 69, 5, 71)]
    [InlineData(15, 74, 72, 6, 78)]
    //[InlineData(16, 78, 78, 6, 82)]
    [InlineData(17, 84, 82, 7, 88)]
    [InlineData(18, 89, 87, 7, 93)]
    [InlineData(19, 94, 92, 8, 98)]
    [InlineData(20, 99, 97, 8, 103)]
    [InlineData(1000, 5204, 4792, 199, 5192)]
    [InlineData(2000, 10419, 9577, 392, 10391)]
    [InlineData(3000, 15638, 14358, 587, 15593)]
    [InlineData(4000, 20858, 19138, 780, 20797)]
    [InlineData(5000, 26075, 23921, 974, 26000)]
    [InlineData(6000, 31294, 28702, 1165, 31204)]
    [InlineData(7000, 36508, 33488, 1360, 36400)]
    [InlineData(8000, 41728, 38268, 1553, 41606)]
    [InlineData(9000, 46945, 43051, 1746, 46807)]
    [InlineData(10000, 52166, 47830, 1938, 52013)]
    public void CalculateMonkeyActivityCorrectly(int rounds, ulong items0, ulong items1, ulong items2, ulong items3)
    {
        var loader = new MonkeysLoader(SAMPLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, rounds, 1);
        Assert.Collection(sut.Monkeys,
            m0 => Assert.Equal(items0, m0.ActivityLevel),
            m1 => Assert.Equal(items1, m1.ActivityLevel),
            m2 => Assert.Equal(items2, m2.ActivityLevel),
            m3 => Assert.Equal(items3, m3.ActivityLevel));
    }

    [Fact]
    public void SolveSecondSample()
    {
        var loader = new MonkeysLoader(SAMPLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, 10000, 1);
        Assert.Equal(2713310158, sut.MonkeyBusiness);
    }
/*
    [Fact]
    public void SolveSecondPuzzle()
    {
        var loader = new MonkeysLoader(PUZZLE_INPUT);
        var sut = new MonkeyInTheMiddle(loader.Monkeys, 10000, 1);
        Assert.True(16120642006UL < sut.MonkeyBusiness);
    }*/
}