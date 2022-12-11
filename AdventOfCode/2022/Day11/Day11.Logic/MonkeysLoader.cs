namespace Day11.Logic;

public class MonkeysLoader
{
    private readonly string _input;
    private readonly string[] _lines;
    private Func<long, long> CapCalculator { get; }

    public List<Monkey> Monkeys { get; }

    public static MonkeysLoader LoadWithoutCap(string input) =>
        new(input, c => long.MaxValue);

    public static MonkeysLoader LoadWithCap(string input) =>
        new(input, c => c);

    private MonkeysLoader(string input, Func<long, long> capCalculator)
    {
        _input = input + "\n";
        _lines = _input.Split("\n");

        Monkeys = new List<Monkey>();
        CapCalculator = capCalculator;

        Parse();
    }

    private void Parse()
    {
        string[] tokens = Array.Empty<string>();
        List<long> items = new();
        char operation = ' ';
        string operand = string.Empty;
        int divisor = -1;
        int targetOnSuccess = -1;
        int targetOnFailure = -1;
        int cap = 1;
        List<(List<long> Items, char Operation, string Operand, int Divisor, int TargetOnSuccess, int TargetOnFailure)> parsedValues = new();

        foreach (var line in _lines)
        {
            if (line.StartsWith("Monkey "))
            {
            }
            else if (line.StartsWith("  Starting items: "))
            {
                items = line.Split(":")[1].Split(",").ToList().Select(p => long.Parse(p)).ToList();
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
                cap *= divisor;
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
                parsedValues.Add((items, operation, operand, divisor, targetOnSuccess, targetOnFailure));
            }
        }

        foreach (var (Items, Operation, Operand, Divisor, TargetOnSuccess, TargetOnFailure) in parsedValues)
        {
            var monkey = new Monkey(Items, Operation, Operand, Divisor, TargetOnSuccess, TargetOnFailure, CapCalculator(cap));
            Monkeys.Add(monkey);
        }
    }
}