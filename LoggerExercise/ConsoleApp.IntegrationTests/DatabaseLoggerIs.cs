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