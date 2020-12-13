using Xunit;
using AdventOfCode2020.Day13.Logic;

namespace AdventOfCode2020.Day13.UnitTests
{
    public class BustStopMust
    {
        [Theory]
        [InlineData("939\n7,13,x,x,59,x,31,19", 939)]
        [InlineData("100\n3,5,7,9", 100)]
        public void Test1(string notes, int expectedArrival)
        {
            var sut = new BusStop(notes);
            Assert.Equal(expectedArrival, sut.Arrival);
        }

        [Fact]
        public void Test2()
        {
            const string notes = "939\n7,13,x,x,59,31,19";
            var sut = new BusStop(notes);
            Assert.Collection(sut.BusesStoppingHere,
                p1 => Assert.Equal(7, p1),
                p2 => Assert.Equal(13, p2),
                p3 => Assert.Equal(19, p3),
                p4 => Assert.Equal(31, p4),
                p5 => Assert.Equal(59, p5));
        }

        [Fact]
        public void Test3()
        {
            const string notes = "939\n7,13,x,x,59,31,19";
            var sut = new BusStop(notes);
            sut.CalculateEarliestArrival();
            Assert.Equal((59, 944), sut.EarliestBusArrival);
            Assert.Equal(295, sut.Solution);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            const string notes = @"1007125
13,x,x,41,x,x,x,x,x,x,x,x,x,569,x,29,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,19,x,x,x,23,x,x,x,x,x,x,x,937,x,x,x,x,x,37,x,x,x,x,x,x,x,x,x,x,17";
            var sut = new BusStop(notes);
            sut.CalculateEarliestArrival();
            Assert.Equal((569, 1007130), sut.EarliestBusArrival);
            Assert.Equal(2845, sut.Solution);
        }
    }
}
