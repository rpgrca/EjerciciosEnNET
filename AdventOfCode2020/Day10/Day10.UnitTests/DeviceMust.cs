using Xunit;
using AdventOfCode2020.Day10.Logic;

namespace AdventOfCode2020.Day10.UnitTests
{
    public class DeviceMust
    {
        [Fact]
        public void Test1()
        {
            long[] joltages =
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            var sut = new Device(joltages);
            Assert.Equal(22, sut.BuiltInJoltageAdapterRating);
        }

        [Fact]
        public void Test2()
        {
            long[] joltages =
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            var sut = new Device(joltages);
            sut.CalculateChain();

            Assert.Collection(sut.ChainOfAdapters,
                p0 => Assert.Equal(0, p0),
                p1 => Assert.Equal(1, p1),
                p2 => Assert.Equal(4, p2),
                p3 => Assert.Equal(5, p3),
                p4 => Assert.Equal(6, p4),
                p5 => Assert.Equal(7, p5),
                p6 => Assert.Equal(10, p6),
                p7 => Assert.Equal(11, p7),
                p8 => Assert.Equal(12, p8),
                p9 => Assert.Equal(15, p9),
                p10 => Assert.Equal(16, p10),
                p11 => Assert.Equal(19, p11),
                p12 => Assert.Equal(22, p12));

            Assert.Equal(35, sut.DifferenceMultiplied);
        }

        [Fact]
        public void Test3()
        {
            long[] joltages =
            {
28,
33,
18,
42,
31,
14,
46,
20,
48,
47,
24,
23,
49,
45,
19,
38,
39,
11,
1,
32,
25,
35,
8,
17,
7,
9,
4,
2,
34,
10,
3
            };

            var sut = new Device(joltages);
            sut.CalculateChain();
            Assert.Equal(220, sut.DifferenceMultiplied);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            long[] data =
            {
                47,
                61,
                131,
                15,
                98,
                123,
                32,
                6,
                137,
                111,
                25,
                28,
                107,
                20,
                99,
                36,
                2,
                97,
                88,
                124,
                138,
                75,
                112,
                52,
                122,
                78,
                46,
                110,
                41,
                64,
                63,
                16,
                93,
                104,
                105,
                91,
                27,
                45,
                119,
                14,
                1,
                65,
                62,
                118,
                37,
                79,
                77,
                19,
                71,
                35,
                130,
                69,
                5,
                44,
                9,
                48,
                125,
                136,
                103,
                140,
                53,
                126,
                106,
                55,
                129,
                139,
                87,
                68,
                21,
                85,
                76,
                31,
                113,
                12,
                100,
                24,
                96,
                82,
                13,
                70,
                72,
                86,
                26,
                117,
                58,
                132,
                114,
                40,
                54,
                133,
                51,
                92
            };

            var sut = new Device(data);
            sut.CalculateChain();
            Assert.Equal(1700, sut.DifferenceMultiplied);
        }

        [Fact]
        public void Test4()
        {
            long[] joltages =
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            var sut = new Device(joltages);
            sut.CalculateChain();
            Assert.Equal(8, sut.CalculateAmountOfPossibleChains());
        }

        [Fact]
        public void Test5()
        {
            long[] joltages =
            {
28,
33,
18,
42,
31,
14,
46,
20,
48,
47,
24,
23,
49,
45,
19,
38,
39,
11,
1,
32,
25,
35,
8,
17,
7,
9,
4,
2,
34,
10,
3
            };

            var sut = new Device(joltages);
            sut.CalculateChain();
            Assert.Equal(19208, sut.CalculateAmountOfPossibleChains());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            long[] data =
            {
                47,
                61,
                131,
                15,
                98,
                123,
                32,
                6,
                137,
                111,
                25,
                28,
                107,
                20,
                99,
                36,
                2,
                97,
                88,
                124,
                138,
                75,
                112,
                52,
                122,
                78,
                46,
                110,
                41,
                64,
                63,
                16,
                93,
                104,
                105,
                91,
                27,
                45,
                119,
                14,
                1,
                65,
                62,
                118,
                37,
                79,
                77,
                19,
                71,
                35,
                130,
                69,
                5,
                44,
                9,
                48,
                125,
                136,
                103,
                140,
                53,
                126,
                106,
                55,
                129,
                139,
                87,
                68,
                21,
                85,
                76,
                31,
                113,
                12,
                100,
                24,
                96,
                82,
                13,
                70,
                72,
                86,
                26,
                117,
                58,
                132,
                114,
                40,
                54,
                133,
                51,
                92
            };

            var sut = new Device(data);
            sut.CalculateChain();
            Assert.Equal(12401793332096, sut.CalculateAmountOfPossibleChains());
        }
    }
}