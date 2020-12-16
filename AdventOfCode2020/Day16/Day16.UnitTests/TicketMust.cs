using Xunit;
using AdventOfCode2020.Day16.Logic;

namespace AdventOfCode2020.Day16.UnitTests
{
    public class TicketMust
    {
        [Fact]
        public void Test1()
        {
            var rule = new Rule("class: 1-3");
            var sut = new Ticket("7,1,14");
            Assert.False(sut.HasValuesDefinedIn(rule));
        }

        [Fact]
        public void Test2()
        {
            var rule = new Rule("class: 1-3");
            var sut = new Ticket("1,2");
            Assert.True(sut.HasValuesDefinedIn(rule));
        }

        [Theory]
        [InlineData("7,1,14")]
        [InlineData("7,3,47")]
        public void Test3(string validTicket)
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
        public void Test4(string invalidTicket)
        {
            const string data = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50";

            var rules = new Rules(data);
            var sut = new Ticket(invalidTicket);

            Assert.False(sut.HasValuesDefinedIn(rules));
        }

        [Fact]
        public void Test5()
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
    }
}