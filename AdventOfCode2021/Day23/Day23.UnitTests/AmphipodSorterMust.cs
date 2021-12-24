using System;
using System.Collections.Generic;
using Day23.Logic;
using Xunit;

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
        public void Test1()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(5).To(0);
            Assert.Equal(@"#############
#B..........#
###.#C#B#D###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void WalkStep1InSolution()
        {
            var sut = new AmphipodSorter2(SAMPLE_LONG_MAP);
            sut.MoveAmphipodFrom(23).To(26);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
            sut.MoveAmphipodFrom(4).To(21);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
            sut.MoveAmphipodFrom(4).To(21);
            sut.MoveAmphipodFrom(3).To(7);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
            sut.MoveAmphipodFrom(4).To(21);
            sut.MoveAmphipodFrom(3).To(7);
            sut.MoveAmphipodFrom(1).To(3);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
            sut.MoveAmphipodFrom(4).To(21);
            sut.MoveAmphipodFrom(3).To(7);
            sut.MoveAmphipodFrom(1).To(3);
            sut.MoveAmphipodFrom(0).To(4);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
            sut.MoveAmphipodFrom(4).To(21);
            sut.MoveAmphipodFrom(3).To(7);
            sut.MoveAmphipodFrom(1).To(3);
            sut.MoveAmphipodFrom(0).To(4);
            sut.MoveAmphipodFrom(7).To(22);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
            sut.MoveAmphipodFrom(4).To(21);
            sut.MoveAmphipodFrom(3).To(7);
            sut.MoveAmphipodFrom(1).To(3);
            sut.MoveAmphipodFrom(0).To(4);
            sut.MoveAmphipodFrom(7).To(22);
            sut.MoveAmphipodFrom(25).To(5);
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
            sut.MoveAmphipodFrom(23).To(26);
            sut.MoveAmphipodFrom(22).To(0);
            sut.MoveAmphipodFrom(17).To(25);
            sut.MoveAmphipodFrom(16).To(19);
            sut.MoveAmphipodFrom(15).To(1);
            sut.MoveAmphipodFrom(11).To(15);
            sut.MoveAmphipodFrom(10).To(16);
            sut.MoveAmphipodFrom(9).To(13);
            sut.MoveAmphipodFrom(8).To(7);
            sut.MoveAmphipodFrom(13).To(8);
            sut.MoveAmphipodFrom(19).To(9);
            sut.MoveAmphipodFrom(25).To(10);
            sut.MoveAmphipodFrom(21).To(17);
            sut.MoveAmphipodFrom(20).To(25);
            sut.MoveAmphipodFrom(7).To(20);
            sut.MoveAmphipodFrom(5).To(11);
            sut.MoveAmphipodFrom(4).To(21);
            sut.MoveAmphipodFrom(3).To(7);
            sut.MoveAmphipodFrom(1).To(3);
            sut.MoveAmphipodFrom(0).To(4);
            sut.MoveAmphipodFrom(7).To(22);
            sut.MoveAmphipodFrom(25).To(5);
            sut.MoveAmphipodFrom(26).To(23);
            Assert.Equal(@"#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########", sut.ToString());
            Assert.Equal(44169, sut.TotalCost);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Walker(REAL_LONG_MAP);
            sut.Run();
            Assert.Equal(0, sut.LowestTotalCost);
        }
    }

    public class Walker
    {
        private readonly string _map;

        public Walker(string map) =>
            _map = map;

        public IEnumerable<object> LowestTotalCost { get; internal set; }

        public void Run()
        {
            int[] initialAmphipods = { 5, 11, 17, 23 };
            var amphipodSorter = new AmphipodSorter2(_map);
            foreach (var amphipod in )
        }
    }
}