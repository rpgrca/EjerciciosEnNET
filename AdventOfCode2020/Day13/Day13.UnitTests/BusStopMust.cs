using Xunit;
using AdventOfCode2020.Day13.Logic;

namespace AdventOfCode2020.Day13.UnitTests
{
    public class BustStopMust
    {
        [Theory]
        [InlineData("939\n7,13,x,x,59,x,31,19", 939)]
        [InlineData("100\n3,5,7,9", 100)]
        public void ExtractArrivalFromNotes(string notes, int expectedArrival)
        {
            var sut = new BusStop(notes);
            Assert.Equal(expectedArrival, sut.Arrival);
        }

        [Fact]
        public void ExtractBusIdsFromNotes()
        {
            const string notes = "939\n7,13,x,x,59,31,19";
            var sut = new BusStop(notes);
            Assert.Collection(sut.BusesArrivingByOffset,
                p1 => Assert.Equal((7, 0), p1),
                p2 => Assert.Equal((13, 1), p2),
                p3 => Assert.Equal((59, 4), p3),
                p4 => Assert.Equal((31, 5), p4),
                p5 => Assert.Equal((19, 6), p5));
        }

        [Fact]
        public void CalculateBusArrivingFirst()
        {
            const string notes = "939\n7,13,x,x,59,31,19";
            var sut = new BusStop(notes);

            sut.CalculateEarliestArrival();
            Assert.Equal(59, sut.EarliestBusArriving);
        }

        [Fact]
        public void CalculateSolutionForFirstPuzzle()
        {
            const string notes = "939\n7,13,x,x,59,31,19";
            var sut = new BusStop(notes);

            sut.CalculateEarliestArrival();
            Assert.Equal(295, sut.BusIdTimesWaitingTime);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new BusStop(PuzzleData.PUZZLE_DATA);

            sut.CalculateEarliestArrival();
            Assert.Equal(2845, sut.BusIdTimesWaitingTime);
        }

        [Theory]
        [InlineData("939\n17,x,13,19", 3417)]
        [InlineData("939\n67,7,59,61", 754018)]
        [InlineData("939\n67,x,7,59,61", 779210)]
        [InlineData("939\n67,7,x,59,61", 1261476)]
        [InlineData("939\n1789,37,47,1889", 1202161486)]
        public void Test4(string notes, long expectedResult)
        {
            var sut = new BusStop(notes);
            sut.CalculateEarliestConsecutiveArrival();

            Assert.Equal(expectedResult, sut.EarliestConsecutiveBusArrival);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new BusStop(PuzzleData.PUZZLE_DATA);
            sut.CalculateEarliestConsecutiveArrival();

            Assert.Equal(487905974205117, sut.EarliestConsecutiveBusArrival);
        }
    }
}
