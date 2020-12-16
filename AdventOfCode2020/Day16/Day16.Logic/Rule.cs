using System.Collections.Generic;
using System.Linq;
using System;

namespace AdventOfCode2020.Day16.Logic
{
    public class Rule
    {
        private readonly string _rules;
        private readonly string _name;
        private readonly List<Func<int, bool>> _ranges;

        public Rule(string rules)
        {
            _rules = rules;
            _ranges = new List<Func<int, bool>>();

            ParseRules();
        }

        private void ParseRules()
        {
            var sections = _rules.Split(":");
            var _name = sections[0];
            var rules = sections[1].Split(" or ");

            foreach (var rule in rules)
            {
                var range = rule.Split("-");
                _ranges.Add(x => x >= int.Parse(range[0]) && x <= int.Parse(range[1]));
            }
        }

        public bool Includes(int value)
        {
            return _ranges.Any(x => x(value));
        }
    }



/*
    public class Scanner
    {
        private readonly string _rules;

        public Scanner(string rules)
        {
            _rules = rules;
        }



    }


        [Fact]
        public void Test1()
        {
            var rules = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

            var scanner = new Scanner(rules);
            
        }*/

}
