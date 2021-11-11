using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Entry : IEntry
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

            public IEntry Build()
            {
                if (string.IsNullOrWhiteSpace(_text))
                {
                    return new NullEntry();
                }

                return new Entry(_text, _message, _warning, _error);
            }
        }

        public string Text { get; }
        public bool Message { get; }
        public bool Warning { get; }
        public bool Error { get; }
        private List<ILevel> _levels;

        protected Entry(string text, bool message, bool warning, bool error)
        {
            if (!message && !warning && !error)
            {
                throw new Exception(Logger.MUST_SPECIFY_MESSAGE_WARNING_ERROR);
            }

            Text = text;
            _levels = new List<ILevel>();
            if (message)
            {
                _levels.Add(new Message());
            }

            if (warning)
            {
                _levels.Add(new Warning());
            }

            if (error)
            {
                _levels.Add(new Error());
            }
        }

        public void LogInto(ILogger logger)
        {
            foreach (var level in _levels)
            {
                level.LogInto(logger, Text);
            }
        }
    }
}