namespace Day11.Logic;

public class Item
{
    private readonly List<int> _owners;

    public long WorryLevel { get; private set; }

    public Item(long worryLevel)
    {
        WorryLevel = worryLevel;
        _owners = new List<int>();
    }

    public Item Multiply(long factor)
    {
        WorryLevel *= factor;
        return this;
    }

    public Item Add(long value)
    {
        WorryLevel += value;
        return this;
    }

    public void AddOwner(int owner)
    {
        _owners.Add(owner);
    }

    public bool DivisibleBy(int divisor)
    {
        return WorryLevel % divisor == 0;
    }

    public Item DivideBy(int v)
    {
        WorryLevel = WorryLevel / v;
        return this;
    }
}

public class Monkey1
{
    private readonly int _order;
    private readonly char _operation;
    private readonly string _operand;
    private readonly int _divisor;
    private readonly int _targetOnSuccess;
    private readonly int _targetOnFailure;

    public List<Item> Items { get; }
    public int ActivityLevel { get; private set; }

    public Monkey1(int order, List<Item> items, char operation, string operand, int divisor, int targetOnSuccess, int targetOnFailure)
    {
        ActivityLevel = 0;

        _order = order;
        _operation = operation;
        _operand = operand;
        _divisor = divisor;
        _targetOnSuccess = targetOnSuccess;
        _targetOnFailure = targetOnFailure;

        Items = new List<Item>();
        foreach (var item in items)
        {
            Give(item);
        }
    }

    public void Give(Item item)
    {
        if (_order == 2)
        {
            item.AddOwner(_order);
        }
        else
        {
            item.AddOwner(_order);
        }

        Items.Add(item);
    }

    public void DoTurn(List<Monkey1> monkeys)
    {
        ActivityLevel += Items.Count;

        foreach (var item in Items)
        {
            var newItem = Operation(item).DivideBy(3);
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

    public void DoTurn2(List<Monkey1> monkeys)
    {
        ActivityLevel += Items.Count;

        foreach (var item in Items)
        {
            var newItem = Operation2(item);
            if (Test(newItem))
            {
                Success(monkeys, newItem);
            }
            else
            {
                //newItem = new Item(_divisor + (newItem.WorryLevel % _divisor));
                Failure(monkeys, newItem);
            }
        }

        Items.Clear();
    }


    public Item Operation(Item item) => _operation switch
    {
        '*' => item.Multiply(_operand == "old"? item.WorryLevel : long.Parse(_operand)),
        '+' => item.Add(long.Parse(_operand)),
        _ => throw new ArgumentException("Invalid operation"),
    };

    public Item Operation2(Item item) => _operation switch
    {
        '*' => item.Multiply(_operand == "old"? item.WorryLevel : long.Parse(_operand)),
        '+' => item.Add(long.Parse(_operand)),
        _ => throw new ArgumentException("Invalid operation"),
    };

    public bool Test(Item item) => item.DivisibleBy(_divisor);

    private void Success(List<Monkey1> monkeys, Item item) =>
        monkeys[_targetOnSuccess].Give(item);

    private void Failure(List<Monkey1> monkeys, Item item) =>
        monkeys[_targetOnFailure].Give(item);

    public List<long> ItemsAsWorries => Items.Select(p => p.WorryLevel).ToList();
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