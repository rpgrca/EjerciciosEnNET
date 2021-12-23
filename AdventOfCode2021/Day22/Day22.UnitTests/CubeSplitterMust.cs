using Xunit;
using Day22.Logic;

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
        public void MustSplitCubeDismissingOverlaps_1_Reverse()
        {
            var sut = new CubeSplitter((-49, -1, -11, 42, -10, 38), (-44, 5, -27, 21, -14, 35));
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
        public void MustSplitCubeDismissingOverlaps_2_Reverse()
        {
            var sut = new CubeSplitter((-44, 5, -27, 21, -14, 35), (-5, 47, -31, 22, -19, 33));
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
        public void MustSplitCubeDismissingOverlaps_3_Reverse()
        {
            var sut = new CubeSplitter((-20, 34, -40, 6, -44, 1), (-49, -1, -11, 42, -10, 38));
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
        public void MustSplitCubeDismissingOverlaps_4_Reverse()
        {
            var sut = new CubeSplitter((26, 39, 40, 50, -2, 11), (-20, 34, -40, 6, -44, 1));
            Assert.Equal(@"on x=26..39,y=40..50,z=-2..11
on x=-20..34,y=-40..6,z=-44..1", sut.ToString());
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

        [Fact]
        public void MustSplitCubeDismissingOverlaps_5_Reverse()
        {
            var sut = new CubeSplitter((-43, -33, -45, -28, 7, 25), (-41, 5, -41, 6, -36, 8));
            Assert.Equal(@"on x=-43..-42,y=-45..-28,z=7..25
on x=-41..-33,y=-45..-42,z=7..25
on x=-41..-33,y=-41..-28,z=-36..6
on x=-41..-33,y=-41..-28,z=7..8
on x=-41..-33,y=-41..-28,z=9..25
on x=-41..-33,y=-27..6,z=-36..8
on x=-32..5,y=-41..6,z=-36..8", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_6()
        {
            var sut = new CubeSplitter((-43, -33, -45, -28, 7, 25), (-33, 15, -32, 19, -34, 11));
            Assert.Equal(@"on x=-43..-34,y=-45..-28,z=7..25
on x=-33..-33,y=-45..-33,z=7..25
on x=-33..-33,y=-32..-28,z=-34..6
on x=-33..-33,y=-32..-28,z=7..11
on x=-33..-33,y=-32..-28,z=12..25
on x=-33..-33,y=-27..19,z=-34..11
on x=-32..15,y=-32..19,z=-34..11", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_6_Reverse()
        {
            var sut = new CubeSplitter((-33, 15, -32, 19, -34, 11), (-43, -33, -45, -28, 7, 25));
            Assert.Equal(@"on x=-43..-34,y=-45..-28,z=7..25
on x=-33..-33,y=-45..-33,z=7..25
on x=-33..-33,y=-32..-28,z=-34..6
on x=-33..-33,y=-32..-28,z=7..11
on x=-33..-33,y=-32..-28,z=12..25
on x=-33..-33,y=-27..19,z=-34..11
on x=-32..15,y=-32..19,z=-34..11", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_7()
        {
            var sut = new CubeSplitter((-33, 15, -32, 19, -34, 11), (35, 47, -46, -34, -11, 5));
            Assert.Equal(@"on x=-33..15,y=-32..19,z=-34..11
on x=35..47,y=-46..-34,z=-11..5", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_7_Reverse()
        {
            var sut = new CubeSplitter((35, 47, -46, -34, -11, 5), (-33, 15, -32, 19, -34, 11));
            Assert.Equal(@"on x=35..47,y=-46..-34,z=-11..5
on x=-33..15,y=-32..19,z=-34..11", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_8()
        {
            var sut = new CubeSplitter((35, 47, -46, -34, -11, 5), (-14, 36, -6, 44, -16, 29));
            Assert.Equal(@"on x=35..47,y=-46..-34,z=-11..5
on x=-14..36,y=-6..44,z=-16..29", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_8_Reverse()
        {
            var sut = new CubeSplitter((-14, 36, -6, 44, -16, 29), (35, 47, -46, -34, -11, 5));
            Assert.Equal(@"on x=-14..36,y=-6..44,z=-16..29
on x=35..47,y=-46..-34,z=-11..5", sut.ToString());
        }


        [Fact]
        public void MustSplitCubeDismissingOverlaps_9()
        {
            var sut = new CubeSplitter((-5, 47, -31, 22, -19, 33), (-49, -1, -11, 42, -10, 38));
            Assert.Equal(@"on x=-49..-6,y=-11..42,z=-10..38
on x=-5..-1,y=-31..-12,z=-19..33
on x=-5..-1,y=-11..22,z=-19..-11
on x=-5..-1,y=-11..22,z=-10..33
on x=-5..-1,y=-11..22,z=34..38
on x=-5..-1,y=23..42,z=-10..38
on x=0..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_9_Reverse()
        {
            var sut = new CubeSplitter((-49, -1, -11, 42, -10, 38), (-5, 47, -31, 22, -19, 33));
            Assert.Equal(@"on x=-49..-6,y=-11..42,z=-10..38
on x=-5..-1,y=-31..-12,z=-19..33
on x=-5..-1,y=-11..22,z=-19..-11
on x=-5..-1,y=-11..22,z=-10..33
on x=-5..-1,y=-11..22,z=34..38
on x=-5..-1,y=23..42,z=-10..38
on x=0..47,y=-31..22,z=-19..33", sut.ToString());
        }


        [Fact]
        public void MustSplitCubeDismissingOverlaps_10()
        {
            var sut = new CubeSplitter((-5, 47, -31, 22, -19, 33), (-20, 34, -40, 6, -44, 1));
            Assert.Equal(@"on x=-20..-6,y=-40..6,z=-44..1
on x=-5..34,y=-40..-32,z=-44..1
on x=-5..34,y=-31..6,z=-44..-20
on x=-5..34,y=-31..6,z=-19..1
on x=-5..34,y=-31..6,z=2..33
on x=-5..34,y=7..22,z=-19..33
on x=35..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_10_Reverse()
        {
            var sut = new CubeSplitter((-20, 34, -40, 6, -44, 1), (-5, 47, -31, 22, -19, 33));
            Assert.Equal(@"on x=-20..-6,y=-40..6,z=-44..1
on x=-5..34,y=-40..-32,z=-44..1
on x=-5..34,y=-31..6,z=-44..-20
on x=-5..34,y=-31..6,z=-19..1
on x=-5..34,y=-31..6,z=2..33
on x=-5..34,y=7..22,z=-19..33
on x=35..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_11()
        {
            var sut = new CubeSplitter((-5, 47, -31, 22, -19, 33), (26, 39, 40, 50, -2, 11));
            Assert.Equal(@"on x=-5..47,y=-31..22,z=-19..33
on x=26..39,y=40..50,z=-2..11", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_11_Reverse()
        {
            var sut = new CubeSplitter((26, 39, 40, 50, -2, 11), (-5, 47, -31, 22, -19, 33));
            Assert.Equal(@"on x=26..39,y=40..50,z=-2..11
on x=-5..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_12()
        {
            var sut = new CubeSplitter((-5, 47, -31, 22, -19, 33), (-41, 5, -41, 6, -36, 8));
            Assert.Equal(@"on x=-41..-6,y=-41..6,z=-36..8
on x=-5..5,y=-41..-32,z=-36..8
on x=-5..5,y=-31..6,z=-36..-20
on x=-5..5,y=-31..6,z=-19..8
on x=-5..5,y=-31..6,z=9..33
on x=-5..5,y=7..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_13()
        {
            var sut = new CubeSplitter((-41, 5, -41, 6, -36, 8), (-5, 47, -31, 22, -19, 33));
            Assert.Equal(@"on x=-41..-6,y=-41..6,z=-36..8
on x=-5..5,y=-41..-32,z=-36..8
on x=-5..5,y=-31..6,z=-36..-20
on x=-5..5,y=-31..6,z=-19..8
on x=-5..5,y=-31..6,z=9..33
on x=-5..5,y=7..22,z=-19..33
on x=6..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_14()
        {
            var sut = new CubeSplitter((-5, 47, -31, 22, -19, 33), (-43, -33, -45, -28, 7, 25));
            Assert.Equal(@"on x=-5..47,y=-31..22,z=-19..33
on x=-43..-33,y=-45..-28,z=7..25", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_15()
        {
            var sut = new CubeSplitter((-43, -33, -45, -28, 7, 25), (-5, 47, -31, 22, -19, 33));
            Assert.Equal(@"on x=-43..-33,y=-45..-28,z=7..25
on x=-5..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_16()
        {
            var sut = new CubeSplitter((-5, 47, -31, 22, -19, 33), (-33, 15, -32, 19, -34, 11));
            Assert.Equal(@"on x=-33..-6,y=-32..19,z=-34..11
on x=-5..15,y=-32..-32,z=-34..11
on x=-5..15,y=-31..19,z=-34..-20
on x=-5..15,y=-31..19,z=-19..11
on x=-5..15,y=-31..19,z=12..33
on x=-5..15,y=20..22,z=-19..33
on x=16..47,y=-31..22,z=-19..33", sut.ToString());
        }

        [Fact]
        public void MustSplitCubeDismissingOverlaps_17()
        {
            var sut = new CubeSplitter((-33, 15, -32, 19, -34, 11),(-5, 47, -31, 22, -19, 33));
            Assert.Equal(@"on x=-33..-6,y=-32..19,z=-34..11
on x=-5..15,y=-32..-32,z=-34..11
on x=-5..15,y=-31..19,z=-34..-20
on x=-5..15,y=-31..19,z=-19..11
on x=-5..15,y=-31..19,z=12..33
on x=-5..15,y=20..22,z=-19..33
on x=16..47,y=-31..22,z=-19..33", sut.ToString());
        }
    }
}