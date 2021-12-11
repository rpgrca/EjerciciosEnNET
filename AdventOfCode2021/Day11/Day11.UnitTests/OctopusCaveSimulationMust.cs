using System;
using Xunit;
using Day11.Logic;
using static Day11.UnitTests.Constants;

namespace Day11.UnitTests
{
    public class OctopusCaveSimulationMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ThrowException_WhenInitializedWithInvalidInput(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new OctopusCaveSimulation(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }

        [Theory]
        [InlineData(0, 0, 5)]
        [InlineData(9, 9, 6)]
        public void LoadsInputCorrectly(int x, int y, int expectedPower)
        {
            var sut = new OctopusCaveSimulation(SAMPLE_CAVE);
            Assert.Equal(expectedPower, sut.GetOctopusEnergyLevelAt(x, y));
        }

        [Theory]
        [InlineData(1, "34543\n40004\n50005\n40004\n34543")]
        [InlineData(2, "45654\n51115\n61116\n51115\n45654")]
        public void ExecuteStepsCorrectly(int steps, string expectedMap)
        {
            const string map = "11111\n19991\n19191\n19991\n11111";

            var sut = new OctopusCaveSimulation(map);
            sut.Step(steps);
            Assert.Equal(expectedMap, sut.GetMap());
        }

        [Theory]
        [InlineData(0, SAMPLE_CAVE)]
        [InlineData(1, @"6594254334
3856965822
6375667284
7252447257
7468496589
5278635756
3287952832
7993992245
5957959665
6394862637")]
        [InlineData(2, @"8807476555
5089087054
8597889608
8485769600
8700908800
6600088989
6800005943
0000007456
9000000876
8700006848")]
        [InlineData(3, @"0050900866
8500800575
9900000039
9700000041
9935080063
7712300000
7911250009
2211130000
0421125000
0021119000")]
        [InlineData(4, @"2263031977
0923031697
0032221150
0041111163
0076191174
0053411122
0042361120
5532241122
1532247211
1132230211")]
        [InlineData(5, @"4484144000
2044144000
2253333493
1152333274
1187303285
1164633233
1153472231
6643352233
2643358322
2243341322")]
        [InlineData(6, @"5595255111
3155255222
3364444605
2263444496
2298414396
2275744344
2264583342
7754463344
3754469433
3354452433")]

        [InlineData(7, @"6707366222
4377366333
4475555827
3496655709
3500625609
3509955566
3486694453
8865585555
4865580644
4465574644")]
        [InlineData(8, @"7818477333
5488477444
5697666949
4608766830
4734946730
4740097688
6900007564
0000009666
8000004755
6800007755")]
        [InlineData(9, @"9060000644
7800000976
6900000080
5840000082
5858000093
6962400000
8021250009
2221130009
9111128097
7911119976")]
        [InlineData(10, @"0481112976
0031112009
0041112504
0081111406
0099111306
0093511233
0442361130
5532252350
0532250600
0032240000")]
        public void ExecuteStepsCorrectly_WhenUsingSampleMap(int steps, string expectedMap)
        {
            var sut = new OctopusCaveSimulation(SAMPLE_CAVE);
            sut.Step(steps);
            Assert.Equal(expectedMap, sut.GetMap());
        }

        [Fact]
        public void CountFlashesCorrectly()
        {
            var sut = new OctopusCaveSimulation(SAMPLE_CAVE);
            sut.Step(10);
            Assert.Equal(204, sut.FlashCount);
        }
    }
}