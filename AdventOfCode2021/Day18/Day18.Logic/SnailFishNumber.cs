namespace Day18.Logic
{
    public abstract class Number : IVisitable
    {
        public abstract void Explode(RegularNumber leftSide, RegularNumber rightSide);
        public abstract void Accept(NumberVisitor visitor);
    }

    public class RegularNumber : Number
    {
        private int _number;

        public RegularNumber(int number) =>
            _number = number;

        public override bool Equals(object obj)
        {
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

        public override void Accept(NumberVisitor visitor) => visitor.Visit(this);
    }

    public class SnailFishNumber : Number
    {
        private Number _leftSide;
        private Number _rightSide;

        public SnailFishNumber(Number leftSide, Number rightSide)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
        }

        public override bool Equals(object obj)
        {
            var other = (SnailFishNumber)obj;
            return other._leftSide.Equals(_leftSide) && other._rightSide.Equals(_rightSide);
        }

        public override void Explode(RegularNumber leftSide, RegularNumber rightSide)
        {
            leftSide.Add((RegularNumber)_leftSide);
            rightSide.Add((RegularNumber)_rightSide);
        }

        public override void Accept(NumberVisitor visitor) => visitor.Visit(this);
    }
}