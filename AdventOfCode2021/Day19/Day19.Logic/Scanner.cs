using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19.Logic
{
    public class Scanner
    {
        private readonly string _data;
        private (int X, int Y, int Z) _origin;

        public int Id { get; private set; }
        public List<(int X, int Y, int Z)> Beacons { get; }
        public List<(double Distance, (int X, int Y, int Z) From, (int X, int Y, int Z) To)> Distances { get; set; }
        public (int X, int Y, int Z) Origin => _origin;

        public Scanner(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;

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

        internal bool IsAtOrigin() => Origin == (0, 0, 0);

        public void SetOriginTo((int X, int Y, int Z) origin, Func<(int X, int Y, int Z), (int X, int Y, int Z)> callback)
        {
            _origin = origin;
            var beacons = Beacons.ConvertAll(p => callback(p));
            Beacons.Clear();
            Beacons.AddRange(beacons);

            CalculateDistances();
        }

        public void CalculateDistances()
        {
            Distances.Clear();

            for (var index = 0; index < Beacons.Count - 1; index++)
            {
                for (var subIndex = index + 1; subIndex < Beacons.Count; subIndex++)
                {
                    var from = Beacons[index];
                    var to = Beacons[subIndex];
                    Distances.Add((new EuclideanDistance(from, to).Distance, from, to));
                }
            }
        }

/*
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
*/
    }
}