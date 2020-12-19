using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day19.Logic
{
    public class Rule
    {
        private readonly string _rule;
        private readonly List<List<int>> _subRules;

        public int Id { get; private set; }
        public char? Character { get; private set; }

        public Rule(string rule)
        {
            _rule = rule;
            _subRules = new List<List<int>>();

            ParseRule();
        }

        private void ParseRule()
        {
            var line = _rule.Split(":");
            Id = int.Parse(line[0]);

            if (line[1].Trim().StartsWith("\""))
            {
                Character = line[1].Trim()[1];
            }
            else
            {
                foreach (var subRule in line[1].Trim().Split("|"))
                {
                    var subRules = new List<int>();
                    subRule.Trim()
                        .Split(" ")
                        .ToList()
                        .ForEach(s => subRules.Add(int.Parse(s)));

                    _subRules.Add(subRules);
                }
            }
        }

        public int Consumes(string message, Rules rules)
        {
            if (Character.HasValue)
            {
                return message[0] == Character? 1 : 0;
            }
            else
            {
                foreach (var subRule in _subRules)
                {
                    var consumed = 0;
                    var fail = false;
                    foreach (var id in subRule)
                    {
                        var consumedNow = rules.ConsumesMessageWith(id, message[consumed..]);
                        if (consumedNow < 1)
                        {
                            fail = true;
                            break;
                        }

                        consumed += consumedNow;
                    }

                    if (! fail)
                    {
                        return consumed;
                    }
                }
            }

            return 0;
        }
    }
}