using System.Linq;
using System;

namespace Day17.Logic
{
    public class Launcher
    {
        private readonly string _targetArea;
        private (int X, int Y) _initialVelocity;
        private (int X, int Y) _probePosition;

        public (int X, int Y) Maximum { get; private set; }
        public (int X, int Y) Minimum { get; private set; }

        public Launcher(string targetArea)
        {
            if (string.IsNullOrWhiteSpace(targetArea))
            {
                throw new ArgumentException("Invalid target area");
            }

            _targetArea = targetArea;

            Parse();
        }

        private void Parse()
        {
            var coordinates = _targetArea
                .Split(": ")[1]
                .Split(", ")
                .Select(p => p.Split("=")[1])
                .Select(p => p.Split(".."))
                .Select(p => (int.Parse(p[0]), int.Parse(p[1])))
                .ToList();
            Maximum = (coordinates[0].Item2, coordinates[1].Item1);
            Minimum = (coordinates[0].Item1, coordinates[1].Item2);
        }

        public void InitialVelocity(int x, int y) => _initialVelocity = (x, y);

        public bool IsCurrentVelocityEqualTo(int x, int y) => _initialVelocity == (x, y);

        public bool IsProbePositionedAt(int x, int y) => _probePosition == (x, y);
    }
}