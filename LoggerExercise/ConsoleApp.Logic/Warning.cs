namespace ConsoleApp
{
    public class Warning : ILevel
    {
        public void LogInto(ILogger logger, string text) =>
            logger.LogEntryAsWarning(text);
    }
}