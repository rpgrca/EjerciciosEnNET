using System;
using System.Linq;
using System.Collections.Generic;

namespace Day20.Logic
{
    public class ImageEnhancement
    {
        private readonly string _input;
        private readonly List<char[]> _image;

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
            _image = new List<char[]>();

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");
            Algorithm = lines[0];

            foreach (var line in lines[2..])
            {
                _image.Add(line.ToCharArray());
            }

            ImageWidth = _image[0].Length;
            ImageHeight = _image.Count;
        }

        public void Enhance(int levels)
        {
            var enhancedImage = new List<char[]>();

            for (var level = 0; level < levels; level++)
            {
                enhancedImage.Clear();

                for (var index = 0; index < ImageHeight + 2; index ++)
                {
                    enhancedImage.Add(new string('.', ImageWidth + 2).ToCharArray());
                }

                for (var y = 0; y < ImageHeight + 2; y++)
                {
                    for (var x = 0; x < ImageWidth + 2; x++)
                    {
                        var index = GetSurroundingPixelsFromlImage(x, y);
                        enhancedImage[y][x] = EnhancePixel(index);
                    }
                }

                _image.Clear();
                _image.AddRange(enhancedImage);
                ImageHeight += 2;
                ImageWidth += 2;
            }
        }

        /*
                 .....
         ...  →  .....
         .#.     ..#..
         ###     .###.
                 .....
        */

        private int GetSurroundingPixelsFromlImage(int x, int y)
        {
            var enhancedPixel = string.Empty;

            foreach (var pixel in new[] { (y-1, x-1), (y-1, x), (y-1, x+1), (y, x-1), (y, x), (y, x+1), (y+1, x-1), (y+1, x), (y+1, x+1) })
            {
                var (oldX, oldY) = ConvertToOldImageCoordinates(pixel.Item1, pixel.Item2);
                if (oldX >= 0 && oldX < ImageWidth && oldY >= 0 && oldY < ImageHeight)
                {
                    enhancedPixel += _image[oldY][oldX] == '.' ? "0" : "1";
                }
                else
                {
                    enhancedPixel += "0";
                }
            }

            return Convert.ToInt32(enhancedPixel, 2);
        }

        private static (int, int) ConvertToOldImageCoordinates(int x, int y) => (y - 1, x - 1);

        private char EnhancePixel(int index) => Algorithm[index];

        public string GetOutputImage() => string.Join('\n', _image.Select(p => new string(p)));
    }
}