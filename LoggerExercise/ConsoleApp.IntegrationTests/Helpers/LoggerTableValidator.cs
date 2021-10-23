using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;
using static ConsoleApp.IntegrationTests.Constants;

namespace ConsoleApp.IntegrationTests.Helpers
{
    public class LoggerTableValidator
    {
        private readonly List<(string, int)> _contents;
        private int _currentRecord;

        public LoggerTableValidator()
        {
            _contents = new List<(string, int)>();
            _currentRecord = 0;

            using var connection = ObtainConnection();
            using var command = new SqlCommand("SELECT * FROM Log_Values", connection);
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _contents.Add((reader.GetString(0), reader.GetInt32(1)));
                }
            }

            reader.Close();
            connection.Close();
        }

        private static SqlConnection ObtainConnection()
        {
            var connectionString = $"Server={DATABASE_SERVER};Initial Catalog={DATABASE_NAME};User ID={DATABASE_USERNAME};Password={DATABASE_PASSWORD};";
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public void EnsureRegisterCountIs(int amount) =>
            Assert.Equal(amount, _contents.Count);

        public void EnsureThatPoppedLineIs(string text, int level) =>
            Assert.Equal((text, level), _contents[_currentRecord++]);

        internal void EnsureItIsEmpty() =>
            Assert.Empty(_contents);
    }
}