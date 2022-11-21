using System.Diagnostics;
using Day18.Logic.Visitors;

namespace Day18.Logic.Numbers
{
    [DebuggerDisplay("{ToString()}")]
    public class SnailFishNumber : Number
    {
        public Number LeftSide { get; set; }
        public Number RightSide { get; set; }

        public SnailFishNumber(Number leftSide, Number rightSide)
        {
            LeftSide = leftSide;
            RightSide = rightSide;
        }

        public override int GetMagnitude() =>
            LeftSide.GetMagnitude() * 3 + RightSide.GetMagnitude() * 2;

        internal void ReplaceSideWith(SnailFishNumber oldSnailFishNumber, RegularNumber regularNumber)
        {
            if (LeftSide == oldSnailFishNumber)
            {
                LeftSide = regularNumber;
            }
            else
            {
                RightSide = regularNumber;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is SnailFishNumber other)
            {
                return other.RightSide.Equals(RightSide) && other.LeftSide.Equals(LeftSide);
            }

            return false;
        }

        public override int GetHashCode() => LeftSide.GetHashCode() * RightSide.GetHashCode();

        public override string ToString() => $"[{LeftSide},{RightSide}]";

        public override void Accept(INumberVisitor visitor)
        {
            visitor.AddLevel();

            visitor.Visit(this);
            LeftSide.Accept(visitor);
            RightSide.Accept(visitor);

            visitor.RemoveLevel();
        }

        internal bool HasAsSide(RegularNumber numberToSplit) =>
            LeftSide == numberToSplit || RightSide == numberToSplit;
    }
}