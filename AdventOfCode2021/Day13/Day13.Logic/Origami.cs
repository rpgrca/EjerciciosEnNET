using System.Linq;
using System;
using System.Collections.Generic;

namespace Day13.Logic
{
    public class Origami
    {
        private readonly string _instructions;
        private readonly List<(int X, int Y)> _points;
        private readonly List<(string Axis, int Value)> _folds;
        private int _width;
        private int _height;

        public Origami(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                throw new ArgumentException("Invalid instructions");
            }

            _instructions = instructions;
            _points = new List<(int, int)>();
            _folds = new List<(string, int)>();

            Parse();
        }

        private void Parse()
        {
            ParsePoints();
            CalculateWidth();
            CalculateHeight();
            ParseFoldInstructions();
       }

        private void ParsePoints() =>
            _points.AddRange(_instructions
                .Split("\n")
                .TakeWhile(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => p.Split(","))
                .Select(p => (int.Parse(p[0]), int.Parse(p[1]))));

        private void CalculateWidth() =>
            _width = _points.Max(p => p.X) + 1;

        private void CalculateHeight() =>
            _height = _points.Max(p => p.Y) + 1;

        private void ParseFoldInstructions() =>
            _folds.AddRange(_instructions
                .Split("\n")
                .Skip(_points.Count + 1)
                .Select(p => p.Replace("fold along ", string.Empty).Split("="))
                .Select(p => (p[0], int.Parse(p[1]))));

        public int GetPointCount() => _points.Count;

        public int GetFoldCount() => _folds.Count;

        public void FoldAlongY(int y) =>
            FoldAlong((p, y) => p.Y <= y ? p : (p.X, y - (p.Y - y)), y, y => _height = y);

        public void FoldAlongX(int x) =>
            FoldAlong((p, x) => p.X <= x ? p : (x - (p.X - x), p.Y), x, x => _width = x);

        private void FoldAlong(Func<(int X, int Y), int, (int X, int Y)> Transformation, int value, Action<int> Resize)
        {
            var points = _points
                .Select(p => Transformation(p, value))
                .Distinct()
                .ToList();

            _points.Clear();
            _points.AddRange(points);
            Resize(value);
        }

        public void FoldAccordingToInstructions()
        {
            var actions = new Dictionary<string, Action<int>>
            {
                { "x", p => FoldAlongX(p) },
                { "y", p => FoldAlongY(p) }
            };

            _folds.ForEach(p => actions[p.Axis](p.Value));
        }

        public string PlotPoints()
        {
            var value = string.Empty;

            var plot = Enumerable.Repeat(".", _width * _height).ToList();
            _points.ForEach(p => plot[(p.Y * _width) + p.X] = "#");
            return string.Concat(plot.Select((p, i) => i % _width == 0 ? $"\n{p}" : p)).Trim();
        }
    }
}