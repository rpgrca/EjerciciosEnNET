using System;
using System.Diagnostics;
namespace Day18.Logic
{
    public abstract class Number : IVisitable
    {
        public abstract void Explode(RegularNumber leftSide, RegularNumber rightSide);
        public abstract void Accept(INumberVisitor visitor);
    }

    public class RegularNumber : Number
    {
        private int _number;
        private readonly int _order;

        public RegularNumber(int number, int order = -1)
        {
            _number = number;
            _order = order;
        }

        public override bool Equals(object obj)
        {
            if (obj is not RegularNumber) return false;

            var other = (RegularNumber)obj;
            return _number == other._number;
        }

        public override void Explode(RegularNumber leftSide, RegularNumber rightSide)
        {
        }

        public void Add(RegularNumber number)
        {
            _number += number._number;
        }

        public bool IsOrder(int order) => _order == order;

        public override void Accept(INumberVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"{_number}";

        public bool IsLeftOf(RegularNumber number) => number.IsOrder(_order + 1);

        public bool IsRightOf(RegularNumber number) => _order > 0 && number.IsOrder(_order - 1);
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

        public override bool Equals(object obj)
        {
            var other = (SnailFishNumber)obj;
            return other.LeftSide.Equals(LeftSide) && other.RightSide.Equals(RightSide);
        }

        public override string ToString() => $"[{LeftSide},{RightSide}]";

        public override void Explode(RegularNumber leftSide, RegularNumber rightSide)
        {
            leftSide.Add((RegularNumber)LeftSide);
            rightSide.Add((RegularNumber)RightSide);
        }

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