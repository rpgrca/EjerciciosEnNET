using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15.Logic
{
    public class CaveMap
    {
        private readonly string _input;
        private List<int> _minimumRiskPath;
        private (int RiskLevel, int TotalRiskSoFar)[][] _map;
        private int _minimumRisk;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public CaveMap(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid map");
            }

            _input = input;
            _minimumRiskPath = new List<int>();

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");
            var index = 0;

            _map = new (int, int)[lines.Length][];
            foreach (var line in lines)
            {
                _map[index++] = line.Select(p => (p - '0', int.MaxValue)).ToArray();
            }

            Height = _map.Length;
            Width = _map[0].Length;
        }

        public List<int> GetPath()
        {
            CalculateBorderPathRisk();
            CalculateLowestRiskPath2();

            return _minimumRiskPath;
        }

        private void CalculateBorderPathRisk()
        {
            foreach (var (RiskLevel, _) in _map[0][1..])
            {
                _minimumRisk += RiskLevel;
            }

            for (var index = 1; index < Height; index++)
            {
                _minimumRisk += _map[index][Width - 1].RiskLevel;
            }
        }

        private void CalculateLowestRiskPath2()
        {
            CalculateLowestRiskPath2(0, 0, 0, true);
        }

        private void CalculateLowestRiskPath2(int x, int y, int accumulatedRiskLevel, bool firstTime)
        {
            if (! firstTime)
            {
                accumulatedRiskLevel += _map[y][x].RiskLevel;
            }

            if (accumulatedRiskLevel >= _minimumRisk)
            {
                return;
            }

            if (_map[y][x].TotalRiskSoFar <= accumulatedRiskLevel)
            {
                return;
            }

            _map[y][x].TotalRiskSoFar = accumulatedRiskLevel;

            if (x == Width - 1 && y == Height - 1)
            {
                var sum = accumulatedRiskLevel;
                if (sum < _minimumRisk)
                {
                    _minimumRisk = sum;
                }

                return;
            }

            var sortedList = new SortedList<int, (int X, int Y)>();
            if (y > 0) sortedList.Add(_map[y - 1][x].RiskLevel << 14 | (y - 1) << 7 | x, (x, y - 1));
            if (y + 1 < Height) sortedList.Add(_map[y + 1][x].RiskLevel << 14 | (y + 1) << 7 | x, (x, y + 1));
            if (x > 0) sortedList.Add(_map[y][x - 1].RiskLevel << 14 | y << 7 | (x - 1), (x - 1, y));
            if (x + 1 < Width) sortedList.Add(_map[y][x + 1].RiskLevel << 14 | y << 7 | (x + 1), (x + 1, y));

 /*           if (y > 0) sortedList.Add(_map[y - 1][x].RiskLevel << 14 | (y - 1) << 7 | x, (x, y - 1));
            if (y + 1 < Height) sortedList.Add(_map[y + 1][x].RiskLevel << 14 | (y + 1) << 7 | x, (x, y + 1));
            if (x > 0) sortedList.Add(_map[y][x - 1].RiskLevel << 14 | y << 7 | (x - 1), (x - 1, y));
            if (x + 1 < Width) sortedList.Add(_map[y][x + 1].RiskLevel << 14 | y << 7 | (x + 1), (x + 1, y));*/
            foreach (var coordinates in sortedList)
            {
                CalculateLowestRiskPath2(coordinates.Value.X, coordinates.Value.Y, accumulatedRiskLevel, false);
            }
        }
/*
        private void CalculateLowestRiskPath()
        {
            var path = new List<int>();
            var positions = new List<(int, int)>();

            CalculateLowestRiskPath(0, 0, path, positions);
        }


        private void CalculateLowestRiskPath(int x, int y, List<int> path, List<(int, int)> positions)
        {
            if (path.Sum() + _map[y][x] > _minimumRisk)
            {
                return;
            }

            if (positions.Contains((x, y)))
            {
                return;
            }

            positions.Add((x, y));
            path.Add(_map[y][x]);

            if (x == Width - 1 && y == Height - 1)
            {
                var sum = path.Sum() - path[0];
                if (sum < _minimumRisk)
                {
                    _minimumRiskPath = new List<int>(path);
                    _minimumRisk = sum;
                }

                positions.RemoveAt(positions.Count - 1);
                path.RemoveAt(path.Count - 1);

                return;
            }

            var sortedList = new List<(int X, int Y)>();
            if (y > 0) sortedList.Add((x, y - 1));
            if (y + 1 < Height) sortedList.Add((x, y + 1));
            if (x > 0) sortedList.Add((x - 1, y));
            if (x + 1 < Width) sortedList.Add((x + 1, y));

            foreach (var coordinates in sortedList.OrderBy(p => _map[p.Y][p.X]))
            {
                CalculateLowestRiskPath(coordinates.X, coordinates.Y, path, positions);
            }

            positions.RemoveAt(positions.Count - 1);
            path.RemoveAt(path.Count - 1);
        }*/

        public int GetPathLevel()
        {
            return _minimumRisk;
        }
    }

    public class FullCaveMap
    {
        private readonly string _input;
        private List<int> _minimumRiskPath;
        private (int RiskLevel, int TotalRiskSoFar)[][] _map;
        private int _minimumRisk;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public FullCaveMap(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid map");
            }

            _input = input;
            _minimumRiskPath = new List<int>();

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");
            var index = 0;

            _map = new (int, int)[lines.Length * 5][];
            foreach (var line in lines)
            {
                var convertedLine = line.Select(p => (p - '0', int.MaxValue)).ToList();
                convertedLine.AddRange(line.Select(p => (p - '0' + 1, int.MaxValue)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 2, int.MaxValue)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 3, int.MaxValue)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 4, int.MaxValue)));

                _map[index++] = convertedLine.ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 1, p.TotalRiskSoFar)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 2, p.TotalRiskSoFar)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 3, p.TotalRiskSoFar)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 4, p.TotalRiskSoFar)).ToArray();
            }

            Height = _map.Length;
            Width = _map[0].Length;

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (_map[y][x].RiskLevel > 9)
                    {
                        _map[y][x].RiskLevel -= 9;
                    }
                }
            }
        }

        public List<int> GetPath()
        {
            CalculateBorderPathRisk();
            CalculateLowestRiskPath2();

            return _minimumRiskPath;
        }

        private void CalculateBorderPathRisk()
        {
            foreach (var (RiskLevel, _) in _map[0][1..])
            {
                _minimumRisk += RiskLevel;
            }

            for (var index = 1; index < Height; index++)
            {
                _minimumRisk += _map[index][Width - 1].RiskLevel;
            }
        }

        private void CalculateLowestRiskPath2()
        {
            CalculateLowestRiskPath2(0, 0, 0, true);
        }

        private void CalculateLowestRiskPath2(int x, int y, int accumulatedRiskLevel, bool firstTime)
        {
            if (! firstTime)
            {
                accumulatedRiskLevel += _map[y][x].RiskLevel;
            }

            if (accumulatedRiskLevel >= _minimumRisk)
            {
                return;
            }

            if (_map[y][x].TotalRiskSoFar <= accumulatedRiskLevel)
            {
                return;
            }

            _map[y][x].TotalRiskSoFar = accumulatedRiskLevel;

            if (x == Width - 1 && y == Height - 1)
            {
                var sum = accumulatedRiskLevel;
                if (sum < _minimumRisk)
                {
                    _minimumRisk = sum;
                }

                return;
            }

            var sortedList = new SortedList<int, (int X, int Y)>();
            if (y + 1 < Height) sortedList.Add(_map[y + 1][x].RiskLevel << 16 | (y + 1) << 8 | x, (x, y + 1));
            if (x + 1 < Width) sortedList.Add(_map[y][x + 1].RiskLevel << 16 | y << 8 | (x + 1), (x + 1, y));
            if (y > 0) sortedList.Add(_map[y - 1][x].RiskLevel << 24 | (y - 1) << 8 | x, (x, y - 1));
            if (x > 0) sortedList.Add(_map[y][x - 1].RiskLevel << 24 | y << 8 | (x - 1), (x - 1, y));

            foreach (var coordinates in sortedList)
            {
                CalculateLowestRiskPath2(coordinates.Value.X, coordinates.Value.Y, accumulatedRiskLevel, false);
            }
        }

        public int GetPathLevel()
        {
            return _minimumRisk;
        }

        public string GetHorizontalLine(int index)
        {
            return _map[index].Aggregate(string.Empty, (t, i) => t += i.RiskLevel);
        }

        public string GetVerticalLine(int index)
        {
            var result = string.Empty;
            for (var y = 0; y < Height; y++)
            {
                result += _map[y][index].RiskLevel;
            }

            return result;
        }
    }
}