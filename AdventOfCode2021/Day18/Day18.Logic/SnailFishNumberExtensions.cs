using Day18.Logic.Numbers;

namespace Day18.Logic
{
    public static class SnailFishNumberExtensions
    {
        public static RegularNumber AsNumber(this int value) => new(value);

        public static SnailFishNumber AsNumber(this (int Left, int Right) value) => new(value.Left.AsNumber(), value.Right.AsNumber());

        public static SnailFishNumber AsNumber(this (SnailFishNumber Left, int Right) value) => new(value.Left, value.Right.AsNumber());

        public static SnailFishNumber AsNumber(this (int Left, SnailFishNumber Right) value) => new(value.Left.AsNumber(), value.Right);

        public static SnailFishNumber AsNumber(this (SnailFishNumber Left, SnailFishNumber Right) value) => new(value.Left, value.Right);
    }
}