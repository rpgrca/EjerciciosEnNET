using Xunit;
using AdventOfCode2020.Day16.Logic;

namespace AdventOfCode2020.Day16.UnitTests
{
    public class TicketMust
    {
        [Theory]
        [InlineData("7,1,14")]
        [InlineData("7,3,47")]
        public void ReturnTrue_WhenTicketIsValidAccordingToGivenRules(string validTicket)
        {
            const string data = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50";

            var rules = new Rules(data);
            var sut = new Ticket(validTicket);

            Assert.True(sut.HasValuesDefinedIn(rules));
        }

        [Theory]
        [InlineData("40,4,50")]
        [InlineData("55,2,20")]
        [InlineData("38,6,12")]
        public void ReturnFalse_WhenTicketIsNotValidAccordingToGivenRules(string invalidTicket)
        {
            const string data = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50";

            var rules = new Rules(data);
            var sut = new Ticket(invalidTicket);

            Assert.False(sut.HasValuesDefinedIn(rules));
        }
    }
}