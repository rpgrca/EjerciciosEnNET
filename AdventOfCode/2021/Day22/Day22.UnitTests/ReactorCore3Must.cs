using Xunit;
using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests
{

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