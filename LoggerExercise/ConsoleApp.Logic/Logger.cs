using System;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApp
{
    public class Summary
    {
        private readonly bool _logError;
        private readonly bool _logWarning;
        private readonly bool _logMessage;

        public Summary(bool logMessage, bool logWarning, bool logError)
        {
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logError = logError;
        }

        public string Build(string messageText, bool message, bool warning, bool error)
        {
            string l = string.Empty;
            if (error && _logError)
            {
                l = l + "error " + DateTime.Now + " " + messageText + "\n";
            }

            if (warning && _logWarning)
            {
                l = l + "warning " + DateTime.Now + " " + messageText + "\n";
            }

            if (message && _logMessage)
            {
                l = l + "message " + DateTime.Now + " " + messageText + "\n";
            }

            return l.Trim();
        }
    }

    public class Logger
    {
        public const string INVALID_CONFIGURATION = "Invalid configuration";
        public const string MUST_SPECIFY_MESSAGE_WARNING_ERROR = "Error or Warning or Message must be specified";
        public const string INVALID_CONFIGURATION_VARIABLES = "Invalid configuration variables";
        private readonly bool logToFile;
        private readonly bool logToConsole;
        private readonly bool logToDatabase;
        private readonly bool logMessage;
        private readonly bool logWarning;
        private readonly bool logError;
        private static IDictionary dbParams;

        public Logger(bool logToFileParam, bool logToConsoleParam, bool logToDatabaseParam, bool logMessageParam, bool logWarningParam, bool logErrorParam, IDictionary dbParamsMap)
        {
            if (!logToConsoleParam && !logToFileParam && !logToDatabaseParam)
            {
                throw new Exception(INVALID_CONFIGURATION);
            }

            if (!logErrorParam && !logMessageParam && !logWarningParam)
            {
                throw new Exception(MUST_SPECIFY_MESSAGE_WARNING_ERROR);
            }

            if (dbParamsMap is null)
            {
                throw new Exception(INVALID_CONFIGURATION_VARIABLES);
            }

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
            if (!message && !warning && !error)
            {
                throw new Exception(MUST_SPECIFY_MESSAGE_WARNING_ERROR);
            }

            string l = new Summary(logMessage, logWarning, logError).Build(messageText.Trim(), message, warning, error);

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
                LogToDatabase(messageText, message, warning, error);
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

        private void LogToDatabase(string messageText, bool message, bool warning, bool error)
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

            if (t != 0)
            {
                string connectionString = "Server=" + dbParams["serverName"] + ";Initial Catalog=" + dbParams["DataBaseName"] + ";User ID=" + dbParams["userName"] + ";Password=" + dbParams["password"] + ";";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string insertStatement = "insert into Log_Values values('" + messageText + "', " + t.ToString() + ")";
                SqlCommand sqlCommand = new SqlCommand(insertStatement, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
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