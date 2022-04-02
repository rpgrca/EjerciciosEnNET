using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day19.Logic
{
    internal class RuleParser
    {
        private readonly string _rule;
        private string[] _lineSplitInHalf;
        private int _id;

        public RuleParser(string rule) => _rule = rule;

        public void Parse(Rule rule)
        {
            SplitIdAndMatch();
            ObtainIdFromLine();
            SetIdTo(rule);

            if (IsFinalNode())
            {
                SetCharacterIn(rule);
            }
            else
            {
                ParseSubRules(rule);
            }
        }

        private void SplitIdAndMatch() => _lineSplitInHalf = _rule.Split(":");

        private void ObtainIdFromLine() => _id = int.Parse(_lineSplitInHalf[0]);

        private void SetIdTo(Rule rule) => rule.SetId(_id);

        private bool IsFinalNode() => _lineSplitInHalf[1].Trim().StartsWith("\"");

        private void SetCharacterIn(Rule rule) => rule.SetCharacter(_lineSplitInHalf[1].Trim()[1]);

        private void ParseSubRules(Rule rule)
        {
            foreach (var subRule in _lineSplitInHalf[1].Trim().Split("|"))
            {
                var subRules = new List<int>();
                subRule.Trim()
                    .Split(" ")
                    .ToList()
                    .ForEach(s => subRules.Add(int.Parse(s)));

                rule.AddSubRule(subRules);
            }
        }
    }
}