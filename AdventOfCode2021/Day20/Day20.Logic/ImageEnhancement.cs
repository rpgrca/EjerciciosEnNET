using System;
using System.Linq;
using System.Collections.Generic;

namespace Day20.Logic
{
    public class ImageEnhancement
    {
        private readonly string _input;
        private readonly List<char[]> _image;
        private char _infinitePixel;

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
            _infinitePixel = '.';

            Parse();
        }

        private void Parse()
        {
            var lines = _input.Split("\n");
            Algorithm = lines[0];

            for (var index = 0; index < 60; index++)
            {
                _image.Add(new string('.', lines[2].Length + 120).ToCharArray());
            }

            foreach (var line in lines[2..])
            {
                _image.Add((new string('.', 60) + line + new string('.', 60)).ToCharArray());
            }

            for (var index = 0; index < 60; index++)
            {
                _image.Add(new string('.', lines[0].Length + 120).ToCharArray());
            }

            ImageWidth = _image[0].Length;
            ImageHeight = _image.Count;
        }

        public void Enhance(int levels)
        {
            for (var level = 0; level < levels; level++)
            {
                var enhancedImage = CreateImage();

                /*for (var index = 0; index < ImageHeight + 10; index ++)
                {
                    enhancedImage.Add(new string('.', ImageWidth + 10).ToCharArray());
                }*/

                for (var y = 0; y < ImageHeight; y++)
                {
                    for (var x = 0; x < ImageWidth; x++)
                    {
                        var index = GetSurroundingPixelsFromlImage(x, y);
                        enhancedImage[y][x] = EnhancePixel(index);
                    }
                }

                _infinitePixel = EnhancePixel(GetSurroundingPixelsFromlImage(2, 2));

                _image.Clear();
                _image.AddRange(enhancedImage);

                for (var x = 0; x < ImageWidth; x++)
                {
                    _image[0][x] = _infinitePixel;
                }

                for (var y = 0; y < ImageHeight; y++)
                {
                    _image[y][0] = _image[y][ImageWidth - 1] = _infinitePixel;
                }

                for (var x = 0; x < ImageWidth; x++)
                {
                    _image[ImageHeight - 1][x] = _infinitePixel;
                }
            }
        }

        private List<char[]> CreateImage()
        {
            var image = new List<char[]>();
            for (var y = 0; y < ImageHeight; y++)
            {
                image.Add(new string(' ', ImageWidth).ToCharArray());
            }

            return image;
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
                    enhancedPixel += _infinitePixel == '.' ? "0" : "1";
                }
            }

            return Convert.ToInt32(enhancedPixel, 2);
        }

        private static (int, int) ConvertToOldImageCoordinates(int x, int y) => (y, x);

        private char EnhancePixel(int index) => Algorithm[index];

        public string GetOutputImage() => string.Join('\n', _image.Select(p => new string(p)));

        public int CountLitPixels()
        {
            return _image.Sum(p => p.Count(q => q == '#'));
        }
    }
}