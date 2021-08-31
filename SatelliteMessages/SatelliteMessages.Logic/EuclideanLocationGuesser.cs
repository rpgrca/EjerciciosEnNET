using System;
using System.Collections.Generic;
using System.Linq;

namespace SatelliteMessages.Logic
{
    public class EuclideanLocationGuesser : ILocationGuesser
    {
        private (double A, double B, double C) Discriminant { get; set; }
        private (double X, double Y) GuessedSource { get; set; }
        private List<SatelliteLocation> _locations;
        private double _acceptedOffset;

        public (double X, double Y) GetLocation(List<SatelliteLocation> locations, double acceptedOffset)
        {
            _locations = locations;
            _acceptedOffset = acceptedOffset;

            var anySatelliteRightAboveSource = locations.Find(p => p.Distance == 0);
            if (anySatelliteRightAboveSource is not null)
            {
                return (anySatelliteRightAboveSource.X, anySatelliteRightAboveSource.Y);
            }

            CalculateDiscriminantValues();

            if (CanLocateSourceWithSatellites())
            {
                return GuessedSource;
            }

            throw new Exception("Could not locate source");
        }

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
    }
}