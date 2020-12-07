using Xunit;
using AdventOfCode2020.Day6.Logic;

namespace AdventOfCode2020.Day6.UnitTests
{
    public class AnswersInCommonInAGroupMust
    {
        [Theory]
        [InlineData("abc", 3)]
        [InlineData(@"a
b
c", 0)]
        [InlineData(@"ab
ac", 1)]
        [InlineData(@"a
a
a
a", 1)]
        [InlineData("b", 1)]
        public void CountTotalOfSameAnswers(string answers, int expectedAnswer)
        {
            var sut = new AnswersInCommonInAGroup(answers);
            Assert.Equal(expectedAnswer, sut.Yes);
        }
    }
}