using System;
using System.Collections.Generic;

namespace Day11.Logic
{
    public class OctopusCaveSimulation
    {
        private readonly string _input;
        private int[,] _map;
        private int _width;
        private int _height;

        public int FlashCount { get; private set; }

        public OctopusCaveSimulation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");

            _height = lines.Length;
            _width = lines[0].Length;
            _map = new int[_height, _width];

            var y = 0;
            foreach (var line in lines)
            {
                var x = 0;
                foreach (var octopus in line)
                {
                    _map[y, x++] = octopus - '0';
                }

                y++;
            }
        }

        public int GetOctopusEnergyLevelAt(int x, int y)
        {
            return _map[y,x];
        }

        public void Step(int steps)
        {
            while (steps-- > 0)
            {
                for (var y = 0; y < _height; y++)
                {
                    for (var x = 0; x < _width; x++)
                    {
                        _map[y,x]++;
                    }
                }

                for (var y = 0; y < _height; y++)
                {
                    for (var x = 0; x < _width; x++)
                    {
                        TryFlash(x, y);
                    }
                }

                for (var y = 0; y < _height; y++)
                {
                    for (var x = 0; x < _width; x++)
                    {
                        if (_map[y,x] == -1)
                        {
                            _map[y,x] = 0;
                        }
                    }
                }
            }
        }

        private void TryFlash(int x, int y)
        {
            if (_map[y, x] > 9)
            {
                _map[y, x] = -1;
                FlashCount++;

                if (x > 0)
                {
                    if (_map[y, x - 1] != -1)
                    {
                        _map[y, x - 1]++;
                        TryFlash(x - 1, y);
                    }

                    if (y > 0)
                    {
                        if (_map[y - 1, x - 1] != -1)
                        {
                            _map[y - 1, x - 1]++;
                            TryFlash(x - 1, y - 1);
                        }
                    }

                    if (y < _height - 1)
                    {
                        if (_map[y + 1, x - 1] != -1)
                        {
                            _map[y + 1, x - 1]++;
                            TryFlash(x - 1, y + 1);
                        }
                    }
                }

                if (x < _width - 1)
                {
                    if (_map[y, x + 1] != -1)
                    {
                        _map[y, x + 1]++;
                        TryFlash(x + 1, y);
                    }

                    if (y > 0)
                    {
                        if (_map[y - 1, x + 1] != -1)
                        {
                            _map[y - 1, x + 1]++;
                            TryFlash(x + 1, y - 1);
                        }
                    }

                    if (y < _height - 1)
                    {
                        if (_map[y + 1, x + 1] != -1)
                        {
                            _map[y + 1, x + 1]++;
                            TryFlash(x + 1, y + 1);
                        }
                    }
                }

                if (y > 0)
                {
                    if (_map[y - 1, x] != -1)
                    {
                        _map[y - 1, x]++;
                        TryFlash(x, y - 1);
                    }
                }

                if (y < _height - 1)
                {
                    if (_map[y + 1, x] != -1)
                    {
                        _map[y + 1, x]++;
                        TryFlash(x, y + 1);
                    }
                }
            }
        }

        public string GetMap()
        {
            var map = string.Empty;
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    map += _map[y,x];
                }

                map += "\n";
            }

            return map.Trim();
        }
    }
}
