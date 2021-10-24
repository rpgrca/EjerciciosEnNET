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
            var entry = Entry.Director.ConfigureToBuildMessage(SAMPLE_LOG_TEXT).Build();
            sut.LogMessage(entry);

            var validator = new LoggerTableValidator();
            validator.EnsureRegisterCountIs(1);
            validator.EnsureThatPoppedLineIs(SAMPLE_LOG_TEXT, 1);
        }

        [Fact]
        public void AddingArecord_WhenAwarningArrivesAndLoggerIsConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, false, true, false, GetDatabaseParameters());
            var entry = Entry.Director.ConfigureToBuildWarning(SAMPLE_LOG_TEXT).Build();
            sut.LogMessage(entry);

            var validator = new LoggerTableValidator();
            validator.EnsureRegisterCountIs(1);
            validator.EnsureThatPoppedLineIs(SAMPLE_LOG_TEXT, 3);
        }

        [Fact]
        public void AddingArecord_WhenAnErrorArrivesAndLoggerIsConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, false, false, true, GetDatabaseParameters());
            var entry = Entry.Director.ConfigureToBuildError(SAMPLE_LOG_TEXT).Build();
            sut.LogMessage(entry);

            var validator = new LoggerTableValidator();
            validator.EnsureRegisterCountIs(1);
            validator.EnsureThatPoppedLineIs(SAMPLE_LOG_TEXT, 2);
        }

        [Fact]
        public void AddingNoRecord_WhenMessageArrivesAndItsNotConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, false, true, true, GetDatabaseParameters());
            var entry = Entry.Director.ConfigureToBuildMessage(SAMPLE_LOG_TEXT).Build();
            sut.LogMessage(entry);

            var validator = new LoggerTableValidator();
            validator.EnsureItIsEmpty();
        }

        [Fact]
        public void AddingNoRecord_WhenWarningArrivesAndItsNotConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, true, false, true, GetDatabaseParameters());
            var entry = Entry.Director.ConfigureToBuildWarning(SAMPLE_LOG_TEXT).Build();
            sut.LogMessage(entry);

            var validator = new LoggerTableValidator();
            validator.EnsureItIsEmpty();
        }

        [Fact]
        public void AddingNoRecord_WhenErrorArrivesAndItsNotConfiguredToLogThem()
        {
            var sut = new Logger(false, false, true, true, true, false, GetDatabaseParameters());
            var entry = Entry.Director.ConfigureToBuildError(SAMPLE_LOG_TEXT).Build();
            sut.LogMessage(entry);

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