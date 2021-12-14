using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Logic
{
    public class PolymerizationEquipment
    {
        private readonly string _input;
        private readonly Dictionary<string, char> _rules;
        private readonly Dictionary<string, Dictionary<char, long>> _count;
        private long _substraction;

        public string PolymerTemplate { get; private set; }

        public PolymerizationEquipment(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
            _rules = new Dictionary<string, char>();
            _count = new Dictionary<string, Dictionary<char, long>>();

            Parse();
        }

        private void Parse()
        {
            var input = _input.Split("\n");
            PolymerTemplate = input[0];
            input[2..].Select(p => p.Split(" -> ")).ToList().ForEach(p => _rules.Add(p[0], p[1][0]));
        }

        public int GetPairInsertionRulesCount() => _rules.Keys.Count;

        public void Step(int count)
        {
            for (var index = 0; index < count; index++)
            {
                Step();
            }

            var groups = PolymerTemplate.GroupBy(p => p);
            var values = groups.Select(p => new { Key = p.Key, Count = p.Count() }).ToList();
            _substraction = groups.Max(p => p.Count()) - groups.Min(p => p.Count());

//            Step2(count);
        }

        private void Step()
        {
            var stringBuilder = new StringBuilder(PolymerTemplate[0].ToString());

            for (var index = 0; index < PolymerTemplate.Length - 1; index++)
            {
                stringBuilder
                    .Append(_rules[PolymerTemplate[index..(index + 2)]])
                    .Append(PolymerTemplate[index + 1]);
            }

            PolymerTemplate = stringBuilder.ToString();
        }

        public void Step2(int count)
        {
            var counter = new Dictionary<char, long>();
            var cache = new Dictionary<string, Dictionary<char, long>>();

            for (var index = 0; index < PolymerTemplate.Length - 1; index++)
            {
                CountValues(count + 1, PolymerTemplate[index], PolymerTemplate[index + 1], counter, cache);
            }

            foreach (var value in PolymerTemplate)
            {
                counter[value]++;
            }

            _substraction = counter.Max(p => p.Value) - counter.Min(p => p.Value);
        }

        private void CountValues(int count, char first, char second, Dictionary<char, long> counter, Dictionary<string, Dictionary<char, long>> cache)
        {
            count--;
            if (count == 0)
            {
                return;
            }

            var newCharacter = _rules[$"{first}{second}"];
            counter.TryAdd(newCharacter, 0);
            counter[newCharacter]++;

            var key = $"{first}{newCharacter}[{count}]";
            if (!cache.ContainsKey(key))
            {
                var newCounter = new Dictionary<char, long>();
                CountValues(count, first, newCharacter, newCounter, cache);
                cache.Add(key, newCounter);
            }

            foreach (var (k, v) in cache[key])
            {
                counter.TryAdd(k, 0);
                counter[k] += v;
            }

            key = $"{newCharacter}{second}[{count}]";
            if (!cache.ContainsKey(key))
            {
                var newCounter = new Dictionary<char, long>();
                CountValues(count, newCharacter, second, newCounter, cache);
                cache.Add(key, newCounter);
            }

            foreach (var (k, v) in cache[key])
            {
                counter.TryAdd(k, 0);
                counter[k] += v;
            }
        }

        public long CountElementInTemplate(string value) => PolymerTemplate.Count(p => p == value[0]);

        public long GetSubstraction() => _substraction;
    }
}