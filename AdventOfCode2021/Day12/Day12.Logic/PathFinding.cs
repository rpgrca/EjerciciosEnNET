using System;

namespace Day12.Logic
{
    public class PathFinding
    {
        private readonly string _data;

        public PathFinding(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
        }
    }
}
