using System;
using System.Linq;
using System.Collections.Generic;

namespace Day12.Logic
{
    public class PathFinding
    {
        private readonly string _data;
        private readonly Dictionary<string, List<string>> _map;

        public int CaveCount { get; private set; }
        public int LargeCaveCount { get; private set; }
        public int SmallCaveCount { get; private set; }

        public PathFinding(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new Dictionary<string, List<string>>();

            Parse();
        }

        private void Parse()
        {
            foreach (var path in _data.Split("\n"))
            {
                var cave = path.Split("-");

                if (cave[1] == "start" || cave[1] == "end")
                {
                    if (! _map.ContainsKey(cave[1]))
                    {
                        _map.Add(cave[1], new List<string>());
                    }

                    _map[cave[1]].Add(cave[0]);
                }
                else
                {
                    if (! _map.ContainsKey(cave[0]))
                    {
                        _map.Add(cave[0], new List<string>());
                    }

                    _map[cave[0]].Add(cave[1]);

                    if (!_map.ContainsKey(cave[1]))
                    {
                        _map.Add(cave[1], new List<string>());
                    }

                    _map[cave[1]].Add(cave[0]);
                }
            }

            CaveCount = _map.Keys.Count;
            SmallCaveCount = _map.Count(p => p.Key != p.Key.ToUpper()) - 2;
            LargeCaveCount = _map.Count(p => p.Key == p.Key.ToUpper());
        }
    }
}
