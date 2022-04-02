using System;
using System.Collections.Generic;
using System.Linq;

namespace Day23.Logic
{
    //
    //  +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+ 
    //  | 0 |---| 1 |---| 4 |---| 5 |---| 8 |---| 9 |---|12 |---|13 |---|16 |---|17 |---|18 |
    //  +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+ 
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 3 |           | 7 |           |11 |           |15 |
    //                  +---+           +---+           +---+           +---+
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 2 |           | 6 |           |10 |           |14 |
    //                  +---+           +---+           +---+           +---+
    //
    public class ShortMap : IMapInformation
    {
        private readonly char[] _rooms;
        private readonly int[] _amphipods;
        private readonly int[] _mapRelocator;
        private readonly int[][] _paths;
        private readonly string _data;
        private string _map;

        public ShortMap(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;

            _rooms = new string('.', 19).ToCharArray();

            _amphipods = new int[] { 3, 7, 11, 15 };

            _mapRelocator = new int[] { 0, 1, 4, 5, 8, 9, 12, 13, 16, 17, 18, 3, 7, 11, 15, 2, 6, 10, 14 };

            _paths = new int[][]
            {
                     //  0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18
                new[] { -1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                new[] {  0, -1,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4 },
                new[] {  3,  3, -1,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3 },
                new[] {  4,  4,  2, -1,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4 },
                new[] {  1,  1,  3,  3, -1,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5 },
                new[] {  4,  4,  4,  4,  4, -1,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8 },
                new[] {  7,  7,  7,  7,  7,  7, -1,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7 },
                new[] {  8,  8,  8,  8,  8,  8,  6, -1,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8 },
                new[] {  5,  5,  5,  5,  5,  5,  7,  7, -1,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9 },
                new[] {  8,  8,  8,  8,  8,  8,  8,  8,  8, -1, 12, 12, 12, 12, 12, 12, 12, 12, 12 },

                     //  0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18
                new[] { 11, 11, 11, 11, 11, 11, 11, 11, 11, 10, -1, 11, 11, 11, 11, 11, 11, 11, 11 },
                new[] { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 10, -1, 12, 12, 12, 12, 12, 12, 12 },
                new[] {  9,  9,  9,  9,  9,  9,  9,  9,  9,  9, 11, 11, -1, 13, 13, 13, 13, 13, 13 },
                new[] { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, -1, 16, 16, 16, 16, 16 },
                new[] { 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, -1, 15, 15, 15, 15 },
                new[] { 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, -1, 16, 16, 16 },
                new[] { 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 15, 15, -1, 17, 17 },
                new[] { 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, -1, 18 },
                new[] { 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, -1 }
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
            if (amphipod is 0 or 1 or 5 or 9 or 13 or 17 or 18)
            {
                if (option is 0 or 1 or 5 or 9 or 13 or 17 or 18)
                {
                    return false;
                }
            }

            if (InHomeArea(option))
            {
                if (GoingToOwnHome(amphipod, option))
                {
                    if (!StrangersAtHome(amphipod))
                    {
                        return _rooms[option] == '.';
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return _rooms[option] == '.';
        }

        public bool GoingToOwnHome(int amphipod, int target) =>
                (_rooms[amphipod] == 'A' && target is 2 or 3) ||
                (_rooms[amphipod] == 'B' && target is 6 or 7) ||
                (_rooms[amphipod] == 'C' && target is 10 or 11) ||
                (_rooms[amphipod] == 'D' && target is 14 or 15);



    //
    //  +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+ 
    //  | 0 |---| 1 |---| 4 |---| 5 |---| 8 |---| 9 |---|12 |---|13 |---|16 |---|17 |---|18 |
    //  +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+   +---+ 
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 3 |           | 7 |           |11 |           |15 |
    //                  +---+           +---+           +---+           +---+
    //                    |               |               |               |
    //                  +---+           +---+           +---+           +---+
    //                  | 2 |           | 6 |           |10 |           |14 |
    //                  +---+           +---+           +---+           +---+
    //


        public IEnumerable<int> AvailableMovementOptions(int amphipod)
        {
            if (amphipod != 0) yield return 0;
            if (amphipod != 1) yield return 1;
            if (amphipod != 2)
            {
                if (_rooms[2] == '.')
                {
                    yield return 2;
                }
                else
                {
                    yield return 3;
                }
            }

            if (amphipod != 5) yield return 5;
            if (amphipod != 6)
            {
                if (_rooms[6] == '.')
                {
                    yield return 6;
                }
                else
                {
                    yield return 7;
                }
            }

            if (amphipod != 9) yield return 9;
            if (amphipod != 10)
            {
                if (_rooms[10] == '.')
                {
                    yield return 10;
                }
                else
                {
                    yield return 11;
                }
            }

            if (amphipod != 13) yield return 13;
            if (amphipod != 14)
            {
                if (_rooms[14] == '.')
                {
                    yield return 14;
                }
                else
                {
                    yield return 15;
                }
            }

            yield return 17;
            yield return 18;


            /*
            if (amphipod != 0) yield return 0;
            if (amphipod != 1) yield return 1;

            for (var subIndex = 1; subIndex <= 13; subIndex += 6)
            {
                for (var index = subIndex + 1; index < subIndex + 2; index++)
                {
                    if (_rooms[index] == '.')
                    {
                        if (amphipod != index) yield return index;
                        break;
                    }
                }

                if (amphipod != (subIndex + 4)) yield return subIndex + 4;
            }

            if (amphipod != 18) yield return 18;*/
        }

        public bool ForeignersInOwnHomeArea(int amphipod) =>
            ((amphipod is 2 or 3) && ((_rooms[2] is not '.' and not 'A') || (_rooms[3] is not '.' and not 'A'))) ||
            ((amphipod is 6 or 7) && ((_rooms[6] is not '.' and not 'B') || (_rooms[6] is not '.' and not 'B'))) ||
            ((amphipod is 10 or 11) && ((_rooms[10] is not '.' and not 'C') || (_rooms[11] is not '.' and not 'C'))) ||
            ((amphipod is 14 or 15) && ((_rooms[14] is not '.' and not 'D') || (_rooms[15] is not '.' and not 'D')));

        public override string ToString() => string.Format(_map, _rooms.Select(p => p.ToString()).ToArray());

        public bool IsHomeAreaBeingCompleted(int amphipod) =>
            ((_rooms[amphipod] == 'A') && (_rooms[2] is '.' or 'A') && (_rooms[3] is '.' or 'A')) ||
            ((_rooms[amphipod] == 'B') && (_rooms[6] is '.' or 'B') && (_rooms[7] is '.' or 'B')) ||
            ((_rooms[amphipod] == 'C') && (_rooms[10] is '.' or 'C') && (_rooms[11] is '.' or 'C')) ||
            ((_rooms[amphipod] == 'D') && (_rooms[14] is '.' or 'D') && (_rooms[15] is '.' or 'D'));

        public bool HasFinalPositionBeenReached() =>
            _rooms[2] == 'A' && _rooms[3] == 'A' &&
            _rooms[6] == 'B' && _rooms[7] == 'B' &&
            _rooms[10] == 'C' && _rooms[11] == 'C' &&
            _rooms[14] == 'D' && _rooms[15] == 'D';

        // TODO: make it bitwise mapping the home area for direct access
        public bool InHomeArea(int location) =>
            location is 2 or 3 or 6 or 7 or 10 or 11 or 14 or 15;

        public bool InOwnHomeArea(int location) =>
                (_rooms[location] == 'A' && location is 2 or 3) ||
                (_rooms[location] == 'B' && location is 6 or 7) ||
                (_rooms[location] == 'C' && location is 10 or 11) ||
                (_rooms[location] == 'D' && location is 14 or 15);

        public bool StrangersAtHome(int amphipod) =>
            (_rooms[amphipod] == 'A' && ((_rooms[2] is 'B' or 'C' or 'D') || (_rooms[3] is 'B' or 'C' or 'D'))) ||
            (_rooms[amphipod] == 'B' && ((_rooms[6] is 'A' or 'C' or 'D') || (_rooms[7] is 'A' or 'C' or 'D'))) ||
            (_rooms[amphipod] == 'C' && ((_rooms[10] is 'A' or 'B' or 'D') || (_rooms[11] is 'A' or 'B' or 'D'))) ||
            (_rooms[amphipod] == 'D' && ((_rooms[14] is 'A' or 'B' or 'C') || (_rooms[15] is 'A' or 'B' or 'C')));

        public bool IsThereAnAmphipodAt(int node) => _rooms[node] is >= 'A' and <= 'D';

        public void MoveFrom(int from, int to)
        {
            _rooms[from] = _rooms[to];
            _rooms[to] = '.';
        }

        public char GetRoomAt(int nextRoom) => _rooms[nextRoom];

        public int GetRoomLength() => _rooms.Length;

        public bool AtHomeAreaEntrance(int currentLocation) => currentLocation is 4 or 8 or 12 or 16;
    }
}