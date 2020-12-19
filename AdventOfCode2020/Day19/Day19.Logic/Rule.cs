using System.Linq;
using System.Collections.Generic;
using System;

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

        public List<int> Consumes(string message, Rules rules)
        {
            var finalConsumedList = new List<int>();
            var consumedList = new List<int>();
            var actions = new List<Action<List<int>>>();

            if (string.IsNullOrEmpty(message))
            {
                return consumedList;
            }

            if (Character.HasValue)
            {
                finalConsumedList.Add(message[0] == Character? 1 : 0);
                return finalConsumedList;
            }
            else
            {
                foreach (var subRule in _subRules)
                {
                    consumedList.Add(0);
                    var fail = false;
                    foreach (var id in subRule)
                    {
                        foreach (var consumed in consumedList)
                        {
                            var consumedNow = rules.ConsumesMessageWith(id, message[consumed..]).Where(p => p > 0).ToList();
                            if (consumedNow.Count > 0)
                            {
                                consumedNow.ForEach(c => actions.Add(l => l.Add(c + consumed)));
                            }
                            else
                            {
                                actions.Add(l => l.Remove(consumed));
                                fail = true;
                            }
                        }

                        consumedList.Clear();
                        actions.ForEach(a => a(consumedList));
                        actions.Clear();

                        if (fail)
                        {
                            break;
                        }
                    }

                    if (consumedList.Any(p => p == message.Length))
                    {
                        return consumedList;
                    }
                    else
                    {
                        finalConsumedList.AddRange(consumedList);
                        consumedList.Clear();
                    }
                }
            }

            return finalConsumedList;
        }
    }
}