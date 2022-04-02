using System;

namespace AdventOfCode2020.Day3.Logic
{
    public class PathFinder
    {
        private readonly string[] _map;
        private int _currentX = 0;
        private int _currentY = 0;

        public PathFinder(string[] map) =>
            _map = map;

        public long TraverseWith(Func<int, int> moveX, Func<int, int> moveY)
        {
            var trees = 0;

            while ((_currentY = moveY(_currentY)) < _map.Length)
            {
                _currentX = moveX(_currentX) % _map[0].Length;
                if (_map[_currentY][_currentX] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }
    }
}