namespace ConsoleApp
{
    public class Entry
    {
        public static class Director
        {
            public static Builder ConfigureToBuildMessage(string text) =>
                new Builder()
                    .WithText(text)
                    .AsMessage();

            public static Builder ConfigureToBuildWarning(string text) =>
                new Builder()
                    .WithText(text)
                    .AsWarning();

            public static Builder ConfigureToBuildError(string text) =>
                new Builder()
                    .WithText(text)
                    .AsError();

            public static Builder ConfigureToBuildProblem(string text) =>
                new Builder()
                    .WithText(text)
                    .AsWarning()
                    .AsError();

            public static Builder ConfigureToBuildFullLog(string text) =>
                new Builder()
                    .WithText(text)
                    .AsMessage()
                    .AsWarning()
                    .AsError();
        }

        public class Builder
        {
            private string _text;
            private bool _message;
            private bool _warning;
            private bool _error;

            public Builder WithText(string text)
            {
                _text = text;
                return this;
            }

            public Builder AsMessage()
            {
                _message = true;
                return this;
            }

            public Builder AsWarning()
            {
                _warning = true;
                return this;
            }

            public Builder AsError()
            {
                _error = true;
                return this;
            }

            public Entry Build() =>
                new Entry(_text, _message, _warning, _error);
        }

        public string Text { get; }
        public bool Message { get; }
        public bool Warning { get; }
        public bool Error { get; }

        private Entry(string text, bool message = false, bool warning = false, bool error = false) =>
            (Text, Message, Warning, Error) = (text, message, warning, error);
    }
}