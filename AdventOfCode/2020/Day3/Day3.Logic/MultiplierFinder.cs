using System;
using System.Linq;

namespace AdventOfCode2020.Day3.Logic
{
    public class MultiplierFinder
    {
        private readonly (Func<int, int> MoveX, Func<int, int> MoveY)[] _paths = new (Func<int, int> MoveX, Func<int, int>)[]
        {
            (x => x + 3, y => y + 1),
            (x => x + 1, y => y + 1),
            (x => x + 5, y => y + 1),
            (x => x + 7, y => y + 1),
            (x => x + 1, y => y + 2)
        };

        private readonly string[] _map;

        public MultiplierFinder(string[] map) =>
            _map = map;

        public long CalculateSolution() =>
            _paths
                .Select(p => new PathFinder(_map).TraverseWith(p.MoveX, p.MoveY))
                .Aggregate(1L, (r, i) => r *= i);
    }
}