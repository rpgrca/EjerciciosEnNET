namespace YouGotChange.Logic;

public class Change
{
    private readonly int[] _bills;
    private int _amount;

    public int[] OptimizedChange { get; }

    public Change(int amount, int[] bills)
    {
        _amount = amount;
        _bills = bills;
        OptimizedChange = _bills.Select(p => Math.DivRem(_amount, p, out _amount)).Reverse().ToArray();
    }
}