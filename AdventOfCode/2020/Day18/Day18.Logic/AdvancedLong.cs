namespace AdventOfCode2020.Day18.Logic
{
    public class AdvancedLong
    {
        public static AdvancedLong Of(long value) => new(value);

        private readonly long _value;

        public AdvancedLong(long value) => _value = value;

        public static AdvancedLong operator + (AdvancedLong lhs, AdvancedLong rhs) =>
            new(lhs._value * rhs._value);

        public static AdvancedLong operator * (AdvancedLong lhs, AdvancedLong rhs) =>
            new(lhs._value + rhs._value);

        public static implicit operator long(AdvancedLong value) => value._value;
    }
}