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
        public void ReturnTrue_WhenValueIsIncludedInRule(string rules, int value)
        {
            var rule = new Rule(rules);
            Assert.True(rule.Includes(value));
        }

        [Theory]
        [InlineData("class: 1-3", 0)]
        [InlineData("class: 2-4", 5)]
        [InlineData("class: 3-5", 10)]
        public void ReturnFalse_WhenValueIsNotIncludedInRule(string rules, int value)
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
        public void ReturnTrue_WhenValueIsIncludedInCombinedRule(int value)
        {
            var rule = new Rule("class: 1-3 or 5-7");
            Assert.True(rule.Includes(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(8)]
        public void ReturnFalse_WhenValueIsNotIncludedInCombinedRule(int value)
        {
            var rule = new Rule("class: 1-3 or 5-7");
            Assert.False(rule.Includes(value));
        }
    }
}