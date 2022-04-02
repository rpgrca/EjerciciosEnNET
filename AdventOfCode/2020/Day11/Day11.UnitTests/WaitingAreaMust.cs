using System.Collections.Generic;
using Xunit;
using AdventOfCode2020.Day11.Logic;

namespace AdventOfCode2020.Day11.UnitTests
{
    public partial class WaitingAreaMust
    {
        [Theory]
        [InlineData(@"...
.L.
...", @"...
.#.
...")]
        [InlineData(@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL", @"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##")]
        [InlineData(@"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##", @"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##")]
        [InlineData(@"#.LL.L#.##
#LLLLLL.L#
L.L.L..L..
#LLL.LL.L#
#.LL.LL.LL
#.LLLL#.##
..L.L.....
#LLLLLLLL#
#.LLLLLL.L
#.#LLLL.##", @"#.##.L#.##
#L###LL.L#
L.#.#..#..
#L##.##.L#
#.##.LL.LL
#.###L#.##
..#.#.....
#L######L#
#.LL###L.L
#.#L###.##")]
        [InlineData(@"#.##.L#.##
#L###LL.L#
L.#.#..#..
#L##.##.L#
#.##.LL.LL
#.###L#.##
..#.#.....
#L######L#
#.LL###L.L
#.#L###.##", @"#.#L.L#.##
#LLL#LL.L#
L.L.L..#..
#LLL.##.L#
#.LL.LL.LL
#.LL#L#.##
..L.L.....
#L#LLLL#L#
#.LLLLLL.L
#.#L#L#.##")]
        [InlineData(@"#.#L.L#.##
#LLL#LL.L#
L.L.L..#..
#LLL.##.L#
#.LL.LL.LL
#.LL#L#.##
..L.L.....
#L#LLLL#L#
#.LLLLLL.L
#.#L#L#.##", @"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##")]
        public void UpdateLayout_WhenPassengersArrive(string layout, string expectedLayout)
        {
            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new NormalBehaviour());
            Assert.Equal(expectedLayout, sut.Layout);
        }

        [Fact]
        public void ReturnSameLayout_WhenMaximumCombinationsAreReached()
        {
            const string layout = @"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new NormalBehaviour());
            Assert.Equal(layout, sut.Layout);
        }

        [Fact]
        public void CalculateOccupiedSeats_AfterReceivingPassengers()
        {
            const string layout = @"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new NormalBehaviour());
            Assert.Equal(37, sut.OccupiedSeats);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new WaitingArea(PuzzleData.PUZZLE_DATA);

            sut.UntilNothingChangesAddPassengersWith(new NormalBehaviour());
            Assert.Equal(2334, sut.OccupiedSeats);
        }

        [Fact]
        public void Test9()
        {
            var layout = new List<string>()
            {
                ".......#.",
                "...#.....",
                ".#.......",
                ".........",
                "..#L....#",
                "....#....",
                ".........",
                "#........",
                "...#....."
            };

            var sut = new TestableShyBehaviour();
            Assert.Equal(8, sut.CallCountSurroundingPlaces(layout, 4, 3));
        }

        [Fact]
        public void Test10()
        {
            var layout = new List<string>()
            {
                ".............",
                ".L.L.#.#.#.#.",
                "............."
            };

            var sut = new TestableShyBehaviour();
            Assert.Equal(0, sut.CallCountSurroundingPlaces(layout, 1, 1));
        }

        [Fact]
        public void Test11()
        {
            var layout = new List<string>()
            {
                ".##.##.",
                "#.#.#.#",
                "##...##",
                "...L...",
                "##...##",
                "#.#.#.#",
                ".##.##."
            };

            var sut = new TestableShyBehaviour();
            Assert.Equal(0, sut.CallCountSurroundingPlaces(layout, 3,3));
        }

        [Fact]
        public void Test12()
        {
            var layout = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new ShyBehaviour());

            Assert.Equal(@"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##", sut.Layout);
        }

        [Fact]
        public void Test13()
        {
            const string layout = @"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new ShyBehaviour());

            Assert.Equal(@"#.LL.LL.L#
#LLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLLL.L
#.LLLLL.L#", sut.Layout);
        }

        [Fact]
        public void Test14()
        {
            const string layout = @"#.LL.LL.L#
#LLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLLL.L
#.LLLLL.L#";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new ShyBehaviour());

            Assert.Equal(@"#.L#.##.L#
#L#####.LL
L.#.#..#..
##L#.##.##
#.##.#L.##
#.#####.#L
..#.#.....
LLL####LL#
#.L#####.L
#.L####.L#", sut.Layout);
        }

        [Fact]
        public void Test15()
        {
            const string layout = @"#.L#.##.L#
#L#####.LL
L.#.#..#..
##L#.##.##
#.##.#L.##
#.#####.#L
..#.#.....
LLL####LL#
#.L#####.L
#.L####.L#";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new ShyBehaviour());

            Assert.Equal(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##LL.LL.L#
L.LL.LL.L#
#.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLL#.L
#.L#LL#.L#", sut.Layout);
        }

        [Fact]
        public void Test16()
        {
            const string layout = @"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##LL.LL.L#
L.LL.LL.L#
#.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLL#.L
#.L#LL#.L#";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new ShyBehaviour());

            Assert.Equal(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.#L.L#
#.L####.LL
..#.#.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#", sut.Layout);
        }

        [Fact]
        public void Test17()
        {
            const string layout = @"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.#L.L#
#.L####.LL
..#.#.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new ShyBehaviour());

            Assert.Equal(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.LL.L#
#.LLLL#.LL
..#.L.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#", sut.Layout);
        }

        [Fact]
        public void Test18()
        {
            const string layout = @"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.LL.L#
#.LLLL#.LL
..#.L.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#";

            var sut = new WaitingArea(layout);
            sut.AddPassengersWith(new ShyBehaviour());

            Assert.Equal(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.LL.L#
#.LLLL#.LL
..#.L.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#", sut.Layout);
            Assert.Equal(26, sut.OccupiedSeats);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new WaitingArea(PuzzleData.PUZZLE_DATA);

            sut.UntilNothingChangesAddPassengersWith(new ShyBehaviour());

            Assert.Equal(2100, sut.OccupiedSeats);
        }
    }
}