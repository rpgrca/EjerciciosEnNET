namespace Day14.Logic
{
    internal interface IStringAccumulator
    {
        void Append(char value);
        string Value { get; }
    }

    internal class StringAccumulator : IStringAccumulator
    {
        public string Value { get; private set; } = string.Empty;

        public void Append(char value) => Value += value;
    }

    internal class NullAccumulator : IStringAccumulator
    {
        public void Append(char value)
        {
        }

        public string Value { get; } = string.Empty;
    }
}