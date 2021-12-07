using System;
using System.Collections.Generic;

namespace Day7.Logic
{
    public class SubmarineAlignment
    {
        public int BestPosition { get; set; }

        public SubmarineAlignment(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }

            BestPosition = int.Parse(input);
        }
    }
}
