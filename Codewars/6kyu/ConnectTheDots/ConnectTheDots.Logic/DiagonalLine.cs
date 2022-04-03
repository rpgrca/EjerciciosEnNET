using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.ConnectTheDots.Logic
{
    public class DiagonalLine : ILine
    {
        protected readonly (int Y, int X) _source;
        protected readonly (int Y, int X) _target;
        protected readonly int _horizontalOffset;
        protected readonly int _verticalOffset;
        private readonly int _multiplier;
        private readonly Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> Steps;

        public DiagonalLine((int Y, int X) source, (int Y, int X) target, int horizontalOffset, int verticalOffset, int multiplier, Func<(int Y, int X), (int Y, int X), int, int, IEnumerable<int>> steps)
        {
            _source = source;
            _target = target;
            _horizontalOffset = horizontalOffset;
            _verticalOffset = verticalOffset;
            _multiplier = multiplier;
            Steps = steps;
        }

        public void TraceTo(List<(int Y, int X)> dots)
        {
            var verticalStep = _verticalOffset / (_multiplier * _horizontalOffset);
            var step = 0;

            Steps(_source, _target, _horizontalOffset, _verticalOffset)
                .ToList()
                .ForEach(p => dots.Add((_source.Y + (step++ * verticalStep), p)));
        }
    }
}