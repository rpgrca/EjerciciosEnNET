using System;
using System.Linq;
using System.Collections.Generic;

namespace Day12.Logic
{
    public sealed partial class PathFinding
    {
        private readonly string _data;
        private readonly Dictionary<string, List<string>> _map;
        private readonly List<List<string>> _paths;
        private readonly ISmallCaveBehaviour _searchAlgorithm;

        public int Paths => _paths.Count;

        public static PathFinding CreateWithoutRepetition(string data) => new(data, new WalkOnlyOnceInSmallCave());

        public static PathFinding CreateWithAtMostOneRepetion(string data) => new(data, new RepeatUpToOneSmallCave());

        private PathFinding(string data, ISmallCaveBehaviour searchAlgorithm)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new Dictionary<string, List<string>>();
            _paths = new List<List<string>>();
            _searchAlgorithm = searchAlgorithm;

            Parse();
            CalculatePaths();
        }

        private void Parse()
        {
            foreach (var (caveFrom, caveTo) in _data.Split("\n").Select(p => p.Split("-")).Select(p => (p[0], p[1])))
            {
                if (caveTo == "start" || caveFrom == "end")
                {
                    AddCavePassage(caveTo, caveFrom);
                }
                else if (caveFrom == "start" || caveTo == "end")
                {
                    AddCavePassage(caveFrom, caveTo);
                }
                else
                {
                    AddCavePassage(caveFrom, caveTo);
                    AddCavePassage(caveTo, caveFrom);
                }
            }
        }

        private void AddCavePassage(string caveFrom, string caveTo)
        {
            _map.TryAdd(caveFrom, new List<string>());
            _map[caveFrom].Add(caveTo);
        }

        private static bool IsLargeCave(string cave) => cave == cave.ToUpper();

        private static bool IsSmallCave(string cave) => cave != "start" && cave != "end" && cave == cave.ToLower();

        private void CalculatePaths()
        {
            var walkedThrough = new List<string>();
            FindPathToEndFrom("start", walkedThrough, _searchAlgorithm);
        }

        private void FindPathToEndFrom(string from, List<string> walkedThrough, ISmallCaveBehaviour smallCaveSearch)
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
                smallCaveSearch.Do(this, from, walkedThrough, new WalkOnlyOnceInSmallCave());
                return;
            }

            WalkThisCave(from, walkedThrough, smallCaveSearch);
        }

        private void WalkThisCave(string from, List<string> walkedThrough, ISmallCaveBehaviour smallCaveSearch)
        {
            walkedThrough.Add(from);

            foreach (var cave in _map[from])
            {
                FindPathToEndFrom(cave, walkedThrough, smallCaveSearch);
            }

            walkedThrough.RemoveAt(walkedThrough.Count - 1);
        }

        public bool HasExactlyCaves(int amount) => amount == _map.Keys.Count + 1;

        public bool HasExactlyLargeCaves(int amount) => amount == _map.Count(p => IsLargeCave(p.Key));

        public bool HasExactlySmallCaves(int amount) => amount == _map.Count(p => IsSmallCave(p.Key));
    }
}