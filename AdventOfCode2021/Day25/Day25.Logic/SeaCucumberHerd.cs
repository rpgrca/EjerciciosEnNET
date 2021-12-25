using System;
using System.Collections.Generic;
using System.Linq;

namespace Day25.Logic
{
    public class SeaCucumberHerd
    {
        private readonly string _seafloor;
        private char[][] _map;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public SeaCucumberHerd(string seafloor)
        {
            if (string.IsNullOrWhiteSpace(seafloor))
            {
                throw new ArgumentException("Invalid seafloor");
            }

            _seafloor = seafloor;

            Parse();
        }

        private void Parse()
        {
            var lines = _seafloor.Split("\n");

            Height = lines.Length;
            _map = new char[Height][];

            for (var index = 0; index < lines.Length; index++)
            {
                _map[index] = lines[index].ToCharArray();
            }

            Width = _map[0].Length;
        }

        public void Step()
        {
            var moves = new List<((int X, int Y) Source, (int X, int Y) Target)>();
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (_map[y][x] == '>')
                    {
                        if (x + 1 < Width)
                        {
                            if (_map[y][x + 1] == '.')
                            {
                                moves.Add(((x, y),(x+1, y)));
                            }
                        }
                        else
                        {
                            if (_map[y][0] == '.')
                            {
                                moves.Add(((x, y), (0, y)));
                            }
                        }
                    }
                }
            }

            foreach (var (source, target) in moves)
            {
                _map[target.Y][target.X] = '>';
                _map[source.Y][source.X] = '.';
            }
        }

        public override string ToString() =>
            _map.Aggregate(string.Empty, (t, i) => string.Join("\n", t, new string(i))).Trim();
    }
}
