using System;
using Xunit;
using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests
{
    public class ReactorCoreMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidSteps(string invalidSteps)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ReactorCore(invalidSteps));
            Assert.Equal("Invalid steps", exception.Message);
        }

        [Theory]
        [InlineData("on x=10..12,y=10..12,z=10..12", 27)]
        [InlineData(@"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13", 46)]
        [InlineData(@"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13
off x=9..11,y=9..11,z=9..11", 38)]
        [InlineData(@"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13
off x=9..11,y=9..11,z=9..11
on x=10..10,y=10..10,z=10..10", 39)]
        public void BeInitializedCorrectly(string steps, int expectedCount)
        {
            var sut = new ReactorCore(steps);
            Assert.Equal(expectedCount, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test1()
        {
            var sut = new ReactorCore(@"on x=-5..47,y=-31..22,z=-19..33
on x=-44..5,y=-27..21,z=-14..35");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test2()
        {
            var sut = new ReactorCore(
@"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..22,z=-19..33
on x=-5..5,y=-27..21,z=-14..35
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test3()
        {
            var sut = new ReactorCore(
@"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..-27,z=-19..33
on x=-5..5,y=-27..21,z=-19..35
on x=-5..5,y=21..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test4()
        {
            var sut = new ReactorCore(
@"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..-28,z=-19..33
on x=-5..5,y=-27..21,z=-14..35
on x=-5..5,y=-27..21,z=-19..33
on x=-5..5,y=22..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test5()
        {
            var sut = new ReactorCore(
                @"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..-28,z=-19..33
on x=-5..5,y=-27..21,z=-19..-15
on x=-5..5,y=-27..21,z=-14..33
on x=-5..5,y=-27..21,z=34..35
on x=-5..5,y=22..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");

            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test7()
        {
            var sut = new ReactorCore(@"on x=-44..5,y=-27..21,z=-14..35
on x=-49..-1,y=-11..42,z=-10..38");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test8()
        {
            var sut = new ReactorCore(@"on x=-49..-45,y=-11..42,z=-10..38
on x=-44..-1,y=-27..21,z=-14..35
on x=-44..-1,y=-11..42,z=-10..38
on x=0..5,y=-27..21,z=-14..35");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test9()
        {
            var sut = new ReactorCore(@"on x=-49..-45,y=-11..42,z=-10..38
on x=-44..-1,y=-27..-12,z=-14..35
on x=-44..-1,y=-11..21,z=-14..35
on x=-44..-1,y=-11..21,z=-10..38
on x=-44..-1,y=22..42,z=-10..38
on x=0..5,y=-27..21,z=-14..35");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void DetectNoOverlaps()
        {
            var sut = new ReactorCore(@"on x=-49..-45,y=-11..42,z=-10..38
on x=-44..-1,y=-27..-12,z=-14..35
on x=-44..-1,y=-11..21,z=-14..-11
on x=-44..-1,y=-11..21,z=-10..35
on x=-44..-1,y=-11..21,z=36..38
on x=-44..-1,y=22..42,z=-10..38
on x=0..5,y=-27..21,z=-14..35");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test10()
        {
            var sut = new ReactorCore(@"on x=-49..-1,y=-11..42,z=-10..38
on x=-20..34,y=-40..6,z=-44..1");
            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test11()
        {
            var sut = new ReactorCore(@"on x=-49..-21,y=-11..42,z=-10..38
on x=-20..-1,y=-11..42,z=-10..38
on x=-20..-1,y=-40..6,z=-44..1
on x=0..34,y=-40..6,z=-44..1");

            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test12()
        {
            var sut = new ReactorCore(@"on x=-49..-21,y=-11..42,z=-10..38
on x=-20..-1,y=-40..-12,z=-44..1
on x=-20..-1,y=-11..6,z=-10..38
on x=-20..-1,y=-11..6,z=-44..1
on x=-20..-1,y=7..42,z=-10..38
on x=0..34,y=-40..6,z=-44..1");

            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
            Assert.True(sut.HasOverlaps);
        }

        [Fact]
        public void Test13()
        {
            var sut = new ReactorCore(@"on x=-49..-21,y=-11..42,z=-10..38
on x=-20..-1,y=-40..-12,z=-44..1
on x=-20..-1,y=-11..6,z=-44..-11
on x=-20..-1,y=-11..6,z=-10..1
on x=-20..-1,y=-11..6,z=2..38
on x=-20..-1,y=7..42,z=-10..38
on x=0..34,y=-40..6,z=-44..1");

            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
            Assert.False(sut.HasOverlaps);
        }

        [Theory]
        [InlineData(@"on x=-20..34,y=-40..6,z=-44..1
on x=26..39,y=40..50,z=-2..11", 121066)]
        [InlineData(@"off x=26..39,y=40..50,z=-2..11
on x=-41..5,y=-41..6,z=-36..8", 101520)]
        public void DetectNonOverlappedCubes(string core, int expectedCubes)
        {
            var sut = new ReactorCore(core);
            Assert.Equal(expectedCubes, sut.GetTurnedOnCubesCount());
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test14()
        {
            var sut = new ReactorCore(@"on x=-43..-42,y=-45..-28,z=7..25
on x=-41..-33,y=-45..-42,z=7..25
on x=-41..-33,y=-41..-28,z=-36..6
on x=-41..-33,y=-41..-28,z=7..8
on x=-41..-33,y=-41..-28,z=9..25
on x=-41..-33,y=-27..6,z=-36..8
on x=-32..5,y=-41..6,z=-36..8");
            Assert.Equal(105030, sut.GetTurnedOnCubesCount());
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test15()
        {
            var sut = new ReactorCore(@"on x=-43..-34,y=-45..-28,z=7..25
on x=-33..-33,y=-45..-33,z=7..25
on x=-33..-33,y=-32..-28,z=-34..6
on x=-33..-33,y=-32..-28,z=7..11
on x=-33..-33,y=-32..-28,z=12..25
on x=-33..-33,y=-27..19,z=-34..11
on x=-32..15,y=-32..19,z=-34..11");
            Assert.Equal(120945, sut.GetTurnedOnCubesCount());
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test16()
        {
            var original = new ReactorCore(@"on x=-5..47,y=-31..22,z=-19..33
on x=-49..-1,y=-11..42,z=-10..38");
            var sut = new ReactorCore(@"on x=-49..-6,y=-11..42,z=-10..38
on x=-5..-1,y=-31..-12,z=-19..33
on x=-5..-1,y=-11..22,z=-19..-11
on x=-5..-1,y=-11..22,z=-10..33
on x=-5..-1,y=-11..22,z=34..38
on x=-5..-1,y=23..42,z=-10..38
on x=0..47,y=-31..22,z=-19..33");
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
            Assert.True(original.HasOverlaps);
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test17()
        {
            var original = new ReactorCore(@"on x=-5..47,y=-31..22,z=-19..33
on x=-20..34,y=-40..6,z=-44..1");
            var sut = new ReactorCore(@"on x=-20..-6,y=-40..6,z=-44..1
on x=-5..34,y=-40..-32,z=-44..1
on x=-5..34,y=-31..6,z=-44..-20
on x=-5..34,y=-31..6,z=-19..1
on x=-5..34,y=-31..6,z=2..33
on x=-5..34,y=7..22,z=-19..33
on x=35..47,y=-31..22,z=-19..33");
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
            Assert.True(original.HasOverlaps);
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test18()
        {
            var original = new ReactorCore(@"on x=-5..47,y=-31..22,z=-19..33
on x=-41..5,y=-41..6,z=-36..8");
            var sut = new ReactorCore(@"on x=-41..-6,y=-41..6,z=-36..8
on x=-5..5,y=-41..-32,z=-36..8
on x=-5..5,y=-31..6,z=-36..-20
on x=-5..5,y=-31..6,z=-19..8
on x=-5..5,y=-31..6,z=9..33
on x=-5..5,y=7..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
            Assert.True(original.HasOverlaps);
            Assert.False(sut.HasOverlaps);
        }

        [Fact]
        public void Test19()
        {
            var original = new ReactorCore(@"on x=-5..47,y=-31..22,z=-19..33
on x=-33..15,y=-32..19,z=-34..11");
            var sut = new ReactorCore(@"on x=-33..-6,y=-32..19,z=-34..11
on x=-5..15,y=-32..-32,z=-34..11
on x=-5..15,y=-31..19,z=-34..-20
on x=-5..15,y=-31..19,z=-19..11
on x=-5..15,y=-31..19,z=12..33
on x=-5..15,y=20..22,z=-19..33
on x=16..47,y=-31..22,z=-19..33");
            Assert.Equal(235693, original.GetTurnedOnCubesCount());
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
            Assert.True(original.HasOverlaps);
            Assert.False(sut.HasOverlaps);
        }

        /*[Fact]
        public void Test20()
        {
            var sut = new ReactorCore2(@"on x=-5..47,y=-31..22,z=-19..33
on x=-44..5,y=-27..21,z=-14..35
on x=-49..-1,y=-11..42,z=-10..38
on x=-20..34,y=-40..6,z=-44..1
off x=26..39,y=40..50,z=-2..11
on x=-41..5,y=-41..6,z=-36..8
off x=-43..-33,y=-45..-28,z=7..25
on x=-33..15,y=-32..19,z=-34..11
off x=35..47,y=-46..-34,z=-11..5
on x=-14..36,y=-6..44,z=-16..29");

            Assert.Equal(235693, sut.GetTurnedOnCubesCount());
        }*/

/*
        [Fact]
        public void TurnOnCubes_WhenTheyAreInA50PositiveNegativeRange()
        {
            var sut = new ReactorCore(SAMPLE_INSTRUCTIONS);
            Assert.Equal(590784, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new ReactorCore(REAL_INSTRUCTIONS);
            Assert.Equal(647062, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void TurnOnCubes_WhenTheyAreInA50PositiveNegativeRangeWithBiggerSample()
        {
            var sut = new ReactorCore(SAMPLE_REBOOT_INSTRUCTIONS);
            Assert.Equal(474140, sut.GetTurnedOnCubesCount());
        }*/
    }

    public class ReactorCore3Must
    {
        [Fact]
        public void BeInitializedCorrectly()
        {
            var sut = new ReactorCore3(@"on x=-20..26,y=-36..17,z=-47..7
on x=-20..33,y=-21..23,z=-26..28
on x=-22..28,y=-29..23,z=-38..16
on x=-46..7,y=-6..46,z=-50..-1
on x=-49..1,y=-3..46,z=-24..28
on x=2..47,y=-22..22,z=-23..27
on x=-27..23,y=-28..26,z=-21..29
on x=-39..5,y=-6..47,z=-3..44
on x=-30..21,y=-8..43,z=-13..34
on x=-22..26,y=-27..20,z=-29..19
off x=-48..-32,y=26..41,z=-47..-37
on x=-12..35,y=6..50,z=-50..-2
off x=-48..-32,y=-32..-16,z=-15..-5
on x=-18..26,y=-33..15,z=-7..46
off x=-40..-22,y=-38..-28,z=23..41
on x=-16..35,y=-41..10,z=-47..6
off x=-32..-23,y=11..30,z=-14..3
on x=-49..-5,y=-3..45,z=-29..18
off x=18..30,y=-20..-8,z=-3..13
on x=-41..9,y=-7..43,z=-33..15");
            Assert.Equal(590784, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void CalculateTurnedOnCubes_WhenUsingSmallSectionOfRealData()
        {
            var sut = new ReactorCore3(@"on x=-37..10,y=-38..8,z=-18..35
on x=-4..42,y=-31..21,z=-2..45
on x=-46..4,y=-37..14,z=-41..4
on x=-3..47,y=-48..0,z=-7..44
on x=-13..36,y=-39..12,z=-31..16
on x=-37..8,y=-38..9,z=-38..11
on x=-35..16,y=-12..39,z=-34..15
on x=-9..45,y=-49..4,z=-45..-1
on x=-8..46,y=-33..13,z=-22..32
on x=-18..36,y=2..47,z=-16..38
off x=17..31,y=19..33,z=27..43
on x=-29..15,y=-4..46,z=-21..23
off x=34..46,y=3..16,z=29..41
on x=-11..34,y=-33..15,z=-1..48
off x=37..46,y=28..40,z=-38..-28
on x=-49..3,y=-19..34,z=-48..5
off x=-7..7,y=4..17,z=-21..-9
on x=-14..34,y=-49..5,z=-27..21
off x=31..43,y=-30..-19,z=-35..-22
on x=-5..43,y=-15..30,z=-10..36");
            Assert.Equal(647062, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void CalculateTurnedOnCubes_WhenUsingPortionOfSampleData()
        {
            var sut = new ReactorCore3(@"on x=-5..47,y=-31..22,z=-19..33
on x=-44..5,y=-27..21,z=-14..35
on x=-49..-1,y=-11..42,z=-10..38
on x=-20..34,y=-40..6,z=-44..1
off x=26..39,y=40..50,z=-2..11
on x=-41..5,y=-41..6,z=-36..8
off x=-43..-33,y=-45..-28,z=7..25
on x=-33..15,y=-32..19,z=-34..11
off x=35..47,y=-46..-34,z=-11..5
on x=-14..36,y=-6..44,z=-16..29");
            Assert.Equal(474140, sut.GetTurnedOnCubesCount());
        }

        [Fact(Skip = "slow test, 1s on own machine, 14s on Github")]
        public void CalculateTurnedOnCubes_WhenUsingSampleData()
        {
            var sut = new ReactorCore3(SAMPLE_REBOOT_INSTRUCTIONS);
            Assert.Equal(2758514936282235, sut.GetTurnedOnCubesCount());
        }

        [Fact(Skip = "slow test, 2m 49s on own machine")]
        public void CalculateTurnedOnCubes_WhenUsingRealData()
        {
            var sut = new ReactorCore3(REAL_INSTRUCTIONS);
            Assert.Equal(1319618626668022, sut.GetTurnedOnCubesCount());
        }
    }
}