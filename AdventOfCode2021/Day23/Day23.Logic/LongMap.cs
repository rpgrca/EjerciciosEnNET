using System;
using System.Collections.Generic;
using System.Linq;

namespace Day23.Logic
{
    public interface IMapInformation
    {
        bool AtHomeAreaEntrance(int currentLocation);
        IEnumerable<int> AvailableMovementOptions(int amphipod);
        bool CanAmphipodMoveTo(int amphipod, int option);
        bool ForeignersInOwnHomeArea(int amphipod);
        int GetNextStep(int from, int to);
        int GetNodeFor(int index);
        char GetRoomAt(int nextRoom);
        int GetRoomLength();
        int[] GetStartingAmphipods();
        bool HasFinalPositionBeenReached();
        bool InHomeArea(int location);
        bool InOwnHomeArea(int location);
        bool IsHomeAreaBeingCompleted(int amphipod);
        bool IsThereAnAmphipodAt(int node);
        void MoveFrom(int from, int to);
        bool StrangersAtHome(int amphipod);
    }

    //
    //  +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+ 
    //  | 0 |---| 1 |---| 6 |---| 7 |---|12 |---|13 |---|18 |---|19 |---|24 |---|25 |---|26 |
    //  +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+ 
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 5 |           |11 |           |17 |           |23 |
    //                  +---+           +---+           +---+           +---+
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 4 |           |10 |           |16 |           |22 |
    //                  +---+           +---+           +---+           +---+
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 3 |           | 9 |           |15 |           |21 |
    //                  +---+           +---+           +---+           +---+
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 2 |           | 8 |           |14 |           |20 |
    //                  +---+           +---+           +---+           +---+
    //
    public class LongMap : IMapInformation
    {
        private readonly char[] _rooms;
        private readonly int[] _amphipods;
        private readonly int[] _mapRelocator;
        private readonly int[][] _paths;
        private readonly string _data;
        private string _map;

        public LongMap(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;

            _rooms = new string('.', 27).ToCharArray();

            _amphipods = new int[] { 5, 11, 17, 23 };

            _mapRelocator = new int[] { 0, 1, 6, 7, 12, 13, 18, 19, 24, 25, 26, 5, 11, 17, 23, 4, 10, 16, 22, 3, 9, 15, 21, 2, 8, 14, 20 };

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
                        _map += $"{{{GetNodeFor(index)}}}";
                        _rooms[GetNodeFor(index)] = room;
                        index++;
                    }
                }

                _map += "\n";
            }

            _map = _map.Trim();
        }

        public int GetNodeFor(int index) => _mapRelocator[index];

        public int GetNextStep(int from, int to) => _paths[from][to];

        public int[] GetStartingAmphipods() => _amphipods;

        public bool CanAmphipodMoveTo(int amphipod, int option)
        {
            if (amphipod is 0 or 1 or 7 or 13 or 19 or 25 or 26)
            {
                if (option is 0 or 1 or 7 or 13 or 19 or 25 or 26)
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<int> AvailableMovementOptions(int amphipod)
        {
            if (amphipod != 0) yield return 0;
            if (amphipod != 1) yield return 1;

            for (var subIndex = 1; subIndex <= 19; subIndex += 6)
            {
                for (var index = subIndex + 1; index <= subIndex + 4; index++)
                {
                    if (_rooms[index] == '.')
                    {
                        if (amphipod != index) yield return index;
                        break;
                    }
                }

                if (amphipod != (subIndex + 6)) yield return subIndex + 6;
            }

            if (amphipod != 26) yield return 26;
        }

        public bool ForeignersInOwnHomeArea(int amphipod) =>
            ((amphipod is >= 2 and <= 5) && ((_rooms[2] is not '.' and not 'A') || (_rooms[3] is not '.' and not 'A') || (_rooms[4] is not '.' and not 'A') || (_rooms[5] is not '.' and not 'A'))) ||
            ((amphipod is >= 8 and <= 11) && ((_rooms[8] is not '.' and not 'B') || (_rooms[9] is not '.' and not 'B') || (_rooms[10] is not '.' and not 'B') || (_rooms[11] is not '.' and not 'B'))) ||
            ((amphipod is >= 14 and <= 17) && ((_rooms[14] is not '.' and not 'C') || (_rooms[15] is not '.' and not 'C') || (_rooms[16] is not '.' and not 'C') || (_rooms[17] is not '.' and not 'C'))) ||
            ((amphipod is >= 20 and <= 23) && ((_rooms[20] is not '.' and not 'D') || (_rooms[21] is not '.' and not 'D') || (_rooms[22] is not '.' and not 'D') || (_rooms[23] is not '.' and not 'D')));

        public override string ToString() => string.Format(_map, _rooms.Select(p => p.ToString()).ToArray());

        public bool IsHomeAreaBeingCompleted(int amphipod) =>
            ((_rooms[amphipod] == 'A') && (_rooms[2] is '.' or 'A') && (_rooms[3] is '.' or 'A') && (_rooms[4] is '.' or 'A') && (_rooms[5] is '.' or 'A')) ||
            ((_rooms[amphipod] == 'B') && (_rooms[8] is '.' or 'B') && (_rooms[9] is '.' or 'B') && (_rooms[10] is '.' or 'B') && (_rooms[11] is '.' or 'B')) ||
            ((_rooms[amphipod] == 'C') && (_rooms[14] is '.' or 'C') && (_rooms[15] is '.' or 'C') && (_rooms[16] is '.' or 'C') && (_rooms[17] is '.' or 'C')) ||
            ((_rooms[amphipod] == 'D') && (_rooms[20] is '.' or 'D') && (_rooms[21] is '.' or 'D') && (_rooms[22] is '.' or 'D') && (_rooms[23] is '.' or 'D'));

        public bool HasFinalPositionBeenReached() =>
            _rooms[2] == 'A' && _rooms[3] == 'A' && _rooms[4] == 'A' && _rooms[5] == 'A' &&
            _rooms[8] == 'B' && _rooms[9] == 'B' && _rooms[10] == 'B' && _rooms[11] == 'B' &&
            _rooms[14] == 'C' && _rooms[15] == 'C' && _rooms[16] == 'C' && _rooms[17] == 'C' &&
            _rooms[20] == 'D' && _rooms[21] == 'D' && _rooms[22] == 'D' && _rooms[23] == 'D';

        public bool InHomeArea(int location) =>
            location is (>= 2 and <= 5) or (>= 8 and <= 11) or (>= 14 and <= 17) or (>= 20 and <= 23);

        public bool InOwnHomeArea(int location) =>
                (_rooms[location] == 'A' && location is >= 2 and <= 5) ||
                (_rooms[location] == 'B' && location is >= 8 and <= 11) ||
                (_rooms[location] == 'C' && location is >= 14 and <= 17) ||
                (_rooms[location] == 'D' && location is >= 20 and <= 23);

        public bool StrangersAtHome(int amphipod) =>
            (_rooms[amphipod] == 'A' && ((_rooms[2] is 'B' or 'C' or 'D') || (_rooms[3] is 'B' or 'C' or 'D') || (_rooms[4] is 'B' or 'C' or 'D'))) ||
            (_rooms[amphipod] == 'B' && ((_rooms[8] is 'A' or 'C' or 'D') || (_rooms[9] is 'A' or 'C' or 'D') || (_rooms[10] is 'A' or 'C' or 'D'))) ||
            (_rooms[amphipod] == 'C' && ((_rooms[14] is 'A' or 'B' or 'D') || (_rooms[15] is 'A' or 'B' or 'D') || (_rooms[16] is 'A' or 'B' or 'D'))) ||
            (_rooms[amphipod] == 'D' && ((_rooms[20] is 'A' or 'B' or 'C') || (_rooms[21] is 'A' or 'B' or 'C') || (_rooms[22] is 'A' or 'B' or 'C')));

        public bool IsThereAnAmphipodAt(int node) => _rooms[node] is >= 'A' and <= 'D';

        public void MoveFrom(int from, int to)
        {
            _rooms[from] = _rooms[to];
            _rooms[to] = '.';
        }

        public char GetRoomAt(int nextRoom) => _rooms[nextRoom];

        public int GetRoomLength() => _rooms.Length;

        public bool AtHomeAreaEntrance(int currentLocation) => currentLocation is 6 or 12 or 18 or 24;
    }
}