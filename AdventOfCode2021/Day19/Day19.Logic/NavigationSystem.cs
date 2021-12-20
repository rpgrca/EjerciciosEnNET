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
            for (var index = 0; index < Scanners.Count - 1; index++)
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

                    var found = dictionary.Single(p => p.Value > 1);

                    if (found.Value >= 11)
                    {
                        result.Add((match.Item1.From, found.Key));
                        list.Add(match.Item1.From);
                    }
                }
            }

            if (result.Count >= 11)
            {
                GuessOriginFrom(result);
            }
        }

        private void GuessOriginFrom(List<((int X, int Y, int Z) Main, (int X, int Y, int Z) Other)> beacons)
        {
            foreach (var rotation in new List<(Func<(int X, int Y, int Z), (int X, int Y, int Z)>, Func<(int X, int Y, int Z), (int X, int Y, int Z)>)>()
            {
                (p => ( p.X,  p.Y,  p.Z), p => (-p.X, -p.Y, -p.Z)),
                (p => ( p.X,  p.Y, -p.Z), p => (-p.X, -p.Y,  p.Z)),
                (p => ( p.X, -p.Y,  p.Z), p => (-p.X,  p.Y, -p.Z)),
                (p => (-p.X,  p.Y,  p.Z), p => ( p.X, -p.Y, -p.Z)),
                (p => ( p.X, -p.Y, -p.Z), p => (-p.X,  p.Y,  p.Z)),
                (p => (-p.X,  p.Y, -p.Z), p => ( p.X, -p.Y,  p.Z)),
                (p => (-p.X, -p.Y,  p.Z), p => ( p.X,  p.Y, -p.Z)),
                (p => (-p.X, -p.Y, -p.Z), p => ( p.X,  p.Y,  p.Z)),
                                               
                (p => ( p.X,  p.Z,  p.Y), p => (-p.X, -p.Z, -p.Y)),
                (p => ( p.X,  p.Z, -p.Y), p => (-p.X, -p.Z,  p.Y)),
                (p => ( p.X, -p.Z,  p.Y), p => (-p.X,  p.Z, -p.Y)),
                (p => (-p.X,  p.Z,  p.Y), p => ( p.X, -p.Z, -p.Y)),
                (p => ( p.X, -p.Z, -p.Y), p => (-p.X,  p.Z,  p.Y)),
                (p => (-p.X,  p.Z, -p.Y), p => ( p.X, -p.Z,  p.Y)),
                (p => (-p.X, -p.Z,  p.Y), p => ( p.X,  p.Z, -p.Y)),
                (p => (-p.X, -p.Z, -p.Y), p => ( p.X,  p.Z,  p.Y)),
                                               
                (p => ( p.Z,  p.X,  p.Y), p => (-p.Z, -p.X, -p.Y)),
                (p => ( p.Z,  p.X, -p.Y), p => (-p.Z, -p.X,  p.Y)),
                (p => ( p.Z, -p.X,  p.Y), p => (-p.Z,  p.X, -p.Y)),
                (p => (-p.Z,  p.X,  p.Y), p => ( p.Z, -p.X, -p.Y)),
                (p => ( p.Z, -p.X, -p.Y), p => (-p.Z,  p.X,  p.Y)),
                (p => (-p.Z,  p.X, -p.Y), p => ( p.Z, -p.X,  p.Y)),
                (p => (-p.Z, -p.X,  p.Y), p => ( p.Z,  p.X, -p.Y)),
                (p => (-p.Z, -p.X, -p.Y), p => ( p.Z,  p.X,  p.Y)),
                                               
                (p => ( p.Y,  p.X,  p.Z), p => (-p.Y, -p.X, -p.Z)),
                (p => ( p.Y,  p.X, -p.Z), p => (-p.Y, -p.X,  p.Z)),
                (p => ( p.Y, -p.X,  p.Z), p => (-p.Y,  p.X, -p.Z)),
                (p => (-p.Y,  p.X,  p.Z), p => ( p.Y, -p.X, -p.Z)),
                (p => ( p.Y, -p.X, -p.Z), p => (-p.Y,  p.X,  p.Z)),
                (p => (-p.Y,  p.X, -p.Z), p => ( p.Y, -p.X,  p.Z)),
                (p => (-p.Y, -p.X,  p.Z), p => ( p.Y,  p.X, -p.Z)),
                (p => (-p.Y, -p.X, -p.Z), p => ( p.Y,  p.X,  p.Z)),
                                               
                (p => ( p.Y,  p.Z,  p.X), p => (-p.Y, -p.Z, -p.X)),
                (p => ( p.Y,  p.Z, -p.X), p => (-p.Y, -p.Z,  p.X)),
                (p => ( p.Y, -p.Z,  p.X), p => (-p.Y,  p.Z, -p.X)),
                (p => (-p.Y,  p.Z,  p.X), p => ( p.Y, -p.Z, -p.X)),
                (p => ( p.Y, -p.Z, -p.X), p => (-p.Y,  p.Z,  p.X)),
                (p => (-p.Y,  p.Z, -p.X), p => ( p.Y, -p.Z,  p.X)),
                (p => (-p.Y, -p.Z,  p.X), p => ( p.Y,  p.Z, -p.X)),
                (p => (-p.Y, -p.Z, -p.X), p => ( p.Y,  p.Z,  p.X)),
                                               
                (p => ( p.Z,  p.Y,  p.X), p => (-p.Z, -p.Y, -p.X)),
                (p => ( p.Z,  p.Y, -p.X), p => (-p.Z, -p.Y,  p.X)),
                (p => ( p.Z, -p.Y,  p.X), p => (-p.Z,  p.Y, -p.X)),
                (p => (-p.Z,  p.Y,  p.X), p => ( p.Z, -p.Y, -p.X)),
                (p => ( p.Z, -p.Y, -p.X), p => (-p.Z,  p.Y,  p.X)),
                (p => (-p.Z,  p.Y, -p.X), p => ( p.Z, -p.Y,  p.X)),
                (p => (-p.Z, -p.Y,  p.X), p => ( p.Z,  p.Y, -p.X)),
                (p => (-p.Z, -p.Y, -p.X), p => ( p.Z,  p.Y,  p.X)),

/*
                p => GetNewPositionAfterRotatingOnXaxis(p, 90),
                p => GetNewPositionAfterRotatingOnXaxis(p, 180),
                p => GetNewPositionAfterRotatingOnXaxis(p, 270),

                p => GetNewPositionAfterRotatingOnYaxis(p, 90),
                p => GetNewPositionAfterRotatingOnYaxis(p, 180),
                p => GetNewPositionAfterRotatingOnYaxis(p, 270),

                p => GetNewPositionAfterRotatingOnZaxis(p, 90),
                p => GetNewPositionAfterRotatingOnZaxis(p, 180),
                p => GetNewPositionAfterRotatingOnZaxis(p, 270),

                p => GetNewPositionAfterRotatingOnXaxis(p, 90),
                p => GetNewPositionAfterRotatingOnXaxis(p, 180),
                p => GetNewPositionAfterRotatingOnXaxis(p, 270),

                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 90), 90),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 90), 180),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 90), 270),

                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 90), 90),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 90), 180),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 90), 270),

                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 180), 90),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 180), 180),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 180), 270),

                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 180), 90),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 180), 180),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 180), 270),

                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 270), 90),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 270), 180),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnZaxis(p, 270), 270),

                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 270), 90),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 270), 180),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnZaxis(p, 270), 270),

                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 90), 90),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 90), 180),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 90), 270),

                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 90), 90),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 90), 180),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 90), 270),

                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 180), 90),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 180), 180),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 180), 270),

                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 180), 90),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 180), 180),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 180), 270),

                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 270), 90),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 270), 180),
                p => GetNewPositionAfterRotatingOnXaxis(GetNewPositionAfterRotatingOnYaxis(p, 270), 270),

                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 270), 90),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 270), 180),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnYaxis(p, 270), 270),

                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 90), 90),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 90), 180),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 90), 270),

                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 90), 90),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 90), 180),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 90), 270),

                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 180), 90),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 180), 180),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 180), 270),

                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 180), 90),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 180), 180),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 180), 270),

                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 270), 90),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 270), 180),
                p => GetNewPositionAfterRotatingOnYaxis(GetNewPositionAfterRotatingOnXaxis(p, 270), 270),

                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 270), 90),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 270), 180),
                p => GetNewPositionAfterRotatingOnZaxis(GetNewPositionAfterRotatingOnXaxis(p, 270), 270),*/

            })
            {
                var origins = beacons.GroupBy(p => Offset(p.Main, rotation.Item1(p.Other))).Distinct().ToList();
                if (origins.Count == 1)
                {
                    Scanners[ScannerPositions.Count].SetOriginTo(origins[0].Key, x => Offset(origins[0].Key, rotation.Item2(x)));
                    ScannerPositions.Add(origins[0].Key);
                    return;
                }
            }

            throw new ArgumentException("Missing transformation");
        }

        private (int X, int Y, int Z) Offset((int X, int Y, int Z) main, (int X, int Y, int Z) other)
        {
            return (main.X + other.X, main.Y + other.Y, main.Z + other.Z);
        }

        private static (int X, int Y, int Z) GetNewPositionAfterRotatingOnXaxis((int X, int Y, int Z) beacon, int degrees) =>
            degrees switch
            {
                0 => (beacon.X, beacon.Y, beacon.Z),
                90 => (beacon.X, beacon.Z, -beacon.Y),
                180 => (beacon.X, -beacon.Y, -beacon.Z),
                _ => (beacon.X, -beacon.Z, beacon.Y)
            };

        private static (int X, int Y, int Z) GetNewPositionAfterRotatingOnYaxis((int X, int Y, int Z) beacon, int degrees) =>
            degrees switch
            {
                0 => (beacon.X, beacon.Y, beacon.Z),
                90 => (-beacon.Z, beacon.Y, beacon.X),
                180 => (-beacon.X, beacon.Y, -beacon.Z),
                _ => (beacon.Z, beacon.Y, -beacon.X),
            };

        private static (int X, int Y, int Z) GetNewPositionAfterRotatingOnZaxis((int X, int Y, int Z) beacon, int degrees) =>
            degrees switch
            {
                0 => (beacon.X, beacon.Y, beacon.Z),
                90 => (beacon.Y, -beacon.X, beacon.Z),
                180 => (-beacon.X, -beacon.Y, beacon.Z),
                _ => (-beacon.Y, beacon.X, beacon.Z)
            };


    }
}