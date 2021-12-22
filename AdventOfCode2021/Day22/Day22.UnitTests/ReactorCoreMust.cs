using System.Runtime.InteropServices;
using System;
using Xunit;
using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests
{
    public class ReactorCoreMustst
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
        }

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
}