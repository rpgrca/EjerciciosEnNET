using System;

namespace Day11.Logic
{
    public class OctopusCaveSimulation
    {
        private string _input;

        public OctopusCaveSimulation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            _input = input;
        }
    }
}
