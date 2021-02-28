using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.ConnectTheDots.Logic
{
    public class Connector
    {
        private readonly string _inputValue;
        private int _maximumLineLength;
        private string[] _lines;
        private readonly SortedDictionary<char, (int Y, int X)> _coordinates = new();
        private char[][] _canvas;
        private readonly List<(int Y, int X)> _dots = new();

        public string Picture { get; private set; }

        public Connector(string inputValue)
        {
            _inputValue = inputValue;
            ParseInputValue();
        }

        private void ParseInputValue()
        {
            _lines = _inputValue.Split("\n");
            _maximumLineLength = _lines[0].Length;
            _canvas = _lines.Select(p => p.ToCharArray()).ToArray();

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
            var previousCharacter = _coordinates.Keys.First();
            foreach (var nextCharacter in _coordinates.Keys.Skip(1))
            {
                CalculateCoordinatesFrom(previousCharacter, nextCharacter);
                previousCharacter = nextCharacter;
            }

            _dots.ForEach(c => _canvas[c.Y][c.X] = '*');
            Picture = string.Join("\n", _canvas.Select(c => new string(c)));
        }

        private void CalculateCoordinatesFrom(char previousCharacter, char nextCharacter)
        {
            var source = _coordinates[previousCharacter];
            var target = _coordinates[nextCharacter];

            var horizontalOffset = target.X - source.X;
            var verticalOffset = target.Y - source.Y;

            if (horizontalOffset != 0)
            {
                IEnumerable<int> range;
                if (source.X <= target.X)
                {
                    range = Enumerable.Range(source.X, target.X - source.X + 1);
                }
                else
                {
                    range = Enumerable.Range(target.X, source.X - target.X + 1).Reverse();
                }

                foreach (var horizontalStep in range)
                {
                    _dots.Add((source.Y + (verticalOffset / horizontalOffset), horizontalStep));
                }
            }
            else
            {
                IEnumerable<int> range;
                if (source.Y <= target.Y)
                {
                    range = Enumerable.Range(source.Y, target.Y - source.Y + 1);
                }
                else
                {
                    range = Enumerable.Range(target.Y, source.Y - target.Y + 1).Reverse();
                }

                foreach (var verticalStep in range)
                {
                    _dots.Add((verticalStep, source.X + (horizontalOffset / verticalOffset)));
                }
            }
        }
    }
}
