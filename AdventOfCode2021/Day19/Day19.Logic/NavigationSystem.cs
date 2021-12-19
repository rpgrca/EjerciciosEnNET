using System.Security.Cryptography;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Day19.Logic
{
    public class NavigationSystem
    {
        private readonly string _data;

        public List<Scanner> Scanners { get; set; }
        public List<(int X, int Y, int Z)> ScannerPositions { get; }

        public NavigationSystem(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            Scanners = new List<Scanner>();
            ScannerPositions = new List<(int X, int Y, int Z)>
            {
                (0, 0, 0)
            };

            Parse();
        }

        private void Parse()
        {
            var scannerData = string.Empty;

            foreach (var line in _data.Split("\n"))
            {
                if (! string.IsNullOrEmpty(line))
                {
                    scannerData += line + "\n";
                }
                else
                {
                    Scanners.Add(new Scanner(scannerData.Trim()));
                    scannerData = string.Empty;
                }
            }

            Scanners.Add(new Scanner(scannerData.Trim()));
        }

        public void CalculateDistances()
        {
            foreach (var scanner in Scanners)
            {
                scanner.CalculateDistances();
            }
        }

        public void FindPossibleIntersectingBeacons()
        {
            // Check only against Scanner 0
            for (var index = 0; index < 1; index++)
            {
                for (var subIndex = index + 1; subIndex < Scanners.Count; subIndex++)
                {
                    var possibleHits = Scanners[index].Distances
                        .GroupJoin(Scanners[subIndex].Distances, p => p.Distance, q => q.Distance, (p, q) => new { From = p, To = q })
                        .Where(p => p.To.Any())
                        .Select(p => ((p.From.From, p.From.To), (p.To.Single().From, p.To.Single().To)))
                        .ToList();

                    LocateScannerInFirstScannerScope(possibleHits);
                }
            }
        }

        private void LocateScannerInFirstScannerScope(List<(((int X, int Y, int Z) From, (int X, int Y, int Z) To), ((int X, int Y, int Z) From, (int X, int Y, int Z) To))> matches)
        {
            var list = new List<(int X, int Y, int Z)>();
            var result = new List<((int X, int Y, int Z) Main, (int X, int Y, int Z) Other)>();

            foreach (var match in matches)
            {
                if (! list.Contains(match.Item1.From))
                {
                    var dictionary = new Dictionary<(int X, int Y, int Z), int>();

                    foreach (var subMatch in matches.Where(p => p.Item1.From == match.Item1.From || p.Item1.To == match.Item1.From).Select(p => p))
                    {
                        dictionary.TryAdd(subMatch.Item2.From, 0);
                        dictionary[subMatch.Item2.From]++;

                        dictionary.TryAdd(subMatch.Item2.To, 0);
                        dictionary[subMatch.Item2.To]++;
                    }

                    var found = dictionary.Single(p => p.Value > 1).Key;

                    result.Add((match.Item1.From, found));
                    list.Add(match.Item1.From);
                }
            }

            GuessOriginFrom(result);
        }

        private void GuessOriginFrom(List<((int X, int Y, int Z) Main, (int X, int Y, int Z) Other)> beacons)
        {
            var origins = beacons.GroupBy(p => (p.Main.X + p.Other.X, p.Main.Y - p.Other.Y, p.Main.Z + p.Other.Z)).Distinct().ToList();
            if (origins.Count == 1)
            {
                ScannerPositions.Add(origins[0].Key);
            }
            else
                throw new ArgumentException("Missing transformation");
        }
    }
}