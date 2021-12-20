using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15.Logic
{
    public class CaveMap
    {
        private readonly string _input;
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

        public void GetPath()
        {
            CalculateBorderPathRisk();
            CalculateLowestRiskPath2();
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

            foreach (var coordinates in sortedList)
            {
                CalculateLowestRiskPath2(coordinates.Value.X, coordinates.Value.Y, accumulatedRiskLevel, false);
            }
        }
        public int GetPathLevel()
        {
            return _minimumRisk;
        }
    }

    public class FullCaveMap
    {
        private readonly string _input;
        private (int RiskLevel, int TotalRiskSoFar, bool Visited, int X, int Y)[][] _map;
        private HashSet<(int RiskLevel, int TotalRiskSoFar, bool Visited, int X, int Y)> _unvisited;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public FullCaveMap(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid map");
            }

            _input = input;
            _unvisited = new HashSet<(int RiskLevel, int TotalRiskSoFar, bool Visited, int X, int Y)>();

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");
            var index = 0;

            _map = new (int, int, bool, int, int)[lines.Length * 5][];
            foreach (var line in lines)
            {
                var convertedLine = line.Select(p => (p - '0', int.MaxValue, false, 0, 0)).ToList();
                convertedLine.AddRange(line.Select(p => (p - '0' + 1, int.MaxValue, false, 0, 0)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 2, int.MaxValue, false, 0, 0)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 3, int.MaxValue, false, 0, 0)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 4, int.MaxValue, false, 0, 0)));

                _map[index++] = convertedLine.ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 1, p.TotalRiskSoFar, false, 0, 0)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 2, p.TotalRiskSoFar, false, 0, 0)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 3, p.TotalRiskSoFar, false, 0, 0)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 4, p.TotalRiskSoFar, false, 0, 0)).ToArray();
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

                    _map[y][x].X = x;
                    _map[y][x].Y = y;
                    _unvisited.Add(_map[y][x]);
                }
            }
        }

        public void GetPath()
        {
            //CalculateBorderPathRisk();
            CalculateLowestRiskPath2();

            for (var y = 0; y < Height; y++)
            {
                System.IO.File.AppendAllText("/home/roberto/Desktop/map.txt", _map[y].Aggregate(string.Empty, (t, i) => t += $"{i.TotalRiskSoFar,5}") + "\n");
            }
        }

        private void CalculateLowestRiskPath2()
        {
            _map[0][0].TotalRiskSoFar = 0;
            var next = _unvisited.First();
            _unvisited.Remove(next);

            CalculateLowestRiskPath2(0, 0, true);
        }

        private void CalculateLowestRiskPath2(int x, int y, bool firstTime)
        {
            if (_map[y][x].Visited || _map[Height - 1][Width - 1].Visited)
            {
                return;
            }

            _map[y][x].Visited = true;

            if (x == Width - 1 && y == Height - 1)
            {
                return;
            }

            if (y + 1 < Height && !_map[y + 1][x].Visited && _map[y + 1][x].TotalRiskSoFar > _map[y][x].TotalRiskSoFar + _map[y + 1][x].RiskLevel)
            {
                _map[y + 1][x].TotalRiskSoFar = _map[y][x].TotalRiskSoFar + _map[y + 1][x].RiskLevel;
            }

            if (x + 1 < Width && !_map[y][x + 1].Visited && _map[y][x + 1].TotalRiskSoFar > _map[y][x].TotalRiskSoFar + _map[y][x + 1].RiskLevel)
            {
                _map[y][x + 1].TotalRiskSoFar = _map[y][x].TotalRiskSoFar + _map[y][x + 1].RiskLevel;
            }

            if (_unvisited.Any())
            {
                var next = _unvisited.OrderBy(p => p.TotalRiskSoFar).First();
                _unvisited.Remove(next);
                CalculateLowestRiskPath2(next.X, next.Y, false);
            }
        }

        public int GetPathLevel()
        {
            return _map[Height - 1][Width - 1].TotalRiskSoFar;
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