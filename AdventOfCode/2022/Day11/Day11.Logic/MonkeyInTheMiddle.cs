namespace Day11.Logic;

public class MonkeyInTheMiddle
{
    private readonly int _rounds;
    private readonly int _divisor;
    public List<Monkey> Monkeys { get; private set; }
    public ulong MonkeyBusiness { get; private set; }

    public MonkeyInTheMiddle(List<Monkey> monkeys, int rounds, int divisor = 3)
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
                monkey.DoTurn(Monkeys, _divisor);
            }
        }
    
        MonkeyBusiness = Monkeys.Select(m => m.ActivityLevel).OrderByDescending(p => p).Take(2).Aggregate(1UL, (t, i) => t *= i);
    }
}