using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class ConsoleLogging : ILogger
    {
        private readonly bool _message;
        private readonly bool _warning;
        private readonly bool _error;

        public ConsoleLogging(bool message, bool warning, bool error, IDictionary<string, string> _)
        {
            _message = message;
            _warning = warning;
            _error = error;
        }

        public void Log(IEntry entry) => entry.LogInto(this);

        public void LogEntryAsMessage(string text)
        {
            if (_message)
            {
                var l = "message " + DateTime.Now + " " + text + "\n";

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(l);
                Console.ResetColor();
            }
        }

        public void LogEntryAsWarning(string text)
        {
            if (_warning)
            {
                var l = "warning " + DateTime.Now + " " + text + "\n";

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(l);
                Console.ResetColor();
            }
        }

        public void LogEntryAsError(string text)
        {
            if (_error)
            {
                var l = "error " + DateTime.Now + " " + text + "\n";

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(l);
                Console.ResetColor();
            }
        }
    }
}