using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Logic
{
    public sealed class PolymerizationEquipment
    {
        private readonly string _input;
        private readonly Dictionary<string, char> _rules;
        private readonly Dictionary<char, long> _counter;
        private readonly ICache _cache;
        private readonly IStringAccumulator _stringAccumulator;
        private long _subtraction;

        public string PolymerTemplate { get; private set; }

        public static PolymerizationEquipment CreateEquipmentTrackingPolymers(string input) =>
            new(input, new StringAccumulator(), new TranscientCache());

        public static PolymerizationEquipment CreateEquipmentCountingPolymers(string input) =>
            new(input, new NullAccumulator(), new PersistentCache());

        private PolymerizationEquipment(string input, IStringAccumulator stringAccumulator, ICache cache)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
            _rules = new Dictionary<string, char>();
            _counter = new Dictionary<char, long>();
            _stringAccumulator = stringAccumulator;
            _cache = cache;

            Parse();
        }

        private void Parse()
        {
            var input = _input.Split("\n");
            PolymerTemplate = input[0];
            _stringAccumulator.Append(PolymerTemplate[0]);

            input[2..]
                .Select(p => p.Split(" -> "))
                .ToList()
                .ForEach(p => _rules.Add(p[0], p[1][0]));
        }

        public int GetPairInsertionRulesCount() => _rules.Keys.Count;

        public void RunFor(int steps)
        {
            InitializeCounterWithPolymerTemplate();
            ProcessEveryPairInPolymerTemplate(steps);
            StoreGeneratedString();
            CalculateSubtractionBetweenMoreAndLeastCommonPolymers();
        }

        private void InitializeCounterWithPolymerTemplate() =>
            PolymerTemplate
                .ToList()
                .ForEach(p => {
                    _counter.TryAdd(p, 0);
                    _counter[p]++;
                });

        private void ProcessEveryPairInPolymerTemplate(int steps) =>
            PolymerTemplate[0..^1]
                .Zip(PolymerTemplate[1..])
                .ToList()
                .ForEach(p => CountValues(steps, p.First, p.Second, _counter));

        private void StoreGeneratedString() =>
            PolymerTemplate = _stringAccumulator.Value;

        private void CalculateSubtractionBetweenMoreAndLeastCommonPolymers() =>
            _subtraction = _counter.Max(p => p.Value) - _counter.Min(p => p.Value);

        private void CountValues(int recursionDepth, char first, char second, Dictionary<char, long> counter)
        {
            if (recursionDepth-- == 0)
            {
                _stringAccumulator.Append(second);
                return;
            }

            var key = $"{first}{second}";
            var characterToInsert = _rules[key];
            counter.TryAdd(characterToInsert, 0);
            counter[characterToInsert]++;

            var values = CountValuesIn(recursionDepth, first, characterToInsert);
            AccumulateValuesIn(counter, values);

            values = CountValuesIn(recursionDepth, characterToInsert, second);
            AccumulateValuesIn(counter, values);
        }

        private Dictionary<char, long> CountValuesIn(int recursionDepth, char first, char second)
        {
            var key = GetKeyFor(first, second, recursionDepth);
            if (!_cache.ContainsKey(key))
            {
                var newCounter = new Dictionary<char, long>();
                CountValues(recursionDepth, first, second, newCounter);
                _cache.Add(key, newCounter);
            }

            return _cache[key];
        }

        private static string GetKeyFor(char first, char second, int recursionDepth) =>
            $"{first}{second}{recursionDepth}";

        private static void AccumulateValuesIn(Dictionary<char, long> to, Dictionary<char, long> from) =>
            from.ToList().ForEach(kv =>
            {
                to.TryAdd(kv.Key, 0);
                to[kv.Key] += kv.Value;
            });

        public long CountElementInTemplate(string value) =>
            PolymerTemplate.Count(p => p == value[0]);

        public long GetSubtraction() => _subtraction;
    }
}