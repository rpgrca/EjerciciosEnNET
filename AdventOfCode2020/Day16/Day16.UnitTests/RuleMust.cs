using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;
using AdventOfCode2020.Day16.Logic;

namespace AdventOfCode2020.Day16.UnitTests
{
    public class RuleMust
    {
        [Theory]
        [InlineData("class: 1-3", 1)]
        [InlineData("class: 2-4", 3)]
        [InlineData("class: 3-5", 5)]
        public void Test1(string rules, int value)
        {
            var rule = new Rule(rules);
            Assert.True(rule.Includes(value));
        }

        [Theory]
        [InlineData("class: 1-3", 0)]
        [InlineData("class: 2-4", 5)]
        [InlineData("class: 3-5", 10)]
        public void Test2(string rules, int value)
        {
            var rule = new Rule(rules);
            Assert.False(rule.Includes(value));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void Test3(int value)
        {
            var rule = new Rule("class: 1-3 or 5-7");
            Assert.True(rule.Includes(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(8)]
        public void Test4(int value)
        {
            var rule = new Rule("class: 1-3 or 5-7");
            Assert.False(rule.Includes(value));
        }


    }

/*
    public class UnitTest1
    {
        [Fact]
        public void Test0()
        {
            var rule = "1-3";
            var ticket = "7,1,14";

            var sut = new Ticket(ticket);
            Assert.True(sut.HasValuesDefinedIn(rule));
        }

    }

    public class Ticket
    {
        private readonly string _ticket;

        public Ticket(string ticket)
        {
            _ticket = ticket;
        }

        public bool HasValuesDefinedIn(string rule)
        {

        }
    }
*/
/*
    public class Scanner
    {
        private readonly string _rules;

        public Scanner(string rules)
        {
            _rules = rules;
        }



    }


        [Fact]
        public void Test1()
        {
            var rules = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

            var scanner = new Scanner(rules);
            
        }*/

}
