using System.Collections.Generic;
using System.Linq;
using System;

namespace AdventOfCode2020.Day16.Logic
{
    public class Rule
    {
        private readonly string _rules;
        private List<Func<int, bool>> _ranges;
        public string Name { get; private set; }

        public Rule(string rules)
        {
            _rules = rules;

            ParseRules();
        }

        private void ParseRules()
        {
            var sections = _rules.Split(":");
            Name = sections[0];

            _ranges = sections[1]
                .Split(" or ")
                .Select(s => (Bottom: int.Parse(s.Split("-")[0]), Top: int.Parse(s.Split("-")[1])))
                .Select(p => new Func<int, bool>(x => x >= p.Bottom && x <= p.Top))
                .ToList();
        }

        public bool Includes(int value) =>
            _ranges.Any(x => x(value));
    }
}