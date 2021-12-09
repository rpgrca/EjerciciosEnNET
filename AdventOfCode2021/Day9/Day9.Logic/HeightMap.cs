using System.Linq;
using System;
using System.Collections.Generic;

namespace Day9.Logic
{
    public class HeightMap
    {
        private readonly string _data;
        private readonly List<int[]> _map;

        public int Width => _map[0].Length;
        public int Height => _map.Count;

        public HeightMap(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new List<int[]>();

            Parse();
        }

        private void Parse()
        {
            foreach (var row in _data.Split("\n").ToList())
            {
                _map.Add(row.Select(p => p - '0').ToArray());
            }
        }
    }
}
