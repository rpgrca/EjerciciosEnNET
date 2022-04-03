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
            var exception = Assert.Throws<ArgumentException>(() => new ReactorCore3(invalidSteps));
            Assert.Equal("Invalid steps", exception.Message);
        }

        [Theory]
        [InlineData("on x=10..12,y=10..12,z=10..12", 27)]
        [InlineData(@"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13", 46)]
        [InlineData(@"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13
off x=9..11,y=9..11,z=9..11", 26)]
        [InlineData(@"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13
off x=9..11,y=9..11,z=9..11
on x=10..10,y=10..10,z=10..10", 25)]
        public void BeInitializedCorrectly(string steps, int expectedCount)
        {
            var sut = new ReactorCore3(steps);
            Assert.Equal(expectedCount, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test1()
        {
            var sut = new ReactorCore3(@"on x=-5..47,y=-31..22,z=-19..33
on x=-44..5,y=-27..21,z=-14..35");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test2()
        {
            var sut = new ReactorCore3(
@"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..22,z=-19..33
on x=-5..5,y=-27..21,z=-14..35
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test3()
        {
            var sut = new ReactorCore3(
@"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..-27,z=-19..33
on x=-5..5,y=-27..21,z=-19..35
on x=-5..5,y=21..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test4()
        {
            var sut = new ReactorCore3(
@"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..-28,z=-19..33
on x=-5..5,y=-27..21,z=-14..35
on x=-5..5,y=-27..21,z=-19..33
on x=-5..5,y=22..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test5()
        {
            var sut = new ReactorCore3(
                @"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..-28,z=-19..33
on x=-5..5,y=-27..21,z=-19..-15
on x=-5..5,y=-27..21,z=-14..33
on x=-5..5,y=-27..21,z=34..35
on x=-5..5,y=22..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");

            Assert.Equal(248314, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test7()
        {
            var sut = new ReactorCore3(@"on x=-44..5,y=-27..21,z=-14..35
on x=-49..-1,y=-11..42,z=-10..38");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test8()
        {
            var sut = new ReactorCore3(@"on x=-49..-45,y=-11..42,z=-10..38
on x=-44..-1,y=-27..21,z=-14..35
on x=-44..-1,y=-11..42,z=-10..38
on x=0..5,y=-27..21,z=-14..35");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test9()
        {
            var sut = new ReactorCore3(@"on x=-49..-45,y=-11..42,z=-10..38
on x=-44..-1,y=-27..-12,z=-14..35
on x=-44..-1,y=-11..21,z=-14..35
on x=-44..-1,y=-11..21,z=-10..38
on x=-44..-1,y=22..42,z=-10..38
on x=0..5,y=-27..21,z=-14..35");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void DetectNoOverlaps()
        {
            var sut = new ReactorCore3(@"on x=-49..-45,y=-11..42,z=-10..38
on x=-44..-1,y=-27..-12,z=-14..35
on x=-44..-1,y=-11..21,z=-14..-11
on x=-44..-1,y=-11..21,z=-10..35
on x=-44..-1,y=-11..21,z=36..38
on x=-44..-1,y=22..42,z=-10..38
on x=0..5,y=-27..21,z=-14..35");
            Assert.Equal(185362, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test10()
        {
            var sut = new ReactorCore3(@"on x=-49..-1,y=-11..42,z=-10..38
on x=-20..34,y=-40..6,z=-44..1");
            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test11()
        {
            var sut = new ReactorCore3(@"on x=-49..-21,y=-11..42,z=-10..38
on x=-20..-1,y=-11..42,z=-10..38
on x=-20..-1,y=-40..6,z=-44..1
on x=0..34,y=-40..6,z=-44..1");

            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test12()
        {
            var sut = new ReactorCore3(@"on x=-49..-21,y=-11..42,z=-10..38
on x=-20..-1,y=-40..-12,z=-44..1
on x=-20..-1,y=-11..6,z=-10..38
on x=-20..-1,y=-11..6,z=-44..1
on x=-20..-1,y=7..42,z=-10..38
on x=0..34,y=-40..6,z=-44..1");

            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test13()
        {
            var sut = new ReactorCore3(@"on x=-49..-21,y=-11..42,z=-10..38
on x=-20..-1,y=-40..-12,z=-44..1
on x=-20..-1,y=-11..6,z=-44..-11
on x=-20..-1,y=-11..6,z=-10..1
on x=-20..-1,y=-11..6,z=2..38
on x=-20..-1,y=7..42,z=-10..38
on x=0..34,y=-40..6,z=-44..1");

            Assert.Equal(244244, sut.GetTurnedOnCubesCount());
        }

        [Theory]
        [InlineData(@"on x=-20..34,y=-40..6,z=-44..1
on x=26..39,y=40..50,z=-2..11", 121066)]
        [InlineData(@"off x=26..39,y=40..50,z=-2..11
on x=-41..5,y=-41..6,z=-36..8", 101520)]
        public void DetectNonOverlappedCubes(string core, int expectedCubes)
        {
            var sut = new ReactorCore3(core);
            Assert.Equal(expectedCubes, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test14()
        {
            var sut = new ReactorCore3(@"on x=-43..-42,y=-45..-28,z=7..25
on x=-41..-33,y=-45..-42,z=7..25
on x=-41..-33,y=-41..-28,z=-36..6
on x=-41..-33,y=-41..-28,z=7..8
on x=-41..-33,y=-41..-28,z=9..25
on x=-41..-33,y=-27..6,z=-36..8
on x=-32..5,y=-41..6,z=-36..8");
            Assert.Equal(105030, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test15()
        {
            var sut = new ReactorCore3(@"on x=-43..-34,y=-45..-28,z=7..25
on x=-33..-33,y=-45..-33,z=7..25
on x=-33..-33,y=-32..-28,z=-34..6
on x=-33..-33,y=-32..-28,z=7..11
on x=-33..-33,y=-32..-28,z=12..25
on x=-33..-33,y=-27..19,z=-34..11
on x=-32..15,y=-32..19,z=-34..11");
            Assert.Equal(120945, sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test16()
        {
            var original = new ReactorCore3(@"on x=-5..47,y=-31..22,z=-19..33
on x=-49..-1,y=-11..42,z=-10..38");
            var sut = new ReactorCore3(@"on x=-49..-6,y=-11..42,z=-10..38
on x=-5..-1,y=-31..-12,z=-19..33
on x=-5..-1,y=-11..22,z=-19..-11
on x=-5..-1,y=-11..22,z=-10..33
on x=-5..-1,y=-11..22,z=34..38
on x=-5..-1,y=23..42,z=-10..38
on x=0..47,y=-31..22,z=-19..33");
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test17()
        {
            var original = new ReactorCore3(@"on x=-5..47,y=-31..22,z=-19..33
on x=-20..34,y=-40..6,z=-44..1");
            var sut = new ReactorCore3(@"on x=-20..-6,y=-40..6,z=-44..1
on x=-5..34,y=-40..-32,z=-44..1
on x=-5..34,y=-31..6,z=-44..-20
on x=-5..34,y=-31..6,z=-19..1
on x=-5..34,y=-31..6,z=2..33
on x=-5..34,y=7..22,z=-19..33
on x=35..47,y=-31..22,z=-19..33");
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test18()
        {
            var original = new ReactorCore3(@"on x=-5..47,y=-31..22,z=-19..33
on x=-41..5,y=-41..6,z=-36..8");
            var sut = new ReactorCore3(@"on x=-41..-6,y=-41..6,z=-36..8
on x=-5..5,y=-41..-32,z=-36..8
on x=-5..5,y=-31..6,z=-36..-20
on x=-5..5,y=-31..6,z=-19..8
on x=-5..5,y=-31..6,z=9..33
on x=-5..5,y=7..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33");
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void Test19()
        {
            var original = new ReactorCore3(@"on x=-5..47,y=-31..22,z=-19..33
on x=-33..15,y=-32..19,z=-34..11");
            var sut = new ReactorCore3(@"on x=-33..-6,y=-32..19,z=-34..11
on x=-5..15,y=-32..-32,z=-34..11
on x=-5..15,y=-31..19,z=-34..-20
on x=-5..15,y=-31..19,z=-19..11
on x=-5..15,y=-31..19,z=12..33
on x=-5..15,y=20..22,z=-19..33
on x=16..47,y=-31..22,z=-19..33");
            Assert.Equal(235693, original.GetTurnedOnCubesCount());
            Assert.Equal(original.GetTurnedOnCubesCount(), sut.GetTurnedOnCubesCount());
        }

        [Fact]
        public void TurnOnCubes_WhenTheyAreInA50PositiveNegativeRange()
        {
            var sut = new ReactorCore3(SAMPLE_INSTRUCTIONS);
            Assert.Equal(39769202357779, sut.GetTurnedOnCubesCount());
        }
    }
}