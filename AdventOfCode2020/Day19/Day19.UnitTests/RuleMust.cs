using Xunit;
using AdventOfCode2020.Day19.Logic;

namespace AdventOfCode2020.Day19.UnitTests
{
    public class RuleMust
    {
        [Fact]
        public void CreateRuleDeferencingOthers()
        {
            const string data = "9: 1 2";

            var rule = new Rule(data);
            Assert.Equal(9, rule.Id);
        }

        [Fact]
        public void CreateRuleMatchingCharacter()
        {
            const string data = "13: \"a\"";

            var rule = new Rule(data);
            Assert.Equal(13, rule.Id);
        }

        [Fact]
        public void Test1()
        {
            const string data = "0: \"a\"";

            var rule = new Rule(data);
            Assert.Equal(1, rule.Consumes("a", null));
        }

        [Fact]
        public void Test2()
        {
            const string data = "0: \"a\"";

            var rule = new Rule(data);
            Assert.Equal(0, rule.Consumes("b", null));
        }
    }
}