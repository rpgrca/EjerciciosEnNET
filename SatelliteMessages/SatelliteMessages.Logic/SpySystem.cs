using System;
using System.Collections.Generic;
using System.Linq;

namespace SatelliteMessages.Logic
{
    public class SpySystem
    {
        private readonly List<(double X, double Y)> _satellites;
        private double _formulaeA;
        private double _formulaeB;
        private double _formulaeC;
        private (double X, double Y) _guessedSource;
        private List<SatelliteLocation> _locations;

        public SpySystem(List<(double X, double Y)> satellites)
        {
            if (satellites is null || satellites.Count == 0)
            {
                throw new ArgumentException("No satellites");
            }

            _satellites = satellites;
        }

        public (double X, double Y) GetLocation(List<double> distances)
        {
            GuardAgainstEmptyDistances(distances);
            GuardAgainstMismatchNumberOfSatellitesAndDistances(distances);
            GuardAgainstNotEnoughWorkingSatellites(distances);

            if (distances.Contains(0))
            {
                return _satellites[distances.IndexOf(0)];
            }

            BuildSatelliteLocations(distances);
            CalculateDiscriminantValues();

            if (CanLocateSourceWithSatellites())
            {
                return _guessedSource;
            }

            throw new Exception("Could not locate source");
        }

        private static void GuardAgainstEmptyDistances(List<double> distances)
        {
            if (distances is null || distances.Count == 0)
            {
                throw new ArgumentException("No distances");
            }
        }

        private void GuardAgainstMismatchNumberOfSatellitesAndDistances(List<double> distances)
        {
            if (_satellites.Count != distances.Count)
            {
                throw new ArgumentException("Satellite count and distance count do not match");
            }
        }

        private static void GuardAgainstNotEnoughWorkingSatellites(List<double> distances)
        {
            if (distances.Count == 1 && distances[0] != 0)
            {
                throw new ArgumentException("Not enough satellites to obtain coordinates");
            }
        }

        private void BuildSatelliteLocations(List<double> distances) =>
            _locations = _satellites.Select((p, i) => new SatelliteLocation(p.X, p.Y, distances[i])).ToList();

        private void CalculateDiscriminantValues()
        {
            var firstLocationYsquaredMinusDistance = Math.Pow(_locations[0].Y, 2) - Math.Pow(_locations[0].Distance, 2);
            var number = (Math.Pow(_locations[1].Distance, 2) - Math.Pow(_locations[1].Y, 2) + firstLocationYsquaredMinusDistance - Math.Pow(_locations[0].X - _locations[1].X, 2)) / 2 / (_locations[0].X - _locations[1].X);
            var locationsDiffYdividedBydiffX = (_locations[0].Y - _locations[1].Y) / (_locations[0].X - _locations[1].X);

            _formulaeA = Math.Pow(locationsDiffYdividedBydiffX, 2) + 1;
            _formulaeB = -2 * ((number * locationsDiffYdividedBydiffX) + _locations[0].Y);
            _formulaeC = firstLocationYsquaredMinusDistance + Math.Pow(number, 2);
        }

        private bool CanLocateSourceWithSatellites() =>
            new Func<double, double, double>[] { (a, b) => a + b, (a, b) => a - b }
                .Any(GuessedPositionValidatesAllSatellites);

        private bool GuessedPositionValidatesAllSatellites(Func<double, double, double> adder)
        {
            GuessCoordinates(adder);
            return _locations.All(l => NegligibleDifferenceBetweenGuessedPointAnd(l));
        }

        private void GuessCoordinates(Func<double, double, double> adder)
        {
            var y = adder(-_formulaeB, GetSquareRootedDiscriminant()) / (2 * _formulaeA);
            var x =  _locations[0].SolveXfor(y);
            _guessedSource = (x, y);
        }

        private bool NegligibleDifferenceBetweenGuessedPointAnd(SatelliteLocation location) =>
            location.GetDifferenceInDistanceTo(_guessedSource) < 0.00001;

        private double GetSquareRootedDiscriminant() =>
            Math.Sqrt((_formulaeB * _formulaeB) - (4 * _formulaeA * _formulaeC));
    }
}