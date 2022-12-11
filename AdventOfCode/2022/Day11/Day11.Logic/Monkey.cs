namespace Day11.Logic;

public class Monkey
{
    private readonly char _operation;
    private readonly string _operand;
    private readonly int _divisor;
    private readonly int _targetOnSuccess;
    private readonly int _targetOnFailure;
    private readonly long _cap;

    public List<long> Items { get; }
    public int ActivityLevel { get; private set; }

    public Monkey(List<long> items, char operation, string operand, int divisor, int targetOnSuccess, int targetOnFailure, long cap)
    {
        ActivityLevel = 0;

        _operation = operation;
        _operand = operand;
        _divisor = divisor;
        _targetOnSuccess = targetOnSuccess;
        _targetOnFailure = targetOnFailure;
        _cap = cap;

        Items = new List<long>();
        foreach (var item in items)
        {
            Give(item);
        }
    }

    public void Give(long item) => Items.Add(item % _cap);

    public void DoTurn(List<Monkey> monkeys, int divisor)
    {
        ActivityLevel += Items.Count;

        foreach (var item in Items)
        {
            var newItem = Operation(item) / divisor;
            if (Test(newItem))
            {
                Success(monkeys, newItem);
            }
            else
            {
                Failure(monkeys, newItem);
            }
        }

        Items.Clear();
    }

    public long Operation(long item) => _operation switch
    {
        '*' => item * (_operand == "old"? item : long.Parse(_operand)),
        _ => item + long.Parse(_operand),
    };

    public bool Test(long item) => item % _divisor == 0;

    private void Success(List<Monkey> monkeys, long item) =>
        monkeys[_targetOnSuccess].Give(item);

    private void Failure(List<Monkey> monkeys, long item) =>
        monkeys[_targetOnFailure].Give(item);
}