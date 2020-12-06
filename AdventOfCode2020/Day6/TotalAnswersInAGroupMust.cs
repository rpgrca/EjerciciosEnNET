using Xunit;

namespace AdventOfCode2020.Day6
{
    public class TotalAnswersInAGroupMust
    {
        [Theory]
        [InlineData("abcx\nabcy\nabcz")]
        public void CountNumberOfUniqueAnswers(string answers)
        {
            var sut = new TotalAnswersInAGroup(answers);
            Assert.Equal(6, sut.Yes);
        }
    }
}