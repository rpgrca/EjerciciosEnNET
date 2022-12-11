namespace Day11.Logic;

public class MonkeyInTheMiddle
{
    private readonly int _rounds;

    public List<Monkey> Monkeys { get; set; }

    public static MonkeyInTheMiddle CreateForFirstPuzzle(string input, int rounds)
    {
        var monkeys = new List<Monkey>
        {
            new(o => o * 19, t => (t % 23) == 0, (m, i) => m[2].Give(i), (m, i) => m[3].Give(i), 79, 98),
            new(o => o + 6, t => t % 19 == 0, (m, i) => m[2].Give(i), (m, i) => m[0].Give(i), 54, 65, 75, 74),
            new(o => o * o, t => t % 13 == 0, (m, i) => m[1].Give(i), (m, i) => m[3].Give(i), 79, 60, 97),
            new(o => o + 3, t => t % 17 == 0, (m, i) => m[0].Give(i), (m, i) => m[1].Give(i), 74)
        };

        return new MonkeyInTheMiddle(input, monkeys, rounds);
    }

    private MonkeyInTheMiddle(string input, List<Monkey> monkeys, int rounds)
    {
        Monkeys = monkeys;
        _rounds = rounds;

        while (rounds-- > 0)
        {
            foreach (var monkey in Monkeys)
            {
                monkey.DoTurn(Monkeys);
            }
        }
    }
}
