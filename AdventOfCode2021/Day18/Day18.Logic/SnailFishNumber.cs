using System.Linq.Expressions;
using System.Diagnostics;
using System.Collections.Generic;

namespace Day18.Logic
{
    public abstract class Number : IVisitable
    {
        public abstract void Accept(INumberVisitor visitor);
    }

    public class RegularNumber : Number
    {
        private int _number;
        private int _order;

        public int Value => _number;

        public RegularNumber(int number, int order = -1)
        {
            _number = number;
            _order = order;
        }

        public override bool Equals(object obj)
        {
            if (obj is not RegularNumber) return false;

            var other = (RegularNumber)obj;
            return Value == other.Value;
        }

        public void Add(RegularNumber number)
        {
            _number += number.Value;
        }

        public bool IsOrder(int order) => _order == order;

        public override void Accept(INumberVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"{Value}";

        public bool IsLeftOf(RegularNumber number) => number.IsOrder(_order + 1);

        public bool IsRightOf(RegularNumber number) => _order > 0 && number.IsOrder(_order - 1);

        public void ReorderTo(int newOrder) => _order = newOrder;
    }

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
            var magnitude = 0;

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

        public override bool Equals(object obj)
        {
            var other = (SnailFishNumber)obj;
            return other.LeftSide.Equals(LeftSide) && other.RightSide.Equals(RightSide);
        }

        public override string ToString() => $"[{LeftSide},{RightSide}]";

        public override void Accept(INumberVisitor visitor)
        {
            visitor.AddLevel();

            visitor.Visit(this);
            LeftSide.Accept(visitor);
            RightSide.Accept(visitor);

            visitor.RemoveLevel();
        }
    }
}