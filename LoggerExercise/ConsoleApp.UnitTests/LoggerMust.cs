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

        [Theory]
        [InlineData(true, false, false)]
        [InlineData(false, false, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(false, true, true)]
        [InlineData(true, true, true)]
        public void ThrowException_WhenNullDictionaryIsSuppliedAndLoggerNeedsIt(bool logToFile, bool logToConsole, bool logToDatabase)
        {
            var exception = Assert.Throws<Exception>(() => new Logger(logToFile, logToConsole, logToDatabase, true, true, true, null));
            Assert.Equal(Logger.INVALID_CONFIGURATION_VARIABLES, exception.Message);
        }
    }
}