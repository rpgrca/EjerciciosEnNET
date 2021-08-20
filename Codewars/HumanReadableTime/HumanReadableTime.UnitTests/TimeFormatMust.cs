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
        }

        [Fact]
        public void HumanReadableTest2()
        {
            Assert.Equal("00:00:05", TimeFormat.GetReadableTime(5));
        }

        [Fact]
        public void HumanReadableTest3()
        {
            Assert.Equal("00:01:00", TimeFormat.GetReadableTime(60));
        }

        [Fact]
        public void HumanReadableTest4()
        {
            Assert.Equal("23:59:59", TimeFormat.GetReadableTime(86399));
        }

        [Fact]
        public void HumanReadableTest5()
        {
            Assert.Equal("99:59:59", TimeFormat.GetReadableTime(359999));
        }
    }
}