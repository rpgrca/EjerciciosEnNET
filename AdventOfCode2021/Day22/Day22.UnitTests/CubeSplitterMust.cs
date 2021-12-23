using Day22.Logic;
using Xunit;

namespace Day22.UnitTests
{
    public class CubeSplitterMust
    {
        [Fact]
        public void MustSplitCubeDismissingOverlaps_1()
        {
            var sut = new CubeSplitter((-44, 5, -27, 21, -14, 35), (-49, -1, -11, 42, -10, 38));
            Assert.Equal(@"on x=-49..-45,y=-11..42,z=-10..38
on x=-44..-1,y=-27..-12,z=-14..35
on x=-44..-1,y=-11..21,z=-14..-11
on x=-44..-1,y=-11..21,z=-10..35
on x=-44..-1,y=-11..21,z=36..38
on x=-44..-1,y=22..42,z=-10..38
on x=0..5,y=-27..21,z=-14..35", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_2()
        {
            var sut = new CubeSplitter((-5, 47, -31, 22, -19, 33), (-44, 5, -27, 21, -14, 35));
            Assert.Equal(@"on x=-44..-6,y=-27..21,z=-14..35
on x=-5..5,y=-31..-28,z=-19..33
on x=-5..5,y=-27..21,z=-19..-15
on x=-5..5,y=-27..21,z=-14..33
on x=-5..5,y=-27..21,z=34..35
on x=-5..5,y=22..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_3()
        {
            var sut = new CubeSplitter((-49, -1, -11, 42, -10, 38), (-20, 34, -40, 6, -44, 1));
            Assert.Equal(@"on x=-49..-21,y=-11..42,z=-10..38
on x=-20..-1,y=-40..-12,z=-44..1
on x=-20..-1,y=-11..6,z=-44..-11
on x=-20..-1,y=-11..6,z=-10..1
on x=-20..-1,y=-11..6,z=2..38
on x=-20..-1,y=7..42,z=-10..38
on x=0..34,y=-40..6,z=-44..1", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_4()
        {
            var sut = new CubeSplitter((-20, 34, -40, 6, -44, 1), (26, 39, 40, 50, -2, 11));
            Assert.Equal(@"on x=-20..34,y=-40..6,z=-44..1
on x=26..39,y=40..50,z=-2..11", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_5()
        {
            var sut = new CubeSplitter((-41, 5, -41, 6, -36, 8), (-43, -33, -45, -28, 7, 25));
            Assert.Equal(@"on x=-43..-42,y=-45..-28,z=7..25
on x=-41..-33,y=-45..-42,z=7..25
on x=-41..-33,y=-41..-28,z=-36..6
on x=-41..-33,y=-41..-28,z=7..8
on x=-41..-33,y=-41..-28,z=9..25
on x=-41..-33,y=-27..6,z=-36..8
on x=-32..5,y=-41..6,z=-36..8", sut.ToString());
        }

/*
        [Fact]
        public void MustSplitCubeDismissingOverlaps_3()
        {
            var sut = new CubeSplitter((10, 12, 10, 12, 10, 12), (11, 13, 11, 13, 11 ,13));
            var steps = sut.ToString();

            var reactorCore = new ReactorCore(steps);
            Assert.Equal(46, reactorCore.GetTurnedOnCubesCount());
            Assert.False(reactorCore.HasOverlaps);
        }*/
    }
}