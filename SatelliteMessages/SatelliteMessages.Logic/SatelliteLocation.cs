using System;

namespace SatelliteMessages.Logic
{
    public class SatelliteLocation
    {
        public double X { get; }
        public double Y { get; }
        public double Distance { get; }

        internal SatelliteLocation(double x, double y, double distance) =>
            (X, Y, Distance) = (x, y, distance);

        public double SolveXfor(double y) =>
            Math.Sqrt((Distance * Distance) - Math.Pow(y - Y, 2)) + X;

        public double GetDistanceTo((double X, double Y) point) =>
            Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));

        public double GetDifferenceInDistanceTo((double X, double Y) guessedPoint) =>
            Math.Abs(GetDistanceTo(guessedPoint) - Distance);
    }
}