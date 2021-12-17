using System;

namespace Day17.Logic
{
    public class Launcher
    {
        private readonly string _velocity;

        public Launcher(string velocity)
        {
            if (string.IsNullOrWhiteSpace(velocity))
            {
                throw new ArgumentException("Invalid velocity");
            }

            _velocity = velocity;
        }
    }
}
