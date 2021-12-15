using System;
using System.Linq;

namespace Day15.Logic
{
    public class CaveMap
    {
        private readonly string _input;
        private int[][] _map;

        public int Width { get; set; }

        public CaveMap(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid map");
            }

            _input = input;

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");
            var index = 0;

            _map = new int[lines.Length][];
            foreach (var line in lines)
            {
                _map[index++] = line.Select(p => p - '0').ToArray();
            }

            Width = _map.Length;
        }
    }
}
