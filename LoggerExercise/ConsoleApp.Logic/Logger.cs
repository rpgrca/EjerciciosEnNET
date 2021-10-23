using System;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApp
{
    public class Logger
    {
        public const string INVALID_CONFIGURATION = "Invalid configuration";
        public const string MUST_SPECIFY_MESSAGE_WARNING_ERROR = "Error or Warning or Message must be specified";
        private static bool logToFile;
        private static bool logToConsole;
        private static bool logMessage;
        private static bool logWarning;
        private static bool logError;
        private static bool logToDatabase;
        private static IDictionary dbParams;

        public Logger(bool logToFileParam, bool logToConsoleParam, bool logToDatabaseParam, bool logMessageParam, bool logWarningParam, bool logErrorParam, IDictionary dbParamsMap)
        {
            logError = logErrorParam;
            logMessage = logMessageParam;
            logWarning = logWarningParam;
            logToDatabase = logToDatabaseParam;
            logToFile = logToFileParam;
            logToConsole = logToConsoleParam;
            dbParams = dbParamsMap;
        }

        public void LogMessage(string messageText, bool message, bool warning, bool error)
        {
            if (string.IsNullOrWhiteSpace(messageText))
            {
                return;
            }
            if (!logToConsole && !logToFile && !logToDatabase)
            {
                throw new Exception(INVALID_CONFIGURATION);
            }
            if ((!logError && !logMessage && !logWarning) || (!message && !warning && !error))
            {
                throw new Exception(MUST_SPECIFY_MESSAGE_WARNING_ERROR);
            }

            string connectionString = "Server=" + dbParams["serverName"] + ";Initial Catalog=" + dbParams["DataBaseName"] + ";User ID=" + dbParams["userName"] + ";Password=" + dbParams["password"] + ";";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string l = BuildLogText(messageText.Trim(), message, warning, error);

            if (logToFile)
            {
                LogToFile(dbParams["logFileFolder"] + "/logFile.txt", l);
            }

            if (logToConsole)
            {
                LogToConsole(message, warning, error, l);
            }

            if (logToDatabase)
            {
                LogToDatabase(messageText, message, warning, error, sqlConnection);
            }
        }

        private static void LogToConsole(bool message, bool warning, bool error, string l)
        {
            if (message)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(l);
                Console.ResetColor();
            }

            if (warning)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(l);
                Console.ResetColor();
            }

            if (error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(l);
                Console.ResetColor();
            }
        }

        private static void LogToDatabase(string messageText, bool message, bool warning, bool error, SqlConnection sqlConnection)
        {
            int t = 0;
            if (message && logMessage)
            {
                t = 1;
            }

            if (error && logError)
            {
                t = 2;
            }

            if (warning && logWarning)
            {
                t = 3;
            }

            string insertStatement = "insert into Log_Values values('" + messageText + "', " + t.ToString() + ")";
            SqlCommand sqlCommand = new SqlCommand(insertStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }

        private static string BuildLogText(string messageText, bool message, bool warning, bool error)
        {
            string l = string.Empty;
            if (error && logError)
            {
                l = l + "error " + DateTime.Now + " " + messageText + "\n";
            }

            if (warning && logWarning)
            {
                l = l + "warning " + DateTime.Now + " " + messageText + "\n";
            }

            if (message && logMessage)
            {
                l = l + "message " + DateTime.Now + " " + messageText + "\n";
            }

            return l.Trim();
        }

        private static void LogToFile(string logFile, string l)
        {
            bool exists = File.Exists(logFile);
            StreamWriter file = null;
            if (!exists)
            {
                file = File.CreateText(logFile);
            }

            file.WriteLine(l.Trim());
            file.Close();
        }
    }
}
