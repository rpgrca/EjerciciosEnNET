using System;
using System.Collections.Generic;
using System.Linq;

namespace Day25.Logic
{
    public class SeaCucumberHerd
    {
        private readonly string _seafloor;
        private char[][] _map;
        private bool _cucumbersMoved;

        public int Height { get; private set; }
        public int Width { get; private set; }
        public int StepCount { get; private set; }

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

        public void MoveEast()
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
                _cucumbersMoved = true;
            }
        }

        public void Step(int steps)
        {
            for (var step = 0; step < steps; step++)
            {
                MoveEast();
                MoveSouth();
            }
        }

        public void MoveSouth()
        {
            var moves = new List<((int X, int Y) Source, (int X, int Y) Target)>();
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (_map[y][x] == 'v')
                    {
                        if (y + 1 < Height)
                        {
                            if (_map[y + 1][x] == '.')
                            {
                                moves.Add(((x, y),(x, y + 1)));
                            }
                        }
                        else
                        {
                            if (_map[0][x] == '.')
                            {
                                moves.Add(((x, y), (x, 0)));
                            }
                        }
                    }
                }
            }

            foreach (var (source, target) in moves)
            {
                _map[target.Y][target.X] = 'v';
                _map[source.Y][source.X] = '.';
                _cucumbersMoved = true;
            }
        }

        public override string ToString() =>
            _map.Aggregate(string.Empty, (t, i) => string.Join("\n", t, new string(i))).Trim();

        public void StepUntilNoMovement()
        {
            do
            {
                _cucumbersMoved = false;
                Step(1);
                StepCount++;
            } while (_cucumbersMoved);
        }
    }
}
