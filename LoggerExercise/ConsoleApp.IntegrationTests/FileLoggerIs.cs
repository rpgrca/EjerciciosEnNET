using System;
using System.Collections.Generic;
using Xunit;
using ConsoleApp.IntegrationTests.Helpers;
using static ConsoleApp.IntegrationTests.Constants;

namespace ConsoleApp.IntegrationTests
{
    public class FileLoggerIs : IDisposable
    {
        private bool _disposedValue;

        public FileLoggerIs()
        {
            LoggerDirectory.Create();
            LoggerDirectory.DeleteLogFile();
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void StoppingProcess_WhenMessageIsEmpty(string invalidMessage)
        {
            var sut = new Logger(true, true, true, true, true, true, new Dictionary<string, string>());

            sut.LogMessage(new Entry(invalidMessage, true, true, true));
            Assert.False(LoggerDirectory.LogFileExists());
        }

        [Fact]
        public void ThrowingException_WhenNoneOfMessageWarningErrorIsSpecifiedInMethod()
        {
            var sut = new Logger(true, true, true, true, true, true, new Dictionary<string, string>());

            var exception = Assert.Throws<Exception>(() => sut.LogMessage(new Entry("test", false, false, false)));
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
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, true, false, false));

            var loggerFile = new LoggerFileValidator();
            loggerFile.EnsureThatPoppedLineIs("message", SAMPLE_LOG_TEXT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void NotLoggingAmessage_WhenConstructorIsSetNotToLogMessages(bool logWarnings, bool logErrors)
        {
            var sut = new Logger(true, false, false, false, logWarnings, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, true, false, false));

            var validator = new LoggerFileValidator();
            validator.EnsureItIsEmpty();
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void LoggingAwarning_WhenAwarningArrivesAndLoggerIsConfiguredToLogThem(bool logMessages, bool logErrors)
        {
            var sut = new Logger(true, false, false, logMessages, true, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, false, true, false));

            var validator = new LoggerFileValidator();
            validator.EnsureLineCountIs(1);
            validator.EnsureThatPoppedLineIs("warning", SAMPLE_LOG_TEXT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void NotLoggingAwarning_WhenConstructorIsSetNotToLogWarnings(bool logMessages, bool logErrors)
        {
            var sut = new Logger(true, false, false, logMessages, false, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, false, true, false));

            var validator = new LoggerFileValidator();
            validator.EnsureItIsEmpty();
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void LoggingAnError_WhenAnErrorArrivesAndLoggerIsConfiguredToLogThem(bool logMessages, bool logWarnings)
        {
            var sut = new Logger(true, false, false, logMessages, logWarnings, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, false, false, true));

            var validator = new LoggerFileValidator();
            validator.EnsureLineCountIs(1);
            validator.EnsureThatPoppedLineIs("error", SAMPLE_LOG_TEXT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void NotLoggingAnError_WhenConstructorIsSetNotToLogErrors(bool logMessages, bool logWarnings)
        {
            var sut = new Logger(true, false, false, logMessages, logWarnings, false, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, false, false, true));

            var validator = new LoggerFileValidator();
            validator.EnsureItIsEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggingMessageAndWarning_WhenTheyArriveAndLoggerIsConfiguredToLogThem(bool logErrors)
        {
            var sut = new Logger(true, false, false, true, true, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, true, true, false));

            var validator = new LoggerFileValidator();
            validator.EnsureLineCountIs(2);
            validator.EnsureThatPoppedLineIs("warning", SAMPLE_LOG_TEXT);
            validator.EnsureThatPoppedLineIs("message", SAMPLE_LOG_TEXT);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggingMessageAndError_WhenTheyArriveAndLoggerIsConfiguredToLogThem(bool logWarnings)
        {
            var sut = new Logger(true, false, false, true, logWarnings, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, true, false, true));

            var validator = new LoggerFileValidator();
            validator.EnsureLineCountIs(2);
            validator.EnsureThatPoppedLineIs("error", SAMPLE_LOG_TEXT);
            validator.EnsureThatPoppedLineIs("message", SAMPLE_LOG_TEXT);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggingWarningAndError_WhenTheyArriveAndLoggerIsConfiguredToLogThem(bool logMessages)
        {
            var sut = new Logger(true, false, false, logMessages, true, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, false, true, true));

            var validator = new LoggerFileValidator();
            validator.EnsureLineCountIs(2);
            validator.EnsureThatPoppedLineIs("error", SAMPLE_LOG_TEXT);
            validator.EnsureThatPoppedLineIs("warning", SAMPLE_LOG_TEXT);
        }

        [Fact]
        public void LoggingMessageWarningAndError_WhenTheyArriveAndLoggerIsConfiguredToLogThem()
        {
            var sut = new Logger(true, false, false, true, true, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(new Entry(SAMPLE_LOG_TEXT, true, true, true));

            var validator = new LoggerFileValidator();
            validator.EnsureLineCountIs(3);
            validator.EnsureThatPoppedLineIs("error", SAMPLE_LOG_TEXT);
            validator.EnsureThatPoppedLineIs("warning", SAMPLE_LOG_TEXT);
            validator.EnsureThatPoppedLineIs("message", SAMPLE_LOG_TEXT);
        }

#region Disposing code
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    LoggerDirectory.DeleteLogFile();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
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