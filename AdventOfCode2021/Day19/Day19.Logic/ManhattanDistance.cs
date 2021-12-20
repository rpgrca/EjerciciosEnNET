using System;
using System.Collections.Generic;

namespace Day19.Logic
{
    public class ManhattanDistance
    {
        public int Maximum { get; }

        public ManhattanDistance(List<Scanner> scanners)
        {
            foreach (var firstScanner in scanners.ToArray()[0..^1])
            {
                foreach (var secondScanner in scanners.ToArray()[1..])
                {
                    var distance = CalculateAbsoluteDistance(firstScanner, secondScanner);
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