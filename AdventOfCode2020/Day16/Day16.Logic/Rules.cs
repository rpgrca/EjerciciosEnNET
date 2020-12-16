using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day16.Logic
{
    public class Rules
    {
        private readonly string _rules;
        private List<Rule> _activeRules;

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
    }
}