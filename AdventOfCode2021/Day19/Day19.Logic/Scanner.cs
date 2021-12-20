using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19.Logic
{
    public class Scanner
    {
        private (int X, int Y, int Z) _origin;
        private readonly string _data;
        private readonly List<List<(int X, int Y, int Z)>> _rotations;

        public int Id { get; private set; }
        public List<(int X, int Y, int Z)> Beacons { get; }
        public List<(double Distance, (int X, int Y, int Z) From, (int X, int Y, int Z) To)> Distances { get; set; }

        public Scanner(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _rotations = new List<List<(int X, int Y, int Z)>>();

            Beacons = new List<(int X, int Y, int Z)>();
            Distances = new List<(double Distance, (int X, int Y, int Z), (int X, int Y, int Z))>();

            Parse();
        }

        private void Parse()
        {
            var lines = _data.Split("\n");
            Id = int.Parse(lines[0].Replace("---", string.Empty).Replace("scanner", string.Empty));

            foreach (var line in lines[1..])
            {
                var coordinates = line.Split(",").Select(p => int.Parse(p)).ToArray();
                Beacons.Add((coordinates[0], coordinates[1], coordinates[2]));
            }
        }

        public void RotateOnZaxis(int degrees)
        {
            var beacons = Beacons.ConvertAll(p => GetNewPositionAfterRotatingOnZaxis(p, degrees));
            Beacons.Clear();
            Beacons.AddRange(beacons);
        }

        private static (int X, int Y, int Z) GetNewPositionAfterRotatingOnZaxis((int X, int Y, int Z) beacon, int degrees) =>
            degrees switch
            {
                0 => (beacon.X, beacon.Y, beacon.Z),
                90 => (beacon.Y, -beacon.X, beacon.Z),
                180 => (-beacon.X, -beacon.Y, beacon.Z),
                _ => (-beacon.Y, beacon.X, beacon.Z)
            };

        public void RotateOnXaxis(int degrees)
        {
            var beacons = Beacons.ConvertAll(p => GetNewPositionAfterRotatingOnXaxis(p, degrees));
            Beacons.Clear();
            Beacons.AddRange(beacons);
        }

        private static (int X, int Y, int Z) GetNewPositionAfterRotatingOnXaxis((int X, int Y, int Z) beacon, int degrees) =>
            degrees switch
            {
                0 => (beacon.X, beacon.Y, beacon.Z),
                90 => (beacon.X, beacon.Z, -beacon.Y),
                180 => (beacon.X, -beacon.Y, -beacon.Z),
                _ => (beacon.X, -beacon.Z, beacon.Y)
            };

        public void RotateOnYaxis(int degrees)
        {
            var beacons = Beacons.ConvertAll(p => GetNewPositionAfterRotatingOnYaxis(p, degrees));
            Beacons.Clear();
            Beacons.AddRange(beacons);
        }

        private static (int X, int Y, int Z) GetNewPositionAfterRotatingOnYaxis((int X, int Y, int Z) beacon, int degrees) =>
            degrees switch
            {
                0 => (beacon.X, beacon.Y, beacon.Z),
                90 => (-beacon.Z, beacon.Y, beacon.X),
                180 => (-beacon.X, beacon.Y, -beacon.Z),
                _ => (beacon.Z, beacon.Y, -beacon.X),
            };

        public void GenerateRotations()
        {
            foreach (var beacon in Beacons)
            {
                _rotations.Add(GenerateRotationsFor(beacon));
            }
        }

        private List<(int X, int Y, int Z)> GenerateRotationsFor((int X, int Y, int Z) beacon)
        {
            return new()
            {
                GetNewPositionAfterRotatingOnXaxis(beacon, 0),
                GetNewPositionAfterRotatingOnXaxis(beacon, 90),
                GetNewPositionAfterRotatingOnXaxis(beacon, 180),
                GetNewPositionAfterRotatingOnXaxis(beacon, 270),

                GetNewPositionAfterRotatingOnYaxis(beacon, 0),
                GetNewPositionAfterRotatingOnYaxis(beacon, 90),
                GetNewPositionAfterRotatingOnYaxis(beacon, 180),
                GetNewPositionAfterRotatingOnYaxis(beacon, 270),

                GetNewPositionAfterRotatingOnZaxis(beacon, 0),
                GetNewPositionAfterRotatingOnZaxis(beacon, 90),
                GetNewPositionAfterRotatingOnZaxis(beacon, 180),
                GetNewPositionAfterRotatingOnZaxis(beacon, 270)
            };
        }

        public void SetOriginTo((int X, int Y, int Z) origin, Func<(int X, int Y, int Z), (int X, int Y, int Z)> callback)
        {
            _origin = origin;
            var beacons = Beacons.ConvertAll(p => callback(p));
            Beacons.Clear();
            Beacons.AddRange(beacons);

            CalculateDistances();
        }

        public double CalculateDistanceBetweenBeaconsWithIndex(int firstBeacon, int secondBeacon)
        {
            var p = Beacons[firstBeacon];
            var q = Beacons[secondBeacon];
            return CalculateDistanceBetween(p, q);
        }

        private static double CalculateDistanceBetween((int X, int Y, int Z) p, (int X, int Y, int Z) q)
        {
            return Math.Sqrt(Math.Pow(p.X - q.X, 2) + Math.Pow(p.Y - q.Y, 2) + Math.Pow(p.Z - q.Z, 2));
        }

        public void CalculateDistances()
        {
            Distances.Clear();

            for (var index = 0; index < Beacons.Count - 1; index++)
            {
                for (var subIndex = index + 1; subIndex < Beacons.Count; subIndex++)
                {
                    var p = Beacons[index];
                    var q = Beacons[subIndex];
                    Distances.Add((CalculateDistanceBetween(p, q), p, q));
                }
            }
        }

        public List<(int X, int Y, int Z)> GetRotationsForBeacon(int index) => _rotations[index];
    }
}