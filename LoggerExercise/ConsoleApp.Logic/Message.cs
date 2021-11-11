namespace ConsoleApp
{
    public class Message : ILevel
    {
        public void LogInto(ILogger logger, string text) =>
            logger.LogEntryAsMessage(text);
    }
}