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
        [InlineData(20, @"3936556452
5686556806
4496555690
4448655580
4456865570
5680086577
7000009896
0000000344
6000000364
4600009543")]
        [InlineData(30, @"0643334118
4253334611
3374333458
2225333337
2229333338
2276733333
2754574565
5544458511
9444447111
7944446119")]
        [InlineData(40, @"6211111981
0421111119
0042111115
0003111115
0003111116
0065611111
0532351111
3322234597
2222222976
2222222762")]
        [InlineData(50, @"9655556447
4865556805
4486555690
4458655580
4574865570
5700086566
6000009887
8000000533
6800000633
5680000538")]
        [InlineData(60, @"2533334200
2743334640
2264333458
2225333337
2225333338
2287833333
3854573455
1854458611
1175447111
1115446111")]
        [InlineData(70, @"8211111164
0421111166
0042111114
0004211115
0000211116
0065611111
0532351111
7322235117
5722223475
4572222754")]
        [InlineData(80, @"1755555697
5965555609
4486555680
4458655580
4570865570
5700086566
7000008666
0000000990
0000000800
0000000000")]
        [InlineData(90, @"7433333522
2643333522
2264333458
2226433337
2222433338
2287833333
2854573333
4854458333
3387779333
3333333333")]
        [InlineData(100, @"0397666866
0749766918
0053976933
0004297822
0004229892
0053222877
0532222966
9322228966
7922286866
6789998766")]
        public void ExecuteStepsCorrectly_WhenUsingSampleMap(int steps, string expectedMap)
        {
            var sut = new OctopusCaveSimulation(SAMPLE_CAVE);
            sut.Step(steps);
            Assert.Equal(expectedMap, sut.GetMap());
        }

        [Theory]
        [InlineData(10, 204)]
        [InlineData(100, 1656)]
        public void CountFlashesCorrectly(int steps, int expectedFlashes)
        {
            var sut = new OctopusCaveSimulation(SAMPLE_CAVE);
            sut.Step(steps);
            Assert.Equal(expectedFlashes, sut.FlashCount);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new OctopusCaveSimulation(REAL_CAVE);
            sut.Step(100);
            Assert.Equal(1717, sut.FlashCount);
        }

        [Fact]
        public void FindFirstSynchronizedFlash_WhenUsingSampleData()
        {
            var sut = new OctopusCaveSimulation(SAMPLE_CAVE);
            Assert.Equal(195, sut.GetFirstSyncFlashStep());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new OctopusCaveSimulation(REAL_CAVE);
            Assert.Equal(476, sut.GetFirstSyncFlashStep());
        }
    }
}