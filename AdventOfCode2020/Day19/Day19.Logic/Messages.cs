using System;
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

            foreach (var message in _data.Split("\n\n")[1].Split("\n"))
            {
                _messages.Add(message);
            }
        }

        public int ThatMatchRule(int ruleId, Rules rules)
        {
            return _messages.Count(p => rules.VerifiesWithRule(ruleId, p));
        }
    }
}