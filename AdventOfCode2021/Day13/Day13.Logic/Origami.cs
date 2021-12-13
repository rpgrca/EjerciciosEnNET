using System;

namespace Day13.Logic
{
    public class Origami
    {
        private readonly string _instructions;

        public Origami(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                throw new ArgumentException("Invalid instructions");
            }

            _instructions = instructions;
        }
    }
}
