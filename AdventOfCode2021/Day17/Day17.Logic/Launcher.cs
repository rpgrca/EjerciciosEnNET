using System.Resources;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Day17.Logic
{
    public class Launcher
    {
        private readonly string _targetArea;
        private (int X, int Y) _velocity;
        private (int X, int Y) _probePosition;

        public (int Minimum, int Maximum) RangeX { get; private set; }
        public (int Minimum, int Maximum) RangeY { get; private set; }
        public int HighestPoint { get; private set; }
        public (int X, int Y) BestVelocity { get; set; }

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
            RangeX = (coordinates[0].Item1, coordinates[0].Item2);
            RangeY = (coordinates[1].Item1, coordinates[1].Item2);
        }

        public void InitialVelocity(int x, int y) => _velocity = (x, y);

        public bool IsCurrentVelocityEqualTo(int x, int y) => _velocity == (x, y);

        public bool IsProbePositionedAt(int x, int y) => _probePosition == (x, y);

        public void Step(int steps)
        {
            for (var step = 0; step < steps; step++)
            {
                _probePosition.X += _velocity.X;
                _probePosition.Y += _velocity.Y;

                if (_velocity.X > 0)
                {
                    _velocity.X--;
                }
                else if (_velocity.X < 0)
                {
                    _velocity.X++;
                }

                _velocity.Y--;

                if (_probePosition.Y > HighestPoint)
                {
                    HighestPoint = _probePosition.Y;
                }
            }
        }

        public int CountStepsUntilHittingTargetArea()
        {
            var steps = 0;

            while (_probePosition.X <= RangeX.Maximum && _probePosition.Y >= RangeY.Minimum)
            {
                if (IsProbeWithinTargetArea())
                {
                    return steps;
                }

                Step(1);
                steps++;
            }

            return -1;
        }

        private bool IsProbeWithinTargetArea() =>
            _probePosition.X >= RangeX.Minimum && _probePosition.Y <= RangeY.Maximum;

        public void CalculateBestShoot()
        {
            List<(int X, int Y, int Highest)> values =new();
            int step = 0;

            for (var x = RangeX.Minimum; x >= 0; x -= step)
            {
                step++;
            }

            var minimumX = step;
            var maximumX = RangeX.Maximum;

            while (minimumX <= maximumX)
            {
                for (var y = 0; y < 100; y++)
                {
                    var probe = new Launcher(_targetArea);
                    probe.InitialVelocity(minimumX, y);
                    var steps = probe.CountStepsUntilHittingTargetArea();
                    if (steps != -1)
                    {
                        values.Add((minimumX, y, probe.HighestPoint));
                    }
                }

                minimumX++;
            }

            HighestPoint = values.Max(p => p.Highest);
        }
    }
}