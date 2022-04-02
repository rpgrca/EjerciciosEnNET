using System.Collections.Generic;

namespace Day5.Logic.Movement
{
    internal interface IMovement
    {
        bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint);
        IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint);
    }

    internal class TopLeftToBottomRight : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X < endingPoint.X && startingPoint.Y < endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            int x;
            int y;
            for (x = startingPoint.X, y = startingPoint.Y; x <= endingPoint.X && y <= endingPoint.Y; x++, y++)
                yield return (x, y);
        }
    }

    internal class TopRightToBottomLeft : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            // FIXME: Impossible to get 100% coverage because the second predicate will never be true as otherwise it would
            // be TopLeftToBottomRight which would have already been handled by the proper class. Must create unit test for
            // this class.
            startingPoint.X > endingPoint.X && startingPoint.Y < endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            int x;
            int y;
            for (x = startingPoint.X, y = startingPoint.Y; x >= endingPoint.X && y <= endingPoint.Y; x--, y++)
                yield return (x, y);
        }
    }

    internal class BottomRightToUpperLeft : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X > endingPoint.X && startingPoint.Y > endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            int x;
            int y;
            for (x = startingPoint.X, y = startingPoint.Y; x >= endingPoint.X && y >= endingPoint.Y; x--, y--)
                yield return (x, y);
        }
    }

    internal class BottomLeftToUpperRight : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X < endingPoint.X && startingPoint.Y > endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            int x;
            int y;
            for (x = startingPoint.X, y = startingPoint.Y; x <= endingPoint.X && y >= endingPoint.Y; x++, y--)
                yield return (x, y);
        }
    }

    internal class TopToBottom : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X == endingPoint.X && startingPoint.Y > endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            for (var y = startingPoint.Y; y >= endingPoint.Y; y--)
                yield return (startingPoint.X, y);
        }
    }

    internal class BottomToTop : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X == endingPoint.X && startingPoint.Y < endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            for (var y = startingPoint.Y; y <= endingPoint.Y; y++)
                yield return (startingPoint.X, y);
        }
    }

    internal class LeftToRight : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X < endingPoint.X && startingPoint.Y == endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            for (var x = startingPoint.X; x <= endingPoint.X; x++)
                yield return (x, startingPoint.Y);
        }
    }

    internal class RightToLeft : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X > endingPoint.X && startingPoint.Y == endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            for (var x = startingPoint.X; x >= endingPoint.X; x--)
                yield return (x, startingPoint.Y);
        }
    }
}