namespace ConsoleApp
{
    public class Error : ILevel
    {
        public void LogInto(ILogger logger, string text) =>
            logger.LogEntryAsError(text);
    }
}