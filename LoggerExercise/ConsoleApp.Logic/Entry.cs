namespace ConsoleApp
{
    public class Entry
    {
        public string Text { get; }
        public bool Message { get; }
        public bool Warning { get; }
        public bool Error { get; }

        public Entry(string text, bool message = false, bool warning = false, bool error = false) =>
            (Text, Message, Warning, Error) = (text, message, warning, error);
    }
}