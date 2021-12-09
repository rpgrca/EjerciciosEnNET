using System.Linq;
using System;
using System.Collections.Generic;

namespace Day9.Logic
{
    public class HeightMap
    {
        private readonly string _data;
        private readonly List<int[]> _map;
        private readonly List<int> _basins;
        private readonly List<(int X, int Y)> _lowPoints;

        public int Width => _map[0].Length;
        public int Height => _map.Count;

        public int RiskLevel { get; private set; }

        public HeightMap(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new List<int[]>();
            _lowPoints = new List<(int X, int Y)>();
            _basins = new List<int>();

            Parse();
            CalculateLowPoints();
            CalculateRiskLevel();
            CalculateBasinSizes();
        }

        private void Parse()
        {
            foreach (var row in _data.Split("\n"))
            {
                _map.Add(row.Select(p => p - '0').ToArray());
            }
        }

        private void CalculateLowPoints()
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (IsLowPoint(x, y))
                    {
                        _lowPoints.Add((x, y));
                    }
                }
            }
        }

        private void CalculateRiskLevel() =>
            RiskLevel = _lowPoints.Select(p => _map[p.Y][p.X] + 1).Sum();

        private bool IsLowPoint(int x, int y)
        {
            var adjacentLocations = new List<(int X, int Y)>
            {
                (x, y - 1),
                (x, y + 1),
                (x - 1, y),
                (x + 1, y)
            };

            foreach (var (X, Y) in adjacentLocations)
            {
                if (OutOfBounds(X, Y)) continue;

                if (_map[y][x] >= _map[Y][X])
                {
                    return false;
                }
            }

            return true;
        }

        private bool OutOfBounds(int x, int y) =>
            x < 0 || x >= Width || y < 0 || y >= Height;

        private void CalculateBasinSizes() =>
            _lowPoints.ForEach(p => _basins.Add(CalculateBasinSize(p.X, p.Y)));

        private int CalculateBasinSize(int x, int y)
        {
            if (OutOfBounds(x, y) || _map[y][x] == 9 || _map[y][x] == -1)
            {
                return 0;
            }

            _map[y][x] = -1;
            return 1 + CalculateBasinSize(x - 1, y) + CalculateBasinSize(x + 1, y) + CalculateBasinSize(x, y - 1) + CalculateBasinSize(x, y + 1);
        }

        public int GetBasinSizeFor(int index) => _basins[index];

        public int GetBasinMultiplication() => _basins
            .OrderByDescending(p => p)
            .Take(3)
            .Aggregate(1, (t, i) => t *= i);
    }
}