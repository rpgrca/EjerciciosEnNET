using System;

namespace Day7.Logic
{
    public class SubmarineAlignment
    {
        public SubmarineAlignment(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input");
            }
        }
    }
}
