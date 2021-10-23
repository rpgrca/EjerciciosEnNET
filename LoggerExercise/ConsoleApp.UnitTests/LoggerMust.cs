using System;
using Xunit;

namespace ConsoleApp.UnitTests
{
    public class LoggerMust
    {
        [Fact]
        public void ThrowException_WhenConfigurationIsInvalid()
        {
            var exception = Assert.Throws<Exception>(() => new Logger(false, false, false, true, true, true, null));
            Assert.Equal(Logger.INVALID_CONFIGURATION, exception.Message);
        }
    }
}