using Xunit;
using AdventOfCode2020.Day16.Logic;

namespace AdventOfCode2020.Day16.UnitTests
{
    public class ScannerMust
    {
        [Fact]
        public void ReturnErrorRate_WhenScanningData()
        {
            const string data = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

            var sut = new Scanner(data);

            sut.Scan();
            Assert.Equal(71, sut.ErrorRate);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Scanner(PuzzleData.PUZZLE_DATA);
            sut.Scan();

            Assert.Equal(27850, sut.ErrorRate);
        }

        [Fact]
        public void DetermineFieldOrderingCorrectly()
        {
            const string data = @"class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9";
            var sut = new Scanner(data);
            sut.DiscardInvalidTickets();

            sut.Translate();
            Assert.Equal(12, sut.FromMyTicketGet("class"));
            Assert.Equal(11, sut.FromMyTicketGet("row"));
            Assert.Equal(13, sut.FromMyTicketGet("seat"));
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Scanner(PuzzleData.PUZZLE_DATA);
            sut.DiscardInvalidTickets();
            sut.Translate();

            Assert.Equal(137, sut.FromMyTicketGet("departure location"));
            Assert.Equal(173, sut.FromMyTicketGet("departure station"));
            Assert.Equal(61, sut.FromMyTicketGet("departure platform"));
            Assert.Equal(59, sut.FromMyTicketGet("departure track"));
            Assert.Equal(79, sut.FromMyTicketGet("departure date"));
            Assert.Equal(73, sut.FromMyTicketGet("departure time"));
            Assert.Equal(491924517533, sut.MultiplyDepartureKeys());
        }
    }
}