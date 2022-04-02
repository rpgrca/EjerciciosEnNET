
using System;
using Xunit;
using Day23.Logic;

namespace Day23.UnitTests
{
    public class ShortMapAmphipodSorterMust
    {
        private const string SAMPLE_SHORT_MAP = @"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########";

        private const string REAL_SHORT_MAP = @"#############
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
            var exception = Assert.Throws<ArgumentException>(() => AmphipodSorter2.CreateShortMapSorter(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_SHORT_MAP)]
        [InlineData(REAL_SHORT_MAP)]
        public void LoadMapCorrectly(string map)
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(map);
            Assert.Equal(map, sut.ToString());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidLongMap(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => AmphipodSorter2.CreateShortMapSorter(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Fact]
        public void WalkStep1InSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            Assert.Equal(@"#############
#...B.......#
###B#C#.#D###
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk2StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            Assert.Equal(@"#############
#...B.......#
###B#.#C#D###
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk3StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            Assert.Equal(@"#############
#...B.D.....#
###B#.#C#D###
  #A#.#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk4StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            sut.MoveAmphipodFrom(5).To(6).OrFail();
            Assert.Equal(@"#############
#.....D.....#
###B#.#C#D###
  #A#B#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk5StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            sut.MoveAmphipodFrom(5).To(6).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            Assert.Equal(@"#############
#.....D.....#
###.#B#C#D###
  #A#B#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk6StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            sut.MoveAmphipodFrom(5).To(6).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(15).To(13).OrFail();
            Assert.Equal(@"#############
#.....D.D...#
###.#B#C#.###
  #A#B#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk7StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            sut.MoveAmphipodFrom(5).To(6).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(15).To(13).OrFail();
            sut.MoveAmphipodFrom(14).To(17).OrFail();
            Assert.Equal(@"#############
#.....D.D.A.#
###.#B#C#.###
  #A#B#C#.#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk8StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            sut.MoveAmphipodFrom(5).To(6).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(15).To(13).OrFail();
            sut.MoveAmphipodFrom(14).To(17).OrFail();
            sut.MoveAmphipodFrom(13).To(14).OrFail();
            Assert.Equal(@"#############
#.....D...A.#
###.#B#C#.###
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk9StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            sut.MoveAmphipodFrom(5).To(6).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(15).To(13).OrFail();
            sut.MoveAmphipodFrom(14).To(17).OrFail();
            sut.MoveAmphipodFrom(13).To(14).OrFail();
            sut.MoveAmphipodFrom(9).To(15).OrFail();
            Assert.Equal(@"#############
#.........A.#
###.#B#C#D###
  #A#B#C#D#
  #########", sut.ToString());
        }

        [Fact]
        public void Walk10StepsInSolution()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(11).To(5).OrFail();
            sut.MoveAmphipodFrom(7).To(11).OrFail();
            sut.MoveAmphipodFrom(6).To(9).OrFail();
            sut.MoveAmphipodFrom(5).To(6).OrFail();
            sut.MoveAmphipodFrom(3).To(7).OrFail();
            sut.MoveAmphipodFrom(15).To(13).OrFail();
            sut.MoveAmphipodFrom(14).To(17).OrFail();
            sut.MoveAmphipodFrom(13).To(14).OrFail();
            sut.MoveAmphipodFrom(9).To(15).OrFail();
            sut.MoveAmphipodFrom(17).To(3).OrFail();
            Assert.Equal(@"#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #########", sut.ToString());
           Assert.Equal(12521, sut.TotalCost);
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(3, 10)]
        [InlineData(15, 2)]
        [InlineData(15, 3)]
        public void ReturnToStartingPoint_WhenCannotWalkToTarget(int startingPoint, int target)
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(startingPoint).To(target).OrReturnBack();
            Assert.Equal(@"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(3, 10)]
        [InlineData(15, 2)]
        [InlineData(15, 3)]
        public void ThrowException_WhenCannotWalkToTarget(int startingPoint, int target)
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            var exception = Assert.Throws<ArgumentException>(() => sut.MoveAmphipodFrom(startingPoint).To(target).OrFail());
            Assert.Equal("Could not complete path", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenThereIsNoAmphipodAtStartingPoint()
        {
          var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
          var exception = Assert.Throws<ArgumentException>(() => sut.MoveAmphipodFrom(0).To(1).OrFail());
          Assert.Equal("No amphipod there", exception.Message);
        }

        [Fact]
        public void NeverReachFinalPosition_WhenInitialAmphipodListIsInvalid()
        {
          var flag = false;
          var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
          sut.OnFinalPositionReached((_, __) => flag = true);
          sut.WalkWith(new [] { 0, 1 }, new System.Collections.Generic.List<(int From, int To)>());
          Assert.False(flag);
        }

        [Fact]
        public void ReturnTrue_WhenAskedToMoveToSamePlaceAsOrigin()
        {
          var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
          var stayInSamePlace = sut.MoveAmphipodFrom(3).To(3).AndStopOnFail();
          Assert.True(stayInSamePlace);
        }

        [Fact]
        public void StayInSamePosition_WhenCannotStartWalkingToTarget()
        {
            var sut = AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(3).To(2).AndStopOnFail();
            Assert.Equal(@"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void StayInLastPosition_WhenCannotWalkToTarget()
        {
            var sut =  AmphipodSorter2.CreateShortMapSorter(SAMPLE_SHORT_MAP);
            sut.MoveAmphipodFrom(3).To(7).AndStopOnFail();
            Assert.Equal(@"#############
#...B.......#
###.#C#B#D###
  #A#D#C#A#
  #########", sut.ToString());
        }

        [Fact]
        public void SolveFirstTrivialSample()
        {
          var sut = Walker.CreateWithShortMapSupport(@"#############
#...........#
###D#C#B#A###
  #A#B#C#D#
  #########");
          sut.Run();
          Assert.Equal(8470, sut.LowestTotalCost);
        }

        [Fact]
        public void SolveSecondTrivialSample()
        {
          var sut = Walker.CreateWithShortMapSupport(@"#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #########");
          sut.Run();
          Assert.Equal(0, sut.LowestTotalCost);
        }

        [Fact]
        public void SolveFourthTrivialSample()
        {
          var sut = Walker.CreateWithShortMapSupport(@"#############
#...........#
###A#B#D#C###
  #A#B#C#D#
  #########");
          sut.Run();
          Assert.Equal(4600, sut.LowestTotalCost);
        }

        [Fact]
        public void SolveFirstShortSample()
        {
          var sut = Walker.CreateWithShortMapSupport(SAMPLE_SHORT_MAP);
          sut.Run();
          Assert.Equal(12521, sut.LowestTotalCost);
        }

/*
        // 5 min 14 seg
        [Fact]
        public void SolveFirstPuzzle()
        {
          var sut = Walker.CreateWithShortMapSupport(REAL_SHORT_MAP);
          sut.Run();
          Assert.Equal(15322, sut.LowestTotalCost);
        }

        // Taking too long still (42m, 9m). Commenting til better solution found
        [Fact]
        public void SolveFirstSample()
        {
            var sut = new Walker(SAMPLE_LONG_MAP);
            sut.Run();
            Assert.Equal(44169, sut.LowestTotalCost);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Walker(REAL_LONG_MAP);
            sut.Run();
            Assert.Equal(56324, sut.LowestTotalCost);
        }
*/
    }
}
