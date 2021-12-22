using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22.Logic
{
    public class ReactorCore
    {
        private readonly string _steps;
        private readonly Dictionary<(int X, int Y, int Z), int> _turnedOn;

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
                        if (_turnedOn.ContainsKey((x, y, z)))
                        {
                            System.Diagnostics.Debugger.Break();
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
        private readonly string _steps;
        private readonly Dictionary<int, (int MinimumX, int MinimumY, int MaximumX, int MaximumY)> _turnedOn;

        public ReactorCore2(string steps)
        {
            if (string.IsNullOrWhiteSpace(steps))
            {
                throw new ArgumentException("Invalid steps");
            }

            _steps = steps;
            _turnedOn = new Dictionary<int, (int MinimumX, int MinimumY, int MaximumX, int MaximumY)>();

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

            if (minimumX < -50 || minimumX > 50 || maximumX < -50 || maximumX > 50)
            {
                return;
            }

            var minimumY = int.Parse(axis[1][0]);
            var maximumY = int.Parse(axis[1][1]);

            for (var z = int.Parse(axis[2][0]); z <= int.Parse(axis[2][1]); z++)
            {
                if (! _turnedOn.ContainsKey(z))
                {
                    _turnedOn.Add(z, (minimumX, minimumY, maximumX, maximumY));
                }
                else
                {

                }
            }

            for (var x = minimumX; x <= maximumX; x++)
            {
                for (var y = int.Parse(axis[1][0]); y <= int.Parse(axis[1][1]); y++)
                {
                    for (var z = int.Parse(axis[2][0]); z <= int.Parse(axis[2][1]); z++)
                    {
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
                    }
                }
            }
        }

        public int GetTurnedOnCubesCount() => _turnedOn.Count;
    }

}