using System;
using System.Collections.Generic;
using System.Linq;

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

    public interface IMovementFrom2
    {
        IMovementFrom2 To(int node);
    }

    public class AmphipodSorter2 : IMovementFrom2
    {
        private readonly string _data;

        private readonly int[][] _graph;
        private readonly int[][][] _paths;
        private string _map;
        private readonly int[] _mapRelocator;
        private readonly string[] _rooms;
        private readonly Dictionary<string, int> _amphipodeTypes;
        private int _currentAmphipod;

        public int TotalCost { get; private set; }

        public AmphipodSorter2(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _amphipodeTypes = new Dictionary<string, int>
            {
                { "A", 1 },
                { "B", 10 },
                { "C", 100 },
                { "D", 1000 }
            };

            _mapRelocator = new int[] { 0, 1, 6, 7, 12, 13, 18, 19, 24, 25, 26, 5, 11, 17, 23, 4, 10, 16, 22, 3, 9, 15, 21, 2, 8, 14, 20 };
            _rooms = new string[]
            {
                ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",
                ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."
            };

            _graph = new int[][]
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

            _paths = new int[][][]
            {
                new int[][]
                {
                    /*  0 to  0 */ Array.Empty<int>(),
                    /*  0 to  1 */ new int[] { 1 },
                    /*  0 to  2 */ new int[] { 1, 6, 5, 4, 3, 2 },
                    /*  0 to  3 */ new int[] { 1, 6, 5, 4, 3 },
                    /*  0 to  4 */ new int[] { 1, 6, 5, 4 },
                    /*  0 to  5 */ new int[] { 1, 6, 5 },
                    /*  0 to  6 */ new int[] { 1, 6 },
                    /*  0 to  7 */ new int[] { 1, 6, 7 },
                    /*  0 to  8 */ new int[] { 1, 6, 7, 12, 11, 10, 9, 8 },
                    /*  0 to  9 */ new int[] { 1, 6, 7, 12, 11, 10, 9 },
                    /*  0 to 10 */ new int[] { 1, 6, 7, 12, 11, 10 },
                    /*  0 to 11 */ new int[] { 1, 6, 7, 12, 11 },
                    /*  0 to 12 */ new int[] { 1, 6, 7, 12 },
                    /*  0 to 13 */ new int[] { 1, 6, 7, 12, 13 },
                    /*  0 to 14 */ new int[] { 1, 6, 7, 12, 13, 18, 17, 16, 15, 14 },
                    /*  0 to 15 */ new int[] { 1, 6, 7, 12, 13, 18, 17, 16, 15 },
                    /*  0 to 16 */ new int[] { 1, 6, 7, 12, 13, 18, 17, 16 },
                    /*  0 to 17 */ new int[] { 1, 6, 7, 12, 13, 18, 17 },
                    /*  0 to 18 */ new int[] { 1, 6, 7, 12, 13, 18 },
                    /*  0 to 19 */ new int[] { 1, 6, 7, 12, 13, 18, 19 },
                    /*  0 to 20 */ new int[] { 1, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  0 to 21 */ new int[] { 1, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  0 to 22 */ new int[] { 1, 6, 7, 12, 13, 18, 19, 24, 23, 22 },
                    /*  0 to 23 */ new int[] { 1, 6, 7, 12, 13, 18, 19, 24, 23 },
                    /*  0 to 24 */ new int[] { 1, 6, 7, 12, 13, 18, 19, 24 },
                    /*  0 to 25 */ new int[] { 1, 6, 7, 12, 13, 18, 19, 24, 25 },
                    /*  0 to 26 */ new int[] { 1, 6, 7, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  1 to  0 */ new int[] { 0 },
                    /*  1 to  1 */ Array.Empty<int>(),
                    /*  1 to  2 */ new int[] { 6, 5, 4, 3, 2 },
                    /*  1 to  3 */ new int[] { 6, 5, 4, 3 },
                    /*  1 to  4 */ new int[] { 6, 5, 4 },
                    /*  1 to  5 */ new int[] { 6, 5 },
                    /*  1 to  6 */ new int[] { 6 },
                    /*  1 to  7 */ new int[] { 6, 7 },
                    /*  1 to  8 */ new int[] { 6, 7, 12, 11, 10, 9, 8 },
                    /*  1 to  9 */ new int[] { 6, 7, 12, 11, 10, 9 },
                    /*  1 to 10 */ new int[] { 6, 7, 12, 11, 10 },
                    /*  1 to 11 */ new int[] { 6, 7, 12, 11 },
                    /*  1 to 12 */ new int[] { 6, 7, 12 },
                    /*  1 to 13 */ new int[] { 6, 7, 12, 13 },
                    /*  1 to 14 */ new int[] { 6, 7, 12, 13, 18, 17, 16, 15, 14 },
                    /*  1 to 15 */ new int[] { 6, 7, 12, 13, 18, 17, 16, 15 },
                    /*  1 to 16 */ new int[] { 6, 7, 12, 13, 18, 17, 16 },
                    /*  1 to 17 */ new int[] { 6, 7, 12, 13, 18, 17 },
                    /*  1 to 18 */ new int[] { 6, 7, 12, 13, 18 },
                    /*  1 to 19 */ new int[] { 6, 7, 12, 13, 18, 19 },
                    /*  1 to 20 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  1 to 21 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  1 to 22 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23, 22 },
                    /*  1 to 23 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23 },
                    /*  1 to 24 */ new int[] { 6, 7, 12, 13, 18, 19, 24 },
                    /*  1 to 25 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 25 },
                    /*  1 to 26 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  2 to  0 */ new int[] { 3, 4, 5, 6, 1, 0 },
                    /*  2 to  1 */ new int[] { 3, 4, 5, 6, 1 },
                    /*  2 to  2 */ Array.Empty<int>(),
                    /*  2 to  3 */ new int[] { 3 },
                    /*  2 to  4 */ new int[] { 3, 4 },
                    /*  2 to  5 */ new int[] { 3, 4, 5 },
                    /*  2 to  6 */ new int[] { 3, 4, 5, 6 },
                    /*  2 to  7 */ new int[] { 3, 4, 5, 6, 7 },
                    /*  2 to  8 */ new int[] { 3, 4, 5, 6, 7, 12, 11, 10, 9, 8 },
                    /*  2 to  9 */ new int[] { 3, 4, 5, 6, 7, 12, 11, 10, 9 },
                    /*  2 to 10 */ new int[] { 3, 4, 5, 6, 7, 12, 11, 10 },
                    /*  2 to 11 */ new int[] { 3, 4, 5, 6, 7, 12, 11 },
                    /*  2 to 12 */ new int[] { 3, 4, 5, 6, 7, 12 },
                    /*  2 to 13 */ new int[] { 3, 4, 5, 6, 7, 12, 13 },
                    /*  2 to 14 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 17, 16, 15, 14 },
                    /*  2 to 15 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 17, 16, 15 },
                    /*  2 to 16 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 17, 16 },
                    /*  2 to 17 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 17 },
                    /*  2 to 18 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18 },
                    /*  2 to 19 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19 },
                    /*  2 to 20 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  2 to 21 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  2 to 22 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19, 24, 23, 22 },
                    /*  2 to 23 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19, 24, 23 },
                    /*  2 to 24 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19, 24 },
                    /*  2 to 25 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19, 24, 25 },
                    /*  2 to 26 */ new int[] { 3, 4, 5, 6, 7, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  3 to  0 */ new int[] { 4, 5, 6, 1, 0 },
                    /*  3 to  1 */ new int[] { 4, 5, 6, 1 },
                    /*  3 to  2 */ new int[] { 2 },
                    /*  3 to  3 */ Array.Empty<int>(),
                    /*  3 to  4 */ new int[] { 4 },
                    /*  3 to  5 */ new int[] { 4, 5 },
                    /*  3 to  6 */ new int[] { 4, 5, 6 },
                    /*  3 to  7 */ new int[] { 4, 5, 6, 7 },
                    /*  3 to  8 */ new int[] { 4, 5, 6, 7, 12, 11, 10, 9, 8 },
                    /*  3 to  9 */ new int[] { 4, 5, 6, 7, 12, 11, 10, 9 },
                    /*  3 to 10 */ new int[] { 4, 5, 6, 7, 12, 11, 10 },
                    /*  3 to 11 */ new int[] { 4, 5, 6, 7, 12, 11 },
                    /*  3 to 12 */ new int[] { 4, 5, 6, 7, 12 },
                    /*  3 to 13 */ new int[] { 4, 5, 6, 7, 12, 13 },
                    /*  3 to 14 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 17, 16, 15, 14 },
                    /*  3 to 15 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 17, 16, 15 },
                    /*  3 to 16 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 17, 16 },
                    /*  3 to 17 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 17 },
                    /*  3 to 18 */ new int[] { 4, 5, 6, 7, 12, 13, 18 },
                    /*  3 to 19 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19 },
                    /*  3 to 20 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  3 to 21 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  3 to 22 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19, 24, 23, 22 },
                    /*  3 to 23 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19, 24, 23 },
                    /*  3 to 24 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19, 24 },
                    /*  3 to 25 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19, 24, 25 },
                    /*  3 to 26 */ new int[] { 4, 5, 6, 7, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  4 to  0 */ new int[] { 5, 6, 1, 0 },
                    /*  4 to  1 */ new int[] { 5, 6, 1 },
                    /*  4 to  2 */ new int[] { 3, 2 },
                    /*  4 to  3 */ new int[] { 3 },
                    /*  4 to  4 */ Array.Empty<int>(),
                    /*  4 to  5 */ new int[] { 5 },
                    /*  4 to  6 */ new int[] { 5, 6 },
                    /*  4 to  7 */ new int[] { 5, 6, 7 },
                    /*  4 to  8 */ new int[] { 5, 6, 7, 12, 11, 10, 9, 8 },
                    /*  4 to  9 */ new int[] { 5, 6, 7, 12, 11, 10, 9 },
                    /*  4 to 10 */ new int[] { 5, 6, 7, 12, 11, 10 },
                    /*  4 to 11 */ new int[] { 5, 6, 7, 12, 11 },
                    /*  4 to 12 */ new int[] { 5, 6, 7, 12 },
                    /*  4 to 13 */ new int[] { 5, 6, 7, 12, 13 },
                    /*  4 to 14 */ new int[] { 5, 6, 7, 12, 13, 18, 17, 16, 15, 14 },
                    /*  4 to 15 */ new int[] { 5, 6, 7, 12, 13, 18, 17, 16, 15 },
                    /*  4 to 16 */ new int[] { 5, 6, 7, 12, 13, 18, 17, 16 },
                    /*  4 to 17 */ new int[] { 5, 6, 7, 12, 13, 18, 17 },
                    /*  4 to 18 */ new int[] { 5, 6, 7, 12, 13, 18 },
                    /*  4 to 19 */ new int[] { 5, 6, 7, 12, 13, 18, 19 },
                    /*  4 to 20 */ new int[] { 5, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  4 to 21 */ new int[] { 5, 6, 7, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  4 to 22 */ new int[] { 5, 6, 7, 12, 13, 18, 19, 24, 23, 22 },
                    /*  4 to 23 */ new int[] { 5, 6, 7, 12, 13, 18, 19, 24, 23 },
                    /*  4 to 24 */ new int[] { 5, 6, 7, 12, 13, 18, 19, 24 },
                    /*  4 to 25 */ new int[] { 5, 6, 7, 12, 13, 18, 19, 24, 25 },
                    /*  4 to 26 */ new int[] { 5, 6, 7, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  5 to  0 */ new int[] { 6, 1, 0 },
                    /*  5 to  1 */ new int[] { 6, 1 },
                    /*  5 to  2 */ new int[] { 4, 3, 2 },
                    /*  5 to  3 */ new int[] { 4, 3 },
                    /*  5 to  4 */ new int[] { 4 },
                    /*  5 to  5 */ Array.Empty<int>(),
                    /*  5 to  6 */ new int[] { 6 },
                    /*  5 to  7 */ new int[] { 6, 7 },
                    /*  5 to  8 */ new int[] { 6, 7, 12, 11, 10, 9, 8 },
                    /*  5 to  9 */ new int[] { 6, 7, 12, 11, 10, 9 },
                    /*  5 to 10 */ new int[] { 6, 7, 12, 11, 10 },
                    /*  5 to 11 */ new int[] { 6, 7, 12, 11 },
                    /*  5 to 12 */ new int[] { 6, 7, 12 },
                    /*  5 to 13 */ new int[] { 6, 7, 12, 13 },
                    /*  5 to 14 */ new int[] { 6, 7, 12, 13, 18, 17, 16, 15, 14 },
                    /*  5 to 15 */ new int[] { 6, 7, 12, 13, 18, 17, 16, 15 },
                    /*  5 to 16 */ new int[] { 6, 7, 12, 13, 18, 17, 16 },
                    /*  5 to 17 */ new int[] { 6, 7, 12, 13, 18, 17 },
                    /*  5 to 18 */ new int[] { 6, 7, 12, 13, 18 },
                    /*  5 to 19 */ new int[] { 6, 7, 12, 13, 18, 19 },
                    /*  5 to 20 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  5 to 21 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  5 to 22 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23, 22 },
                    /*  5 to 23 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 23 },
                    /*  5 to 24 */ new int[] { 6, 7, 12, 13, 18, 19, 24 },
                    /*  5 to 25 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 25 },
                    /*  5 to 26 */ new int[] { 6, 7, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  6 to  0 */ new int[] { 1, 0 },
                    /*  6 to  1 */ new int[] { 1 },
                    /*  6 to  2 */ new int[] { 5, 4, 3, 2 },
                    /*  6 to  3 */ new int[] { 5, 4, 3 },
                    /*  6 to  4 */ new int[] { 5, 4 },
                    /*  6 to  5 */ new int[] { 5 },
                    /*  6 to  6 */ Array.Empty<int>(),
                    /*  6 to  7 */ new int[] { 7 },
                    /*  6 to  8 */ new int[] { 7, 12, 11, 10, 9, 8 },
                    /*  6 to  9 */ new int[] { 7, 12, 11, 10, 9 },
                    /*  6 to 10 */ new int[] { 7, 12, 11, 10 },
                    /*  6 to 11 */ new int[] { 7, 12, 11 },
                    /*  6 to 12 */ new int[] { 7, 12 },
                    /*  6 to 13 */ new int[] { 7, 12, 13 },
                    /*  6 to 14 */ new int[] { 7, 12, 13, 18, 17, 16, 15, 14 },
                    /*  6 to 15 */ new int[] { 7, 12, 13, 18, 17, 16, 15 },
                    /*  6 to 16 */ new int[] { 7, 12, 13, 18, 17, 16 },
                    /*  6 to 17 */ new int[] { 7, 12, 13, 18, 17 },
                    /*  6 to 18 */ new int[] { 7, 12, 13, 18 },
                    /*  6 to 19 */ new int[] { 7, 12, 13, 18, 19 },
                    /*  6 to 20 */ new int[] { 7, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  6 to 21 */ new int[] { 7, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  6 to 22 */ new int[] { 7, 12, 13, 18, 19, 24, 23, 22 },
                    /*  6 to 23 */ new int[] { 7, 12, 13, 18, 19, 24, 23 },
                    /*  6 to 24 */ new int[] { 7, 12, 13, 18, 19, 24 },
                    /*  6 to 25 */ new int[] { 7, 12, 13, 18, 19, 24, 25 },
                    /*  6 to 26 */ new int[] { 7, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  7 to  0 */ new int[] { 6, 1, 0 },
                    /*  7 to  1 */ new int[] { 6, 1 },
                    /*  7 to  2 */ new int[] { 6, 5, 4, 3, 2 },
                    /*  7 to  3 */ new int[] { 6, 5, 4, 3 },
                    /*  7 to  4 */ new int[] { 6, 5, 4 },
                    /*  7 to  5 */ new int[] { 6, 5 },
                    /*  7 to  6 */ new int[] { 6 },
                    /*  7 to  7 */ Array.Empty<int>(),
                    /*  7 to  8 */ new int[] { 12, 11, 10, 9, 8 },
                    /*  7 to  9 */ new int[] { 12, 11, 10, 9 },
                    /*  7 to 10 */ new int[] { 12, 11, 10 },
                    /*  7 to 11 */ new int[] { 12, 11 },
                    /*  7 to 12 */ new int[] { 12 },
                    /*  7 to 13 */ new int[] { 12, 13 },
                    /*  7 to 14 */ new int[] { 12, 13, 18, 17, 16, 15, 14 },
                    /*  7 to 15 */ new int[] { 12, 13, 18, 17, 16, 15 },
                    /*  7 to 16 */ new int[] { 12, 13, 18, 17, 16 },
                    /*  7 to 17 */ new int[] { 12, 13, 18, 17 },
                    /*  7 to 18 */ new int[] { 12, 13, 18 },
                    /*  7 to 19 */ new int[] { 12, 13, 18, 19 },
                    /*  7 to 20 */ new int[] { 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  7 to 21 */ new int[] { 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  7 to 22 */ new int[] { 12, 13, 18, 19, 24, 23, 22 },
                    /*  7 to 23 */ new int[] { 12, 13, 18, 19, 24, 23 },
                    /*  7 to 24 */ new int[] { 12, 13, 18, 19, 24 },
                    /*  7 to 25 */ new int[] { 12, 13, 18, 19, 24, 25 },
                    /*  7 to 26 */ new int[] { 12, 13, 18, 19, 24, 25, 26 }
                }
            };

            Parse();
        }

        private void Parse()
        {
            var index = 0;

            foreach (var line in _data.Split("\n"))
            {
                foreach (var room in line)
                {
                    if (room == '#' || room == ' ')
                    {
                        _map += room;
                    }
                    else
                    {
                        _map += $"{{{_mapRelocator[index]}}}";
                        _rooms[_mapRelocator[index++]] = room.ToString();
                    }
                }

                _map += "\n";
            }

            _map = _map.Trim();
        }

        public override string ToString() => string.Format(_map, _rooms);

        public IMovementFrom2 MoveAmphipodFrom(int node)
        {
            if (!IsThereAnAmphipodAt(node))
            {
                throw new ArgumentException("No amphipod there");
            }

            _currentAmphipod = node;
            return this;
        }

        public IMovementFrom2 To(int target)
        {
            var currentLocation = _currentAmphipod;
            while (_paths[currentLocation][target].Length > 0)
            {
                var nextRoom = _paths[currentLocation][target][0];
                if (_rooms[nextRoom] == ".")
                {
                    TotalCost += _amphipodeTypes[_rooms[currentLocation]];
                    _rooms[nextRoom] = _rooms[currentLocation];
                    _rooms[currentLocation] = ".";
                    currentLocation = nextRoom;
                }
            }

            return this;
        }

        private bool IsThereAnAmphipodAt(int node) => _rooms[node] is "A" or "B" or "C" or "D";
    }
}