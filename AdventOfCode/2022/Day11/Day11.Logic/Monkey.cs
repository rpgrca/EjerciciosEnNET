namespace Day11.Logic;

public class Monkey1
{
    private readonly char _operation;
    private readonly string _operand;
    private readonly int _divisor;
    private readonly int _targetOnSuccess;
    private readonly int _targetOnFailure;

    public List<long> Items { get; }
    public int ActivityLevel { get; private set; }

    public Monkey1(List<long> items, char operation, string operand, int divisor, int targetOnSuccess, int targetOnFailure)
    {
        Items = items;
        ActivityLevel = 0;

        _operation = operation;
        _operand = operand;
        _divisor = divisor;
        _targetOnSuccess = targetOnSuccess;
        _targetOnFailure = targetOnFailure;
    }

    public void Give(long i) => Items.Add(i);

    public void DoTurn(List<Monkey1> monkeys)
    {
        ActivityLevel += Items.Count;

        foreach (var item in Items)
        {
            var newWorryLevel = Operation(item) / 3;
            if (Test(newWorryLevel))
            {
                Success(monkeys, newWorryLevel);
            }
            else
            {
                Failure(monkeys, newWorryLevel);
            }
        }

        Items.Clear();
    }

    public long Operation(long worryLevel) => _operation switch
    {
        '*' => worryLevel * (_operand == "old"? worryLevel : long.Parse(_operand)),
        '+' => worryLevel + long.Parse(_operand),
        _ => throw new ArgumentException("Invalid operation"),
    };

    public bool Test(long worryLevel) => worryLevel % _divisor == 0;

    private void Success(List<Monkey1> monkeys, long worryLevel) =>
        monkeys[_targetOnSuccess].Give(worryLevel);

    private void Failure(List<Monkey1> monkeys, long worryLevel) =>
        monkeys[_targetOnFailure].Give(worryLevel);
}
/*
public class Monkey
{
    public List<int> Items { get; }
    public Func<int, int> Operation { get; }
    public Func<int, bool> Test { get; }
    private Action<List<Monkey>, int> Success { get; }
    private Action<List<Monkey>, int> Failure { get; }

    public int ActivityLevel { get; private set; }

    public Monkey(Func<int, int> operation, Func<int, bool> test, Action<List<Monkey>, int> success, Action<List<Monkey>, int> failure, params int[] items)
    {
        Items = new List<int>(items);
        Operation = operation;
        Test = test;
        Success = success;
        Failure = failure;
    }

    public void Give(int i) => Items.Add(i);

    public void DoTurn(List<Monkey> monkeys)
    {
        foreach (var item in Items)
        {
            var newWorryLevel = Operation(item);
            newWorryLevel /= 3;
            if (Test(newWorryLevel))
            {
                Success(monkeys, newWorryLevel);
            }
            else
            {
                Failure(monkeys, newWorryLevel);
            }

            ActivityLevel++;
        }

        Items.Clear();
    }
}
*/