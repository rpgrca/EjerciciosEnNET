using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day19.Logic
{
    public class Rules
    {
        private readonly string _data;
        private readonly Dictionary<int, Rule> _rules;

        public Rules (string data)
        {
            _rules = new Dictionary<int, Rule>();
            _data = data;

            ParseRules();
        }

        private void ParseRules() =>
            _data
                .Split("\n\n")[0].Split("\n")
                .ToList()
                .ForEach(r => {
                    var rule = new Rule(r);
                    _rules.Add(rule.Id, rule);
                });

        internal List<int> ConsumesMessageWith(int id, string message) =>
            _rules[id].Consumes(message, this);

        public bool VerifiesWith(int id, string message) =>
            ConsumesMessageWith(id, message).Any(p => p == message.Length);
    }
}