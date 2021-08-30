using System;

namespace SatelliteMessages.Logic
{
    internal class SatelliteLocation
    {
        public double X { get; }
        public double Y { get; }
        public double Distance { get; }

        public SatelliteLocation(double x, double y, double distance)
        {
            (X, Y, Distance) = (x, y, distance);
        }

        public double SolveXfor(double y) =>
            Math.Sqrt((Distance * Distance) - Math.Pow(y - Y, 2)) + X;

        public double GetDistanceTo((double X, double Y) point) =>
            Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));

        internal double GetDifferenceInDistanceTo((double X, double Y) guessedSource) =>
            Math.Abs(GetDistanceTo(guessedSource) - Distance);
    }
}