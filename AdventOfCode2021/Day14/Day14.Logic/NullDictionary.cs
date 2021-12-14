using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Day14.Logic
{
    public class NullDictionary<T, V> : IDictionary<T, V>
    {
        private T _lastKey;
        private V _lastValue;

        public V this[T key] {
            get
            {
                if (key.Equals(_lastKey)) return _lastValue;
                throw new NotImplementedException();
            }
            set => throw new NotImplementedException();
        }

        public ICollection<T> Keys => throw new NotImplementedException();

        public ICollection<V> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T key, V value)
        {
            _lastKey = key;
            _lastValue = value;
        }

        public void Add(KeyValuePair<T, V> item)
        {
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<T, V> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(T key)
        {
            return false;
        }

        public void CopyTo(KeyValuePair<T, V>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<T, V>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<T, V> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(T key, [MaybeNullWhen(false)] out V value)
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}