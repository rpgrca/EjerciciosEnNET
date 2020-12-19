using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day19.Logic
{
    public class Rules
    {
        private readonly Dictionary<int, Rule> _rules;

        public int Count => _rules.Count;

        public Rules (string data)
        {
            _rules = new Dictionary<int, Rule>();

            foreach (var line in data.Split("\n\n")[0].Split("\n"))
            {
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var rule = new Rule(line);
                _rules.Add(rule.Id, rule);
            }
        }

        public Rule GetRule(int id)
        {
            return _rules[id];
        }

        public List<int> ConsumesMessageWith(int id, string message)
        {
            return _rules[id].Consumes(message, this);
        }

        public bool VerifiesWithRule(int id, string message)
        {
            return ConsumesMessageWith(id, message).Any(p => p == message.Length);
        }
    }
}