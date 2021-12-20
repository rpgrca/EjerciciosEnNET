using System;

namespace Day20.Logic
{
    public class ImageEnhancement
    {
        private readonly string _input;

        public ImageEnhancement(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
        }
    }
}