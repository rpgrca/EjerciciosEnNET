using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Day12.Logic
{
    public class PathFinding
    {
        private readonly string _data;
        private readonly Dictionary<string, List<string>> _map;
        private readonly List<List<string>> _paths;

        public int CaveCount { get; private set; }
        public int LargeCaveCount { get; private set; }
        public int SmallCaveCount { get; private set; }
        public int Paths => _paths.Count;

        public PathFinding(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new Dictionary<string, List<string>>();
            _paths = new List<List<string>>();

            Parse();
            CalculatePaths();
        }

        private void Parse()
        {
            foreach (var path in _data.Split("\n"))
            {
                var cave = path.Split("-");

                if (cave[1] == "start" || cave[0] == "end")
                {
                    if (! _map.ContainsKey(cave[1]))
                    {
                        _map.Add(cave[1], new List<string>());
                    }

                    _map[cave[1]].Add(cave[0]);
                }
                else if (cave[0] == "start")
                {
                    if (! _map.ContainsKey(cave[1]))
                    {
                        _map.Add(cave[1], new List<string>());
                    }

                    if (! _map.ContainsKey(cave[0]))
                    {
                        _map.Add(cave[0], new List<string>());
                    }

                    _map[cave[0]].Add(cave[1]);
                }
                else if (cave[1] == "end")
                {
                    if (! _map.ContainsKey(cave[0]))
                    {
                        _map.Add(cave[0], new List<string>());
                    }

                    _map[cave[0]].Add(cave[1]);
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

            CaveCount = _map.Keys.Count + 1;
            SmallCaveCount = _map.Count(p => IsSmallCave(p.Key));
            LargeCaveCount = _map.Count(p => IsLargeCave(p.Key));
        }

        private static bool IsLargeCave(string cave) => cave == cave.ToUpper();

        private static bool IsSmallCave(string cave) => cave == cave.ToLower() && cave != "start" && cave != "end";

        private void CalculatePaths()
        {
            var walkedThrough = new List<string>();
            FindPathToEndFrom("start", walkedThrough);
        }

        private void FindPathToEndFrom(string from, List<string> walkedThrough)
        {
            if (from == "end")
            {
                var finalPath = new List<string>(walkedThrough)
                {
                    from
                };

                _paths.Add(finalPath);
                return;
            }

            if (IsSmallCave(from) && walkedThrough.Contains(from))
            {
                return;
            }

            walkedThrough.Add(from);
            foreach (var cave in _map[from])
            {
                FindPathToEndFrom(cave, walkedThrough);
            }
            walkedThrough.RemoveAt(walkedThrough.Count - 1);
        }

        public PathFinding(string data, bool _)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new Dictionary<string, List<string>>();
            _paths = new List<List<string>>();

            Parse();
            CalculatePathsWhenOneSmallCaveCanBeVisitedTwice();
        }

        private void CalculatePathsWhenOneSmallCaveCanBeVisitedTwice()
        {
             var walkedThrough = new List<string>();
            FindPathToEndFrom("start", walkedThrough, false);
        }

        private void FindPathToEndFrom(string from, List<string> walkedThrough, bool smallCaveAlreadyVisitedTwice)
        {
            if (from == "end")
            {
                var finalPath = new List<string>(walkedThrough)
                {
                    from
                };

                _paths.Add(finalPath);
                return;
            }

            if (IsSmallCave(from) && walkedThrough.Contains(from))
            {
                if (smallCaveAlreadyVisitedTwice)
                {
                    return;
                }
                else
                {
                    smallCaveAlreadyVisitedTwice = true;
                    walkedThrough.Add(from);
                    foreach (var cave in _map[from])
                    {
                        FindPathToEndFrom(cave, walkedThrough, smallCaveAlreadyVisitedTwice);
                    }

                    walkedThrough.RemoveAt(walkedThrough.Count - 1);
                    return;
                }
            }

            walkedThrough.Add(from);
            foreach (var cave in _map[from])
            {
                FindPathToEndFrom(cave, walkedThrough, smallCaveAlreadyVisitedTwice);
            }
            walkedThrough.RemoveAt(walkedThrough.Count - 1);
        }
    }
}