using System;
using System.Collections.Generic;

namespace Day25.Logic
{
    public class SeaCucumberHerd
    {
        private readonly string _seafloor;
        private char[][] _map;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public SeaCucumberHerd(string seafloor)
        {
            if (string.IsNullOrWhiteSpace(seafloor))
            {
                throw new ArgumentException("Invalid seafloor");
            }

            _seafloor = seafloor;

            Parse();
        }

        private void Parse()
        {
            var lines = _seafloor.Split("\n");

            Height = lines.Length;
            _map = new char[Height][];

            for (var index = 0; index < lines.Length; index++)
            {
                _map[index] = lines[index].ToCharArray();
            }

            Width = _map[0].Length;
        }
    }
}
