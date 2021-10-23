using System;
using System.Collections.Generic;
using Xunit;
using ConsoleApp.IntegrationTests.Helpers;
using static ConsoleApp.IntegrationTests.Constants;

namespace ConsoleApp.IntegrationTests
{
    public class DatabaseLoggerIs : IDisposable
    {
        private bool _disposedValue;

        public DatabaseLoggerIs() => LoggerDatabase.Empty();

        [Fact]
        public void AddingArecord_WhenAmessageArrivesAndLoggerIsConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, true, false, false, GetDatabaseParameters());
            sut.LogMessage(SAMPLE_LOG_TEXT, true, false, false);

            var validator = new LoggerTableValidator();
            validator.EnsureRegisterCountIs(1);
            validator.EnsureThatPoppedLineIs(SAMPLE_LOG_TEXT, 1);
        }

        [Fact]
        public void AddingArecord_WhenAwarningArrivesAndLoggerIsConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, false, true, false, GetDatabaseParameters());
            sut.LogMessage(SAMPLE_LOG_TEXT, false, true, false);

            var validator = new LoggerTableValidator();
            validator.EnsureRegisterCountIs(1);
            validator.EnsureThatPoppedLineIs(SAMPLE_LOG_TEXT, 3);
        }

        [Fact]
        public void AddingArecord_WhenAnErrorArrivesAndLoggerIsConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, false, false, true, GetDatabaseParameters());
            sut.LogMessage(SAMPLE_LOG_TEXT, false, false, true);

            var validator = new LoggerTableValidator();
            validator.EnsureRegisterCountIs(1);
            validator.EnsureThatPoppedLineIs(SAMPLE_LOG_TEXT, 2);
        }

        [Theory]
        [InlineData(false, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        public void AddingNoRecord_WhenSomethingArrivesAndItsNotConfiguredToLogThem(bool message, bool warning, bool error)
        {
            var sut = new Logger(false, false, true, message, warning, error, GetDatabaseParameters());
            sut.LogMessage(SAMPLE_LOG_TEXT, !message, !warning, !error);

            var validator = new LoggerTableValidator();
            validator.EnsureItIsEmpty();
        }

        private static Dictionary<string, string> GetDatabaseParameters() =>
            new()
            {
                { "serverName", DATABASE_SERVER },
                { "DataBaseName", DATABASE_NAME },
                { "userName", DATABASE_USERNAME },
                { "password", DATABASE_PASSWORD }
            };

#region Disposing code
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    LoggerDatabase.Empty();
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