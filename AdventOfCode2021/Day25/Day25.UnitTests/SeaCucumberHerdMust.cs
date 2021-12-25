using System;
using Xunit;
using Day25.Logic;
using static Day25.UnitTests.Constants;

namespace Day25.UnitTests
{
    public class SeaCucumberHerdMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidSeafloor(string invalidSeafloor)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SeaCucumberHerd(invalidSeafloor));
            Assert.Equal("Invalid seafloor", exception.Message);
        }

        [Fact]
        public void BeInitializedCorrectly_WhenLoadingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            Assert.Equal(9, sut.Height);
            Assert.Equal(10, sut.Width);
        }

        [Fact]
        public void BeInitializedCorrectly_WhenLoadingRealMap()
        {
            var sut = new SeaCucumberHerd(REAL_SEAFLOOR);
            Assert.Equal(137, sut.Height);
            Assert.Equal(139, sut.Width);
        }

        [Fact]
        public void MoveCucumbersOnePositionEast()
        {
            var sut = new SeaCucumberHerd("...>>>>>...");
            sut.MoveEast();

            Assert.Equal("...>>>>.>..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersTwoPositionsEast()
        {
            var sut = new SeaCucumberHerd("...>>>>>...");
            sut.MoveEast();
            sut.MoveEast();

            Assert.Equal("...>>>.>.>.", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersOnePositionSout()
        {
            var sut = new SeaCucumberHerd(@".
.
.
v
v
v
v
v
.
.
.");
            sut.MoveSouth();
            Assert.Equal(@".
.
.
v
v
v
v
.
v
.
.", sut.ToString());
        }

        [Fact]
        public void ExecuteOneStep()
        {
            var sut = new SeaCucumberHerd(@"..........
.>v....v..
.......>..
..........");

            sut.Step(1);
            Assert.Equal(@"..........
.>........
..v....v>.
..........", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersOneStepToTheOtherSideOfMap_WhenReachingAborder()
        {
            var sut = new SeaCucumberHerd(@"...>...
.......
......>
v.....>
......>
.......
..vvv..");

            sut.Step(1);
            Assert.Equal(@"..vv>..
.......
>......
v.....>
>......
.......
....v..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersTwoStepsToTheOtherSideOfMap_WhenReachingAborder()
        {
            var sut = new SeaCucumberHerd(@"...>...
.......
......>
v.....>
......>
.......
..vvv..");

            sut.Step(2);
            Assert.Equal(@"....v>.
..vv...
.>.....
......>
v>.....
.......
.......", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersThreeStepsToTheOtherSideOfMap_WhenReachingAborder()
        {
            var sut = new SeaCucumberHerd(@"...>...
.......
......>
v.....>
......>
.......
..vvv..");
            sut.Step(3);
            Assert.Equal(@"......>
..v.v..
..>v...
>......
..>....
v......
.......", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFourStepsToTheOtherSideOfMap_WhenReachingAborder()
        {
            var sut = new SeaCucumberHerd(@"...>...
.......
......>
v.....>
......>
.......
..vvv..");
            sut.Step(4);
            Assert.Equal(@">......
..v....
..>.v..
.>.v...
...>...
.......
v......", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersOneStep_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(1);
            Assert.Equal(@"....>.>v.>
v.v>.>v.v.
>v>>..>v..
>>v>v>.>.v
.>v.v...v.
v>>.>vvv..
..v...>>..
vv...>>vv.
>.v.v..v.v", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersTwoStep_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(2);
            Assert.Equal(@">.v.v>>..v
v.v.>>vv..
>v>.>.>.v.
>>v>v.>v>.
.>..v....v
.>v>>.v.v.
v....v>v>.
.vv..>>v..
v>.....vv.", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersThreeStep_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(3);
            Assert.Equal(@"v>v.v>.>v.
v...>>.v.v
>vv>.>v>..
>>v>v.>.v>
..>....v..
.>.>v>v..v
..v..v>vv>
v.v..>>v..
.v>....v..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFourStep_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(4);
            Assert.Equal(@"v>..v.>>..
v.v.>.>.v.
>vv.>>.v>v
>>.>..v>.>
..v>v...v.
..>>.>vv..
>.v.vv>v.v
.....>>vv.
vvv>...v..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFiveStep_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(5);
            Assert.Equal(@"vv>...>v>.
v.v.v>.>v.
>.v.>.>.>v
>v>.>..v>>
..v>v.v...
..>.>>vvv.
.>...v>v..
..v.v>>v.v
v.v.>...v.", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersTenSteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(10);
            Assert.Equal(@"..>..>>vv.
v.....>>.v
..v.v>>>v>
v>.>v.>>>.
..v>v.vv.v
.v.>>>.v..
v.v..>v>..
..v...>v.>
.vv..v>vv.", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersTwentySteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(20);
            Assert.Equal(@"v>.....>>.
>vv>.....v
.>v>v.vv>>
v>>>v.>v.>
....vv>v..
.v.>>>vvv.
..v..>>vv.
v.v...>>.v
..v.....v>", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersThirtySteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(30);
            Assert.Equal(@".vv.v..>>>
v>...v...>
>.v>.>vv.>
>v>.>.>v.>
.>..v.vv..
..v>..>>v.
....v>..>v
v.v...>vv>
v.v...>vvv", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFortySteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(40);
            Assert.Equal(@">>v>v..v..
..>>v..vv.
..>>>v.>.v
..>>>>vvv>
v.....>...
v.v...>v>>
>vv.....v>
.>v...v.>v
vvv.v..v.>", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFiftySteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(50);
            Assert.Equal(@"..>>v>vv.v
..v.>>vv..
v.>>v>>v..
..>>>>>vv.
vvv....>vv
..v....>>>
v>.......>
.vv>....v>
.>v.vv.v..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFiftyFiveSteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(55);
            Assert.Equal(@"..>>v>vv..
..v.>>vv..
..>>v>>vv.
..>>>>>vv.
v......>vv
v>v....>>v
vvv...>..>
>vv.....>.
.>v.vv.v..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFiftySixSteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(56);
            Assert.Equal(@"..>>v>vv..
..v.>>vv..
..>>v>>vv.
..>>>>>vv.
v......>vv
v>v....>>v
vvv....>.>
>vv......>
.>v.vv.v..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFiftySevenSteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(57);
            Assert.Equal(@"..>>v>vv..
..v.>>vv..
..>>v>>vv.
..>>>>>vv.
v......>vv
v>v....>>v
vvv.....>>
>vv......>
.>v.vv.v..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersFiftyEightSteps_WhenUsingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.Step(58);
            Assert.Equal(@"..>>v>vv..
..v.>>vv..
..>>v>>vv.
..>>>>>vv.
v......>vv
v>v....>>v
vvv.....>>
>vv......>
.>v.vv.v..", sut.ToString());
        }

        [Fact]
        public void SolveFirstSample()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            sut.StepUntilNoMovement();
            Assert.Equal(58, sut.StepCount);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new SeaCucumberHerd(REAL_SEAFLOOR);
            sut.StepUntilNoMovement();
            Assert.Equal(334, sut.StepCount);
        }
    }
}