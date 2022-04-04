using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day24.Logic
{
    [DebuggerDisplay("({Position.X}, {Position.Y}), Black? {IsBlack}}")]
    public class Tile
    {
        private readonly string _data;
        private List<string> _path;
        private (double X, double Y) _position;

        public (double X, double Y) Position => _position;
        public int IsBlack { get; private set; }

        public Tile(string data)
        {
            _data = data;
            _path = new List<string>();
            IsBlack = 1;

            ParsePath();
            TraversePathToLocatePosition();
        }

        public Tile(double x, double y)
        {
            _position.X = x;
            _position.Y = y;
            IsBlack = 0;
            _data = string.Empty;
            _path = new List<string>();
        }

        private void TraversePathToLocatePosition()
        {
            _position = (X: 0.0, Y: 0.0);

            foreach (var step in _path)
            {
                switch (step)
                {
                    case "w": _position.X--; break;
                    case "e": _position.X++; break;

                    case "ne":
                        _position.X += 0.5;
                        _position.Y++;
                        break;

                    case "nw":
                        _position.X -= 0.5;
                        _position.Y++;
                        break;

                    case "se":
                        _position.X += 0.5;
                        _position.Y--;
                        break;

                    case "sw":
                        _position.X -= 0.5;
                        _position.Y--;
                        break;
                }
            }
        }

        private void ParsePath()
        {
            _path = _data.Replace("nw", "1").Replace("ne", "2").Replace("se", "4").Replace("sw", "5")
                .Select(x => new string(x, 1))
                .ToArray()
                .Select(p => p
                    .Replace("1", "nw")
                    .Replace("2", "ne")
                    .Replace("4", "se")
                    .Replace("5", "sw"))
                .ToList();
        }

        public void Flip() => IsBlack ^= IsBlack;

        public void SetToWhite() => IsBlack = 0;

        public void SetToBlack() => IsBlack = 1;
    }
}