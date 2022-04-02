using System.Linq;
using System;
using System.Collections.Generic;

namespace Day17.Logic
{
    public class Launcher
    {
        private readonly string _targetArea;

        public (int Minimum, int Maximum) RangeX { get; private set; }
        public (int Minimum, int Maximum) RangeY { get; private set; }
        public int HighestPointAbleToReach { get; private set; }
        public int AmountOfShootsAbleToHitTargetArea { get; private set; }

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

       public int CountStepsUntilHittingTargetArea(Probe probe)
        {
            for (var steps = 0; probe.HasntReached(RangeX, RangeY); steps++)
            {
                if (probe.IsWithin(RangeX, RangeY))
                {
                    return steps;
                }

                probe.Step(1);
            }

            return -1;
        }

        public void CalculateBestShoot() =>
            HighestPointAbleToReach = GetMaximumHeights().Max(p => p);

        private List<int> GetMaximumHeights()
        {
            var values = new List<int>();
            var minimumX = CalculateMinimumVelocityX();
            var maximumX = RangeX.Maximum;

            while (minimumX <= maximumX)
            {
                for (var y = RangeY.Minimum - 1; y < 100; y++)
                {
                    var probe = new Probe(minimumX, y);
                    var steps = CountStepsUntilHittingTargetArea(probe);
                    if (steps != -1)
                    {
                        values.Add(probe.HighestPoint);
                    }
                }

                minimumX++;
            }

            return values;
        }

        private int CalculateMinimumVelocityX()
        {
            int step = 0;

            for (var x = RangeX.Minimum; x >= 0; x -= step)
            {
                step++;
            }

            return step;
        }

        public void CalculateAllShoots() =>
            AmountOfShootsAbleToHitTargetArea = GetMaximumHeights().Count;
    }
}