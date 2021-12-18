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
}