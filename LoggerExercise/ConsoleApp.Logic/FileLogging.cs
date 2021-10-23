using System.IO;

namespace ConsoleApp
{
    public class FileLogging
    {
        private readonly string _logFile;

        public FileLogging(string logFile) =>
            _logFile = logFile;

        public void Log(string l)
        {
            bool exists = File.Exists(_logFile);
            StreamWriter file = null;
            if (!exists)
            {
                file = File.CreateText(_logFile);
            }

            file.WriteLine(l.Trim());
            file.Close();
        }
    }
}