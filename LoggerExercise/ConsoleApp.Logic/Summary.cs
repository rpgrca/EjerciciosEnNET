using System;

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
}