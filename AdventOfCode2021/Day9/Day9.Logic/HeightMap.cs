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

        public int Width { get; private set; }
        public int Height { get; private set; }
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
            DetermineMapWidthAndHeight();
            CalculateLowPoints();
            CalculateRiskLevel();
            CalculateBasinSizes();
        }

        private void Parse() => _data
            .Split("\n")
            .ToList()
            .ForEach(p => _map.Add(p.Select(p => p - '0').ToArray()));

        private void DetermineMapWidthAndHeight() =>
            (Width, Height) = (_map[0].Length, _map.Count);

        private void CalculateLowPoints() => _lowPoints
            .AddRange(Enumerable
                .Range(0, Width)
                .SelectMany(_ => Enumerable.Range(0, Height), (x, y) => (x, y))
                .Where(p => IsLowPoint(p.x, p.y)));

        private void CalculateRiskLevel() =>
            RiskLevel = _lowPoints.Select(p => _map[p.Y][p.X] + 1).Sum();

        private bool IsLowPoint(int x, int y) => new List<int>
            {
                OutOfBounds(x, y - 1)? 9 : _map[y - 1][x],
                OutOfBounds(x, y + 1)? 9 : _map[y + 1][x],
                OutOfBounds(x - 1, y)? 9 : _map[y][x - 1],
                OutOfBounds(x + 1, y)? 9 : _map[y][x + 1]
            }.TrueForAll(p => p > _map[y][x]);

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