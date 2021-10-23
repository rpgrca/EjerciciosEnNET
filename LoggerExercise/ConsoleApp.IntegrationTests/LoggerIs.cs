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
            AssertThatLogFileExists();
            var loggedText = GetOneLineOrAssert();
            Assert.Matches($"^{expectedType}.+{expectedText}$", loggedText);
        }

        private static void AssertThatLogFileExists() =>
            Assert.True(System.IO.File.Exists(DEFAULT_LOG), "expected log file does not exist");

        private static string GetOneLineOrAssert()
        {
            var loggedLines = System.IO.File.ReadAllLines(DEFAULT_LOG);
            Assert.Single(loggedLines);
            return loggedLines[0];
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

        private static void AssertThatLogFileIsEmpty()
        {
            Assert.True(System.IO.File.Exists(DEFAULT_LOG));
            Assert.Equal("\n", System.IO.File.ReadAllText(DEFAULT_LOG));
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

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void LoggingAnError_WhenAnErrorArrivesAndLoggerIsConfiguredToLogThem(bool logMessages, bool logWarnings)
        {
            var sut = new Logger(true, false, false, logMessages, logWarnings, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, false, false, true);
            VerifyThatLogFileHas("error", SAMPLE_LOG_TEXT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void NotLoggingAnError_WhenConstructorIsSetNotToLogErrors(bool logMessages, bool logWarnings)
        {
            var sut = new Logger(true, false, false, logMessages, logWarnings, false, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, false, false, true);
            AssertThatLogFileIsEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggingMessageAndWarning_WhenTheyArriveAndLoggerIsConfiguredToLogThem(bool logErrors)
        {
            var sut = new Logger(true, false, false, true, true, logErrors, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, true, true, false);
            AssertThatLogFileHasTwoLines(new[] { ("warning", SAMPLE_LOG_TEXT), ("message", SAMPLE_LOG_TEXT) });
        }

        private static void AssertThatLogFileHasTwoLines((string Type, string Text)[] expectedLine)
        {
            AssertThatLogFileExists();
            var loggedText = GetTwoLinesOrAssert();

            Assert.Matches($"^{expectedLine[0].Type}.+{expectedLine[0].Text}$", loggedText[0]);
            Assert.Matches($"^{expectedLine[1].Type}.+{expectedLine[1].Text}$", loggedText[1]);
        }

        private static string[] GetTwoLinesOrAssert()
        {
            var loggedLines = System.IO.File.ReadAllLines(DEFAULT_LOG);
            Assert.Equal(2, loggedLines.Length);
            return loggedLines;
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggingMessageAndError_WhenTheyArriveAndLoggerIsConfiguredToLogThem(bool logWarnings)
        {
            var sut = new Logger(true, false, false, true, logWarnings, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, true, false, true);
            AssertThatLogFileHasTwoLines(new[] { ("error", SAMPLE_LOG_TEXT), ("message", SAMPLE_LOG_TEXT) });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggingWarningAndError_WhenTheyArriveAndLoggerIsConfiguredToLogThem(bool logMessages)
        {
            var sut = new Logger(true, false, false, logMessages, true, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, false, true, true);
            AssertThatLogFileHasTwoLines(new[] { ("error", SAMPLE_LOG_TEXT), ("warning", SAMPLE_LOG_TEXT) });
        }

        [Fact]
        public void LoggingMessageWarningAndError_WhenTheyArriveAndLoggerIsConfiguredToLogThem()
        {
            var sut = new Logger(true, false, false, true, true, true, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage(SAMPLE_LOG_TEXT, true, true, true);
            AssertThatLogFileHasThreeLines(new[] { ("error", SAMPLE_LOG_TEXT), ("warning", SAMPLE_LOG_TEXT), ("message", SAMPLE_LOG_TEXT)});
        }

        private static void AssertThatLogFileHasThreeLines((string Type, string Text)[] expectedLine)
        {
            AssertThatLogFileExists();
            var loggedText = GetThreeLinesOrAssert();

            Assert.Matches($"^{expectedLine[0].Type}.+{expectedLine[0].Text}$", loggedText[0]);
            Assert.Matches($"^{expectedLine[1].Type}.+{expectedLine[1].Text}$", loggedText[1]);
            Assert.Matches($"^{expectedLine[2].Type}.+{expectedLine[2].Text}$", loggedText[2]);
        }

        private static string[] GetThreeLinesOrAssert()
        {
            var loggedLines = System.IO.File.ReadAllLines(DEFAULT_LOG);
            Assert.Equal(3, loggedLines.Length);
            return loggedLines;
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
