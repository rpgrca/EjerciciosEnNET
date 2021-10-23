using System;
using Xunit;
using static ConsoleApp.IntegrationTests.Constants;

namespace ConsoleApp.IntegrationTests.Helpers
{
    public class LoggerFileValidator
    {
        private readonly string[] _contents;
        private int _currentLine;

        public LoggerFileValidator()
        {
            _currentLine = 0;
            _contents = System.IO.File.ReadAllLines(DEFAULT_LOG);
        }

        public void EnsureLineCountIs(int amount) =>
            Assert.Equal(amount, _contents.Length);

        public void EnsureThatPoppedLineIs(string type, string text) =>
            Assert.Matches($"^{type}.+{text}$", _contents[_currentLine++]);

        public void EnsureItIsEmpty() =>
            Assert.Empty(_contents[0]);
    }
}
