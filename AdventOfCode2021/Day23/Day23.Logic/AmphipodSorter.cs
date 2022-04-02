#if false
using System;
using System.Collections.Generic;

namespace Day23.Logic
{
    public interface IMovementFrom
    {
        IMovementFrom To(int x, int y);
    }

    public class AmphipodSorter : IMovementFrom
    {
        private readonly string _data;

        private readonly int[][] _graph;
        private readonly char[][] _map;
        private readonly Dictionary<char, int> _amphipodeTypes;
        private (int X, int Y) _currentAmphipod;

        public int TotalCost { get; private set; }

        public AmphipodSorter(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _amphipodeTypes = new Dictionary<char, int>
            {
                { 'A', 1 },
                { 'B', 10 },
                { 'C', 100 },
                { 'D', 1000 }
            };

            _map = new char[5][]
            {
                new char[13],
                new char[13],
                new char[13],
                new char[13],
                new char[13]
            };

            _graph= new int[][]
            {
                new[] { -1, -1,  1, -1 },
                new[] { -1, -1,  6,  1 },
                new[] {  3, -1, -1, -1 },
                new[] {  4,  2, -1, -1 },
                new[] {  5,  3, -1, -1 },
                new[] {  6,  4, -1, -1 },
                new[] { -1,  5,  7, -1 },
                new[] { -1, -1, 12,  6 },
                new[] {  9, -1, -1, -1 },
                new[] { 10,  8, -1, -1 },
                new[] { 11,  9, -1, -1 },
                new[] { 12, 10, -1, -1 },
                new[] { 11, -1, 13,  7 },
                new[] { -1, -1, 18, 12 },
                new[] { 15, -1, -1, -1 },
                new[] { 16, 14, -1, -1 },
                new[] { 17, 15, -1, -1 },
                new[] { 18, 16, -1, -1 },
                new[] { -1, 17, 19, 13 },
                new[] { -1, -1, 24, 18 },
                new[] { 21, -1, -1, -1 },
                new[] { 22, 20, -1, -1 },
                new[] { 23, 21, -1, -1 },
                new[] { 24, 22, -1, -1 },
                new[] { -1, 23, 25 ,19 },
                new[] { -1, -1, 26, 24 },
                new[] { -1, -1, -1, 25 }
            };

            Parse();
        }

        private void Parse()
        {
            var y = 0;
            var x = 0;

            foreach (var line in _data.Split("\n"))
            {
                foreach (var room in line)
                {
                    _map[y][x++] = room;

                    if (room is 'A' or 'B' or 'C' or 'D')
                    {
                    }
                }

                x = 0;
                y++;
            }
        }

        public override string ToString()
        {
            var map = string.Empty;

            for (var y = 0; y < _map.Length; y++)
            {
                foreach (var x in _map[y])
                {
                    if (x == '\0')
                    {
                        break;
                    }

                    map += x;
                }

                map += "\n";
            }

            return map.Trim();
        }

        public IMovementFrom MoveAmphipodFrom(int x, int y)
        {
            _currentAmphipod = (x, y);
            return this;
        }

        public (int X, int Y, int Cost, char Name) GetAmphipodAt(int x, int y)
        {
            if (IsThereAnAmphipodAt(_map[y][x]))
            {
                return (x, y, GetCostFor(_map[y][x]), _map[y][x]);
            }

            throw new ArgumentException("No amphipod there");
        }

        private int GetCostFor(char amphipod) => _amphipodeTypes[amphipod];

        private static bool IsThereAnAmphipodAt(char room) => room is 'A' or 'B' or 'C' or 'D';

        public IMovementFrom To(int x, int y)
        {
            if (CurrentAmphipodCanMoveTo(x, y))
            {
                _map[y][x] = _map[_currentAmphipod.Y][_currentAmphipod.X];
                _map[_currentAmphipod.Y][_currentAmphipod.X] = '.';
                _currentAmphipod = (x, y);
                TotalCost += _amphipodeTypes[_map[y][x]];
            }

            return this;
        }

        private bool CurrentAmphipodCanMoveTo(int x, int y) => _map[y][x] == '.';
    }
}
#endif