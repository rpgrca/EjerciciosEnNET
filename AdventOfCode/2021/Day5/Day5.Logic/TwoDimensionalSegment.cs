using System.Collections.Generic;
using System;
using Day5.Logic.Movement;

namespace Day5.Logic
{
    internal sealed class TwoDimensionalSegment
    {
        public class Builder
        {
            private readonly List<IMovement> _movements;
            private (int X, int Y) _startingPoint;
            private (int X, int Y) _endingPoint;
            private Action<(int X, int Y)> _callback;

            public Builder() => _movements = new List<IMovement>();

            public Builder CallingInEveryStep(Action<(int X, int Y)> callback)
            {
                _callback = callback;
                return this;
            }

            public Builder StartingFrom((int X, int Y) startingPoint)
            {
                _startingPoint = startingPoint;
                return this;
            }

            public Builder Until((int X, int Y) endingPoint)
            {
                _endingPoint = endingPoint;
                return this;
            }

            public Builder Supporting(List<IMovement> movements)
            {
                _movements.AddRange(movements);
                return this;
            }

            public TwoDimensionalSegment Build() =>
                new(_startingPoint, _endingPoint, _movements, _callback);
        }

        public static class Director
        {
            public static Builder ConfigureForHorizontalAndVerticalTracing(Builder builder) =>
                builder
                    .Supporting(new()
                    {
                        new TopToBottom(),
                        new BottomToTop(),
                        new LeftToRight(),
                        new RightToLeft()
                    });

            public static Builder ConfigureForHorizontalVerticalAndDiagonalTracing(Builder builder) =>
                ConfigureForHorizontalAndVerticalTracing(builder)
                    .Supporting(new()
                    {
                        new TopLeftToBottomRight(),
                        new TopRightToBottomLeft(),
                        new BottomLeftToUpperRight(),
                        new BottomRightToUpperLeft()
                    });
        }

        private readonly (int X, int Y) _startingPoint;
        private readonly (int X, int Y) _endingPoint;
        private readonly Action<(int X, int Y)> _callback;
        private readonly List<IMovement> _allowedMovements;

        private TwoDimensionalSegment((int X, int Y) startingPoint, (int X, int Y) endingPoint, List<IMovement> allowedMovements, Action<(int X, int Y)> callback)
        {
            _startingPoint = startingPoint;
            _endingPoint = endingPoint;
            _allowedMovements = allowedMovements;
            _callback = callback;
        }

        public void Trace()
        {
            var handler = _allowedMovements.Find(p => p.CanHandle(_startingPoint, _endingPoint));
            if (handler != null)
            {
                foreach (var point in handler.Move(_startingPoint, _endingPoint))
                {
                    _callback(point);
                }
            }
        }
    }
}