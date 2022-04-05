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

        public int GetMagnitude()
        {
            int magnitude;
            if (LeftSide is SnailFishNumber snailFishNumber)
            {
                magnitude = snailFishNumber.GetMagnitude() * 3;
            }
            else
            {
                var leftNumber = (RegularNumber)LeftSide;
                magnitude = leftNumber.Value * 3;
            }

            if (RightSide is SnailFishNumber snailFishNumber1)
            {
                magnitude += snailFishNumber1.GetMagnitude() * 2;
            }
            else
            {
                var rightNumber = (RegularNumber)RightSide;
                magnitude += rightNumber.Value * 2;
            }

            return magnitude;
        }

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