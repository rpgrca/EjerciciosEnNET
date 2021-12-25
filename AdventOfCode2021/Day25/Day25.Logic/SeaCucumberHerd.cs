using System;

namespace Day25.Logic
{
    public class SeaCucumberHerd
    {
        private readonly string _seafloor;

        public SeaCucumberHerd(string seafloor)
        {
            if (string.IsNullOrWhiteSpace(seafloor))
            {
                throw new ArgumentException("Invalid seafloor");
            }

            _seafloor = seafloor;
        }
    }
}
