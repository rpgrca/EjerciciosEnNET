using System;
using Xunit;
using Day23.Logic;

namespace Day23.UnitTests
{
    public class AmphipodSorterMust
    {
        private const string SAMPLE_MAP = @"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########";

        private const string REAL_MAP = @"#############
#...........#
###B#D#C#A###
  #C#D#B#A#
  #########";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new AmphipodSorter(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_MAP)]
        [InlineData(REAL_MAP)]
        public void LoadMapCorrectly(string map)
        {
            var sut = new AmphipodSorter(map);
            Assert.Equal(map, sut.ToString());
        }

        [Fact]
        public void IndividualizeEveryAmphipod()
        {
            var sut = new AmphipodSorter(SAMPLE_MAP);
            Assert.Equal((3, 3, 1, 'A'), sut.GetAmphipodAt(3, 3));
        }

        [Fact]
        public void ThrowException_WhenAskingForAnAmphipodThatIsNotThere()
        {
            var sut = new AmphipodSorter(SAMPLE_MAP);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetAmphipodAt(0, 0));
            Assert.Equal("No amphipod there", exception.Message);
        }

        [Fact]
        public void MakeAmphipodMoveNorth()
        {
            var sut = new AmphipodSorter(SAMPLE_MAP);
            sut.MoveAmphipodFrom(7, 2).To(7, 1);
            Assert.Equal((7, 1, 10, 'B'), sut.GetAmphipodAt(7, 1));
            Assert.Equal(10, sut.TotalCost);
        }

        [Fact]
        public void MakeAmphipodMoveNorthThenWestThrice()
        {
            var sut = new AmphipodSorter(SAMPLE_MAP);
            sut.MoveAmphipodFrom(7, 2).To(7, 1).To(6, 1).To(5, 1).To(4, 1);
            Assert.Equal((4, 1, 10, 'B'), sut.GetAmphipodAt(4, 1));
            Assert.Equal(40, sut.TotalCost);
        }
    }

    public class AmphipodSorter2Must
    {
        private const string SAMPLE_LONG_MAP = @"#############
#...........#
###B#C#B#D###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########";

        private const string REAL_LONG_MAP = @"#############
#...........#
###B#D#C#A###
  #D#C#B#A#
  #D#B#A#C#
  #C#D#B#A#
  #########";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidLongMap(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new AmphipodSorter2(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_LONG_MAP)]
        [InlineData(REAL_LONG_MAP)]
        public void LoadLongMapCorrectly(string map)
        {
            var sut = new AmphipodSorter2(map);
            Assert.Equal(map, sut.ToString());
        }

        [Fact]
        public void WalkStep1InSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            Assert.Equal(@"#############
#..........D#
###B#C#B#.###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk2StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            Assert.Equal(@"#############
#A.........D#
###B#C#B#.###
  #D#C#B#.#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk3StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            Assert.Equal(@"#############
#A........BD#
###B#C#.#.###
  #D#C#B#.#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk4StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            Assert.Equal(@"#############
#A......B.BD#
###B#C#.#.###
  #D#C#.#.#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk5StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            Assert.Equal(@"#############
#AA.....B.BD#
###B#C#.#.###
  #D#C#.#.#
  #D#B#.#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk6StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            Assert.Equal(@"#############
#AA.....B.BD#
###B#.#.#.###
  #D#C#.#.#
  #D#B#C#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk7StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            Assert.Equal(@"#############
#AA.....B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#B#C#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk8StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            Assert.Equal(@"#############
#AA...B.B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#.#C#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk9StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            Assert.Equal(@"#############
#AA.D.B.B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#.#C#C#
  #A#.#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk10StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            Assert.Equal(@"#############
#AA.D...B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#.#C#C#
  #A#B#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk11StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            Assert.Equal(@"#############
#AA.D.....BD#
###B#.#.#.###
  #D#.#C#.#
  #D#B#C#C#
  #A#B#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk12StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            Assert.Equal(@"#############
#AA.D......D#
###B#.#.#.###
  #D#B#C#.#
  #D#B#C#C#
  #A#B#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk13StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            Assert.Equal(@"#############
#AA.D......D#
###B#.#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk14StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            Assert.Equal(@"#############
#AA.D.....AD#
###B#.#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#.#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk15StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            Assert.Equal(@"#############
#AA.......AD#
###B#.#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk16StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            Assert.Equal(@"#############
#AA.......AD#
###.#B#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk17StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            sut.MoveAmphipodFrom(4).To(21).OrFail();
            Assert.Equal(@"#############
#AA.......AD#
###.#B#C#.###
  #.#B#C#.#
  #D#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk18StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            sut.MoveAmphipodFrom(4).To(21).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            Assert.Equal(@"#############
#AA.D.....AD#
###.#B#C#.###
  #.#B#C#.#
  #.#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk19StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            sut.MoveAmphipodFrom(4).To(21).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(1).To(3).OrFail();
            Assert.Equal(@"#############
#A..D.....AD#
###.#B#C#.###
  #.#B#C#.#
  #A#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk20StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            sut.MoveAmphipodFrom(4).To(21).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(1).To(3).OrFail();
            sut.MoveAmphipodFrom(0).To(4).OrFail();
            Assert.Equal(@"#############
#...D.....AD#
###.#B#C#.###
  #A#B#C#.#
  #A#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk21StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            sut.MoveAmphipodFrom(4).To(21).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(1).To(3).OrFail();
            sut.MoveAmphipodFrom(0).To(4).OrFail();
            sut.MoveAmphipodFrom(7).To(22).OrFail();
            Assert.Equal(@"#############
#.........AD#
###.#B#C#.###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk22StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            sut.MoveAmphipodFrom(4).To(21).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(1).To(3).OrFail();
            sut.MoveAmphipodFrom(0).To(4).OrFail();
            sut.MoveAmphipodFrom(7).To(22).OrFail();
            sut.MoveAmphipodFrom(25).To(5).OrFail();
            Assert.Equal(@"#############
#..........D#
###A#B#C#.###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk23StepsInSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26).OrFail();
            sut.MoveAmphipodFrom(22).To(0).OrFail();
            sut.MoveAmphipodFrom(17).To(25).OrFail();
            sut.MoveAmphipodFrom(16).To(19).OrFail();
            sut.MoveAmphipodFrom(15).To(1).OrFail();
            sut.MoveAmphipodFrom(11).To(15).OrFail();
            sut.MoveAmphipodFrom(10).To(16).OrFail();
            sut.MoveAmphipodFrom(9).To(13).OrFail();
            sut.MoveAmphipodFrom(8).To(7).OrFail();
            sut.MoveAmphipodFrom(13).To(8).OrFail();
            sut.MoveAmphipodFrom(19).To(9).OrFail();
            sut.MoveAmphipodFrom(25).To(10).OrFail();
            sut.MoveAmphipodFrom(21).To(17).OrFail();
            sut.MoveAmphipodFrom(20).To(25).OrFail();
            sut.MoveAmphipodFrom(7).To(20).OrFail();
            sut.MoveAmphipodFrom(5).To(11).OrFail();
            sut.MoveAmphipodFrom(4).To(21).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(1).To(3).OrFail();
            sut.MoveAmphipodFrom(0).To(4).OrFail();
            sut.MoveAmphipodFrom(7).To(22).OrFail();
            sut.MoveAmphipodFrom(25).To(5).OrFail();
            sut.MoveAmphipodFrom(26).To(23).OrFail();
            Assert.Equal(@"#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
            Assert.Equal(44169, sut.TotalCost);
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(5, 16)]
        [InlineData(5, 2)]
        [InlineData(23, 2)]
        [InlineData(23, 5)]
        public void ReturnToStartingPoint_WhenCannotWalkToTarget(int startingPoint, int target)
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(startingPoint).To(target).OrReturnBack();
            Assert.Equal(@"#############
#...........#
###B#C#B#D###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(5, 16)]
        [InlineData(5, 2)]
        [InlineData(23, 2)]
        [InlineData(23, 5)]
        public void ThrowException_WhenCannotWalkToTarget(int startingPoint, int target)
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            var exception = Assert.Throws<ArgumentException>(() => sut.MoveAmphipodFrom(startingPoint).To(target).OrFail());
            Assert.Equal("Could not complete path", exception.Message);
        }

        [Fact]
        public void StayInSamePosition_WhenCannotStartWalkingToTarget()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(5).To(4).AndStopOnFail();
            Assert.Equal(@"#############
#...........#
###B#C#B#D###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void StayInLastPosition_WhenCannotWalkToTarget()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(5).To(11).AndStopOnFail();
            Assert.Equal(@"#############
#...B.......#
###.#C#B#D###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());

        }

        [Fact]
        public void SolveFirstSample()
        {
            var sut = new Walker(SAMPLE_LONG_MAP);
            sut.Run();
            Assert.Equal(44169, sut.LowestTotalCost);
        }
    }

    public class Walker
    {
        private readonly string _map;

        public Walker(string map) =>
            _map = map;

        public int LowestTotalCost { get; internal set; } = int.MaxValue;

        public void Run()
        {
            var amphipodSorter = new AmphipodSorter2(_map);
            amphipodSorter.OnFinalPositionReached((s, c) =>
            {
              if (s.TotalCost < LowestTotalCost)
              {
                LowestTotalCost = s.TotalCost;
                Console.WriteLine($"Found new lowest cost of {LowestTotalCost} on step {c}");
              }
            });

            var amphipodes = amphipodSorter.GetAmphipods();
            amphipodSorter.WalkWith(amphipodes);
        }
    }
}