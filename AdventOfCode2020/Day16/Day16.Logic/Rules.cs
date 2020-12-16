using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2020.Day16.Logic
{
    public class Rules
    {
        private readonly string _rules;
        private List<Rule> _activeRules;

        public int Count => _activeRules.Count;

        public Rules(string rules)
        {
            _rules = rules;

            ParseRules();
        }

        private void ParseRules()
        {
            _activeRules = _rules.Split("\n")
                .ToList()
                .ConvertAll(r => new Rule(r));
        }

        public bool Includes(int value)
        {
            return _activeRules.Any(r => r.Includes(value));
        }

        public List<string> GuessFields(List<int> numbers)
        {
            var guessedFields = new List<string>();

            foreach (var rule in _activeRules)
            {
                if (numbers.All(n => rule.Includes(n)))
                {
                    guessedFields.Add(rule.Name);
                }
            }

            return guessedFields;
        }
    }
}