namespace ConsoleApp
{
    public interface ILevel
    {
        void LogInto(ILogger logger, string text);
    }
}