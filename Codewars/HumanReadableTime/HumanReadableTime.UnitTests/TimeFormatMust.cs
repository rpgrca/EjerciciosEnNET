using Xunit;
using HumanReadableTime.Logic;

namespace HumanReadableTime.UnitTests
{
    public class TimeFormatMust
    {
        [Theory]
        [InlineData(0, "00:00:00")]
        [InlineData(5, "00:00:05")]
        [InlineData(60, "00:01:00")]
        [InlineData(86399, "23:59:59")]
        [InlineData(359999, "99:59:59")]
        public void HumanReadableTest(int seconds, string expectedResult) =>
            Assert.Equal(expectedResult, TimeFormat.GetReadableTime(seconds));
    }
}