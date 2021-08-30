using System;
using System.Collections.Generic;

namespace SatelliteMessages.Logic
{
    public class XYZ
    {
        private readonly List<(double X, double Y)> _satellites;
        private double _formulaeA;
        private double _formulaeB;
        private double _formulaeC;

        private (double X, double Y) _guessedSource;

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

            CalculateDiscriminantValues(distances);
            foreach (var adder in new Func<double, double, double>[] { (a, b) => a + b, (a, b) => a - b })
            {
                if (GuessedPositionValidatesAllSatellites(distances, adder))
                {
                    return _guessedSource;
                }
            }

            throw new Exception("Could not locate source");
        }

        private void CalculateDiscriminantValues(List<double> distances)
        {
            var number = (Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2 / (_satellites[0].X - _satellites[1].X);
            var number2 = (_satellites[0].Y - _satellites[1].Y) / (_satellites[0].X - _satellites[1].X);
            var number3 = -Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2) - Math.Pow(number, 2);

            _formulaeA = Math.Pow(number2, 2) + 1;
            _formulaeB = -2 * ((number * number2) + _satellites[0].Y);
            _formulaeC = -number3;
        }

        private bool GuessedPositionValidatesAllSatellites(List<double> distances, Func<double, double, double> adder)
        {
            GuessCoordinates(distances, adder);

            int index;
            for (index = 0; index < distances.Count; index++)
            {
                var distance = Math.Sqrt(Math.Pow(_guessedSource.X - _satellites[index].X, 2) + Math.Pow(_guessedSource.Y - _satellites[index].Y, 2));
                if (Math.Abs(distance - distances[index]) > 0.00001)
                {
                    break;
                }
            }

            return index == distances.Count;
        }

        private void GuessCoordinates(List<double> distances, Func<double, double, double> adder)
        {
            var y = adder(-_formulaeB, GetSquareRootedDiscriminant()) / (2 * _formulaeA);
            var x = Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2)) + _satellites[0].X;
            _guessedSource = (x, y);
        }

        private double GetSquareRootedDiscriminant() =>
            Math.Sqrt((_formulaeB * _formulaeB) - (4 * _formulaeA * _formulaeC));
    }
}