using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Logic
{
    public class PolymerizationEquipment
    {
        private readonly string _input;
        private readonly List<string> _rules;

        public string PolymerTemplate { get; set; }

        public PolymerizationEquipment(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
            _rules = new List<string>();

            Parse();
        }

        private void Parse()
        {
            var input = _input.Split("\n");
            PolymerTemplate = input[0];

            _rules.AddRange(input[2..].Select(p => p));
        }

        public int GetPairInsertionRulesCount() => _rules.Count;
    }
}