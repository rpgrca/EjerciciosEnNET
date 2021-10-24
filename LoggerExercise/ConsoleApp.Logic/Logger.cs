using System;
using System.Collections.Generic;

namespace ConsoleApp
{
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
        private static IDictionary<string, string> dbParams;

        public Logger(bool logToFileParam, bool logToConsoleParam, bool logToDatabaseParam, bool logMessageParam, bool logWarningParam, bool logErrorParam, IDictionary<string, string> dbParamsMap)
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

        public void LogMessage(Entry entry)
        {
            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                return;
            }

            if (!entry.Message && !entry.Warning && !entry.Error)
            {
                throw new Exception(MUST_SPECIFY_MESSAGE_WARNING_ERROR);
            }

            string l = new Summary(logMessage, logWarning, logError).Build(entry.Text.Trim(), entry.Message, entry.Warning, entry.Error);

            if (logToFile)
            {
                new FileLogging(dbParams["logFileFolder"] + "/logFile.txt").Log(l);
            }

            if (logToConsole)
            {
                new ConsoleLogging().Log(entry.Message, entry.Warning, entry.Error, l);
            }

            if (logToDatabase)
            {
                new DatabaseLogging(logMessage, logWarning, logError, dbParams).Log(entry);
            }
        }
    }
}