using System.Linq;
using System;
using System.Collections.Generic;

namespace Day9.Logic
{
    public class HeightMap
    {
        private readonly string _data;
        private readonly List<int[]> _map;
        private readonly List<(int X, int Y)> _lowPoints;

        public int Width => _map[0].Length;
        public int Height => _map.Count;

        public int RiskLevel { get; private set; }
        public List<int> Basins { get; private set; }

        public HeightMap(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new List<int[]>();
            _lowPoints = new List<(int X, int Y)>();
            Basins = new List<int>();

            Parse();
            CalculateRiskLevel();
            CalculateBasinSizes();
        }

        private void Parse()
        {
            foreach (var row in _data.Split("\n").ToList())
            {
                _map.Add(row.Select(p => p - '0').ToArray());
            }
        }

        private void CalculateRiskLevel()
        {
            RiskLevel = 0;
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (IsLowPoint(x, y))
                    {
                        _lowPoints.Add((x, y));
                        RiskLevel += _map[y][x] + 1;
                    }
                }
            }
        }

        private bool IsLowPoint(int x, int y)
        {
            var adjacentLocations = new List<(int X, int Y)>
            {
                (x, y - 1),
                (x, y + 1),
                (x - 1, y),
                (x + 1, y)
            };

            var isLowPoint = true;
            foreach (var adjacentLocation in adjacentLocations)
            {
                if (adjacentLocation.X < 0 || adjacentLocation.X >= Width || adjacentLocation.Y < 0 || adjacentLocation.Y >= Height)
                {
                    continue;
                }

                if (_map[y][x] >= _map[adjacentLocation.Y][adjacentLocation.X])
                {
                    isLowPoint = false;
                    break;
                }
            }

            return isLowPoint;
        }

        private void CalculateBasinSizes()
        {
            foreach (var lowPoint in _lowPoints)
            {
                var basinSize = CalculateBasinSize(lowPoint.X, lowPoint.Y);
                Basins.Add(basinSize);
            }
        }

        private int CalculateBasinSize(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return 0;
            }

            if (_map[y][x] == 9)
            {
                return 0;
            }

            if (_map[y][x] == -1)
            {
                return 0;
            }

            _map[y][x] = -1;
            return 1 + CalculateBasinSize(x - 1, y) + CalculateBasinSize(x + 1, y) + CalculateBasinSize(x, y - 1) + CalculateBasinSize(x, y + 1);
        }
    }
}
