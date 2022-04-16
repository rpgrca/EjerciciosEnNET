namespace YouGotChange.Logic;

public class Kata
{
    public static int[] GiveChange(int amount)
    {
        var bills = new int[] { 100, 50, 20, 10, 5, 1 };
        var change = new Change(amount, bills);
        return change.OptimizedChange;
    }
}

public class Change
{
    private readonly int _amount;
    private readonly int[] _change;
    private readonly int[] _bills;

    public int[] OptimizedChange => _change;

    public Change(int amount, int[] bills)
    {
        _amount = amount;
        _bills = bills;
        _change = new int[_bills.Length];

        CalculateChange();
    }

    private void CalculateChange()
    {
        var amount = _amount;

        for (var position = 0; position < _bills.Length; position++)
        {
            amount -= _bills[position] * (_change[_bills.Length - 1 - position] = amount / _bills[position]);
        }
    }
}