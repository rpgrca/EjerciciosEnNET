using System;
using System.Collections.Generic;

namespace Day19.Logic
{
    public class ManhattanDistance
    {
        public int Maximum { get; }

        public ManhattanDistance(List<Scanner> scanners)
        {
            for (var first = 0; first < scanners.Count - 1; first++)
            {
                for (var second = first + 1; second < scanners.Count; second++)
                {
                    var distance = CalculateAbsoluteDistance(scanners[first], scanners[second]);
                    if (distance > Maximum)
                    {
                        Maximum = distance;
                    }
                }
            }
        }

        private static int CalculateAbsoluteDistance(Scanner firstScanner, Scanner secondScanner) =>
            Math.Abs(firstScanner.Origin.X - secondScanner.Origin.X) +
            Math.Abs(firstScanner.Origin.Y - secondScanner.Origin.Y) +
            Math.Abs(firstScanner.Origin.Z - secondScanner.Origin.Z);
    }
}