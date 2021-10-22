using System;
using Xunit;

namespace ConsoleApp.IntegrationTests
{
    public class LoggerIs
    {
        [Fact]
        public void ThrowingNullReferenceException_WhenMessageIsNull()
        {
            var sut = new Logger(true, true, true, false, false, false, null);
            var exception = Assert.Throws<NullReferenceException>(() => sut.LogMessage(null, true, true, true));
        }
    }
}
