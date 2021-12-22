using System;

namespace Day22.Logic
{
    public class ReactorCore
    {
        private readonly string _steps;

        public ReactorCore(string steps)
        {
            if (string.IsNullOrWhiteSpace(steps))
            {
                throw new ArgumentException("Invalid steps");
            }

            _steps = steps;
        }
    }
}
