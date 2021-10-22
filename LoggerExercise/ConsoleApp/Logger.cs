using System;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApp
{
    class Logger
    {
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
            try
            {
                messageText.Trim();
                if (messageText == null || messageText.Length == 0)
                {
                    return;
                }
                if (!logToConsole && !logToFile && !logToDatabase)
                {
                    throw new Exception("Invalid configuration");
                }
                if ((!logError && !logMessage && !logWarning) || (!message && !warning && !error))
                {
                    throw new Exception("Error or Warning or Message must be specified");
                }

                string connectionString = "Data Source=" + dbParams["serverName"] + "; InitialCatalog=" + dbParams["DataBaseName"] + "; UserID=" + dbParams["userName"] + ";Password=" + dbParams["password"] + ";";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

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

                string l = string.Empty;
                bool exists = File.Exists(dbParams["logFileFolder"] + "/logFile.txt");
                StreamWriter file = null;
                if (!exists)
                {
                    file = File.CreateText(dbParams["logFileFolder"] + "/logFile.txt");
                }

                if (error && logError)
                {
                    l = l + "error " + DateTime.Now + " " + messageText;
                }

                if (warning && logWarning)
                {
                    l = l + "warning " + DateTime.Now + " " + messageText;
                }

                if (message && logMessage)
                {
                    l = l + "message " + DateTime.Now + " " + messageText;
                }

                if (logToFile)
                {
                    if(file == null)
                    {
                        file = File.CreateText(dbParams["logFileFolder"] + "/logFile.txt");
                    }

                    file.WriteLine(l);
                    file.Close();
                }

                if (logToConsole)
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

                if (logToDatabase)
                {
                    string insertStatement = "insert into Log_Values('" + messageText + "', " + t.ToString() + ")";
                    SqlCommand sqlCommand = new SqlCommand(insertStatement, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
