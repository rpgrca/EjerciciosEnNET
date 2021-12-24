using System;
using System.Collections.Generic;

namespace Day24.Logic
{
    public class ArithmeticLogicUnit
    {
        private readonly string _instructions;
        public int X { get; set; }

        public ArithmeticLogicUnit(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                throw new ArgumentException("Invalid instructions");
            }

            _instructions = instructions;
        }

        public void Input(int value)
        {
            X = -value;
        }
    }
}
