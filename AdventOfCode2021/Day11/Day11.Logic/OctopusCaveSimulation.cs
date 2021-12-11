using System;
using System.Collections.Generic;

namespace Day11.Logic
{
    public class OctopusCaveSimulation
    {
        private readonly string _input;
        private readonly int[,] _map;

        public OctopusCaveSimulation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
            _map = new int[10,10];

            Parse();
        }

        private void Parse()
        {
            var y = 0;
            foreach (var line in _input.Split("\n"))
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
    }
}
