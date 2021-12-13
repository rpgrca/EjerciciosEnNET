using System.Linq;
using System;
using System.Collections.Generic;

namespace Day13.Logic
{
    public class Origami
    {
        private readonly string _instructions;
        private readonly List<(int X, int Y)> _points;
        private readonly List<string> _folds;
        private int _width;
        private int _height;

        public Origami(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                throw new ArgumentException("Invalid instructions");
            }

            _instructions = instructions;
            _points = new List<(int X, int Y)>();
            _folds = new List<string>();

            Parse();
        }

        private void Parse()
        {
            _points.AddRange(_instructions
                .Split("\n")
                .TakeWhile(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => p.Split(","))
                .Select(p => (int.Parse(p[0]), int.Parse(p[1]))));

            _width = _points.Max(p => p.X) + 1;
            _height = _points.Max(p => p.Y) + 1;

            _folds.AddRange(_instructions
                .Split("\n")
                .Skip(_points.Count + 1)
                .Select(p => p.Replace("fold along ", string.Empty)));
        }

        public int GetPoints() => _points.Count;

        public int GetFolds() => _folds.Count;

        public void FoldAlongY(int y)
        {
            var points = _points
                .OrderByDescending(p => p.Y)
                .Select(p => p.Y <= y ? p : (p.X, y - (p.Y - y)))
                .Distinct()
                .ToList();

            _points.Clear();
            _points.AddRange(points);
            _height = y;
        }

        public void FoldAlongX(int x)
        {
            var points = _points
                .OrderByDescending(p => p.X)
                .Select(p => p.X <= x ? p : (x - (p.X - x), p.Y))
                .Distinct()
                .ToList();

            _points.Clear();
            _points.AddRange(points);
            _width = x;
        }

        public void FoldAccordingToInstructions()
        {
            foreach (var instruction in _folds)
            {
                var fold = instruction.Split("=");
                if (fold[0] == "x")
                {
                    FoldAlongX(int.Parse(fold[1]));
                }
                else
                {
                    FoldAlongY(int.Parse(fold[1]));
                }
            }
        }

        public string PlotPoints()
        {
            var value = string.Empty;

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_points.Contains((x, y)))
                    {
                        value += "#";
                    }
                    else
                    {
                        value += ".";
                    }
                }

                value += "\n";
            }

            return value.Trim();
        }
    }
}