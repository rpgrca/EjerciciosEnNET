using System.Collections.Generic;

namespace AdventOfCode2020.Day19.Logic
{
    public class Rule
    {
        private readonly string _rule;
        private readonly List<List<int>> _subRules;

        public IEnumerable<List<int>> SubRules => _subRules;
        public int Id { get; private set; }
        public char? Character { get; private set; }

        public Rule(string rule)
        {
            _subRules = new List<List<int>>();
            _rule = rule;

            ParseRule();
        }

        private void ParseRule() => new RuleParser(_rule).Parse(this);

        public List<int> Consumes(string message, Rules rules) => new Consumer(message, this, rules).Consume();

        internal void AddSubRule(List<int> subRules) => _subRules.Add(subRules);

        internal void SetCharacter(char character) => Character = character;

        internal void SetId(int id) => Id = id;
    }
}