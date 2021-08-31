using System;
using System.Collections.Generic;
using System.Linq;

namespace SatelliteMessages.Logic
{
    public sealed partial class SpySystem
    {
        private readonly List<(double X, double Y)> _satellites;
        private List<SatelliteLocation> _locations;
        private readonly double _acceptedOffset;
        private readonly IMessageMerger _messageMerger;
        private readonly ILocationGuesser _locationGuesser;

        private SpySystem(List<(double X, double Y)> satellites, IMessageMerger messageMerger, ILocationGuesser locationGuesser, double acceptedOffset = 0.00001)
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
            _locationGuesser = locationGuesser;
            _acceptedOffset = acceptedOffset;
        }

        public (double X, double Y) GetLocation(List<double> distances)
        {
            GuardAgainstEmptyDistances(distances);
            GuardAgainstMismatchNumberOfSatellitesAndDistances(distances);
            GuardAgainstNotEnoughWorkingSatellites(distances);
            BuildSatelliteLocations(distances);

            return _locationGuesser.GetLocation(_locations, _acceptedOffset);
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