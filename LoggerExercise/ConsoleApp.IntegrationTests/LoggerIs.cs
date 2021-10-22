using System;
using Xunit;

namespace ConsoleApp.IntegrationTests
{
    public class LoggerIs : IDisposable
    {
        private const string LOGFILE_PATH = "./Temp/logFile.txt";
        private bool disposedValue;

        public LoggerIs()
        {
            DeleteLogFile();
        }

        private static void DeleteLogFile()
        {
            if (System.IO.File.Exists(LOGFILE_PATH))
            {
                System.IO.File.Delete(LOGFILE_PATH);
            }
        }

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
    }
}
