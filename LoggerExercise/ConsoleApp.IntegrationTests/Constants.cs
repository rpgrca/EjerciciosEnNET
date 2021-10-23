namespace ConsoleApp.IntegrationTests
{
    public static class Constants
    {
        public const string DEFAULT_LOG_FILE = "logFile.txt";
        public const string DEFAULT_LOG_PATH = "./Temp";
        public const string SAMPLE_LOG_TEXT = "this is a sample text";
        public const string DEFAULT_LOG = DEFAULT_LOG_PATH + "/" + DEFAULT_LOG_FILE;

        public const string DATABASE_SERVER = "tcp:logger-exercise-server.database.windows.net,1433";
        public const string DATABASE_NAME = "logger";
        public const string DATABASE_PASSWORD = "Extremely_Long_Password";
        public const string DATABASE_USERNAME = "Logger_server_admin_login";
    }
}
