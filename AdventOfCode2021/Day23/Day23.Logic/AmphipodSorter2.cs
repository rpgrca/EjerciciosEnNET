using System;
using System.Collections.Generic;

namespace Day23.Logic
{
    public interface IMovementFrom2
    {
        IMovementFrom2 To(int node);
    }

    public class AmphipodSorter2 : IMovementFrom2
    {
        private readonly string _data;

        private readonly int[][] _graph;
        private readonly int[][] _paths;
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

            _paths = new int[][]
            {
                     //  0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26
                new[] { -1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                new[] {  0, -1,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6 },
                new[] {  3,  3, -1,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3 },
                new[] {  4,  4,  2, -1,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4 },
                new[] {  5,  5,  3,  3, -1,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5 },
                new[] {  6,  6,  4,  4,  4, -1,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6 },
                new[] {  1,  1,  5,  5,  5,  5, -1,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7 },
                new[] {  6,  6,  6,  6,  6,  6,  6, -1, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 },
                new[] {  9,  9,  9,  9,  9,  9,  9,  9, -1,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9 },
                new[] { 10, 10, 10, 10, 10, 10, 10, 10,  8, -1, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 },

                     //  0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26
                new[] { 11, 11, 11, 11, 11, 11, 11, 11,  9,  9, -1, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 },
                new[] { 12, 12, 12, 12, 12, 12, 12, 12, 10, 10, 10, -1, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 },
                new[] {  7,  7,  7,  7,  7,  7,  7,  7, 11, 11, 11, 11, -1, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 },
                new[] { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, -1, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18 },
                new[] { 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15 },
                new[] { 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, -1, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16 },
                new[] { 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 15, 15, -1, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 },
                new[] { 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 16, 16, 16, -1, 18, 18, 18, 18, 18, 18, 18, 18, 18 },
                new[] { 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 17, 17, 17, 17, -1, 19, 19, 19, 19, 19, 19, 19, 19 },
                new[] { 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, -1, 24, 24, 24, 24, 24, 24, 24 },

                     //  0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26
                new[] { 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, -1, 21, 21, 21, 21, 21, 21 },
                new[] { 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 20, -1, 22, 22, 22, 22, 22 },
                new[] { 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 21, 21, -1, 23, 23, 23, 23 },
                new[] { 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 22, 22, 22, -1, 24, 24, 24 },
                new[] { 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 23, 23, 23, 23, -1, 25, 25 },
                new[] { 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, -1, 26 },
                new[] { 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, -1 }
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
            while (_paths[currentLocation][target] != -1)
            {
                var nextRoom = _paths[currentLocation][target];
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