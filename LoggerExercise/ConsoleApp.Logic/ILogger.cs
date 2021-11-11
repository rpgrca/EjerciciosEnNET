namespace ConsoleApp
{
    public interface ILogger
    {
        void Log(IEntry entry);
        void LogEntryAsMessage(string text);
        void LogEntryAsWarning(string text);
        void LogEntryAsError(string text);
    }
}