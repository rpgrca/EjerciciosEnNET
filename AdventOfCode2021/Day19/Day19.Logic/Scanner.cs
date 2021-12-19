using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19.Logic
{
    public class Scanner
    {
        private readonly string _data;

        public int Id { get; private set; }
        public List<(int X, int Y, int Z)> Beacons { get; }

        public Scanner(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            Beacons = new List<(int X, int Y, int Z)>();

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
            switch (degrees)
            {
                case 90:
                    break;

                case 180:
                    var beacons = Beacons.Select(p => (-p.X, -p.Y, p.Z)).ToList();
                    Beacons.Clear();
                    Beacons.AddRange(beacons);
                    break;

                case 270:
                    break;
            }
        }

        public void RotateOnXaxis(int degrees)
        {
            List<(int X, int Y, int Z)> beacons;
            switch (degrees)
            {
                case 90:
                    beacons = Beacons.Select(p => (p.X, p.Z, -p.Y)).ToList();
                    Beacons.Clear();
                    Beacons.AddRange(beacons);
                    break;

                case 270:
                    beacons = Beacons.Select(p => (p.X, -p.Z, p.Y)).ToList();
                    Beacons.Clear();
                    Beacons.AddRange(beacons);
                    break;

            }
        }

        public void RotateOnYaxis(int degrees)
        {
            List<(int X, int Y, int Z)> beacons;

            switch (degrees)
            {
                case 90:
                    beacons = Beacons.Select(p => (-p.Z, p.Y, p.X)).ToList();
                    Beacons.Clear();
                    Beacons.AddRange(beacons);
                    break;
            }
        }
    }
}
