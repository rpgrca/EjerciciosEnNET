using System.IO;
using System.Collections.Generic;
using System;

namespace ConsoleApp
{
    public class FileLogging : ILogger
    {
        private readonly string _logFile;
        private readonly bool _message;
        private readonly bool _warning;
        private readonly bool _error;

        public FileLogging(bool message, bool warning, bool error, IDictionary<string, string> dbParams)
        {
            _message = message;
            _warning = warning;
            _error = error;
            _logFile = dbParams["logFileFolder"] + "/logFile.txt";
        }

        public void Log(IEntry entry)
        {
            entry.LogInto(this);
        }

        public void LogEntryAsError(string text)
        {
            if (_error)
            {
                var l = "error " + DateTime.Now + " " + text + "\n";
                Log(l);
            }
        }

        public void LogEntryAsMessage(string text)
        {
            if (_message)
            {
                var l = "message " + DateTime.Now + " " + text + "\n";
                Log(l);
            }
        }

        public void LogEntryAsWarning(string text)
        {
            if (_warning)
            {
                var l = "warning " + DateTime.Now + " " + text + "\n";
                Log(l);
            }
        }

        private void Log(string l)
        {
            bool exists = File.Exists(_logFile);
            StreamWriter file = null;
            if (!exists)
            {
                file = File.CreateText(_logFile);
            }
            else
            {
                file = File.AppendText(_logFile);
            }

            file.WriteLine(l.Trim());
            file.Close();
        }
    }
}