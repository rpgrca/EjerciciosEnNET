using System;
using System.Linq;
using System.Collections.Generic;

namespace Day20.Logic
{
    public class ImageEnhancement
    {
        private readonly string _input;
        private readonly List<char[]> _image;
        private char[] _infinitePixels;

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
            _infinitePixels = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };

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
            for (var level = 0; level < levels; level++)
            {
                var enhancedImage = new BlankCanvas(_image, GetInfinitePixel()).Value;

                for (var y = 0; y < ImageHeight + 2; y++)
                {
                    for (var x = 0; x < ImageWidth + 2; x++)
                    {
                        var index = GetSurroundingPixelsFromImage(x, y);
                        enhancedImage[y][x] = EnhancePixel(index);
                    }
                }

                UpdateInfinitePixel();
                CopyImageFrom(enhancedImage);
                UpdateImageSize();
            }
        }

        private char GetInfinitePixel() => _infinitePixels[4];

        private int GetSurroundingPixelsFromImage(int x, int y)
        {
            var enhancedPixel = string.Empty;

            foreach (var pixel in GetSurroundingPixelCoordinatesFor(x, y))
            {
                var (oldX, oldY) = ConvertToOldImageCoordinates(pixel);

                if (oldX >= 0 && oldX < ImageWidth && oldY >= 0 && oldY < ImageHeight)
                {
                    enhancedPixel += ConvertPixelToNumber(_image[oldY][oldX]);
                }
                else
                {
                    enhancedPixel += ConvertPixelToNumber(GetInfinitePixel());
                }
            }

            return Convert.ToInt32(enhancedPixel, 2);
        }

        private char EnhancePixel(int index) => Algorithm[index];

        private void UpdateInfinitePixel()
        {
            var pixel = EnhancePixel(GetSurroundingPixelsFromInfiniteCanvas());
            _infinitePixels = new string(pixel, 9).ToCharArray();
        }

        private void CopyImageFrom(List<char[]> newImage)
        {
            _image.Clear();
            _image.AddRange(newImage);
        }

        private void UpdateImageSize()
        {
            ImageWidth += 2;
            ImageHeight += 2;
        }

        private static IEnumerable<(int X, int Y)> GetSurroundingPixelCoordinatesFor(int x, int y) => new[]
            {
                (y - 1, x - 1),
                (y - 1, x),
                (y - 1, x + 1),
                (y, x - 1),
                (y, x),
                (y, x + 1),
                (y + 1, x - 1),
                (y + 1, x),
                (y + 1, x + 1)
            };

        private static (int, int) ConvertToOldImageCoordinates((int X, int Y) pixel) =>
            (pixel.Y - 1, pixel.X - 1);

        private static char ConvertPixelToNumber(char pixel) => pixel == '.' ? '0' : '1';

        private int GetSurroundingPixelsFromInfiniteCanvas() =>
            Convert.ToInt32(new string(_infinitePixels.Select(p => p == '.'? '0' : '1').ToArray()), 2);

        public string GetOutputImage() => string.Join('\n', _image.Select(p => new string(p)));

        public int CountLitPixels() => _image.Sum(p => p.Count(q => q == '#'));
    }
}