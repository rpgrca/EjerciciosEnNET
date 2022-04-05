using System.Collections.Generic;

namespace Day14.Logic
{
    internal interface ICache
    {
        Dictionary<char, long> this[string key] { get; }
        void Add(string key, Dictionary<char, long> value);
        bool ContainsKey(string key);
    }

    internal class TranscientCache : ICache
    {
        private Dictionary<char, long> _lastValue = new();

        public Dictionary<char, long> this[string key] => _lastValue;

        public void Add(string key, Dictionary<char, long> value) =>
            _lastValue = value;

        public bool ContainsKey(string key) => false;
    }

    internal class PersistentCache : ICache
    {
        private readonly Dictionary<string, Dictionary<char, long>> _cache;

        public PersistentCache() =>
            _cache = new Dictionary<string, Dictionary<char, long>>();

        public Dictionary<char, long> this[string key] => _cache[key];

        public void Add(string key, Dictionary<char, long> value) => _cache.Add(key, value);

        public bool ContainsKey(string key) => _cache.ContainsKey(key);
    }
}