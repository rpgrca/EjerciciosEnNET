using Xunit;
using AdventOfCode2020.Day5.Logic;

namespace AdventOfCode2020.Day5.UnitTests
{
    public class SeatMust
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void ObtainRowColumnId_WhenParsingSeatData(string seatCode, int expectedRow, int expectedColumn, int expectedId)
        {
            var sut = new Seat(seatCode);

            Assert.Equal(expectedRow, sut.Row);
            Assert.Equal(expectedColumn, sut.Column);
            Assert.Equal(expectedId, sut.Id);
        }
    }
}