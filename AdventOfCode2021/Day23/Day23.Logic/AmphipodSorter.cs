using System;
using System.Collections.Generic;

namespace Day23.Logic
{
    public interface IMovementFrom
    {
        void To(int x, int y);
    }

    public class AmphipodSorter : IMovementFrom
    {
        private readonly string _data;

        private readonly char[][] _map;
        private readonly Dictionary<char, int> _amphipodes;
        private (int X, int Y) _currentAmphipod;

        public int TotalCost { get; private set; }

        public AmphipodSorter(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _amphipodes = new Dictionary<char, int>
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

        private int GetCostFor(char amphipod) => _amphipodes[amphipod];

        private static bool IsThereAnAmphipodAt(char room) => room is 'A' or 'B' or 'C' or 'D';

        public void To(int x, int y)
        {
            if (CurrentAmphipodCanMoveTo(x, y))
            {
                _map[y][x] = _map[_currentAmphipod.Y][_currentAmphipod.X];
                _map[_currentAmphipod.Y][_currentAmphipod.X] = '.';
                TotalCost += _amphipodes[_map[y][x]];
            }
        }

        private bool CurrentAmphipodCanMoveTo(int x, int y) => _map[y][x] == '.';
    }
}
