namespace Day14.Logic
{
    public interface IStringAccumulator
    {
        void Append(char value);
        string Value { get; }
    }

    public class StringAccumulator : IStringAccumulator
    {
        public string Value { get; private set; }

        public void Append(char value)
        {
            Value += value;
        }
    }

    public class NullAccumulator : IStringAccumulator
    {
        public void Append(char value)
        {
        }

        public string Value { get; }
    }
}