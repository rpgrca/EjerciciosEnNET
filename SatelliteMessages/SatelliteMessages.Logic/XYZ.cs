using System;
using System.Linq;
using System.Collections.Generic;

namespace SatelliteMessages.Logic
{
    public class XYZ
    {
        private readonly List<(double X, double Y)> _satellites;

        public XYZ(List<(double X, double Y)> satellites)
        {
            if (satellites is null || satellites.Count == 0)
            {
                throw new ArgumentException("No satellites");
            }

            _satellites = satellites;
        }

        public (double X, double Y) GetLocation(List<double> distances)
        {
            if (distances is null || distances.Count == 0)
            {
                throw new ArgumentException("No distances");
            }

            if (_satellites.Count != distances.Count)
            {
                throw new ArgumentException("Satellite count and distance count do not match");
            }

            if (distances.Count == 1 && distances[0] != 0)
            {
                throw new ArgumentException("Not enough satellites to obtain coordinates");
            }

            if (distances.Contains(0))
            {
                return _satellites[distances.IndexOf(0)];
            }

            var number = ((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X);
            var number2 = (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X));
            var number3 = (-Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2) - Math.Pow(number, 2));

            var a = Math.Pow(number2, 2) + 1;
            var b = -2 * (number * number2 + _satellites[0].Y);
            var c = -number3;

            var y1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            var x11 = Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y1 - _satellites[0].Y, 2)) + _satellites[0].X;

            double distanceBetweenFirstSatelliteAndSource;
            double distanceBetweenSecondSatelliteAndSource;
            double distanceBetweenThirdSatelliteAndSource;

            distanceBetweenFirstSatelliteAndSource = Math.Sqrt(Math.Pow(x11 - _satellites[0].X, 2) + Math.Pow(y1 - _satellites[0].Y, 2));
            if (Math.Abs(distanceBetweenFirstSatelliteAndSource - distances[0]) < 0.00001)
            {
                distanceBetweenSecondSatelliteAndSource = Math.Sqrt(Math.Pow(x11 - _satellites[1].X, 2) + Math.Pow(y1 - _satellites[1].Y, 2));
                if (Math.Abs(distanceBetweenSecondSatelliteAndSource - distances[1]) < 0.00001)
                {
                    distanceBetweenThirdSatelliteAndSource = Math.Sqrt(Math.Pow(x11 - _satellites[2].X, 2) + Math.Pow(y1 - _satellites[2].Y, 2));
                    if (Math.Abs(distanceBetweenThirdSatelliteAndSource - distances[2]) < 0.00001)
                    {
                        return (x11, y1);
                    }
                }
            }

            var y2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            var x12 = Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y2 - _satellites[0].Y, 2)) + _satellites[0].X;

            distanceBetweenFirstSatelliteAndSource = Math.Sqrt(Math.Pow(x12 - _satellites[0].X, 2) + Math.Pow(y2 - _satellites[0].Y, 2));
            if (Math.Abs(distanceBetweenFirstSatelliteAndSource - distances[0]) < 0.00001)
            {
                distanceBetweenSecondSatelliteAndSource = Math.Sqrt(Math.Pow(x12 - _satellites[1].X, 2) + Math.Pow(y2 - _satellites[1].Y, 2));
                if (Math.Abs(distanceBetweenSecondSatelliteAndSource - distances[1]) < 0.00001)
                {
                    distanceBetweenThirdSatelliteAndSource = Math.Sqrt(Math.Pow(x12 - _satellites[2].X, 2) + Math.Pow(y2 - _satellites[2].Y, 2));
                    if (Math.Abs(distanceBetweenThirdSatelliteAndSource - distances[2]) < 0.00001)
                    {
                        return (x12, y2);
                    }
                }
            }


            throw new Exception("Could not locate source");
        }
    }
}
