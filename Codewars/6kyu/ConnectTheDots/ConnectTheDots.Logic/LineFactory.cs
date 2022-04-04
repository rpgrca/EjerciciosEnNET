using System;
using System.Linq;

namespace Codewars.ConnectTheDots.Logic
{
    public static class LineFactory
    {
        public static ILine Create((int Y, int X) source, (int Y, int X) target)
        {
            var horizontalOffset = target.X - source.X;
            var verticalOffset = target.Y - source.Y;

            if (horizontalOffset > 0 && verticalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (s, _, h, _) => Enumerable.Range(s.X, h + 1),
                    (dots, s, p) => dots.Add((s.Y, p)));
            }
            else
            if (horizontalOffset < 0 && verticalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (_, t, h, _) => Enumerable.Range(t.X, -h + 1).Reverse(),
                    (dots, s, p) => dots.Add((s.Y, p)));
            }
            else
            if (verticalOffset > 0 && horizontalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (s, _, _, v) => Enumerable.Range(s.Y, v + 1),
                    (dots, s, p) => dots.Add((p, s.X)));
            }
            else
            if (verticalOffset < 0 && horizontalOffset == 0)
            {
                return new Line(
                    source,
                    target,
                    horizontalOffset,
                    verticalOffset,
                    (_, t, _, v) => Enumerable.Range(t.Y, -v + 1).Reverse(),
                    (dots, s, p) => dots.Add((p, s.X)));
            }
            else
            if (horizontalOffset > 0)
            {
                return new DiagonalLine(
                    source, target,
                    horizontalOffset, verticalOffset,
                    1, (s, _, h, _) => Enumerable.Range(s.X, h + 1));
            }

            return new DiagonalLine(
                source, target,
                horizontalOffset, verticalOffset,
                -1, (_, t, h, _) => Enumerable.Range(t.X, -h + 1).Reverse());
        }
    }
}