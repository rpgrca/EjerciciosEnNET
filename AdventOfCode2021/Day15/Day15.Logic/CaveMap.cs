using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15.Logic
{
    public class CaveMap
    {
        private readonly string _input;
        private List<int> _minimumRiskPath;
        private int[][] _map;
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

            _map = new int[lines.Length][];
            foreach (var line in lines)
            {
                _map[index++] = line.Select(p => p - '0').ToArray();
            }

            Height = _map.Length;
            Width = _map[0].Length;
        }

        public List<int> GetPath()
        {
            CalculateBorderPathRisk();
            CalculateLowestRiskPath();

            return _minimumRiskPath;
        }

        private void CalculateBorderPathRisk()
        {
            foreach (var position in _map[0][1..])
            {
                _minimumRisk += position;
            }

            for (var index = 1; index < Height; index++)
            {
                _minimumRisk += _map[index][Width - 1];
            }
        }

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

            if (y > 0)
            {
                CalculateLowestRiskPath(x, y - 1, path, positions);
            }

            if (y + 1 < Height)
            {
                CalculateLowestRiskPath(x, y + 1, path, positions);
            }

            if (x > 0)
            {
                CalculateLowestRiskPath(x - 1, y, path, positions);
            }

            if (x + 1 < Width)
            {
                CalculateLowestRiskPath(x + 1, y, path, positions);
            }

            positions.RemoveAt(positions.Count - 1);
            path.RemoveAt(path.Count - 1);
        }
    }
}