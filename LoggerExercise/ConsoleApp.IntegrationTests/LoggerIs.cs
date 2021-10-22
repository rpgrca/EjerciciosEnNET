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

        [Fact]
        public void ThrowingException_WhenConfigurationIsInvalid()
        {
            var sut = new Logger(false, false, false, true, true, true, null);
            var exception = Assert.Throws<Exception>(() => sut.LogMessage("test", true, true, true));
            Assert.Equal("Invalid configuration", exception.Message);
        }
    }
}
