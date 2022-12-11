namespace Day11.Logic;

public class MonkeyInTheMiddle
{
    private readonly int _rounds;
    private readonly int _divisor;

    //public List<Monkey> Monkeys { get; private set; }
    public List<Monkey1> Monkeys { get; private set; }
    public int MonkeyBusiness { get; private set; }

    /*public static MonkeyInTheMiddle CreateForSample(string input, int rounds)
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

    public static MonkeyInTheMiddle CreateForPuzzle(string input, int rounds)
    {
        var monkeys = new List<Monkey>
        {
            new(o => o * 11, t => (t % 19) == 0, (m, i) => m[6].Give(i), (m, i) => m[7].Give(i), 74, 73, 57, 77, 74),
            new(o => o + 8, t => (t % 2) == 0, (m, i) => m[6].Give(i), (m, i) => m[0].Give(i), 99, 77, 79),
            new(o => o + 1, t => (t % 3) == 0, (m, i) => m[5].Give(i), (m, i) => m[3].Give(i), 64, 67, 50, 96, 89, 82, 82),
            new(o => o * 7, t => (t % 17)  == 0, (m, i) => m[5].Give(i), (m, i) => m[4].Give(i), 88),
            new(o => o + 4, t => (t % 13)  == 0, (m, i) => m[0].Give(i), (m, i) => m[1].Give(i), 80, 66, 98, 83, 70, 63, 57, 66),
            new(o => o + 7, t => (t % 7) == 0, (m, i) => m[1].Give(i), (m, i) => m[4].Give(i), 81, 93, 90, 61, 62, 64),
            new(o => o * o, t => (t % 5) == 0, (m, i) => m[7].Give(i), (m, i) => m[2].Give(i), 69, 97, 88, 93),
            new(o => o + 6, t => (t % 11)  == 0, (m, i) => m[2].Give(i), (m, i) => m[3].Give(i), 59, 80)
        };

        return new MonkeyInTheMiddle(input, monkeys, rounds);
    }*/

    public MonkeyInTheMiddle(List<Monkey1> monkeys, int rounds, int divisor = 3)
    {
        Monkeys = monkeys;
        _rounds = rounds;
        _divisor = divisor;

        Run();
    }

    private void Run()
    {
        for (var index = 0; index < _rounds; index++)
        {
            foreach (var monkey in Monkeys)
            {
                if (_divisor == 3)
                {
                    monkey.DoTurn(Monkeys);
                }
                else
                {
                    monkey.DoTurn2(Monkeys);
                }
            }
        }
    
        MonkeyBusiness = Monkeys.Select(m => m.ActivityLevel).OrderByDescending(p => p).Take(2).Aggregate(1, (t, i) => t *= i);
    }
}