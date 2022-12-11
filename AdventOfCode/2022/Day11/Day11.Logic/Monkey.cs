namespace Day11.Logic;

public class Monkey
{
    public List<int> Items { get; }
    private Func<int, int> Operation { get; }
    private Func<int, bool> Test { get; }
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
            newWorryLevel = (int)(newWorryLevel / 3);
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
