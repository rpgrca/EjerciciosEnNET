using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleApp.IntegrationTests
{
    public class LoggerIs : IDisposable
    {
        private const string DEFAULT_LOG_FILE = "logFile.txt";
        private const string DEFAULT_LOG_PATH = "./Temp";
        private const string DEFAULT_LOG = DEFAULT_LOG_PATH + "/" + DEFAULT_LOG_FILE;
        private const string SAMPLE_LOG_TEXT = "this is a sample text";
        private bool disposedValue;

        public LoggerIs()
        {
            CreateDirectoryIfNecessary();
            DeleteLogFile();
        }

        private static void CreateDirectoryIfNecessary()
        {
            if (! System.IO.Directory.Exists(DEFAULT_LOG_PATH))
            {
                System.IO.Directory.CreateDirectory(DEFAULT_LOG_PATH);
            }
        }

        private static void DeleteLogFile()
        {
            if (System.IO.File.Exists(DEFAULT_LOG))
            {
                System.IO.File.Delete(DEFAULT_LOG);
            }
        }

        [Fact]
        public void ThrowingException_WhenConfigurationIsInvalid()
        {
            var sut = new Logger(false, false, false, true, true, true, null);
            var exception = Assert.Throws<Exception>(() => sut.LogMessage("test", true, true, true));
            Assert.Equal(Logger.INVALID_CONFIGURATION, exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void StoppingProcess_WhenConfigurationIsInvalidAndMessageIsEmpty(string invalidMessage)
        {
            var sut = new Logger(false, false, false, true, true, true, null);
            sut.LogMessage(invalidMessage, true, true, true);
            AssertThatThereIsNoLogFileCreated();
        }

        private static void AssertThatThereIsNoLogFileCreated() =>
            Assert.False(System.IO.File.Exists(DEFAULT_LOG));

        [Fact]
        public void ThrowingException_WhenNoneOfMessageWarningErrorIsSpecifiedInConstructor()
        {
            var sut = new Logger(true, true, true, false, false, false, null);
            var exception = Assert.Throws<Exception>(() => sut.LogMessage("test", true, true, true));
            Assert.Equal(Logger.MUST_SPECIFY_MESSAGE_WARNING_ERROR, exception.Message);
        }

        [Fact]
        public void ThrowingException_WhenNoneOfMessageWarningErrorIsSpecifiedInMethod()
        {
            var sut = new Logger(true, true, true, true, true, true, null);
            var exception = Assert.Throws<Exception>(() => sut.LogMessage("test", false, false, false));
            Assert.Equal(Logger.MUST_SPECIFY_MESSAGE_WARNING_ERROR, exception.Message);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void LoggingAmessage_WhenAmessageArrivesAndLoggerIsConfiguredToLogThem(bool logWarnings, bool logErrors)
        {
            var sut = new Logger(true, false, false, true, logWarnings, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, true, false, false);
            VerifyThatLogFileHas("message", SAMPLE_LOG_TEXT);
        }

        private static void VerifyThatLogFileHas(string expectedType, string expectedText)
        {
            if (! System.IO.File.Exists(DEFAULT_LOG)) Assert.True(false, "expected log file does not exist");
            var loggedText = System.IO.File.ReadAllText(DEFAULT_LOG);

            Assert.Matches($"^{expectedType}.+{expectedText}$", loggedText);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void NotLoggingAmessage_WhenConstructorIsSetNotToLogMessages(bool logWarnings, bool logErrors)
        {
            var sut = new Logger(true, false, false, false, logWarnings, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, true, false, false);
            AssertThatLogFileIsEmpty();
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void LoggingAwarning_WhenAwarningArrivesAndLoggerIsConfiguredToLogThem(bool logMessages, bool logErrors)
        {
            var sut = new Logger(true, false, false, logMessages, true, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, false, true, false);
            VerifyThatLogFileHas("warning", SAMPLE_LOG_TEXT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void NotLoggingAwarning_WhenConstructorIsSetNotToLogWarnings(bool logMessages, bool logErrors)
        {
            var sut = new Logger(true, false, false, logMessages, false, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, false, true, false);
            AssertThatLogFileIsEmpty();
        }

        private static void AssertThatLogFileIsEmpty()
        {
            Assert.True(System.IO.File.Exists(DEFAULT_LOG));
            Assert.Equal("\n", System.IO.File.ReadAllText(DEFAULT_LOG));
        }

#region Disposing code
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DeleteLogFile();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~LoggerIs()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
#endregion
    }
}
