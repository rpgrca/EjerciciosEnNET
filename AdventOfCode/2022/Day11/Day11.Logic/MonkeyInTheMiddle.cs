namespace Day11.Logic;

public class Monkey
{
    public List<int> Items { get; }
    private Func<int, int> Operation { get; }
    private Func<int, bool> Test { get; }
    private Action<List<Monkey>, int> Success { get; }
    private Action<List<Monkey>, int> Failure { get; }

    public Monkey(Func<int, int> operation, Func<int, bool> test, Action<List<Monkey>, int> success, Action<List<Monkey>, int> failure, params int[] items)
    {
        Items = new List<int>(items);
        Operation = operation;
        Test = test;
        Success = success;
        Failure = failure;
    }

    public void Give(int i)
    {
        throw new NotImplementedException();
    }
}

public class MonkeyInTheMiddle
{
    public List<Monkey> Monkeys { get; set; }

    public static MonkeyInTheMiddle CreateForFirstPuzzle(string input)
    {
        var monkeys = new List<Monkey>
        {
            new(o => o * 19, t => (t % 23) == 0, (m, i) => m[2].Give(i), (m, i) => m[3].Give(i), 79, 98),
            new(o => o + 6, t => t % 19 == 0, (m, i) => m[2].Give(i), (m, i) => m[0].Give(i), 54, 65, 75, 74),
            new(o => o * o, t => t % 13 == 0, (m, i) => m[1].Give(i), (m, i) => m[3].Give(i), 79, 60, 97),
            new(o => o + 3, t => t % 17 == 0, (m, i) => m[0].Give(i), (m, i) => m[1].Give(i), 74)
        };

        return new MonkeyInTheMiddle(input, monkeys);
    }

    private MonkeyInTheMiddle(string input, List<Monkey> monkeys)
    {
        Monkeys = monkeys;
    }
}
