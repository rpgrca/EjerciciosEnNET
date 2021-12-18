namespace Day18.Logic
{
    public interface Number
    {
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
    }

    public static class SnailFishNumberExtesions
    {
        public static RegularNumber AsNumber(this int value) => new(value);

        public static SnailFishNumber AsNumber(this (int Left, int Right) value) => new(value.Left.AsNumber(), value.Right.AsNumber());

        public static SnailFishNumber AsNumber(this (SnailFishNumber Left, int Right) value) => new(value.Left, value.Right.AsNumber());

        public static SnailFishNumber AsNumber(this (int Left, SnailFishNumber Right) value) => new(value.Left.AsNumber(), value.Right);

        public static SnailFishNumber AsNumber(this (SnailFishNumber Left, SnailFishNumber Right) value) => new(value.Left, value.Right);
    }
}