using System;
using System.Collections.Generic;

namespace Day20.Logic
{
    public class ImageEnhancement
    {
        private readonly string _input;
        private readonly List<string> _image;

        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }
        public string Algorithm { get; private set; }

        public ImageEnhancement(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
            _image = new List<string>();

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");
            Algorithm = lines[0];

            _image.AddRange(lines[2..]);

            ImageWidth = _image[0].Length;
            ImageHeight = _image.Count;
        }
    }
}