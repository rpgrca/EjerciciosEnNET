using System;
using Xunit;
using HumanReadableTime.Logic;

namespace HumanReadableTime.UnitTests
{
    public class TimeFormatMust
    {
        [Fact]
        public void HumanReadableTest()
        {
            Assert.Equal("00:00:00", TimeFormat.GetReadableTime(0));
            Assert.Equal("00:00:05", TimeFormat.GetReadableTime(5));
            Assert.Equal("00:01:00", TimeFormat.GetReadableTime(60));
            Assert.Equal("23:59:59", TimeFormat.GetReadableTime(86399));
            Assert.Equal("99:59:59", TimeFormat.GetReadableTime(359999));
        }
    }
}
