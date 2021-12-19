using System;

namespace Day19.Logic
{
    public class Scanner
    {
        private readonly string _data;

        public Scanner(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
        }
    }
}
