using System.Collections.Generic;

namespace AdventOfCode2020.Day11.Logic
{
    public interface IBehaviour
    {
        int MaximumSurroundingOccupied { get; }
        char VerifySurroundingsOf(List<string> layout, int i, int j);
    }
}