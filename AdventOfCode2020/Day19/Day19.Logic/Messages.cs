using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day19.Logic
{
    public class Messages
    {
        private readonly string _data;
        private readonly List<string> _messages;

        public Messages(string data)
        {
            _data = data;
            _messages = new List<string>();

            ParseMessages();
        }

        private void ParseMessages() => _messages.AddRange(_data.Split("\n\n")[1].Split("\n"));

        public int ThatMatchRule(int id, Rules rules) => _messages.Count(p => rules.VerifiesWith(id, p));
    }
}