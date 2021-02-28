using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.ConnectTheDots.Logic
{
    public class Line : ILine
    {
        private readonly (int Y, int X) _source;
        private readonly (int Y, int X) _target;
        private readonly int _horizontalOffset;
        private readonly int _verticalOffset;
        private readonly Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> Steps;
        private readonly Action<List<(int Y, int X)>, (int Y, int X), int> Adding;

        public Line(
            (int Y, int X) source, (int Y, int X) target,
            int horizontalOffset, int verticalOffset,
            Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> steps,
            Action<List<(int Y, int X)>, (int Y, int X), int> adding)
        {
            _source = source;
            _target = target;
            _horizontalOffset = horizontalOffset;
            _verticalOffset = verticalOffset;
            Steps = steps;
            Adding = adding;
        }

        public void TraceTo(List<(int Y, int X)> dots) =>
            Steps(_source, _target, _horizontalOffset, _verticalOffset)
                .ToList()
                .ForEach(p => Adding(dots, _source, p));
    }
}