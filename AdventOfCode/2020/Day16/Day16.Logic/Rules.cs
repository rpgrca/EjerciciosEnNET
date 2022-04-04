using System.Linq;
using System.Collections.Generic;

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
            _activeRules = _rules
                .Split("\n")
                .ToList()
                .ConvertAll(r => new Rule(r));
        }

        public bool Includes(int value) =>
            _activeRules.Any(r => r.Includes(value));

        public List<string> GuessFieldsFor(List<int> numbers) =>
            _activeRules
                .Where(rule => numbers.All(number => rule.Includes(number)))
                .Select(rule => rule.Name)
                .ToList();
    }
}