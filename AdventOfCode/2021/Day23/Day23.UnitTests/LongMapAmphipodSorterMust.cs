using System.Net;
using System;
using Xunit;
using Day23.Logic;

namespace Day23.UnitTests
{
    public class LongMapAmphipodSorterMust
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
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => AmphipodSorter2.CreateLongMapSorter(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_LONG_MAP)]
        [InlineData(REAL_LONG_MAP)]
        public void LoadMapCorrectly(string map)
        {
            var sut = AmphipodSorter2.CreateLongMapSorter(map);
            Assert.Equal(map, sut.ToString());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidLongMap(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => AmphipodSorter2.CreateLongMapSorter(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_LONG_MAP)]
        [InlineData(REAL_LONG_MAP)]
        public void LoadLongMapCorrectly(string map)
        {
            var sut = AmphipodSorter2.CreateLongMapSorter(map);
            Assert.Equal(map, sut.ToString());
        }

        [Fact]
        public void WalkStep1InSolution()
        {
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
            var exception = Assert.Throws<ArgumentException>(() => sut.MoveAmphipodFrom(startingPoint).To(target).OrFail());
            Assert.Equal("Could not complete path", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenThereIsNoAmphipodAtStartingPoint()
        {
          var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
          var exception = Assert.Throws<ArgumentException>(() => sut.MoveAmphipodFrom(0).To(1).OrFail());
          Assert.Equal("No amphipod there", exception.Message);
        }

        [Fact]
        public void NeverReachFinalPosition_WhenInitialAmphipodListIsInvalid()
        {
          var flag = false;
          var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
          sut.OnFinalPositionReached((_, __) => flag = true);
          sut.WalkWith(new [] { 0, 1 }, new System.Collections.Generic.List<(int From, int To)>());
          Assert.False(flag);
        }

        [Fact]
        public void ReturnTrue_WhenAskedToMoveToSamePlaceAsOrigin()
        {
          var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
          var stayInSamePlace = sut.MoveAmphipodFrom(5).To(5).AndStopOnFail();
          Assert.True(stayInSamePlace);
        }

        [Fact]
        public void StayInSamePosition_WhenCannotStartWalkingToTarget()
        {
            var sut = AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
            var sut =  AmphipodSorter2.CreateLongMapSorter(SAMPLE_LONG_MAP);
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
        public void SolveFirstTrivialSample()
        {
          var sut = Walker.CreateWithLongMapSupport(@"#############
#...........#
###D#C#B#A###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########");
          sut.Run();
          Assert.Equal(8470, sut.LowestTotalCost);
        }

        [Fact]
        public void SolveSecondTrivialSample()
        {
          var sut = Walker.CreateWithLongMapSupport(@"#############
#...........#
###A#B#C#D###
  #A#B#D#C#
  #A#B#C#D#
  #A#B#C#D#
  #########");
          sut.Run();
          Assert.Equal(11200, sut.LowestTotalCost);
        }

        [Fact]
        public void SolveThirdTrivialSample()
        {
          var sut = Walker.CreateWithLongMapSupport(@"#############
#...........#
###A#B#C#D###
  #B#A#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########");
          sut.Run();
          Assert.Equal(112, sut.LowestTotalCost);
        }

        [Fact(Skip = "slow test, 40 second in total on Github")]
        public void SolveFourthTrivialSample()
        {
          var sut = Walker.CreateWithLongMapSupport(@"#############
#...........#
###D#A#A#C###
  #B#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########");
          sut.Run();
          Assert.Equal(8465, sut.LowestTotalCost);
        }

        // Taking too long still (42m, 9m). Commenting til better solution found
        [Fact(Skip = "slow test, 42m on own machine")]
        public void SolveFirstSample()
        {
            var sut = Walker.CreateWithLongMapSupport(SAMPLE_LONG_MAP);
            sut.Run();
            Assert.Equal(44169, sut.LowestTotalCost);
        }

        [Fact(Skip = "slow test, 2h on own machine")]
        public void SolveSecondPuzzle()
        {
            var sut = Walker.CreateWithLongMapSupport(REAL_LONG_MAP);
            sut.Run();
            Assert.Equal(56324, sut.LowestTotalCost);
        }
    }
}