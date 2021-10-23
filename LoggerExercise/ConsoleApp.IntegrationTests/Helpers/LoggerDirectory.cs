using static ConsoleApp.IntegrationTests.Constants;

namespace ConsoleApp.IntegrationTests.Helpers
{
    public static class LoggerDirectory
    {
        public static void Create()
        {
            if (! System.IO.Directory.Exists(DEFAULT_LOG_PATH))
            {
                System.IO.Directory.CreateDirectory(DEFAULT_LOG_PATH);
            }
        }

        public static void DeleteLogFile()
        {
            if (System.IO.File.Exists(DEFAULT_LOG))
            {
                System.IO.File.Delete(DEFAULT_LOG);
            }
        }

        public static bool LogFileExists() => System.IO.File.Exists(DEFAULT_LOG);
    }
}
