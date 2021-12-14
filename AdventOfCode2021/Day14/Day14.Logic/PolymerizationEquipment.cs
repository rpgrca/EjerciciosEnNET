using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Logic
{
    public class PolymerizationEquipment
    {
        private readonly string _input;
        private readonly Dictionary<string, string> _rules;

        public string PolymerTemplate { get; private set; }

        public PolymerizationEquipment(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
            _rules = new Dictionary<string, string>();

            Parse();
        }

        private void Parse()
        {
            var input = _input.Split("\n");
            PolymerTemplate = input[0];
            input[2..].Select(p => p.Split(" -> ")).ToList().ForEach(p => _rules.Add(p[0], p[1]));
        }

        public int GetPairInsertionRulesCount() => _rules.Keys.Count;
    }
}