namespace Day11.Logic;

public class MonkeysLoader
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<Monkey1> Monkeys { get; }

    public MonkeysLoader(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Monkeys = new List<Monkey1>();

        Parse();
    }

    private void Parse()
    {
        string[] tokens;
        List<int> items = new();
        char operation = ' ';
        string operand = string.Empty;
        int divisor = -1;
        int targetOnSuccess = -1;
        int targetOnFailure = -1;
        Monkey1 monkey;

        foreach (var line in _lines)
        {
            if (line.StartsWith("Monkey "))
            {
                continue;
            }
            else if (line.StartsWith("  Starting items: "))
            {
                items = line.Split(":")[1].Split(",").ToList().Select(p => int.Parse(p)).ToList();
            }
            else if (line.StartsWith("  Operation: "))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                operation = tokens[3][0];
                operand = tokens[4];
            }
            else if (line.StartsWith("  Test: "))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                divisor = int.Parse(tokens[2]);
            }
            else if (line.StartsWith("    If true:"))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                targetOnSuccess = int.Parse(tokens[3]);
            }
            else if (line.StartsWith("    If false:"))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                targetOnFailure = int.Parse(tokens[3]);
            }
            else
            {
                monkey = new Monkey1(items, operation, operand, divisor, targetOnSuccess, targetOnFailure);
                Monkeys.Add(monkey);
            }
        }

        monkey = new Monkey1(items, operation, operand, divisor, targetOnSuccess, targetOnFailure);
        Monkeys.Add(monkey);
    }
}

public class Monkey1
{
    private readonly char _operation;
    private readonly string _operand;
    private readonly int _divisor;
    private readonly int _targetOnSuccess;
    private readonly int _targetOnFailure;

    public List<int> Items { get; }
    public int ActivityLevel { get; private set; }

    public Monkey1(List<int> items, char operation, string operand, int divisor, int targetOnSuccess, int targetOnFailure)
    {
        Items = items;
        ActivityLevel = 0;

        _operation = operation;
        _operand = operand;
        _divisor = divisor;
        _targetOnSuccess = targetOnSuccess;
        _targetOnFailure = targetOnFailure;
    }

    public void Give(int i) => Items.Add(i);

    public void DoTurn(List<Monkey1> monkeys)
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

    public int Operation(int worryLevel) => _operation switch
    {
        '*' => worryLevel * (_operand == "old"? worryLevel : int.Parse(_operand)),
        '+' => worryLevel + int.Parse(_operand),
        _ => throw new ArgumentException("Invalid operation"),
    };

    public bool Test(int worryLevel) => worryLevel % _divisor == 0;

    private void Success(List<Monkey1> monkeys, int worryLevel) =>
        monkeys[_targetOnSuccess].Give(worryLevel);

    private void Failure(List<Monkey1> monkeys, int worryLevel) =>
        monkeys[_targetOnFailure].Give(worryLevel);
}

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
