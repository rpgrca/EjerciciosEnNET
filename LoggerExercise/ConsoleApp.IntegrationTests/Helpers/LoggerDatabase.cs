using System.Data.SqlClient;
using static ConsoleApp.IntegrationTests.Constants;

namespace ConsoleApp.IntegrationTests.Helpers
{
    public static class LoggerDatabase
    {
        public static void Empty()
        {
            var connectionString = $"Server={DATABASE_SERVER};Initial Catalog={DATABASE_NAME};User ID={DATABASE_USERNAME};Password={DATABASE_PASSWORD};";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using var sqlCommand = new SqlCommand("DELETE FROM Log_Values", sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}