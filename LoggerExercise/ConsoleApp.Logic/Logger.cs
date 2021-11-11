using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Logger
    {
        public const string INVALID_CONFIGURATION = "Invalid configuration";
        public const string MUST_SPECIFY_MESSAGE_WARNING_ERROR = "Error or Warning or Message must be specified";
        public const string INVALID_CONFIGURATION_VARIABLES = "Invalid configuration variables";
        private readonly List<ILogger> _loggers;

        public Logger(bool logToFileParam, bool logToConsoleParam, bool logToDatabaseParam, bool logMessageParam, bool logWarningParam, bool logErrorParam, IDictionary<string, string> dbParams)
        {
            _loggers = new List<ILogger>();

            if (!logToConsoleParam && !logToFileParam && !logToDatabaseParam)
            {
                throw new Exception(INVALID_CONFIGURATION);
            }

            if (!logErrorParam && !logMessageParam && !logWarningParam)
            {
                throw new Exception(MUST_SPECIFY_MESSAGE_WARNING_ERROR);
            }

            if (dbParams is null)
            {
                throw new Exception(INVALID_CONFIGURATION_VARIABLES);
            }

            if (logToFileParam)
            {
                _loggers.Add(new FileLogging(logMessageParam, logWarningParam, logErrorParam, dbParams));
            }

            if (logToConsoleParam)
            {
                _loggers.Add(new ConsoleLogging(logMessageParam, logWarningParam, logErrorParam, dbParams));
            }

            if (logToDatabaseParam)
            {
                _loggers.Add(new DatabaseLogging(logMessageParam, logWarningParam, logErrorParam, dbParams));
            }
        }

        public void LogMessage(IEntry entry)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(entry);
            }
        }
    }
}