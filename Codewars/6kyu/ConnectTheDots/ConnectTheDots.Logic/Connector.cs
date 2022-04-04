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
            _lines = Array.Empty<string>();
            _canvas = Array.Empty<char[]>();
            Picture = string.Empty;
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
            LineFactory
                .Create(_coordinates[points.From], _coordinates[points.To])
                .TraceTo(_dots);
    }
}