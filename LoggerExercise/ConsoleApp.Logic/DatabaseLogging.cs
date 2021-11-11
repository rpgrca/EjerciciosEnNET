using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class DatabaseLogging : ILogger
    {
        private readonly IDictionary<string, string> _dbParams;
        private readonly bool _message;
        private readonly bool _warning;
        private readonly bool _error;

        public DatabaseLogging(bool message, bool warning, bool error, IDictionary<string, string> dbParams)
        {
            _message = message;
            _warning = warning;
            _error = error;
            _dbParams = dbParams;
        }

        public void Log(IEntry entry) => entry.LogInto(this);

        public void LogEntryAsError(string text)
        {
            if (_error)
            {
                Log(text, 2);
            }
        }

        public void LogEntryAsMessage(string text)
        {
            if (_message)
            {
                Log(text, 1);
            }
        }

        public void LogEntryAsWarning(string text)
        {
            if (_warning)
            {
                Log(text, 3);
            }
        }

        private void Log(string text, int t)
        {
            var connectionString = "Server=" + _dbParams["serverName"] + ";Initial Catalog=" + _dbParams["DataBaseName"] + ";User ID=" + _dbParams["userName"] + ";Password=" + _dbParams["password"] + ";";
            var sqlConnection = new SqlConnection(connectionString);

            var insertStatement = "insert into Log_Values values('" + text + "', " + t.ToString() + ")";
            var sqlCommand = new SqlCommand(insertStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }
}