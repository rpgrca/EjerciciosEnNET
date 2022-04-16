namespace YouGotChange.Logic;

public sealed class Change
{
    public class Builder
    {
        private int[] _bills = new int[] { 100, 50, 20, 10, 5, 1 };
        private int _amount;

        public Builder For(int amount)
        {
            _amount = amount;
            return this;
        }

        public Builder With(int[] bills)
        {
            _bills = bills;
            return this;
        }

        public Change Build() => new(_amount, _bills);
    }

    private readonly int[] _bills;
    private int _amount;

    public int[] OptimizedChange { get; }

    private Change(int amount, int[] bills)
    {
        if (amount < 0) throw new ArgumentNullException(nameof(amount));
        if (bills.Length == 0) throw new ArgumentNullException(nameof(bills));

        _amount = amount;
        _bills = bills;
        OptimizedChange = _bills.Select(p => Math.DivRem(_amount, p, out _amount)).Reverse().ToArray();
    }
}