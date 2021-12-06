using System.Collections.Generic;

namespace Day5.Logic.Movement
{
    public interface IMovement
    {
        bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint);
        IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint);
    }

    public class TopLeftToBottomRight : IMovement
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

    public class TopRightToBottomLeft : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X > endingPoint.X && startingPoint.Y < endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            int x;
            int y;
            for (x = startingPoint.X, y = startingPoint.Y; x >= endingPoint.X && y <= endingPoint.Y; x--, y++)
                yield return (x, y);
        }
    }

    public class BottomRightToUpperLeft : IMovement
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

    public class BottomLeftToUpperRight : IMovement
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

    public class TopToBottom : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X == endingPoint.X && startingPoint.Y > endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            for (var y = startingPoint.Y; y >= endingPoint.Y; y--)
                yield return (startingPoint.X, y);
        }
    }

    public class BottomToTop : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X == endingPoint.X && startingPoint.Y < endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            for (var y = startingPoint.Y; y <= endingPoint.Y; y++)
                yield return (startingPoint.X, y);
        }
    }

    public class LeftToRight : IMovement
    {
        public bool CanHandle((int X, int Y) startingPoint, (int X, int Y) endingPoint) =>
            startingPoint.X < endingPoint.X && startingPoint.Y == endingPoint.Y;

        public IEnumerable<(int X, int Y)> Move((int X, int Y) startingPoint, (int X, int Y) endingPoint)
        {
            for (var x = startingPoint.X; x <= endingPoint.X; x++)
                yield return (x, startingPoint.Y);
        }
    }

    public class RightToLeft : IMovement
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