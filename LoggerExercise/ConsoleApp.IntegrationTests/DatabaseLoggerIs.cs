using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;
using ConsoleApp.IntegrationTests.Helpers;
using static ConsoleApp.IntegrationTests.Constants;

namespace ConsoleApp.IntegrationTests
{

    public static class LoggerDatabase
    {
        private static SqlConnection ObtainConnection()
        {
            var connectionString = $"Server={DATABASE_SERVER};Initial Catalog={DATABASE_NAME};User ID={DATABASE_USERNAME};Password={DATABASE_PASSWORD};";
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public static void Empty()
        {
            using var sqlConnection = ObtainConnection();
            var sqlCommand = new SqlCommand("DELETE FROM Log_Values", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }

    public class DatabaseLoggerIs : IDisposable
    {
        private bool _disposedValue;

        public DatabaseLoggerIs()
        {
            LoggerDatabase.Empty();
        }

        [Fact]
        public void Test1()
        {

        }

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