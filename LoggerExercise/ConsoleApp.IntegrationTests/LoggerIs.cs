using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleApp.IntegrationTests
{
    public class LoggerIs : IDisposable
    {
        private const string DEFAULT_LOG_FILE = "logFile.txt";
        private const string DEFAULT_LOG_PATH = "./Temp";
        private const string LOGFILE_PATH = DEFAULT_LOG_PATH + "/" + DEFAULT_LOG_FILE;

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
            if (System.IO.File.Exists(LOGFILE_PATH))
            {
                System.IO.File.Delete(LOGFILE_PATH);
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

            Assert.False(System.IO.File.Exists(LOGFILE_PATH));
        }

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

        [Fact]
        public void Test1()
        {
            var sut = new Logger(true, false, false, true, false, false, new Dictionary<string, string>() { { "logFileFolder", DEFAULT_LOG_PATH } });
            sut.LogMessage("sample message", true, false, false);
            VerifyThatLogFileHas("message", "sample message");
        }

        private static void VerifyThatLogFileHas(string expectedType, string expectedText)
        {
            if (! System.IO.File.Exists(LOGFILE_PATH)) Assert.True(false, "expected log file does not exist");
            var loggedText = System.IO.File.ReadAllLines(LOGFILE_PATH);

            Assert.Single(loggedText);
            Assert.Matches($"{expectedType}.+{expectedText}", loggedText[0]);
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
