using System.Collections.Generic;

namespace Day20.Logic
{
    internal class BlankCanvas
    {
        private readonly List<char[]> _originalImage;
        private readonly char _infinitePixel;

        public List<char[]> Value { get; private set; }

        public BlankCanvas(List<char[]> originalImage, char infinitePixel)
        {
            _originalImage = originalImage;
            _infinitePixel = infinitePixel;
            Value = new List<char[]>();

            CreateSlightlyBiggerCanvas();
        }

        private void CreateSlightlyBiggerCanvas()
        {
            var image = new List<char[]>();
            for (var y = 0; y < _originalImage.Count + 2; y++)
            {
                image.Add(new string(_infinitePixel, _originalImage[0].Length + 2).ToCharArray());
            }

            Value = image;
        }
    }
}