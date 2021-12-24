using System;
using System.Collections.Generic;
using System.Linq;

namespace Day23.Logic
{
    public interface IMovementFrom2
    {
        IMovementTo To(int node);
    }

    public interface IMovementTo
    {
        bool AndStopOnFail();
        bool OrReturnBack();
        void OrFail();
    }

    public interface IMovementBackFrom
    {
        void To(int node);
    }

    public class AmphipodSorter2 : IMovementFrom2, IMovementTo, IMovementBackFrom
    {
        private readonly string _data;

        private readonly int[][] _graph;
        private readonly int[][] _paths;
        private readonly int[][][] _options;
        private string _map;
        private readonly int[] _mapRelocator;
        private readonly string[] _rooms;
        private readonly Dictionary<string, int> _amphipodeTypes;
        private int _currentAmphipod;
        private int _currentTarget;
        private Action<AmphipodSorter2> _onFinalPositionCallback;
        private int _count;

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

            _options = new int[][][]
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
                },
                new int[][]
                {
                    /*  8 to  0 */ new int[] { 9, 10, 11, 12, 7, 6, 1, 0 },
                    /*  8 to  1 */ new int[] { 9, 10, 11, 12, 7, 6, 1 },
                    /*  8 to  2 */ new int[] { 9, 10, 11, 12, 7, 6, 5, 4, 3, 2 },
                    /*  8 to  3 */ new int[] { 9, 10, 11, 12, 7, 6, 5, 4, 3 },
                    /*  8 to  4 */ new int[] { 9, 10, 11, 12, 7, 6, 5, 4 },
                    /*  8 to  5 */ new int[] { 9, 10, 11, 12, 7, 6, 5 },
                    /*  8 to  6 */ new int[] { 9, 10, 11, 12, 7, 6 },
                    /*  8 to  7 */ new int[] { 9, 10, 11, 12, 7 },
                    /*  8 to  8 */ Array.Empty<int>(),
                    /*  8 to  9 */ new int[] { 9, 10, 11, 12, 11, 10, 9 },
                    /*  8 to 10 */ new int[] { 9, 10, 11, 12, 11, 10 },
                    /*  8 to 11 */ new int[] { 9, 10, 11, 12, 11 },
                    /*  8 to 12 */ new int[] { 9, 10, 11, 12 },
                    /*  8 to 13 */ new int[] { 9, 10, 11, 12, 13 },
                    /*  8 to 14 */ new int[] { 9, 10, 11, 12, 13, 18, 17, 16, 15, 14 },
                    /*  8 to 15 */ new int[] { 9, 10, 11, 12, 13, 18, 17, 16, 15 },
                    /*  8 to 16 */ new int[] { 9, 10, 11, 12, 13, 18, 17, 16 },
                    /*  8 to 17 */ new int[] { 9, 10, 11, 12, 13, 18, 17 },
                    /*  8 to 18 */ new int[] { 9, 10, 11, 12, 13, 18 },
                    /*  8 to 19 */ new int[] { 9, 10, 11, 12, 13, 18, 19 },
                    /*  8 to 20 */ new int[] { 9, 10, 11, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  8 to 21 */ new int[] { 9, 10, 11, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  8 to 22 */ new int[] { 9, 10, 11, 12, 13, 18, 19, 24, 23, 22 },
                    /*  8 to 23 */ new int[] { 9, 10, 11, 12, 13, 18, 19, 24, 23 },
                    /*  8 to 24 */ new int[] { 9, 10, 11, 12, 13, 18, 19, 24 },
                    /*  8 to 25 */ new int[] { 9, 10, 11, 12, 13, 18, 19, 24, 25 },
                    /*  8 to 26 */ new int[] { 9, 10, 11, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /*  9 to  0 */ new int[] { 10, 11, 12, 7, 6, 1, 0 },
                    /*  9 to  1 */ new int[] { 10, 11, 12, 7, 6, 1 },
                    /*  9 to  2 */ new int[] { 10, 11, 12, 7, 6, 5, 4, 3, 2 },
                    /*  9 to  3 */ new int[] { 10, 11, 12, 7, 6, 5, 4, 3 },
                    /*  9 to  4 */ new int[] { 10, 11, 12, 7, 6, 5, 4 },
                    /*  9 to  5 */ new int[] { 10, 11, 12, 7, 6, 5 },
                    /*  9 to  6 */ new int[] { 10, 11, 12, 7, 6 },
                    /*  9 to  7 */ new int[] { 10, 11, 12, 7 },
                    /*  9 to  8 */ new int[] { 8 },
                    /*  9 to  9 */ Array.Empty<int>(),
                    /*  9 to 10 */ new int[] { 10, 11, 12, 11, 10 },
                    /*  9 to 11 */ new int[] { 10, 11, 12, 11 },
                    /*  9 to 12 */ new int[] { 10, 11, 12 },
                    /*  9 to 13 */ new int[] { 10, 11, 12, 13 },
                    /*  9 to 14 */ new int[] { 10, 11, 12, 13, 18, 17, 16, 15, 14 },
                    /*  9 to 15 */ new int[] { 10, 11, 12, 13, 18, 17, 16, 15 },
                    /*  9 to 16 */ new int[] { 10, 11, 12, 13, 18, 17, 16 },
                    /*  9 to 17 */ new int[] { 10, 11, 12, 13, 18, 17 },
                    /*  9 to 18 */ new int[] { 10, 11, 12, 13, 18 },
                    /*  9 to 19 */ new int[] { 10, 11, 12, 13, 18, 19 },
                    /*  9 to 20 */ new int[] { 10, 11, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /*  9 to 21 */ new int[] { 10, 11, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /*  9 to 22 */ new int[] { 10, 11, 12, 13, 18, 19, 24, 23, 22 },
                    /*  9 to 23 */ new int[] { 10, 11, 12, 13, 18, 19, 24, 23 },
                    /*  9 to 24 */ new int[] { 10, 11, 12, 13, 18, 19, 24 },
                    /*  9 to 25 */ new int[] { 10, 11, 12, 13, 18, 19, 24, 25 },
                    /*  9 to 26 */ new int[] { 10, 11, 12, 13, 18, 19, 24, 25, 26 }
                },
                new int[][]
                {
                    /* 10 to  0 */ new int[] { 11, 12, 7, 6, 1, 0 },
                    /* 10 to  1 */ new int[] { 11, 12, 7, 6, 1 },
                    /* 10 to  2 */ new int[] { 11, 12, 7, 6, 5, 4, 3, 2 },
                    /* 10 to  3 */ new int[] { 11, 12, 7, 6, 5, 4, 3 },
                    /* 10 to  4 */ new int[] { 11, 12, 7, 6, 5, 4 },
                    /* 10 to  5 */ new int[] { 11, 12, 7, 6, 5 },
                    /* 10 to  6 */ new int[] { 11, 12, 7, 6 },
                    /* 10 to  7 */ new int[] { 11, 12, 7 },
                    /* 10 to  8 */ new int[] { 9, 8 },
                    /* 10 to  9 */ new int[] { 9 },
                    /* 10 to 10 */ Array.Empty<int>(),
                    /* 10 to 11 */ new int[] { 11, 12, 11 },
                    /* 10 to 12 */ new int[] { 11, 12 },
                    /* 10 to 13 */ new int[] { 11, 12, 13 },
                    /* 10 to 14 */ new int[] { 11, 12, 13, 18, 17, 16, 15, 14 },
                    /* 10 to 15 */ new int[] { 11, 12, 13, 18, 17, 16, 15 },
                    /* 10 to 16 */ new int[] { 11, 12, 13, 18, 17, 16 },
                    /* 10 to 17 */ new int[] { 11, 12, 13, 18, 17 },
                    /* 10 to 18 */ new int[] { 11, 12, 13, 18 },
                    /* 10 to 19 */ new int[] { 11, 12, 13, 18, 19 },
                    /* 10 to 20 */ new int[] { 11, 12, 13, 18, 19, 24, 23, 22, 21, 20 },
                    /* 10 to 21 */ new int[] { 11, 12, 13, 18, 19, 24, 23, 22, 21 },
                    /* 10 to 22 */ new int[] { 11, 12, 13, 18, 19, 24, 23, 22 },
                    /* 10 to 23 */ new int[] { 11, 12, 13, 18, 19, 24, 23 },
                    /* 10 to 24 */ new int[] { 11, 12, 13, 18, 19, 24 },
                    /* 10 to 25 */ new int[] { 11, 12, 13, 18, 19, 24, 25 },
                    /* 10 to 26 */ new int[] { 11, 12, 13, 18, 19, 24, 25, 26 }
                }
            };

            Parse();
        }

        public int[] GetAmphipods() =>
            new int[] { 5, 11, 17, 23, 4, 10, 16, 22, 3, 9, 15, 21, 2, 8, 14, 20 };

        public void OnFinalPositionReached(Action<AmphipodSorter2> onFinalPositionCallback) =>
            _onFinalPositionCallback = onFinalPositionCallback;

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

        public IMovementTo To(int target)
        {
            _currentTarget = target;
            return this;
        }

        private bool IsThereAnAmphipodAt(int node) => _rooms[node] is "A" or "B" or "C" or "D";

        public void WalkWith(int[] amphipods, List<(int From, int To)> stack = null)
        {
            _count++;
            if (stack is null)
            {
                stack = new List<(int From, int To)>();
            }

            if (HasFinalPositionBeenReached())
            {
                _onFinalPositionCallback(this);
            }

            foreach (var amphipod in amphipods)
            {
                if (! IsThereAnAmphipodAt(amphipod))
                {
                    continue;
                }

                for (var option = 0; option < 27; option++) // TODO: Complete _options[amphipod])
                {
                    if (option == amphipod)
                    {
                        continue;
                    }

                    if (amphipod is 0 or 1 or 7 or 13 or 19 or 25 or 26)
                    {
                        if (option is 0 or 1 or 7 or 13 or 19 or 25 or 26)
                        {
                            continue;
                        }
                    }

                    if ((stack.Count == 0) || ((amphipod, option) != stack[0] && (option, amphipod) != stack[0]))
                    {
                        var anyPossiblePath = MoveAmphipodFrom(amphipod).To(option).OrReturnBack();
                        if (anyPossiblePath)
                        {
                            stack.Insert(0, (amphipod, option));

                            if (_count == 129524)
                            {
                                System.Diagnostics.Debugger.Break();
                            }

                            var amphipodsAbleToMove = CalculateAmphipodsAbleToMove();

                            //System.IO.File.AppendAllText("./paths.txt", $"{ToString()} [{_count} - {TotalCost}]\n\n");
                            //Console.WriteLine($"{TotalCost}: {ToString()}");
                            WalkWith(amphipodsAbleToMove, stack);

                            var reset = stack[0];
                            stack.RemoveAt(0);
                            ResetAmphipodBackFrom(reset.To).To(reset.From);
                            //Console.WriteLine($"{TotalCost}: {ToString()}");
                            //System.IO.File.AppendAllText("./paths.txt", $"{ToString()} [{_count} - {TotalCost}]\n\n");
                        }
                    }
                }
            }
        }

        private int[] CalculateAmphipodsAbleToMove()
        {
            var amphipodsAbleToMove = new List<int>();

            for (var index = 0; index < _rooms.Length; index++)
            {
                if (IsThereAnAmphipodAt(index))
                {
                    if (InHomeArea(index))
                    {
                        if (InOwnHomeArea(_rooms[index], index))
                        {
                            if (ForeignersInOwnHomeArea(index))
                            {
                                amphipodsAbleToMove.Add(index);
                            }
                        }
                        else
                        {
                            amphipodsAbleToMove.Add(index);
                        }
                    }
                    else
                    {
                        if (IsHomeAreaBeingCompleted(_rooms[index]))
                        {
                            amphipodsAbleToMove.Add(index);
                        }
                    }
                }
            }

            return amphipodsAbleToMove.ToArray();
        }

        private bool ForeignersInOwnHomeArea(int amphipod) =>
            ((amphipod is >= 2 and <= 5) && (string.Format("{0}{1}{2}{3}", _rooms[2..6]).Replace(".", string.Empty).Replace("A", string.Empty)?.Length != 0)) ||
            ((amphipod is >= 8 and <= 11) && (string.Format("{0}{1}{2}{3}", _rooms[8..12]).Replace(".", string.Empty).Replace("B", string.Empty)?.Length != 0)) ||
            ((amphipod is >= 14 and <= 17) && (string.Format("{0}{1}{2}{3}", _rooms[14..18]).Replace(".", string.Empty).Replace("C", string.Empty)?.Length != 0)) ||
            ((amphipod is >= 20 and <= 23) && (string.Format("{0}{1}{2}{3}", _rooms[20..24]).Replace(".", string.Empty).Replace("D", string.Empty)?.Length != 0));

        private bool IsHomeAreaBeingCompleted(string amphipod) =>
            ((amphipod == "A") && (string.Format("{0}{1}{2}{3}", _rooms[2..6]).Replace(".", string.Empty).Replace("A", string.Empty)?.Length == 0)) ||
            ((amphipod == "B") && (string.Format("{0}{1}{2}{3}", _rooms[8..12]).Replace(".", string.Empty).Replace("B", string.Empty)?.Length == 0)) ||
            ((amphipod == "C") && (string.Format("{0}{1}{2}{3}", _rooms[14..18]).Replace(".", string.Empty).Replace("C", string.Empty)?.Length == 0)) ||
            ((amphipod == "D") && (string.Format("{0}{1}{2}{3}", _rooms[20..24]).Replace(".", string.Empty).Replace("D", string.Empty)?.Length == 0));

        private bool HasFinalPositionBeenReached() =>
            _rooms[2] == "A" && _rooms[3] == "A" && _rooms[4] == "A" && _rooms[5] == "A" &&
            _rooms[8] == "B" && _rooms[9] == "B" && _rooms[10] == "B" && _rooms[11] == "B" &&
            _rooms[14] == "C" && _rooms[15] == "C" && _rooms[16] == "C" && _rooms[17] == "C" &&
            _rooms[20] == "D" && _rooms[21] == "D" && _rooms[22] == "D" && _rooms[23] == "D";

        private IMovementBackFrom ResetAmphipodBackFrom(int amphipod)
        {
            _currentAmphipod = amphipod;
            return this;
        }

        void IMovementBackFrom.To(int node)
        {
            var currentLocation = _currentAmphipod;
            _currentTarget = node;

            while (_paths[currentLocation][_currentTarget] != -1)
            {
                var nextRoom = _paths[currentLocation][_currentTarget];
                if (_rooms[nextRoom] == ".")
                {
                    TotalCost -= _amphipodeTypes[_rooms[currentLocation]];
                    _rooms[nextRoom] = _rooms[currentLocation];
                    _rooms[currentLocation] = ".";
                    currentLocation = nextRoom;
                }
                else
                {
                    throw new ArgumentException("Impossible to move through here");
                }
            }
        }

        public bool AndStopOnFail()
        {
            var currentLocation = _currentAmphipod;

            if (_paths[currentLocation][_currentTarget] != -1)
            {
                var nextRoom = _paths[currentLocation][_currentTarget];
                if (_rooms[nextRoom] == ".")
                {
                    var totalCost = _amphipodeTypes[_rooms[currentLocation]];
                    TotalCost += totalCost;
                    _rooms[nextRoom] = _rooms[currentLocation];
                    _rooms[currentLocation] = ".";

                    if (! MoveAmphipodFrom(nextRoom).To(_currentTarget).AndStopOnFail())
                    {
                        if (CanStayInThisPosition(nextRoom))
                        {
                            return true;
                        }
                        else
                        {
                            _currentAmphipod = currentLocation;
                            _rooms[currentLocation] = _rooms[nextRoom];
                            _rooms[nextRoom] = ".";
                            TotalCost -= totalCost;
                            return false;
                        }
                    }
                }
                else
                {
                    if (! CanStayInThisPosition(currentLocation))
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (! CanStayInThisPosition(currentLocation))
                {
                    return false;
                }
            }

            return true;
        }

        public void OrFail()
        {
            if (!OrReturnBack())
            {
                throw new ArgumentException("Could not complete path");
            }
        }

        public bool OrReturnBack()
        {
            var currentLocation = _currentAmphipod;

            if (_paths[currentLocation][_currentTarget] != -1)
            {
                var nextRoom = _paths[currentLocation][_currentTarget];
                if (_rooms[nextRoom] == ".")
                {
                    var totalCost = _amphipodeTypes[_rooms[currentLocation]];
                    TotalCost += totalCost;
                    _rooms[nextRoom] = _rooms[currentLocation];
                    _rooms[currentLocation] = ".";

                    if (! MoveAmphipodFrom(nextRoom).To(_currentTarget).OrReturnBack())
                    {
                        _currentAmphipod = currentLocation;
                        _rooms[currentLocation] = _rooms[nextRoom];
                        _rooms[nextRoom] = ".";
                        TotalCost -= totalCost;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (! CanStayInThisPosition(currentLocation))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CanStayInThisPosition(int currentLocation)
        {
            if (currentLocation is 6 or 12 or 18 or 24)
            {
                return false;
            }

            if (InHomeArea(currentLocation))
            {
                if (!InOwnHomeArea(_rooms[currentLocation], currentLocation))
                {
                    return false;
                }
                else
                {
                    if (StrangersAtHome(_rooms[currentLocation]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool InHomeArea(int location) =>
            location is (>= 2 and <= 5) or (>= 8 and <= 11) or (>= 14 and <= 17) or (>= 20 and <= 23);

        private static bool InOwnHomeArea(string amphipod, int location) =>
                (amphipod == "A" && location is >= 2 and <= 5) ||
                (amphipod == "B" && location is >= 8 and <= 11) ||
                (amphipod == "C" && location is >= 14 and <= 17) ||
                (amphipod == "D" && location is >= 20 and <= 23);

        private bool StrangersAtHome(string amphipod) =>
            (amphipod == "A" && ((_rooms[2] is "B" or "C" or "D") || (_rooms[3] is "B" or "C" or "D") || (_rooms[4] is "B" or "C" or "D"))) ||
            (amphipod == "B" && ((_rooms[8] is "A" or "C" or "D") || (_rooms[9] is "A" or "C" or "D") || (_rooms[10] is "A" or "C" or "D"))) ||
            (amphipod == "C" && ((_rooms[14] is "A" or "B" or "D") || (_rooms[15] is "A" or "B" or "D") || (_rooms[16] is "A" or "B" or "D"))) ||
            (amphipod == "D" && ((_rooms[20] is "A" or "B" or "C") || (_rooms[21] is "A" or "B" or "C") || (_rooms[22] is "A" or "B" or "C")));

    }
}