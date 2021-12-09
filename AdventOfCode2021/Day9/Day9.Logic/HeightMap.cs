using System;

namespace Day9.Logic
{
    public class HeightMap
    {
        private readonly string _data;

        public HeightMap(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
        }
    }
}
