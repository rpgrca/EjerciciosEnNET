using System;
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
    }
}