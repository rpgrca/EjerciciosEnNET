using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.ConnectTheDots.Logic
{
    public class Connector
    {
        private readonly string _inputValue;
        private readonly SortedDictionary<char, (int Y, int X)> _coordinates = new();
        private readonly List<(int Y, int X)> _dots = new();
        private string[] _lines;
        private char[][] _canvas;

        public string Picture { get; private set; }

        public Connector(string inputValue)
        {
            _inputValue = inputValue;
            ParseInputValue();
        }

        private void ParseInputValue()
        {
            SplitInputIntoLines();
            CreateTemporaryCanvas();
            LocateCoordinates();
        }

        private void SplitInputIntoLines() =>
            _lines = _inputValue.Split("\n");

        private void CreateTemporaryCanvas() =>
            _canvas = _lines.Select(p => p.ToCharArray()).ToArray();

        private void LocateCoordinates()
        {
            for (var line = 0; line < _canvas.Length; line++)
            {
                for (var character = 0; character < _canvas[line].Length; character++)
                {
                    if (_canvas[line][character] != ' ')
                    {
                        _coordinates.Add(_canvas[line][character], (line, character));
                    }
                }
            }
        }

        public void Connect()
        {
            _coordinates.Keys
                .Skip(1)
                .Zip(_coordinates.Keys, (To, From) => (From, To))
                .ToList()
                .ForEach(CalculateCoordinatesFrom);

            DrawCanvas();
            ConvertCanvasToPicture();
        }

        private void DrawCanvas() =>
            _dots.ForEach(c => _canvas[c.Y][c.X] = '*');

        private void ConvertCanvasToPicture() =>
            Picture = string.Join("\n", _canvas.Select(c => new string(c)));

        private void CalculateCoordinatesFrom((char From, char To) points) =>
            new LineFactory()
                .Create(_coordinates[points.From], _coordinates[points.To])
                .TraceTo(_dots);
    }

    public class LineFactory
    {
        public ILine Create((int Y, int X) source, (int Y, int X) target)
        {
            var horizontalOffset = target.X - source.X;
            var verticalOffset = target.Y - source.Y;

            if (horizontalOffset > 0 && verticalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (s, _, h, _) => Enumerable.Range(s.X, h + 1),
                    (dots, s, p) => dots.Add((s.Y, p)));
            }
            else
            if (horizontalOffset < 0 && verticalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (_, t, h, _) => Enumerable.Range(t.X, -h + 1).Reverse(),
                    (dots, s, p) => dots.Add((s.Y, p)));
            }
            else
            if (verticalOffset > 0 && horizontalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (s, _, _, v) => Enumerable.Range(s.Y, v + 1),
                    (dots, s, p) => dots.Add((p, s.X)));
            }
            else
            if (verticalOffset < 0 && horizontalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (_, t, _, v) => Enumerable.Range(t.Y, -v + 1).Reverse(),
                    (dots, s, p) => dots.Add((p, s.X)));
            }
            else
            if (horizontalOffset > 0)
            {
                return new DiagonalLine(
                    source, target,
                    horizontalOffset, verticalOffset,
                    1, (s, _, h, _) => Enumerable.Range(s.X, h + 1));
            }
            else
            if (horizontalOffset < 0)
            {
                return new DiagonalLine(
                    source, target,
                    horizontalOffset, verticalOffset,
                    -1, (_, t, h, _) => Enumerable.Range(t.X, -h + 1).Reverse());
            }

            return null;
        }
    }

    public interface ILine
    {
        void TraceTo(List<(int Y, int X)> dots);
    }

    public class Line : ILine
    {
        private readonly (int Y, int X) _source;
        private readonly (int Y, int X) _target;
        private readonly int _horizontalOffset;
        private readonly int _verticalOffset;
        private readonly Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> Steps;
        private readonly Action<List<(int Y, int X)>, (int Y, int X), int> Adding;

        public Line(
            (int Y, int X) source, (int Y, int X) target,
            int horizontalOffset, int verticalOffset,
            Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> steps,
            Action<List<(int Y, int X)>, (int Y, int X), int> adding)
        {
            _source = source;
            _target = target;
            _horizontalOffset = horizontalOffset;
            _verticalOffset = verticalOffset;
            Steps = steps;
            Adding = adding;
        }

        public void TraceTo(List<(int Y, int X)> dots) =>
            Steps(_source, _target, _horizontalOffset, _verticalOffset)
                .ToList()
                .ForEach(p => Adding(dots, _source, p) );
    }

    public class DiagonalLine : ILine
    {
        protected readonly (int Y, int X) _source;
        protected readonly (int Y, int X) _target;
        protected readonly int _horizontalOffset;
        protected readonly int _verticalOffset;
        private readonly int _multiplier;
        private readonly Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> Steps;

        public DiagonalLine((int Y, int X) source, (int Y, int X) target, int horizontalOffset, int verticalOffset, int multiplier, Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> steps)
        {
            _source = source;
            _target = target;
            _horizontalOffset = horizontalOffset;
            _verticalOffset = verticalOffset;
            _multiplier = multiplier;
            Steps = steps;
        }

        public void TraceTo(List<(int Y, int X)> dots)
        {
            var verticalStep = _verticalOffset / (_multiplier * _horizontalOffset);
            var step = 0;

            Steps(_source, _target, _horizontalOffset, _verticalOffset)
                .ToList()
                .ForEach(p => dots.Add((_source.Y + (step++ * verticalStep), p)));
        }
    }
}