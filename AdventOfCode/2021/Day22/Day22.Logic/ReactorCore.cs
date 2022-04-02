using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22.Logic
{
    public class ReactorCore
    {
        private readonly string _steps;
        private readonly Dictionary<(int X, int Y, int Z), int> _turnedOn;

        public bool HasOverlaps { get; private set; }

        public ReactorCore(string steps)
        {
            if (string.IsNullOrWhiteSpace(steps))
            {
                throw new ArgumentException("Invalid steps");
            }

            _steps = steps;
            _turnedOn = new Dictionary<(int X, int Y, int Z), int>();

            Parse();
        }

        private void Parse()
        {
            foreach (var line in _steps.Split("\n"))
            {
                var location = line.Split(" ");

                if (location[0] == "on")
                {
                    TurnOn(location[1]);
                }
                else
                {
                    TurnOff(location[1]);
                }
            }
        }

        private void TurnOn(string area)
        {
            var axis = area.Split(",").Select(p => p.Split("=")).Select(p => p[1]).Select(p => p.Split("..")).ToArray();

            var minimumX = int.Parse(axis[0][0]);
            var maximumX = int.Parse(axis[0][1]);

            for (var x = minimumX; x <= maximumX; x++)
            {
                for (var y = int.Parse(axis[1][0]); y <= int.Parse(axis[1][1]); y++)
                {
                    for (var z = int.Parse(axis[2][0]); z <= int.Parse(axis[2][1]); z++)
                    {
                        if (_turnedOn.ContainsKey((x, y, z)))
                        {
                            HasOverlaps = true;
                        }
                        _turnedOn.TryAdd((x, y, z), 0);
                        _turnedOn[(x, y, z)]++;
                    }
                }
            }
        }

        private void TurnOff(string area)
        {
            var axis = area.Split(",").Select(p => p.Split("=")).Select(p => p[1]).Select(p => p.Split("..")).ToArray();

            var minimumX = int.Parse(axis[0][0]);
            var maximumX = int.Parse(axis[0][1]);

            if (minimumX < -50 || minimumX > 50 || maximumX < -50 || maximumX > 50)
            {
                return;
            }

            for (var x = minimumX; x <= maximumX; x++)
            {
                for (var y = int.Parse(axis[1][0]); y <= int.Parse(axis[1][1]); y++)
                {
                    for (var z = int.Parse(axis[2][0]); z <= int.Parse(axis[2][1]); z++)
                    {
                        _turnedOn.Remove((x, y, z));
                    }
                }
            }
        }

        public int GetTurnedOnCubesCount() => _turnedOn.Count;
    }

    public class ReactorCore2
    {
        private string _steps;
        private readonly List<string> _cubes;

        public ReactorCore2(string steps)
        {
            if (string.IsNullOrWhiteSpace(steps))
            {
                throw new ArgumentException("Invalid steps");
            }

            _steps = steps;
            _cubes = new List<string>();

            Parse();
        }

        private void Parse()
        {
            var newLine = string.Empty;
            var mustContinue = true;

            while (mustContinue)
            {
                var lines = _steps.Split("\n");
                newLine = string.Empty;

                for (var index = 0; index < lines.Length - 1; index += 2)
                {
                    var location = lines[index].Split(" ");

                    if (location[0] == "on")
                    {
                        var location2 = lines[index + 1].Split(" ");
                        if (location2[0] == "on")
                        {
                            var axis = location[1].Split(",").Select(p => p.Split("=")).Select(p => p[1]).Select(p => p.Split("..")).ToArray();
                            var axis2 = location2[1].Split(",").Select(p => p.Split("=")).Select(p => p[1]).Select(p => p.Split("..")).ToArray();

                            var first = (int.Parse(axis[0][0]), int.Parse(axis[0][1]), int.Parse(axis[1][0]), int.Parse(axis[1][1]), int.Parse(axis[2][0]), int.Parse(axis[2][1]));
                            var second = (int.Parse(axis2[0][0]), int.Parse(axis2[0][1]), int.Parse(axis2[1][0]), int.Parse(axis2[1][1]), int.Parse(axis2[2][0]), int.Parse(axis2[2][1]));
                            var cubeSplitter = new CubeSplitter(first, second);
                            var result = cubeSplitter.ToString();
                            newLine += result.Trim() + "\n";
                        }
                        else
                        {
                            // off
                            newLine += lines[index] + "\n" + lines[index + 1] + "\n";
                        }
                    }
                    else
                    {
                        // off
                        newLine += lines[index] + "\n";
                    }
                }

                mustContinue = _steps.Trim() != newLine.Trim();
                _steps = newLine.Trim();
            }

            _cubes.AddRange(_steps.Split("\n"));
        }

        public long GetTurnedOnCubesCount()
        {
            long count = 0;

            foreach (var cube in _cubes)
            {
                var location = cube.Split(" ");
                var axis = location[1].Split(",").Select(p => p.Split("=")).Select(p => p[1]).Select(p => p.Split("..")).ToArray();

                count += (int.Parse(axis[0][1]) - int.Parse(axis[0][0])) * (int.Parse(axis[1][1]) - int.Parse(axis[1][0])) * (int.Parse(axis[2][1]) - int.Parse(axis[2][0]));
            }

            return count;
        }
    }

    public class ReactorCore3
    {
        private readonly string _steps;
        private bool[][][] _reactor;
        private readonly Dictionary<long, int> _xIndexer;
        private readonly Dictionary<long, int> _yIndexer;
        private readonly Dictionary<long, int> _zIndexer;
        private long[] _xIndexerReverse;
        private long[] _yIndexerReverse;
        private long[] _zIndexerReverse;

        public ReactorCore3(string steps)
        {
            if (string.IsNullOrWhiteSpace(steps))
            {
                throw new ArgumentException("Invalid steps");
            }

            _steps = steps;
            _xIndexer = new Dictionary<long, int>();
            _yIndexer = new Dictionary<long, int>();
            _zIndexer = new Dictionary<long, int>();

            Parse();
        }

        private void Parse()
        {
            var xValues = _steps.Split("\n")
                .Select(p => p.Split(" "))
                .Select(p => p[1].Split(","))
                .Select(p => p[0].Split("="))
                .SelectMany(p => p[1].Split(".."))
                .Select(p => int.Parse(p))
                .OrderBy(p => p)
                .Distinct()
                .Select((p, i) => new { Index = i, Value = p });
            var index = 0;

            _xIndexerReverse = new long[xValues.Count() * 3];
            foreach (var value in xValues)
            {
                if (! _xIndexer.ContainsKey(value.Value - 1))
                {
                    _xIndexer.Add(value.Value - 1, index);
                    _xIndexerReverse[index++] = value.Value - 1;
                }

                if (! _xIndexer.ContainsKey(value.Value))
                {
                    _xIndexer.Add(value.Value, index);
                    _xIndexerReverse[index++] = value.Value;
                }

                if (! _xIndexer.ContainsKey(value.Value + 1))
                {
                    _xIndexer.Add(value.Value + 1, index);
                    _xIndexerReverse[index++] = value.Value + 1;
                }
            }

            index = 0;
            var yValues = _steps.Split("\n")
                .Select(p => p.Split(" "))
                .Select(p => p[1].Split(","))
                .Select(p => p[1].Split("="))
                .SelectMany(p => p[1].Split(".."))
                .Select(p => int.Parse(p))
                .OrderBy(p => p)
                .Distinct()
                .Select((p, i) => new { Index = i, Value = p });

            _yIndexerReverse = new long[yValues.Count() * 3];
            foreach (var value in yValues)
            {
                if (! _yIndexer.ContainsKey(value.Value - 1))
                {
                    _yIndexer.Add(value.Value - 1, index);
                    _yIndexerReverse[index++] = value.Value - 1;
                }

                if (! _yIndexer.ContainsKey(value.Value))
                {
                    _yIndexer.Add(value.Value, index);
                    _yIndexerReverse[index++] = value.Value;
                }

                if (! _yIndexer.ContainsKey(value.Value + 1))
                {
                    _yIndexer.Add(value.Value + 1, index);
                    _yIndexerReverse[index++] = value.Value + 1;
                }
            }

            index = 0;
            var zValues = _steps.Split("\n")
                .Select(p => p.Split(" "))
                .Select(p => p[1].Split(","))
                .Select(p => p[2].Split("="))
                .SelectMany(p => p[1].Split(".."))
                .Select(p => int.Parse(p))
                .OrderBy(p => p)
                .Distinct()
                .Select((p, i) => new { Index = i, Value = p });

            _zIndexerReverse = new long[zValues.Count() * 3];
            foreach (var value in zValues)
            {
                if (! _zIndexer.ContainsKey(value.Value - 1))
                {
                    _zIndexer.Add(value.Value - 1, index);
                    _zIndexerReverse[index++] = value.Value - 1;
                }

                if (! _zIndexer.ContainsKey(value.Value))
                {
                    _zIndexer.Add(value.Value, index);
                    _zIndexerReverse[index++] = value.Value;
                }

                if (! _zIndexer.ContainsKey(value.Value + 1))
                {
                    _zIndexer.Add(value.Value + 1, index);
                    _zIndexerReverse[index++] = value.Value + 1;
                }
            }

            _reactor = new bool[_xIndexer.Count][][];
            for (var x = 0; x < _xIndexer.Count; x++)
            {
                _reactor[x] = new bool[_yIndexer.Count][];

                for (var y = 0; y < _yIndexer.Count; y++)
                {
                    _reactor[x][y] = new bool[_zIndexer.Count];
                }
            }

            foreach (var line in _steps.Split("\n"))
            {
                var location = line.Split(" ");

                var axis = location[1].Split(",").Select(p => p.Split("=")).Select(p => p[1]).Select(p => p.Split("..")).ToArray();
                var minimumX = long.Parse(axis[0][0]);
                var maximumX = long.Parse(axis[0][1]);
                var minimumY = long.Parse(axis[1][0]);
                var maximumY = long.Parse(axis[1][1]);
                var minimumZ = long.Parse(axis[2][0]);
                var maximumZ = long.Parse(axis[2][1]);

                for (var x = _xIndexer[minimumX]; x <= _xIndexer[maximumX]; x++)
                {
                    for (var y = _yIndexer[minimumY]; y <= _yIndexer[maximumY]; y++)
                    {
                        int z;
                        for (z = _zIndexer[minimumZ]; z <= _zIndexer[maximumZ]; z++)
                        {
                            _reactor[x][y][z] = location[0] == "on";
                        }
                    }
                }
            }
        }

        public long GetTurnedOnCubesCount()
        {
            var total = 0L;
            var started = false;
            var minimumZ = 0;
            var maximumZ = 0;

            for (var x = 0; x < _reactor.Length; x++)
            {
                for (var y = 0; y < _reactor[x].Length; y++)
                {
                    var z = 0;

                    while (z < _reactor[x][y].Length)
                    {
                        if (_reactor[x][y][z])
                        {
                            if (!started)
                            {
                                started = true;
                                minimumZ = z;
                            }
                            else
                            {
                                maximumZ = z;
                            }
                        }
                        else
                        {
                            if (started)
                            {
                                total +=
                                    (_xIndexerReverse[x + 1] - _xIndexerReverse[x]) *
                                    (_yIndexerReverse[y + 1] - _yIndexerReverse[y]) *
                                    (_zIndexerReverse[maximumZ + 1] - _zIndexerReverse[minimumZ]);

                                minimumZ = maximumZ = 0;
                                started = false;
                            }
                        }

                        z++;
                    }
/*
                    for (var z = 0; z < _reactor[x][y].Count; z++)
                    {
                        var value = _reactor[x][y][z];

                        if (value)
                        {

                            var cubes =
                                (_xIndexer.ElementAt(x + 1).Key - _xIndexer.ElementAt(x).Key) *
                                (_yIndexer.ElementAt(y + 1).Key - _yIndexer.ElementAt(y).Key) *
                                (_zIndexer.ElementAt(z + 1).Key - _zIndexer.ElementAt(z).Key);

                            total += cubes;
                        }
                    }*/
                }
            }

            return total;
        }
    }
}