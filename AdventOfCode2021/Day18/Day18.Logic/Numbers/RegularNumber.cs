using System.Diagnostics;
using Day18.Logic.Visitors;

namespace Day18.Logic.Numbers
{
    [DebuggerDisplay("{ToString()}")]
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

        public void Add(RegularNumber number) => _number += number.Value;

        public override void Accept(INumberVisitor visitor) => visitor.Visit(this);

        public bool IsOrder(int order) => _order == order;

        public bool IsLeftOf(RegularNumber number) => number.IsOrder(_order + 1);

        public bool IsRightOf(RegularNumber number) => number.IsOrder(_order - 1);

        public void ReorderTo(int newOrder) => _order = newOrder;

        public override bool Equals(object obj)
        {
            if (obj is RegularNumber other)
            {
                return Value == other.Value;
            }

            return false;
        }

        public override string ToString() => $"{Value}";
    }
}