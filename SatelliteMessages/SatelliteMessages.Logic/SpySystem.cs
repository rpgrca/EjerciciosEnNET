using System;
using System.Collections.Generic;
using System.Linq;

namespace SatelliteMessages.Logic
{
    public class SpySystem
    {
        public class Builder
        {
            private List<(double X, double Y)> _satellites;
            private double _acceptedOffset;

            private IMessageMerger _messageMerger;

            public Builder WithToleranceOf(double offset)
            {
                _acceptedOffset = offset;
                return this;
            }

            public Builder Using(IMessageMerger messageMerger)
            {
                _messageMerger = messageMerger;
                return this;
            }

            public Builder ConnectingTo(List<(double X, double Y)> satellites)
            {
                _satellites = satellites;
                return this;
            }

            public SpySystem Build() => new(_satellites, _messageMerger, _acceptedOffset);
        }

        private readonly List<(double X, double Y)> _satellites;
        private (double A, double B, double C) Discriminant { get; set; }
        private (double X, double Y) GuessedSource { get; set; }
        private List<SatelliteLocation> _locations;
        private readonly double _acceptedOffset;
        private readonly IMessageMerger _messageMerger;

        private SpySystem(List<(double X, double Y)> satellites, IMessageMerger messageMerger, double acceptedOffset = 0.00001)
        {
            if (satellites is null || satellites.Count == 0)
            {
                throw new ArgumentException("No satellites");
            }

            if (acceptedOffset < 0)
            {
                throw new ArgumentException("Invalid precision");
            }

            _satellites = satellites;
            _messageMerger = messageMerger;
            _acceptedOffset = acceptedOffset;
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
                return GuessedSource;
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

            Discriminant = (A: Math.Pow(locationsDiffYdividedBydiffX, 2) + 1,
                            B: -2 * ((number * locationsDiffYdividedBydiffX) + _locations[0].Y),
                            C: firstLocationYsquaredMinusDistance + Math.Pow(number, 2));
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
            var y = adder(-Discriminant.B, GetSquareRootedDiscriminant()) / (2 * Discriminant.A);
            var x =  _locations[0].SolveXfor(y);
            GuessedSource = (x, y);
        }

        private bool NegligibleDifferenceBetweenGuessedPointAnd(SatelliteLocation location) =>
            location.GetDifferenceInDistanceTo(GuessedSource) < _acceptedOffset;

        private double GetSquareRootedDiscriminant() =>
            Math.Sqrt((Discriminant.B * Discriminant.B) - (4 * Discriminant.A * Discriminant.C));

        public string GetMessage(List<string[]> brokenMessages)
        {
            if (brokenMessages is null || brokenMessages.Count != _satellites.Count)
            {
                throw new ArgumentException("Satellite and message count mismatch");
            }

            return _messageMerger.Merge(brokenMessages);
        }
    }
}